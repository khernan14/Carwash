using DataAccess.SqlServer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Domain.SqlServer {
    public class EncryptedAndDesencrypted {
        ConnectionDAO connectionDAO = new ConnectionDAO();

        public void GuardarConexion( string txtConnection ) {
            connectionDAO.GuardarConnection(txtConnection);
        }
        
        public bool isConnection() {
            return connectionDAO.isConnection();
        }

        public void SaveToXMl( object dbcnString ) {
            connectionDAO.SavetoXML( dbcnString );
        }

        public void ReadfromXML( Guna2TextBox txtConnection ) {
            connectionDAO.ReadfromXML( txtConnection );
        }
    }
}
