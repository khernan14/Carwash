using DataAccess.CRUDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS {
    public class EmpresasD {
        EmpresasDA empresas = new EmpresasDA();

        public DataTable Insertar( string nombre, Byte[] logo, string impuesto, decimal porcentajeImpuesto, string moneda, string usaImpuesto, string modoBusqueda,
                                string carpetaBackups, string correo, string ultimaFechaBackup, DateTime ultimaFechaBDate, int frecuenciaBackups, string estado, string tipoEmpresa,
                                string pais, string redondeo ) {
            return empresas.Insertar(nombre, logo, impuesto, porcentajeImpuesto, moneda , usaImpuesto, modoBusqueda, carpetaBackups, correo, ultimaFechaBackup, ultimaFechaBDate, frecuenciaBackups, estado, tipoEmpresa, pais, redondeo);
        }
    }
}
