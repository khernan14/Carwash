using CarWash.Custom_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash.Forms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void ShowToast(string type, string message) {
            AlertBoxs alert = new AlertBoxs(type, message, this);
            alert.ShowDialog();
        }

        private void guna2Button1_Click( object sender, EventArgs e ) {
            //AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Operating Completed Succesfully", Properties.Resources.success);
            ShowToast("INFORMATION", "This is a information toast");
        }

        private void guna2Button3_Click( object sender, EventArgs e ) {
            ShowToast( "WARNING", "This is a warning toast" );
        }

        private void guna2Button4_Click( object sender, EventArgs e ) {
            ShowToast( "ERROR", "This is a error toast" );
        }

        private void guna2Button2_Click( object sender, EventArgs e ) {
            ShowToast( "SUCCESS", "This is a success toast" );
        }
    }
}
