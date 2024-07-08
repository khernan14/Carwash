namespace CarWash.Forms.Configuraciones.AsistenteInstalacion {
    partial class frmInstalacionServer {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstalacionServer));
            this.customForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.dcTitleBar = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.pnlLoader = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlTimer = new System.Windows.Forms.Panel();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.lblTimeInstaller = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInstalar = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lblbuscador_de_servidores = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblSegundos = new System.Windows.Forms.Label();
            this.lblMilisegundos = new System.Windows.Forms.Label();
            this.timerSegAndMili = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.timerCreateIni = new System.Windows.Forms.Timer(this.components);
            this.timerTemporizador = new System.Windows.Forms.Timer(this.components);
            this.pnlTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.Panel2.SuspendLayout();
            this.pnlLoader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.pnlTimer.SuspendLayout();
            this.Panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.pnlMessage.SuspendLayout();
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
            // dcTitleBar
            // 
            this.dcTitleBar.DockForm = true;
            this.dcTitleBar.DockIndicatorTransparencyValue = 1D;
            this.dcTitleBar.DragStartTransparencyValue = 1D;
            this.dcTitleBar.UseTransparentDrag = true;
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
            this.pnlTitleBar.TabIndex = 343;
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
            // Panel2
            // 
            this.Panel2.Controls.Add(this.pnlLoader);
            this.Panel2.Controls.Add(this.btnInstalar);
            this.Panel2.Controls.Add(this.pnlMessage);
            this.Panel2.Location = new System.Drawing.Point(340, 181);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(652, 646);
            this.Panel2.TabIndex = 618;
            // 
            // pnlLoader
            // 
            this.pnlLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.pnlLoader.Controls.Add(this.PictureBox2);
            this.pnlLoader.Controls.Add(this.pnlTimer);
            this.pnlLoader.Controls.Add(this.Label1);
            this.pnlLoader.Controls.Add(this.PictureBox1);
            this.pnlLoader.Location = new System.Drawing.Point(80, 102);
            this.pnlLoader.Name = "pnlLoader";
            this.pnlLoader.Size = new System.Drawing.Size(482, 496);
            this.pnlLoader.TabIndex = 618;
            this.pnlLoader.Visible = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(0, 310);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(482, 186);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox2.TabIndex = 621;
            this.PictureBox2.TabStop = false;
            // 
            // pnlTimer
            // 
            this.pnlTimer.Controls.Add(this.Panel7);
            this.pnlTimer.Controls.Add(this.Label2);
            this.pnlTimer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimer.Location = new System.Drawing.Point(0, 242);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(482, 68);
            this.pnlTimer.TabIndex = 620;
            this.pnlTimer.Visible = false;
            // 
            // Panel7
            // 
            this.Panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Panel7.Controls.Add(this.Label5);
            this.Panel7.Controls.Add(this.lblTimeInstaller);
            this.Panel7.Controls.Add(this.Label4);
            this.Panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel7.Location = new System.Drawing.Point(280, 0);
            this.Panel7.Name = "Panel7";
            this.Panel7.Size = new System.Drawing.Size(202, 68);
            this.Panel7.TabIndex = 619;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(52, 2);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(52, 34);
            this.Label5.TabIndex = 618;
            this.Label5.Text = "min";
            // 
            // lblTimeInstaller
            // 
            this.lblTimeInstaller.AutoSize = true;
            this.lblTimeInstaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeInstaller.ForeColor = System.Drawing.Color.White;
            this.lblTimeInstaller.Location = new System.Drawing.Point(59, 33);
            this.lblTimeInstaller.Name = "lblTimeInstaller";
            this.lblTimeInstaller.Size = new System.Drawing.Size(30, 24);
            this.lblTimeInstaller.TabIndex = 618;
            this.lblTimeInstaller.Text = "00";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(109, 2);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 34);
            this.Label4.TabIndex = 618;
            this.Label4.Text = "seg";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Font = new System.Drawing.Font("Poppins", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.DarkGray;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(280, 68);
            this.Label2.TabIndex = 619;
            this.Label2.Text = "Tiempo estimado: 6 minutos";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(0, 57);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(482, 185);
            this.Label1.TabIndex = 616;
            this.Label1.Text = "Instalando Servidor...\r\n\r\nNo Cierre esta Ventana, se cerrara Automaticamente cuan" +
    "do este todo Listo";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(482, 57);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 604;
            this.PictureBox1.TabStop = false;
            // 
            // btnInstalar
            // 
            this.btnInstalar.BorderRadius = 12;
            this.btnInstalar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInstalar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInstalar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInstalar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInstalar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnInstalar.Font = new System.Drawing.Font("Poppins", 25F, System.Drawing.FontStyle.Bold);
            this.btnInstalar.ForeColor = System.Drawing.Color.White;
            this.btnInstalar.Location = new System.Drawing.Point(122, 12);
            this.btnInstalar.Name = "btnInstalar";
            this.btnInstalar.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnInstalar.Size = new System.Drawing.Size(413, 84);
            this.btnInstalar.TabIndex = 620;
            this.btnInstalar.Text = "Instalar Servidor";
            this.btnInstalar.Visible = false;
            this.btnInstalar.Click += new System.EventHandler(this.btnInstalar_Click);
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.lblbuscador_de_servidores);
            this.pnlMessage.Controls.Add(this.Panel1);
            this.pnlMessage.Location = new System.Drawing.Point(122, 107);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(413, 153);
            this.pnlMessage.TabIndex = 619;
            // 
            // lblbuscador_de_servidores
            // 
            this.lblbuscador_de_servidores.BackColor = System.Drawing.Color.Transparent;
            this.lblbuscador_de_servidores.Font = new System.Drawing.Font("Poppins", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbuscador_de_servidores.ForeColor = System.Drawing.Color.White;
            this.lblbuscador_de_servidores.Location = new System.Drawing.Point(3, 0);
            this.lblbuscador_de_servidores.Name = "lblbuscador_de_servidores";
            this.lblbuscador_de_servidores.Size = new System.Drawing.Size(410, 153);
            this.lblbuscador_de_servidores.TabIndex = 614;
            this.lblbuscador_de_servidores.Text = "Buscando servidores instalados...";
            this.lblbuscador_de_servidores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel1
            // 
            this.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel1.BackgroundImage")));
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(3, 153);
            this.Panel1.TabIndex = 615;
            // 
            // lblSegundos
            // 
            this.lblSegundos.AutoSize = true;
            this.lblSegundos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegundos.ForeColor = System.Drawing.Color.White;
            this.lblSegundos.Location = new System.Drawing.Point(1056, 181);
            this.lblSegundos.Name = "lblSegundos";
            this.lblSegundos.Size = new System.Drawing.Size(30, 24);
            this.lblSegundos.TabIndex = 619;
            this.lblSegundos.Text = "00";
            // 
            // lblMilisegundos
            // 
            this.lblMilisegundos.AutoSize = true;
            this.lblMilisegundos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilisegundos.ForeColor = System.Drawing.Color.White;
            this.lblMilisegundos.Location = new System.Drawing.Point(1104, 181);
            this.lblMilisegundos.Name = "lblMilisegundos";
            this.lblMilisegundos.Size = new System.Drawing.Size(30, 24);
            this.lblMilisegundos.TabIndex = 620;
            this.lblMilisegundos.Text = "00";
            // 
            // timerSegAndMili
            // 
            this.timerSegAndMili.Interval = 10;
            this.timerSegAndMili.Tick += new System.EventHandler(this.timerSegAndMili_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(1056, 283);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(139, 24);
            this.lblTime.TabIndex = 621;
            this.lblTime.Text = "Timer Example";
            // 
            // timerCreateIni
            // 
            this.timerCreateIni.Interval = 10;
            this.timerCreateIni.Tick += new System.EventHandler(this.timerCreateIni_Tick);
            // 
            // timerTemporizador
            // 
            this.timerTemporizador.Interval = 10;
            this.timerTemporizador.Tick += new System.EventHandler(this.timerTemporizador_Tick);
            // 
            // frmInstalacionServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1301, 850);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSegundos);
            this.Controls.Add(this.lblMilisegundos);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Poppins", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmInstalacionServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInstalacionServer";
            this.Load += new System.EventHandler(this.frmInstalacionServer_Load);
            this.pnlTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.pnlLoader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.pnlTimer.ResumeLayout(false);
            this.Panel7.ResumeLayout(false);
            this.Panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm customForm;
        private Guna.UI2.WinForms.Guna2DragControl dcTitleBar;
        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        internal System.Windows.Forms.Panel pnlLoader;
        internal System.Windows.Forms.Panel pnlTimer;
        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label lblTimeInstaller;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel pnlMessage;
        internal System.Windows.Forms.Label lblbuscador_de_servidores;
        internal System.Windows.Forms.Panel Panel1;
        private Guna.UI2.WinForms.Guna2Button btnInstalar;
        internal System.Windows.Forms.Label lblSegundos;
        internal System.Windows.Forms.Label lblMilisegundos;
        private System.Windows.Forms.Timer timerSegAndMili;
        internal System.Windows.Forms.Label lblTime;
        internal System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.Timer timerCreateIni;
        private System.Windows.Forms.Timer timerTemporizador;
    }
}