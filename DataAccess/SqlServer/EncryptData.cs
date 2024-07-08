using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Metodos {
    public class EncryptData {
        public static string Encriptar( string texto ) {
            try {
                byte[] keyArray;
                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes( texto );

                using ( SHA256CryptoServiceProvider hashsha256 = new SHA256CryptoServiceProvider() ) {
                    keyArray = hashsha256.ComputeHash( UTF8Encoding.UTF8.GetBytes( DesencryptedConnection.appPwdUnique ) );
                }

                using ( TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider() ) {
                    tdes.Key = keyArray.Take( 24 ).ToArray(); // TripleDES key is 24 bytes
                    tdes.Mode = CipherMode.CBC;
                    tdes.Padding = PaddingMode.PKCS7;
                    tdes.GenerateIV(); // Generate a new IV

                    ICryptoTransform cTransform = tdes.CreateEncryptor();
                    byte[] ArrayResultado = cTransform.TransformFinalBlock( Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length );

                    // Combine IV and encrypted data
                    byte[] result = new byte[ tdes.IV.Length + ArrayResultado.Length ];
                    Buffer.BlockCopy( tdes.IV, 0, result, 0, tdes.IV.Length );
                    Buffer.BlockCopy( ArrayResultado, 0, result, tdes.IV.Length, ArrayResultado.Length );

                    return Convert.ToBase64String( result );
                }
            } catch ( Exception ex ) {
                // Log or handle the exception as needed
                Console.WriteLine( $"Encryption error: {ex.Message}" );
                return null;
            }
        }

        public static string Desencriptar( string textoEncriptado ) {
            try {
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String( textoEncriptado );

                using ( SHA256CryptoServiceProvider hashsha256 = new SHA256CryptoServiceProvider() ) {
                    keyArray = hashsha256.ComputeHash( UTF8Encoding.UTF8.GetBytes( DesencryptedConnection.appPwdUnique ) );
                }

                using ( TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider() ) {
                    tdes.Key = keyArray.Take( 24 ).ToArray(); // TripleDES key is 24 bytes
                    tdes.Mode = CipherMode.CBC;
                    tdes.Padding = PaddingMode.PKCS7;

                    // Extract IV from the encrypted text
                    byte[] iv = new byte[ tdes.BlockSize / 8 ];
                    byte[] cipherText = new byte[ Array_a_Descifrar.Length - iv.Length ];

                    Buffer.BlockCopy( Array_a_Descifrar, 0, iv, 0, iv.Length );
                    Buffer.BlockCopy( Array_a_Descifrar, iv.Length, cipherText, 0, cipherText.Length );

                    tdes.IV = iv;
                    ICryptoTransform cTransform = tdes.CreateDecryptor();

                    byte[] resultArray = cTransform.TransformFinalBlock( cipherText, 0, cipherText.Length );

                    return UTF8Encoding.UTF8.GetString( resultArray );
                }
            } catch ( Exception ex ) {
                // Log or handle the exception as needed
                Console.WriteLine( $"Decryption error: {ex.Message}" );
                return null;
            }
        }
    }
}
