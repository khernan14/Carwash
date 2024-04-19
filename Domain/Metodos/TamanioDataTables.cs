using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain {
    public class TamanioDataTables {
        public static void Multilinea(ref Guna2DataGridView dgDatos) {
            dgDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgDatos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDatos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDatos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgDatos.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
            styCabeceras.BackColor = Color.White;
            styCabeceras.ForeColor = Color.Black;
            styCabeceras.Font = new Font("Poppins", 10, FontStyle.Bold);
            dgDatos.ColumnHeadersDefaultCellStyle = styCabeceras;
        }
    }
}
