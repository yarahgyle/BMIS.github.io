
namespace BMIS
{
    partial class frmBlotter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrngy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIncident = new System.Windows.Forms.TextBox();
            this.txtPlaceinc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateinc = new System.Windows.Forms.DateTimePicker();
            this.timeinc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComplainant = new System.Windows.Forms.TextBox();
            this.txtWit1 = new System.Windows.Forms.TextBox();
            this.txtWit2 = new System.Windows.Forms.TextBox();
            this.txtNarrative = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cancelblotter = new System.Windows.Forms.Button();
            this.btnUpdateblotter = new System.Windows.Forms.Button();
            this.btnSaveblotter = new System.Windows.Forms.Button();
            this.txtPurok = new System.Windows.Forms.TextBox();
            this.filenotxt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.statustxt = new System.Windows.Forms.ComboBox();
            this.@__id = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 36);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblName.Location = new System.Drawing.Point(150, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(344, 23);
            this.lblName.TabIndex = 57;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(952, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "[ CLOSE ]";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "BLOTTER INFORMATION";
            // 
            // txtBrngy
            // 
            this.txtBrngy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrngy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBrngy.Location = new System.Drawing.Point(153, 127);
            this.txtBrngy.Name = "txtBrngy";
            this.txtBrngy.Size = new System.Drawing.Size(229, 23);
            this.txtBrngy.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "BARANGAY   |   PUROK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "INCIDENT";
            // 
            // txtIncident
            // 
            this.txtIncident.Location = new System.Drawing.Point(153, 156);
            this.txtIncident.Name = "txtIncident";
            this.txtIncident.Size = new System.Drawing.Size(464, 23);
            this.txtIncident.TabIndex = 13;
            // 
            // txtPlaceinc
            // 
            this.txtPlaceinc.Location = new System.Drawing.Point(153, 185);
            this.txtPlaceinc.Name = "txtPlaceinc";
            this.txtPlaceinc.Size = new System.Drawing.Size(464, 23);
            this.txtPlaceinc.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "PLACE OF INCIDENT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "DATE   |   TIME";
            // 
            // dateinc
            // 
            this.dateinc.Location = new System.Drawing.Point(153, 214);
            this.dateinc.Name = "dateinc";
            this.dateinc.Size = new System.Drawing.Size(229, 23);
            this.dateinc.TabIndex = 18;
            // 
            // timeinc
            // 
            this.timeinc.Location = new System.Drawing.Point(388, 214);
            this.timeinc.Name = "timeinc";
            this.timeinc.Size = new System.Drawing.Size(229, 23);
            this.timeinc.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "COMPLAINANT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "WITNESS 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "WITNESS 2";
            // 
            // txtComplainant
            // 
            this.txtComplainant.Location = new System.Drawing.Point(153, 243);
            this.txtComplainant.Name = "txtComplainant";
            this.txtComplainant.Size = new System.Drawing.Size(464, 23);
            this.txtComplainant.TabIndex = 23;
            // 
            // txtWit1
            // 
            this.txtWit1.Location = new System.Drawing.Point(153, 272);
            this.txtWit1.Name = "txtWit1";
            this.txtWit1.Size = new System.Drawing.Size(464, 23);
            this.txtWit1.TabIndex = 24;
            // 
            // txtWit2
            // 
            this.txtWit2.Location = new System.Drawing.Point(153, 301);
            this.txtWit2.Name = "txtWit2";
            this.txtWit2.Size = new System.Drawing.Size(464, 23);
            this.txtWit2.TabIndex = 25;
            // 
            // txtNarrative
            // 
            this.txtNarrative.Location = new System.Drawing.Point(647, 124);
            this.txtNarrative.Multiline = true;
            this.txtNarrative.Name = "txtNarrative";
            this.txtNarrative.Size = new System.Drawing.Size(348, 200);
            this.txtNarrative.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(644, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "NARRATIVE";
            // 
            // cancelblotter
            // 
            this.cancelblotter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.cancelblotter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelblotter.FlatAppearance.BorderSize = 0;
            this.cancelblotter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelblotter.ForeColor = System.Drawing.Color.White;
            this.cancelblotter.Location = new System.Drawing.Point(918, 330);
            this.cancelblotter.Name = "cancelblotter";
            this.cancelblotter.Size = new System.Drawing.Size(77, 28);
            this.cancelblotter.TabIndex = 57;
            this.cancelblotter.Text = "Clear";
            this.cancelblotter.UseVisualStyleBackColor = false;
            this.cancelblotter.Click += new System.EventHandler(this.cancelblotter_Click);
            // 
            // btnUpdateblotter
            // 
            this.btnUpdateblotter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(218)))));
            this.btnUpdateblotter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateblotter.FlatAppearance.BorderSize = 0;
            this.btnUpdateblotter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateblotter.ForeColor = System.Drawing.Color.White;
            this.btnUpdateblotter.Location = new System.Drawing.Point(840, 330);
            this.btnUpdateblotter.Name = "btnUpdateblotter";
            this.btnUpdateblotter.Size = new System.Drawing.Size(77, 28);
            this.btnUpdateblotter.TabIndex = 56;
            this.btnUpdateblotter.Text = "Update";
            this.btnUpdateblotter.UseVisualStyleBackColor = false;
            this.btnUpdateblotter.Click += new System.EventHandler(this.btnUpdateblotter_Click);
            // 
            // btnSaveblotter
            // 
            this.btnSaveblotter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(218)))));
            this.btnSaveblotter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveblotter.FlatAppearance.BorderSize = 0;
            this.btnSaveblotter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveblotter.ForeColor = System.Drawing.Color.White;
            this.btnSaveblotter.Location = new System.Drawing.Point(762, 330);
            this.btnSaveblotter.Name = "btnSaveblotter";
            this.btnSaveblotter.Size = new System.Drawing.Size(77, 28);
            this.btnSaveblotter.TabIndex = 55;
            this.btnSaveblotter.Text = "Save";
            this.btnSaveblotter.UseVisualStyleBackColor = false;
            this.btnSaveblotter.Click += new System.EventHandler(this.btnSaveblotter_Click);
            // 
            // txtPurok
            // 
            this.txtPurok.Location = new System.Drawing.Point(388, 127);
            this.txtPurok.Name = "txtPurok";
            this.txtPurok.Size = new System.Drawing.Size(229, 23);
            this.txtPurok.TabIndex = 58;
            // 
            // filenotxt
            // 
            this.filenotxt.AutoSize = true;
            this.filenotxt.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenotxt.ForeColor = System.Drawing.Color.Maroon;
            this.filenotxt.Location = new System.Drawing.Point(185, 67);
            this.filenotxt.Name = "filenotxt";
            this.filenotxt.Size = new System.Drawing.Size(172, 45);
            this.filenotxt.TabIndex = 59;
            this.filenotxt.Text = "00000000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 45);
            this.label11.TabIndex = 60;
            this.label11.Text = "Case No : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(819, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 26);
            this.label10.TabIndex = 61;
            this.label10.Text = "Status : ";
            // 
            // statustxt
            // 
            this.statustxt.AutoCompleteCustomSource.AddRange(new string[] {
            "Unsettled",
            "Settled"});
            this.statustxt.FormattingEnabled = true;
            this.statustxt.Items.AddRange(new object[] {
            "Unsettled",
            "Settled"});
            this.statustxt.Location = new System.Drawing.Point(906, 56);
            this.statustxt.Name = "statustxt";
            this.statustxt.Size = new System.Drawing.Size(89, 23);
            this.statustxt.TabIndex = 62;
            // 
            // __id
            // 
            this.@__id.AutoSize = true;
            this.@__id.Location = new System.Drawing.Point(21, 343);
            this.@__id.Name = "__id";
            this.@__id.Size = new System.Drawing.Size(14, 15);
            this.@__id.TabIndex = 63;
            this.@__id.Text = "0";
            this.@__id.Visible = false;
            // 
            // frmBlotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1018, 378);
            this.ControlBox = false;
            this.Controls.Add(this.@__id);
            this.Controls.Add(this.statustxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.filenotxt);
            this.Controls.Add(this.txtPurok);
            this.Controls.Add(this.cancelblotter);
            this.Controls.Add(this.btnUpdateblotter);
            this.Controls.Add(this.btnSaveblotter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNarrative);
            this.Controls.Add(this.txtWit2);
            this.Controls.Add(this.txtWit1);
            this.Controls.Add(this.txtComplainant);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeinc);
            this.Controls.Add(this.dateinc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlaceinc);
            this.Controls.Add(this.txtIncident);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBrngy);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBlotter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBlotter_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBrngy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cancelblotter;
        public System.Windows.Forms.Button btnUpdateblotter;
        public System.Windows.Forms.Button btnSaveblotter;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label filenotxt;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtIncident;
        public System.Windows.Forms.TextBox txtPlaceinc;
        public System.Windows.Forms.DateTimePicker dateinc;
        public System.Windows.Forms.TextBox timeinc;
        public System.Windows.Forms.TextBox txtComplainant;
        public System.Windows.Forms.TextBox txtWit1;
        public System.Windows.Forms.TextBox txtWit2;
        public System.Windows.Forms.TextBox txtNarrative;
        public System.Windows.Forms.TextBox txtPurok;
        public System.Windows.Forms.ComboBox statustxt;
        public System.Windows.Forms.Label __id;
    }
}