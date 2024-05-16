using DataAccess.CRUDS;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain.CRUDS {
    public class KardexD {
        KardexDA kardex = new KardexDA();
        public bool MostrarMovimientos( FlowLayoutPanel flPanel, int productoID ) {
            return kardex.MostrarMovimientos( flPanel, productoID );
        }
        
        public bool Cantidades( Guna2HtmlLabel txtCantidad, Guna2HtmlLabel txtCosto ) {
            return kardex.Cantidades( txtCantidad, txtCosto );
        }

        public bool FiltrarKardex( FlowLayoutPanel flPanel, DateTime fecha, string tipo, int usuarioID ) {
            return kardex.FiltrarKardex( flPanel, fecha, tipo, usuarioID );
        }

        public bool FiltrarKardexAcumulados( FlowLayoutPanel flPanel, DateTime fecha, string tipo, int usuarioID ) {
            return kardex.FiltrarKardexAcumulados( flPanel, fecha, tipo, usuarioID );
        }

        public bool StockMinimo( FlowLayoutPanel flPanel ) {
            return kardex.StockMinimo( flPanel );
        }
        
        public bool MostrarInventarios( FlowLayoutPanel flPanel, string buscar ) {
            return kardex.MostrarInventarios( flPanel, buscar );
        }

        public bool ProductosVencidos( FlowLayoutPanel flPanel, string buscar ) {
            return kardex.ProductosVencidos( flPanel, buscar );
        }

        public bool ProductosVencidosMenor30( FlowLayoutPanel flPanel ) {
            return kardex.ProductosVencidosMenor30( flPanel );
        }

        public DataTable ReporteInventario() {
            DataTable tabla = new DataTable();
            tabla = kardex.ReporteInventarioPrueba();
            return tabla;
        }
    }
}
