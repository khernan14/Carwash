namespace CarWash.Forms.Cajas {
    partial class frmCierreCaja {
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
            this.btnCerrarTurno = new Guna.UI2.WinForms.Guna2Button();
            this.dtpFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.SuspendLayout();
            // 
            // btnCerrarTurno
            // 
            this.btnCerrarTurno.BorderRadius = 12;
            this.btnCerrarTurno.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarTurno.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarTurno.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrarTurno.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrarTurno.FillColor = System.Drawing.Color.Red;
            this.btnCerrarTurno.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCerrarTurno.ForeColor = System.Drawing.Color.White;
            this.btnCerrarTurno.Location = new System.Drawing.Point(302, 274);
            this.btnCerrarTurno.Name = "btnCerrarTurno";
            this.btnCerrarTurno.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnCerrarTurno.Size = new System.Drawing.Size(160, 55);
            this.btnCerrarTurno.TabIndex = 282;
            this.btnCerrarTurno.Text = "CERRAR TURNO";
            this.btnCerrarTurno.Click += new System.EventHandler(this.btnCerrarTurno_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Checked = true;
            this.dtpFecha.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFecha.Location = new System.Drawing.Point(286, 58);
            this.dtpFecha.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 36);
            this.dtpFecha.TabIndex = 283;
            this.dtpFecha.Value = new System.DateTime(2024, 4, 16, 11, 32, 27, 221);
            // 
            // frmCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnCerrarTurno);
            this.Name = "frmCierreCaja";
            this.Text = "frmCierreCaja";
            this.Load += new System.EventHandler(this.frmCierreCaja_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCerrarTurno;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFecha;
    }
}