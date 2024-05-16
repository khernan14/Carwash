using Domain.CRUDS;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Domain {
    public class MetodosListados {

        public void MostrarGrupos( Guna2DataGridView dgDatos ) {
            GruposD objeto = new GruposD();
            dgDatos.DataSource = objeto.Mostrar();
            dgDatos.Columns[ 0 ].Visible = false;
        }

        public void MostrarProductos( Guna2DataGridView dgDatos ) {
            ProductosD objeto = new ProductosD();
            dgDatos.DataSource = objeto.Mostrar();
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 1 ].Visible = false;
        }

        public void BuscarMovimientos( DataGridView dgDatos, string buscar ) {
            ProductosD objeto = new ProductosD();
            dgDatos.DataSource = objeto.BuscarMovimientos(dgDatos, buscar);
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 2 ].Visible = false;
            dgDatos.Columns[ 3 ].Visible = false;
            dgDatos.Columns[ 4 ].Visible = false;
            dgDatos.Columns[ 5 ].Visible = false;
            dgDatos.Columns[ 6 ].Visible = false;
            dgDatos.Columns[ 7 ].Visible = false;
            dgDatos.Columns[ 8 ].Visible = false;
            dgDatos.Columns[ 9 ].Visible = false;
            dgDatos.Columns[ 10 ].Visible = false;
            dgDatos.Columns[ 11 ].Visible = false;
            dgDatos.Columns[ 12 ].Visible = false;
            dgDatos.Columns[ 13 ].Visible = false;
            dgDatos.Columns[ 14 ].Visible = false;
        }

        public void MostrarUsuarios( Guna2DataGridView dgDatos ) {
            UsuariosD objeto = new UsuariosD();
            dgDatos.DataSource = objeto.ListarUsuarios();
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 4 ].Visible = false;
            dgDatos.Columns[ 5 ].Visible = false;
            //dgDatos.Columns[ 6 ].Visible = false;
            dgDatos.Columns[ 7 ].Visible = false;

            //TamanioDataTables.Multilinea( ref dgDatos );
        }

        public void Buscar( Guna2DataGridView dgDatos, string buscar ) {
            UsuariosD objeto = new UsuariosD();
            dgDatos.DataSource = objeto.Buscar( buscar );
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 4 ].Visible = false;
            dgDatos.Columns[ 5 ].Visible = false;
            //dgDatos.Columns[ 6 ].Visible = false;
            dgDatos.Columns[ 7 ].Visible = false;

            //TamanioDataTables.Multilinea( ref dgDatos );
        }

        public void BuscarGrupos( Guna2DataGridView dgDatos, string buscar ) {
            GruposD objeto = new GruposD();
            dgDatos.DataSource = objeto.Buscar( buscar );
            dgDatos.Columns[ 0 ].Visible = false;
        }

        public void Autocomplete( DataGridView dgDatos, string buscar ) {
            ProductosD objeto = new ProductosD();
            dgDatos.DataSource = objeto.Autocomplete( dgDatos, buscar );
        }

        public void ListarUsuarios( ComboBox cmbPuesto ) {
            UsuariosD objeto = new UsuariosD();
            cmbPuesto.DataSource = objeto.ListarUsuarios();
            cmbPuesto.DisplayMember = "Nombre Completo";
            cmbPuesto.ValueMember = "usuarioID";
        }

        //public void ReporteInventario( ComboBox cmbPuesto ) {
        //    KardexD objeto = new KardexD();
        //    objeto.ReporteInventario();
        //}
    }
}
