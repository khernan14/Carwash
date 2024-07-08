using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS {
    public class TicketsD {
        TicketsDA tickets = new TicketsDA();

        public DataTable TicketsDesign( string identificadorFiscal, string direccion, string provincia, string nombreMoneda, string agradecimiento, string paginaWeb, string anuncio,
                                    string datosFiscales, string forDefault ) {
            DataTable table = new DataTable();
            table = tickets.Tickets(identificadorFiscal, direccion, provincia, nombreMoneda, agradecimiento, paginaWeb, anuncio, datosFiscales, forDefault);
            return table;
        }
    }
}
