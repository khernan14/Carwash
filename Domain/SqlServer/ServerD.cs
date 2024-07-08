using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain.SqlServer {
    public class ServerD {
        Server server = new Server();

        public void DeleteDataBase() {
            server.DeleteDataBase();
        }

        public bool CreateDataBase() {
            return server.CreateDataBase();
        }
        
        public void CreateUsuarios() {
            server.CreateUsuarios();
        }

        public void ExecuteSQLServer() {
            server.ExecuteSQLServer();
        }

        public void CreateConfigurationFile( Timer timerCreateIni ) {
            server.CreateConfigurationFile( timerCreateIni );
        }
    }
}
