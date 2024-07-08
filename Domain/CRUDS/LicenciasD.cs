using DataAccess.CRUDS;
using Domain.Metodos;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CRUDS {
    public class LicenciasD {
        LicenciasDA licencias = new LicenciasDA();
        UserModel model = new UserModel();

        private string lblSerialPC;

        public DataTable InsertarLicenciaPrueba() {
            DateTime today = DateTime.Now;
            DateTime fechaFinal = today.AddDays(30);
            string endDate = Convert.ToString( fechaFinal );

            string serialPC = EncryptData.Encriptar( model.SerialCaja( lblSerialPC.Trim() ) );
            string fechaFin = EncryptData.Encriptar( endDate.Trim() );
            string estado = EncryptData.Encriptar( "?Activo?" );
            string fechaActivacion = EncryptData.Encriptar(today.ToString().Trim());

            DataTable table = new DataTable();
            table = licencias.InsertarLicenciaPrueba(serialPC, fechaFin, estado, fechaActivacion);
            return table;
        }
    }
}
