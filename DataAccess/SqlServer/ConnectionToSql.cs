using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess {
    public abstract class ConnectionToSql {
        private readonly string connectionString;
        public ConnectionToSql() {
            //connectionString = "Data Source=KHERNAN14\\SQLEXPRESS;Initial Catalog=dbCarwash; Integrated Security=True";
            connectionString = "Data Source="+Convert.ToString( SqlServer.DesencryptedConnection.checkServer() );
        }

        protected SqlConnection GetConnection() {

            return new SqlConnection( connectionString );

        }


    }
}
