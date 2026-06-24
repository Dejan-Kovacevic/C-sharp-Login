namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpMotor = new System.Windows.Forms.GroupBox();
            this.lblMotortypCap = new System.Windows.Forms.Label();
            this.Txtlbl3 = new System.Windows.Forms.Label();
            this.lblZuendungCap = new System.Windows.Forms.Label();
            this.Txtlbl2 = new System.Windows.Forms.Label();
            this.grpVentil = new System.Windows.Forms.GroupBox();
            this.lblZyl1 = new System.Windows.Forms.Label();
            this.Txtlbl4 = new System.Windows.Forms.Label();
            this.lblZyl2 = new System.Windows.Forms.Label();
            this.Txtlbl5 = new System.Windows.Forms.Label();
            this.lblZyl3 = new System.Windows.Forms.Label();
            this.Txtlbl6 = new System.Windows.Forms.Label();
            this.lblZyl4 = new System.Windows.Forms.Label();
            this.Txtlbl7 = new System.Windows.Forms.Label();
            this.grpKeil = new System.Windows.Forms.GroupBox();
            this.lblBauteilCap = new System.Windows.Forms.Label();
            this.Txtlbl10 = new System.Windows.Forms.Label();
            this.lblMontageCap = new System.Windows.Forms.Label();
            this.Txtlbl9 = new System.Windows.Forms.Label();
            this.lblWartungCap = new System.Windows.Forms.Label();
            this.Txtlbl11 = new System.Windows.Forms.Label();
            this.grpSysteme = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblSystemwertCap = new System.Windows.Forms.Label();
            this.lblSystemwert = new System.Windows.Forms.Label();
            this.grpSteuerung = new System.Windows.Forms.GroupBox();
            this.cmdbtn2 = new System.Windows.Forms.Button();
            this.btnBeenden = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.grpMotor.SuspendLayout();
            this.grpVentil.SuspendLayout();
            this.grpKeil.SuspendLayout();
            this.grpSysteme.SuspendLayout();
            this.grpSteuerung.SuspendLayout();
            this.SuspendLayout();
            //
            // headerPanel
            //
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(85)))));
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(664, 58);
            this.headerPanel.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Fahrzeug-Dashboard – Diesel-Motor";
            //
            // grpMotor
            //
            this.grpMotor.Controls.Add(this.lblMotortypCap);
            this.grpMotor.Controls.Add(this.Txtlbl3);
            this.grpMotor.Controls.Add(this.lblZuendungCap);
            this.grpMotor.Controls.Add(this.Txtlbl2);
            this.grpMotor.Location = new System.Drawing.Point(16, 74);
            this.grpMotor.Name = "grpMotor";
            this.grpMotor.Size = new System.Drawing.Size(300, 92);
            this.grpMotor.TabIndex = 1;
            this.grpMotor.TabStop = false;
            this.grpMotor.Text = "Motor";
            //
            // lblMotortypCap
            //
            this.lblMotortypCap.AutoSize = true;
            this.lblMotortypCap.Location = new System.Drawing.Point(18, 30);
            this.lblMotortypCap.Name = "lblMotortypCap";
            this.lblMotortypCap.Size = new System.Drawing.Size(58, 15);
            this.lblMotortypCap.TabIndex = 0;
            this.lblMotortypCap.Text = "Motortyp:";
            //
            // Txtlbl3
            //
            this.Txtlbl3.AutoSize = true;
            this.Txtlbl3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(85)))));
            this.Txtlbl3.Location = new System.Drawing.Point(150, 30);
            this.Txtlbl3.Name = "Txtlbl3";
            this.Txtlbl3.Size = new System.Drawing.Size(80, 15);
            this.Txtlbl3.TabIndex = 1;
            this.Txtlbl3.Text = "Diesel-Motor";
            //
            // lblZuendungCap
            //
            this.lblZuendungCap.AutoSize = true;
            this.lblZuendungCap.Location = new System.Drawing.Point(18, 58);
            this.lblZuendungCap.Name = "lblZuendungCap";
            this.lblZuendungCap.Size = new System.Drawing.Size(57, 15);
            this.lblZuendungCap.TabIndex = 2;
            this.lblZuendungCap.Text = "Zündung:";
            //
            // Txtlbl2
            //
            this.Txtlbl2.AutoSize = true;
            this.Txtlbl2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl2.ForeColor = System.Drawing.Color.Gray;
            this.Txtlbl2.Location = new System.Drawing.Point(150, 58);
            this.Txtlbl2.Name = "Txtlbl2";
            this.Txtlbl2.Size = new System.Drawing.Size(58, 15);
            this.Txtlbl2.TabIndex = 3;
            this.Txtlbl2.Text = "Schlüssel";
            //
            // grpVentil
            //
            this.grpVentil.Controls.Add(this.lblZyl1);
            this.grpVentil.Controls.Add(this.Txtlbl4);
            this.grpVentil.Controls.Add(this.lblZyl2);
            this.grpVentil.Controls.Add(this.Txtlbl5);
            this.grpVentil.Controls.Add(this.lblZyl3);
            this.grpVentil.Controls.Add(this.Txtlbl6);
            this.grpVentil.Controls.Add(this.lblZyl4);
            this.grpVentil.Controls.Add(this.Txtlbl7);
            this.grpVentil.Location = new System.Drawing.Point(16, 178);
            this.grpVentil.Name = "grpVentil";
            this.grpVentil.Size = new System.Drawing.Size(300, 148);
            this.grpVentil.TabIndex = 2;
            this.grpVentil.TabStop = false;
            this.grpVentil.Text = "Ventilspiel (mm)";
            //
            // lblZyl1
            //
            this.lblZyl1.AutoSize = true;
            this.lblZyl1.Location = new System.Drawing.Point(18, 30);
            this.lblZyl1.Name = "lblZyl1";
            this.lblZyl1.Size = new System.Drawing.Size(58, 15);
            this.lblZyl1.TabIndex = 0;
            this.lblZyl1.Text = "Zylinder 1:";
            //
            // Txtlbl4
            //
            this.Txtlbl4.AutoSize = true;
            this.Txtlbl4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl4.Location = new System.Drawing.Point(150, 30);
            this.Txtlbl4.Name = "Txtlbl4";
            this.Txtlbl4.Size = new System.Drawing.Size(28, 15);
            this.Txtlbl4.TabIndex = 1;
            this.Txtlbl4.Text = "0.15";
            //
            // lblZyl2
            //
            this.lblZyl2.AutoSize = true;
            this.lblZyl2.Location = new System.Drawing.Point(18, 58);
            this.lblZyl2.Name = "lblZyl2";
            this.lblZyl2.Size = new System.Drawing.Size(58, 15);
            this.lblZyl2.TabIndex = 2;
            this.lblZyl2.Text = "Zylinder 2:";
            //
            // Txtlbl5
            //
            this.Txtlbl5.AutoSize = true;
            this.Txtlbl5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl5.Location = new System.Drawing.Point(150, 58);
            this.Txtlbl5.Name = "Txtlbl5";
            this.Txtlbl5.Size = new System.Drawing.Size(28, 15);
            this.Txtlbl5.TabIndex = 3;
            this.Txtlbl5.Text = "0.07";
            //
            // lblZyl3
            //
            this.lblZyl3.AutoSize = true;
            this.lblZyl3.Location = new System.Drawing.Point(18, 86);
            this.lblZyl3.Name = "lblZyl3";
            this.lblZyl3.Size = new System.Drawing.Size(58, 15);
            this.lblZyl3.TabIndex = 4;
            this.lblZyl3.Text = "Zylinder 3:";
            //
            // Txtlbl6
            //
            this.Txtlbl6.AutoSize = true;
            this.Txtlbl6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl6.Location = new System.Drawing.Point(150, 86);
            this.Txtlbl6.Name = "Txtlbl6";
            this.Txtlbl6.Size = new System.Drawing.Size(28, 15);
            this.Txtlbl6.TabIndex = 5;
            this.Txtlbl6.Text = "0.09";
            //
            // lblZyl4
            //
            this.lblZyl4.AutoSize = true;
            this.lblZyl4.Location = new System.Drawing.Point(18, 114);
            this.lblZyl4.Name = "lblZyl4";
            this.lblZyl4.Size = new System.Drawing.Size(58, 15);
            this.lblZyl4.TabIndex = 6;
            this.lblZyl4.Text = "Zylinder 4:";
            //
            // Txtlbl7
            //
            this.Txtlbl7.AutoSize = true;
            this.Txtlbl7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl7.Location = new System.Drawing.Point(150, 114);
            this.Txtlbl7.Name = "Txtlbl7";
            this.Txtlbl7.Size = new System.Drawing.Size(28, 15);
            this.Txtlbl7.TabIndex = 7;
            this.Txtlbl7.Text = "0.09";
            //
            // grpKeil
            //
            this.grpKeil.Controls.Add(this.lblBauteilCap);
            this.grpKeil.Controls.Add(this.Txtlbl10);
            this.grpKeil.Controls.Add(this.lblMontageCap);
            this.grpKeil.Controls.Add(this.Txtlbl9);
            this.grpKeil.Controls.Add(this.lblWartungCap);
            this.grpKeil.Controls.Add(this.Txtlbl11);
            this.grpKeil.Location = new System.Drawing.Point(16, 338);
            this.grpKeil.Name = "grpKeil";
            this.grpKeil.Size = new System.Drawing.Size(300, 120);
            this.grpKeil.TabIndex = 3;
            this.grpKeil.TabStop = false;
            this.grpKeil.Text = "Keilriemen";
            //
            // lblBauteilCap
            //
            this.lblBauteilCap.AutoSize = true;
            this.lblBauteilCap.Location = new System.Drawing.Point(18, 30);
            this.lblBauteilCap.Name = "lblBauteilCap";
            this.lblBauteilCap.Size = new System.Drawing.Size(48, 15);
            this.lblBauteilCap.TabIndex = 0;
            this.lblBauteilCap.Text = "Bauteil:";
            //
            // Txtlbl10
            //
            this.Txtlbl10.AutoSize = true;
            this.Txtlbl10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl10.Location = new System.Drawing.Point(150, 30);
            this.Txtlbl10.Name = "Txtlbl10";
            this.Txtlbl10.Size = new System.Drawing.Size(64, 15);
            this.Txtlbl10.TabIndex = 1;
            this.Txtlbl10.Text = "Keilriemen";
            //
            // lblMontageCap
            //
            this.lblMontageCap.AutoSize = true;
            this.lblMontageCap.Location = new System.Drawing.Point(18, 58);
            this.lblMontageCap.Name = "lblMontageCap";
            this.lblMontageCap.Size = new System.Drawing.Size(56, 15);
            this.lblMontageCap.TabIndex = 2;
            this.lblMontageCap.Text = "Montage:";
            //
            // Txtlbl9
            //
            this.Txtlbl9.AutoSize = true;
            this.Txtlbl9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl9.ForeColor = System.Drawing.Color.ForestGreen;
            this.Txtlbl9.Location = new System.Drawing.Point(150, 58);
            this.Txtlbl9.Name = "Txtlbl9";
            this.Txtlbl9.Size = new System.Drawing.Size(52, 15);
            this.Txtlbl9.TabIndex = 3;
            this.Txtlbl9.Text = "Montiert";
            //
            // lblWartungCap
            //
            this.lblWartungCap.AutoSize = true;
            this.lblWartungCap.Location = new System.Drawing.Point(18, 86);
            this.lblWartungCap.Name = "lblWartungCap";
            this.lblWartungCap.Size = new System.Drawing.Size(54, 15);
            this.lblWartungCap.TabIndex = 4;
            this.lblWartungCap.Text = "Wartung:";
            //
            // Txtlbl11
            //
            this.Txtlbl11.AutoSize = true;
            this.Txtlbl11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Txtlbl11.Location = new System.Drawing.Point(150, 86);
            this.Txtlbl11.Name = "Txtlbl11";
            this.Txtlbl11.Size = new System.Drawing.Size(82, 15);
            this.Txtlbl11.TabIndex = 5;
            this.Txtlbl11.Text = "Wurde ersetzt";
            //
            // grpSysteme
            //
            this.grpSysteme.Controls.Add(this.listBox1);
            this.grpSysteme.Controls.Add(this.lblSystemwertCap);
            this.grpSysteme.Controls.Add(this.lblSystemwert);
            this.grpSysteme.Location = new System.Drawing.Point(332, 74);
            this.grpSysteme.Name = "grpSysteme";
            this.grpSysteme.Size = new System.Drawing.Size(316, 252);
            this.grpSysteme.TabIndex = 4;
            this.grpSysteme.TabStop = false;
            this.grpSysteme.Text = "Fahrzeugsysteme";
            //
            // listBox1
            //
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "Benzin",
            "Fehlermeldung",
            "Klimaanlage",
            "Trip",
            "Kilometerstand",
            "Uhrzeit",
            "Temperatur"});
            this.listBox1.Location = new System.Drawing.Point(18, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 169);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            //
            // lblSystemwertCap
            //
            this.lblSystemwertCap.AutoSize = true;
            this.lblSystemwertCap.Location = new System.Drawing.Point(18, 214);
            this.lblSystemwertCap.Name = "lblSystemwertCap";
            this.lblSystemwertCap.Size = new System.Drawing.Size(35, 15);
            this.lblSystemwertCap.TabIndex = 1;
            this.lblSystemwertCap.Text = "Wert:";
            //
            // lblSystemwert
            //
            this.lblSystemwert.AutoSize = true;
            this.lblSystemwert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSystemwert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(85)))));
            this.lblSystemwert.Location = new System.Drawing.Point(70, 214);
            this.lblSystemwert.Name = "lblSystemwert";
            this.lblSystemwert.Size = new System.Drawing.Size(19, 15);
            this.lblSystemwert.TabIndex = 2;
            this.lblSystemwert.Text = "—";
            //
            // grpSteuerung
            //
            this.grpSteuerung.Controls.Add(this.cmdbtn2);
            this.grpSteuerung.Controls.Add(this.btnBeenden);
            this.grpSteuerung.Location = new System.Drawing.Point(332, 338);
            this.grpSteuerung.Name = "grpSteuerung";
            this.grpSteuerung.Size = new System.Drawing.Size(316, 120);
            this.grpSteuerung.TabIndex = 5;
            this.grpSteuerung.TabStop = false;
            this.grpSteuerung.Text = "Steuerung";
            //
            // cmdbtn2
            //
            this.cmdbtn2.Location = new System.Drawing.Point(18, 32);
            this.cmdbtn2.Name = "cmdbtn2";
            this.cmdbtn2.Size = new System.Drawing.Size(280, 32);
            this.cmdbtn2.TabIndex = 0;
            this.cmdbtn2.Text = "Zündung einschalten";
            this.cmdbtn2.UseVisualStyleBackColor = true;
            this.cmdbtn2.Click += new System.EventHandler(this.cmdbtn2_Click);
            //
            // btnBeenden
            //
            this.btnBeenden.Location = new System.Drawing.Point(18, 72);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(280, 32);
            this.btnBeenden.TabIndex = 1;
            this.btnBeenden.Text = "Beenden";
            this.btnBeenden.UseVisualStyleBackColor = true;
            this.btnBeenden.Click += new System.EventHandler(this.btnBeenden_Click);
            //
            // lblStatus
            //
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(16, 470);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(6, 4, 0, 0);
            this.lblStatus.Size = new System.Drawing.Size(632, 26);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Bereit – Zündung aus.";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 510);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpSteuerung);
            this.Controls.Add(this.grpSysteme);
            this.Controls.Add(this.grpKeil);
            this.Controls.Add(this.grpVentil);
            this.Controls.Add(this.grpMotor);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fahrzeug-Dashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.grpMotor.ResumeLayout(false);
            this.grpMotor.PerformLayout();
            this.grpVentil.ResumeLayout(false);
            this.grpVentil.PerformLayout();
            this.grpKeil.ResumeLayout(false);
            this.grpKeil.PerformLayout();
            this.grpSysteme.ResumeLayout(false);
            this.grpSysteme.PerformLayout();
            this.grpSteuerung.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpMotor;
        private System.Windows.Forms.Label lblMotortypCap;
        private System.Windows.Forms.Label Txtlbl3;
        private System.Windows.Forms.Label lblZuendungCap;
        private System.Windows.Forms.Label Txtlbl2;
        private System.Windows.Forms.GroupBox grpVentil;
        private System.Windows.Forms.Label lblZyl1;
        private System.Windows.Forms.Label Txtlbl4;
        private System.Windows.Forms.Label lblZyl2;
        private System.Windows.Forms.Label Txtlbl5;
        private System.Windows.Forms.Label lblZyl3;
        private System.Windows.Forms.Label Txtlbl6;
        private System.Windows.Forms.Label lblZyl4;
        private System.Windows.Forms.Label Txtlbl7;
        private System.Windows.Forms.GroupBox grpKeil;
        private System.Windows.Forms.Label lblBauteilCap;
        private System.Windows.Forms.Label Txtlbl10;
        private System.Windows.Forms.Label lblMontageCap;
        private System.Windows.Forms.Label Txtlbl9;
        private System.Windows.Forms.Label lblWartungCap;
        private System.Windows.Forms.Label Txtlbl11;
        private System.Windows.Forms.GroupBox grpSysteme;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblSystemwertCap;
        private System.Windows.Forms.Label lblSystemwert;
        private System.Windows.Forms.GroupBox grpSteuerung;
        private System.Windows.Forms.Button cmdbtn2;
        private System.Windows.Forms.Button btnBeenden;
        private System.Windows.Forms.Label lblStatus;
    }
}
