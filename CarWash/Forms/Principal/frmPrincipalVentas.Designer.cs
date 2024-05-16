namespace CarWash.Forms.Cajas {
    partial class frmPrincipalVentas {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipalVentas));
            this.customForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBuscarProductos = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pbPerfil = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnNotification = new FontAwesome.Sharp.IconButton();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfig = new FontAwesome.Sharp.IconButton();
            this.btnProductos = new Guna.UI2.WinForms.Guna2Button();
            this.txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.BordeConfig = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Notificaciones = new Guna.UI2.WinForms.Guna2NotificationPaint(this.components);
            this.dcTitleBar = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlTitleBar.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
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
            this.pnlTitleBar.Controls.Add(this.btnBuscarProductos);
            this.pnlTitleBar.Controls.Add(this.guna2Panel1);
            this.pnlTitleBar.Controls.Add(this.txtBuscar);
            this.pnlTitleBar.Controls.Add(this.guna2HtmlLabel1);
            this.pnlTitleBar.Controls.Add(this.guna2PictureBox1);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1920, 61);
            this.pnlTitleBar.TabIndex = 0;
            // 
            // btnBuscarProductos
            // 
            this.btnBuscarProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnBuscarProductos.BorderColor = System.Drawing.Color.Transparent;
            this.btnBuscarProductos.BorderRadius = 10;
            this.btnBuscarProductos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnBuscarProductos.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnBuscarProductos.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnBuscarProductos.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnBuscarProductos.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBuscarProductos.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnBuscarProductos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscarProductos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuscarProductos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuscarProductos.FillColor = System.Drawing.Color.Empty;
            this.btnBuscarProductos.Font = new System.Drawing.Font("Poppins", 11.78182F);
            this.btnBuscarProductos.ForeColor = System.Drawing.Color.White;
            this.btnBuscarProductos.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscarProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarProductos.Image")));
            this.btnBuscarProductos.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnBuscarProductos.ImageSize = new System.Drawing.Size(32, 32);
            this.btnBuscarProductos.Location = new System.Drawing.Point(635, 9);
            this.btnBuscarProductos.Name = "btnBuscarProductos";
            this.btnBuscarProductos.Size = new System.Drawing.Size(40, 40);
            this.btnBuscarProductos.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Controls.Add(this.pbPerfil);
            this.guna2Panel1.Controls.Add(this.btnNotification);
            this.guna2Panel1.Controls.Add(this.guna2Button2);
            this.guna2Panel1.Controls.Add(this.btnConfig);
            this.guna2Panel1.Controls.Add(this.btnProductos);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(1478, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(442, 61);
            this.guna2Panel1.TabIndex = 344;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 15;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.CustomIconSize = 12F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(397, 12);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(32, 32);
            this.guna2ControlBox1.TabIndex = 280;
            // 
            // pbPerfil
            // 
            this.pbPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPerfil.BackColor = System.Drawing.Color.Transparent;
            this.pbPerfil.Image = ((System.Drawing.Image)(resources.GetObject("pbPerfil.Image")));
            this.pbPerfil.ImageRotate = 0F;
            this.pbPerfil.Location = new System.Drawing.Point(337, 6);
            this.pbPerfil.Name = "pbPerfil";
            this.pbPerfil.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbPerfil.Size = new System.Drawing.Size(48, 48);
            this.pbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPerfil.TabIndex = 5;
            this.pbPerfil.TabStop = false;
            this.pbPerfil.UseTransparentBackground = true;
            // 
            // btnNotification
            // 
            this.btnNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotification.BackColor = System.Drawing.Color.Transparent;
            this.btnNotification.FlatAppearance.BorderSize = 0;
            this.btnNotification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnNotification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotification.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.btnNotification.IconColor = System.Drawing.Color.White;
            this.btnNotification.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnNotification.IconSize = 35;
            this.btnNotification.Location = new System.Drawing.Point(288, 15);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnNotification.Size = new System.Drawing.Size(30, 30);
            this.btnNotification.TabIndex = 4;
            this.btnNotification.UseVisualStyleBackColor = false;
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Empty;
            this.guna2Button2.Font = new System.Drawing.Font("Poppins", 11.78182F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2Button2.Location = new System.Drawing.Point(243, 15);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(30, 30);
            this.guna2Button2.TabIndex = 3;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnConfig.IconColor = System.Drawing.Color.White;
            this.btnConfig.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfig.IconSize = 35;
            this.btnConfig.Location = new System.Drawing.Point(197, 15);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnConfig.Size = new System.Drawing.Size(30, 30);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.UseVisualStyleBackColor = false;
            // 
            // btnProductos
            // 
            this.btnProductos.BorderColor = System.Drawing.Color.Transparent;
            this.btnProductos.BorderRadius = 10;
            this.btnProductos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProductos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProductos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProductos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProductos.FillColor = System.Drawing.Color.Empty;
            this.btnProductos.Font = new System.Drawing.Font("Poppins", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnProductos.ImageSize = new System.Drawing.Size(32, 32);
            this.btnProductos.Location = new System.Drawing.Point(0, 0);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(144, 61);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextOffset = new System.Drawing.Point(20, 0);
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Animated = true;
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.txtBuscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtBuscar.BorderRadius = 8;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.Silver;
            this.txtBuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.Location = new System.Drawing.Point(269, 9);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBuscar.PlaceholderText = "Buscar Por Código Manual";
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.Size = new System.Drawing.Size(358, 40);
            this.txtBuscar.TabIndex = 342;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Poppins", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Silver;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(85, 0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(174, 61);
            this.guna2HtmlLabel1.TabIndex = 281;
            this.guna2HtmlLabel1.Text = "CARWASH SYSTEM";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(85, 61);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // BordeConfig
            // 
            this.BordeConfig.BorderRadius = 35;
            this.BordeConfig.TargetControl = this.btnConfig;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "menu.png");
            // 
            // Notificaciones
            // 
            this.Notificaciones.BorderThickness = 0;
            this.Notificaciones.Font = new System.Drawing.Font("Poppins", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notificaciones.TargetControl = this.btnNotification;
            // 
            // dcTitleBar
            // 
            this.dcTitleBar.DockForm = true;
            this.dcTitleBar.DockIndicatorTransparencyValue = 1D;
            this.dcTitleBar.DragStartTransparencyValue = 1D;
            this.dcTitleBar.TargetControl = this.pnlTitleBar;
            this.dcTitleBar.UseTransparentDrag = true;
            // 
            // frmPrincipalVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrincipalVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.pnlTitleBar.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm customForm;
        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnProductos;
        private Guna.UI2.WinForms.Guna2Button btnBuscarProductos;
        private FontAwesome.Sharp.IconButton btnConfig;
        private Guna.UI2.WinForms.Guna2Elipse BordeConfig;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private FontAwesome.Sharp.IconButton btnNotification;
        private Guna.UI2.WinForms.Guna2NotificationPaint Notificaciones;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbPerfil;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DragControl dcTitleBar;
    }
}