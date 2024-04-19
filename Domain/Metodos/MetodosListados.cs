using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Domain {
    public class MetodosListados {
        public void MostrarUsuarios( Guna2DataGridView dgDatos ) {
            UsuariosD objeto = new UsuariosD();
            dgDatos.DataSource = objeto.Mostrar();
            dgDatos.Columns[ 0 ].Visible = false;
            dgDatos.Columns[ 4 ].Visible = false;
            dgDatos.Columns[ 5 ].Visible = false;
            //dgDatos.Columns[ 6 ].Visible = false;
            dgDatos.Columns[ 7 ].Visible = false;

            //TamanioDataTables.Multilinea( ref dgDatos );
        }

        public void BuscarUsuarios( Guna2DataGridView dgDatos, string buscar ) {
            UsuariosD objeto = new UsuariosD();
            dgDatos.DataSource = objeto.Buscar( buscar );
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
    }
}
