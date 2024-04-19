namespace CarWash.Forms.Configuraciones {
    partial class frmConexionManual {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConexionManual));
            this.customForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Logo_empresa = new System.Windows.Forms.PictureBox();
            this.txtConnection = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGenerarCadena = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_empresa)).BeginInit();
            this.SuspendLayout();
            // 
            // customForm
            // 
            this.customForm.BorderRadius = 30;
            this.customForm.ContainerControl = this;
            this.customForm.DockIndicatorTransparencyValue = 1D;
            this.customForm.DragForm = false;
            this.customForm.DragStartTransparencyValue = 1D;
            this.customForm.HasFormShadow = false;
            this.customForm.ResizeForm = false;
            this.customForm.TransparentWhileDrag = true;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Poppins", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Silver;
            this.Label3.Location = new System.Drawing.Point(67, 59);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(375, 31);
            this.Label3.TabIndex = 594;
            this.Label3.Text = "Ingrese la cadena de conexion LOCAL\r\n";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Poppins", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Silver;
            this.Label2.Location = new System.Drawing.Point(69, 90);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(637, 87);
            this.Label2.TabIndex = 595;
            this.Label2.Text = "Una vez que estes listo dale a \"Generar cadena de conexion\", se creara un Archivo" +
    " que contendra\r\ntu conexion Encryptada. Ahora tu conexion es mas Segura ante Pos" +
    "ibles hackers.";
            // 
            // Logo_empresa
            // 
            this.Logo_empresa.BackColor = System.Drawing.Color.Transparent;
            this.Logo_empresa.Image = ((System.Drawing.Image)(resources.GetObject("Logo_empresa.Image")));
            this.Logo_empresa.Location = new System.Drawing.Point(727, 59);
            this.Logo_empresa.Name = "Logo_empresa";
            this.Logo_empresa.Size = new System.Drawing.Size(75, 70);
            this.Logo_empresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_empresa.TabIndex = 597;
            this.Logo_empresa.TabStop = false;
            // 
            // txtConnection
            // 
            this.txtConnection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtConnection.Animated = true;
            this.txtConnection.BackColor = System.Drawing.Color.Transparent;
            this.txtConnection.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtConnection.BorderRadius = 15;
            this.txtConnection.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConnection.DefaultText = "";
            this.txtConnection.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConnection.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConnection.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConnection.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConnection.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtConnection.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConnection.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnection.ForeColor = System.Drawing.Color.Silver;
            this.txtConnection.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConnection.Location = new System.Drawing.Point(73, 172);
            this.txtConnection.Margin = new System.Windows.Forms.Padding(5);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.PasswordChar = '\0';
            this.txtConnection.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtConnection.PlaceholderText = "Cadena de Conexión";
            this.txtConnection.SelectedText = "";
            this.txtConnection.Size = new System.Drawing.Size(729, 56);
            this.txtConnection.TabIndex = 598;
            // 
            // btnGenerarCadena
            // 
            this.btnGenerarCadena.BorderRadius = 12;
            this.btnGenerarCadena.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerarCadena.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerarCadena.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerarCadena.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerarCadena.FillColor = System.Drawing.Color.Red;
            this.btnGenerarCadena.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarCadena.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCadena.Location = new System.Drawing.Point(73, 246);
            this.btnGenerarCadena.Name = "btnGenerarCadena";
            this.btnGenerarCadena.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnGenerarCadena.Size = new System.Drawing.Size(323, 57);
            this.btnGenerarCadena.TabIndex = 599;
            this.btnGenerarCadena.Text = "Generar Cadena de Conexión";
            this.btnGenerarCadena.Click += new System.EventHandler(this.btnGenerarCadena_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 15;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.CustomIconSize = 12F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(835, 13);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(32, 32);
            this.guna2ControlBox1.TabIndex = 600;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 12;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Red;
            this.guna2Button1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(649, 246);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.guna2Button1.Size = new System.Drawing.Size(153, 57);
            this.guna2Button1.TabIndex = 602;
            this.guna2Button1.Text = "Probar Conexión";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frmConexionManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnGenerarCadena);
            this.Controls.Add(this.txtConnection);
            this.Controls.Add(this.Logo_empresa);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConexionManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConexionManual";
            this.Load += new System.EventHandler(this.frmConexionManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo_empresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm customForm;
        internal System.Windows.Forms.PictureBox Logo_empresa;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        private Guna.UI2.WinForms.Guna2TextBox txtConnection;
        private Guna.UI2.WinForms.Guna2Button btnGenerarCadena;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}