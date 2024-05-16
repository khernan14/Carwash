using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain.SqlServer {
    public class WinAutoCompleteMode {
        public AutoCompleteStringCollection LoadAutocomplete() {
            DataHelper dataHelper = new DataHelper();
            return dataHelper.LoadAutocomplete();
        }
    }
}
