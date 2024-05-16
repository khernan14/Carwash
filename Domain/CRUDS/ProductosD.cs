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
    public class ProductosD {
        ProductosDA productos = new ProductosDA();

        public DataTable Mostrar() {
            DataTable tabla = new DataTable();
            tabla = productos.Mostrar();
            return tabla;
        }

        public bool MostrarProductos( FlowLayoutPanel flPanel, EventHandler myEventLabel, string buscar ) {
            return productos.MostrarProductos( flPanel, myEventLabel, buscar );
        }

        public DataTable BuscarMovimientos( DataGridView dgDatos, string buscar) {
            DataTable tabla = new DataTable();
            tabla = productos.BuscarMovimientos(dgDatos, buscar);
            return tabla;
        }

        public DataTable Autocomplete( DataGridView dgDatos, string buscar ) {
            DataTable tabla = new DataTable();
            tabla = productos.Autocomplete( dgDatos, buscar );
            return tabla;
        }

        public DataTable Insertar( string descripcion, int categoriID, string usaInventario, string stock, decimal precioCompra,
                string fechaVencimiento, decimal precioVenta, string barcode, string tipoVenta, string stockMinimo,
                decimal precioMayoreo, decimal aPartirDe, DateTime fecha, string motivo, decimal cantidad, int usuarioID, string tipo, string estado,
                int cajaId ) {
            DataTable tabla = new DataTable();
            tabla = productos.Insertar(descripcion, categoriID, usaInventario, stock, precioCompra, fechaVencimiento, precioVenta, barcode, 
                tipoVenta, stockMinimo, precioMayoreo, aPartirDe, fecha, motivo, cantidad, usuarioID, tipo, estado, cajaId);
            return tabla;
        }
        
        public DataTable Actualizar( int productoID, string descripcion, int categoriID, string usaInventario, string stock, decimal precioCompra,
                string fechaVencimiento, decimal precioVenta, string barcode, string tipoVenta, string stockMinimo,
                decimal precioMayoreo, decimal aPartirDe ) {
            DataTable tabla = new DataTable();
            tabla = productos.Actualizar(productoID, descripcion, categoriID, usaInventario, stock, precioCompra, fechaVencimiento, precioVenta, barcode, 
                tipoVenta, stockMinimo, precioMayoreo, aPartirDe);
            return tabla;
        }

        public DataTable Eliminar( int productoID ) {
            DataTable tabla = new DataTable();
            tabla = productos.Eliminar( productoID );
            return tabla;
        }
    }
}
