using Common;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace DataAccess.SqlServer {
    public class ConnectionDAO : ConnectionToSql {
        private AES aes = new AES();
        private SqlDataReader leer;
        private DataTable table = new DataTable();

        public void SavetoXML( object dbcnString ) {
            XmlDocument doc = new XmlDocument();
            doc.Load( "ConnectionString.xml" );
            XmlElement root = doc.DocumentElement;
            root.Attributes[ 0 ].Value = Convert.ToString( dbcnString );
            XmlTextWriter writer = new XmlTextWriter( "ConnectionString.xml", null );
            writer.Formatting = Formatting.Indented;
            doc.Save( writer );
            writer.Close();
        }
        string dbcnString;
        public void ReadfromXML( Guna2TextBox txtConnection ) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load( "ConnectionString.xml" );
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[ 0 ].Value;
                txtConnection.Text = (aes.Decrypt( dbcnString, DesencryptedConnection.appPwdUnique, int.Parse( "256" ) ));

            } catch ( System.Security.Cryptography.CryptographicException ex ) {
                MessageDialog.Show(ex.Message);
            }
        }

        public void GuardarConnection( string txtConnection ) {
            SavetoXML( aes.Encrypt( txtConnection, DesencryptedConnection.appPwdUnique, int.Parse( "256" ) ) );
        }

        public bool isConnection() {
            using ( var connection = GetConnection() ) {
                try {
                    connection.Open();
                    using ( var command = new SqlCommand() ) {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM usuarios";
                        command.CommandType = CommandType.Text;
                        SqlDataReader reader = command.ExecuteReader();
                        return true;
                    }
                } catch ( Exception ex ) {
                    MessageDialog.Show( ex.Message );
                    return false;
                }
            }
        }
    }
}
