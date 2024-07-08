namespace CarWash.Forms.Configuraciones.AsistenteInstalacion {
    partial class frmServidorRemoto {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServidorRemoto));
            this.customForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btnSecundaria = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrincipal = new Guna.UI2.WinForms.Guna2Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.dcTitleBar = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
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
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.pnlTitleBar.Controls.Add(this.guna2PictureBox1);
            this.pnlTitleBar.Controls.Add(this.guna2ControlBox1);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1301, 118);
            this.pnlTitleBar.TabIndex = 342;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BorderRadius = 10;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(105, 105);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 15;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.CustomIconSize = 12F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1265, 4);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(32, 32);
            this.guna2ControlBox1.TabIndex = 279;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Controls.Add(this.btnSecundaria);
            this.pnlDatos.Controls.Add(this.btnPrincipal);
            this.pnlDatos.Controls.Add(this.Label4);
            this.pnlDatos.Controls.Add(this.Label9);
            this.pnlDatos.Controls.Add(this.Label1);
            this.pnlDatos.Controls.Add(this.Panel1);
            this.pnlDatos.Controls.Add(this.Panel2);
            this.pnlDatos.Controls.Add(this.PictureBox1);
            this.pnlDatos.Location = new System.Drawing.Point(159, 154);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1027, 477);
            this.pnlDatos.TabIndex = 613;
            // 
            // btnSecundaria
            // 
            this.btnSecundaria.BorderRadius = 12;
            this.btnSecundaria.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSecundaria.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSecundaria.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSecundaria.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSecundaria.FillColor = System.Drawing.Color.Red;
            this.btnSecundaria.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold);
            this.btnSecundaria.ForeColor = System.Drawing.Color.White;
            this.btnSecundaria.Location = new System.Drawing.Point(39, 324);
            this.btnSecundaria.Name = "btnSecundaria";
            this.btnSecundaria.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnSecundaria.Size = new System.Drawing.Size(247, 84);
            this.btnSecundaria.TabIndex = 615;
            this.btnSecundaria.Text = "Secundaria";
            // 
            // btnPrincipal
            // 
            this.btnPrincipal.BorderRadius = 12;
            this.btnPrincipal.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrincipal.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrincipal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrincipal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrincipal.FillColor = System.Drawing.Color.Red;
            this.btnPrincipal.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold);
            this.btnPrincipal.ForeColor = System.Drawing.Color.White;
            this.btnPrincipal.Location = new System.Drawing.Point(137, 122);
            this.btnPrincipal.Name = "btnPrincipal";
            this.btnPrincipal.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnPrincipal.Size = new System.Drawing.Size(247, 84);
            this.btnPrincipal.TabIndex = 614;
            this.btnPrincipal.Text = "Principal";
            this.btnPrincipal.Click += new System.EventHandler(this.btnPrincipal_Click);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(669, 324);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(318, 118);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Se Conecta a la Computadora Principal siempre y cuando la Principal este Encendid" +
    "a";
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.White;
            this.Label9.Location = new System.Drawing.Point(564, 122);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(402, 116);
            this.Label9.TabIndex = 0;
            this.Label9.Text = "Esta Computadora debe estar Encendida para que las Computadoras\r\nSecundarias se C" +
    "onecten. Si se apaga no podran conectarse.";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label1.Font = new System.Drawing.Font("Poppins", 30.10909F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(212, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(596, 81);
            this.Label1.TabIndex = 605;
            this.Label1.Text = "¿Esta Computadora es?";
            // 
            // Panel1
            // 
            this.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel1.BackgroundImage")));
            this.Panel1.Location = new System.Drawing.Point(555, 113);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(3, 135);
            this.Panel1.TabIndex = 606;
            // 
            // Panel2
            // 
            this.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel2.BackgroundImage")));
            this.Panel2.Location = new System.Drawing.Point(653, 313);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(3, 139);
            this.Panel2.TabIndex = 607;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(236, 113);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(472, 339);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 604;
            this.PictureBox1.TabStop = false;
            // 
            // dcTitleBar
            // 
            this.dcTitleBar.DockForm = true;
            this.dcTitleBar.DockIndicatorTransparencyValue = 1D;
            this.dcTitleBar.DragStartTransparencyValue = 1D;
            this.dcTitleBar.TargetControl = this.pnlTitleBar;
            this.dcTitleBar.UseTransparentDrag = true;
            // 
            // frmServidorRemoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1301, 795);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Poppins", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmServidorRemoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmServidorRemoto";
            this.Load += new System.EventHandler(this.frmServidorRemoto_Load);
            this.pnlTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm customForm;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        internal System.Windows.Forms.Panel pnlDatos;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnSecundaria;
        private Guna.UI2.WinForms.Guna2Button btnPrincipal;
        private Guna.UI2.WinForms.Guna2DragControl dcTitleBar;
    }
}