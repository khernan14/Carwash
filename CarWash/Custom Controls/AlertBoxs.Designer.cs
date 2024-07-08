namespace CarWash.Custom_Controls {
    partial class AlertBoxs {
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
            this.lblType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.pnlBorder = new Guna.UI2.WinForms.Guna2Panel();
            this.toastTimer = new System.Windows.Forms.Timer(this.components);
            this.toastHide = new System.Windows.Forms.Timer(this.components);
            this.FormularioCustom = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(68, 10);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(42, 21);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type";
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(68, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(97, 21);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "ToasMessages";
            // 
            // picIcon
            // 
            this.picIcon.Image = global::CarWash.Properties.Resources.success;
            this.picIcon.Location = new System.Drawing.Point(33, 12);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(20, 20);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 4;
            this.picIcon.TabStop = false;
            // 
            // pnlBorder
            // 
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBorder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(155)))), ((int)(((byte)(53)))));
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Size = new System.Drawing.Size(10, 59);
            this.pnlBorder.TabIndex = 5;
            // 
            // toastTimer
            // 
            this.toastTimer.Enabled = true;
            this.toastTimer.Interval = 10;
            this.toastTimer.Tick += new System.EventHandler(this.toastTimer_Tick);
            // 
            // toastHide
            // 
            this.toastHide.Interval = 20;
            this.toastHide.Tick += new System.EventHandler(this.toastHide_Tick);
            // 
            // FormularioCustom
            // 
            this.FormularioCustom.BorderRadius = 16;
            this.FormularioCustom.ContainerControl = this;
            this.FormularioCustom.DockIndicatorTransparencyValue = 0.6D;
            this.FormularioCustom.TransparentWhileDrag = true;
            // 
            // AlertBoxs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 59);
            this.Controls.Add(this.pnlBorder);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblType);
            this.Font = new System.Drawing.Font("Century Gothic", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "AlertBoxs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AlertBoxs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lblType;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMessage;
        private System.Windows.Forms.PictureBox picIcon;
        private Guna.UI2.WinForms.Guna2Panel pnlBorder;
        private System.Windows.Forms.Timer toastTimer;
        private System.Windows.Forms.Timer toastHide;
        private Guna.UI2.WinForms.Guna2BorderlessForm FormularioCustom;
    }
}