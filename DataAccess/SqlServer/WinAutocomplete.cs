using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataAccess.SqlServer {
    public class DataHelper : ConnectionToSql {
        public DataTable LoadDataTable() {
            Font prFont = new Font( "Poppins", 12, FontStyle.Bold );
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            SqlConnection cnn = new SqlConnection();
            using ( cnn = GetConnection() ) {
                cnn.Open();
                da = new SqlDataAdapter( "SELECT TOP 10 productoID, descripcion FROM productos", cnn );
                da.Fill( dt );
                return dt;
            }
        }

        public AutoCompleteStringCollection LoadAutocomplete() {
            DataTable dt = LoadDataTable();
            AutoCompleteStringCollection stringColl = new AutoCompleteStringCollection();
            foreach ( DataRow row in dt.Rows ) {
                stringColl.Add( Convert.ToString( row[ "descripcion" ] ) );
            }

            return stringColl;
        }
    }
}
