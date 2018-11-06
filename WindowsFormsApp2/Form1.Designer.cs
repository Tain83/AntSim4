namespace AntSim4GUI
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownFieldLength = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBaseXPos = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownBaseYPos = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelRoundNumber = new System.Windows.Forms.Label();
            this.labelMessageText = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFieldLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseXPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseYPos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Feldlänge:";
            // 
            // numericUpDownFieldLength
            // 
            this.numericUpDownFieldLength.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownFieldLength.Location = new System.Drawing.Point(92, 34);
            this.numericUpDownFieldLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFieldLength.Name = "numericUpDownFieldLength";
            this.numericUpDownFieldLength.Size = new System.Drawing.Size(142, 20);
            this.numericUpDownFieldLength.TabIndex = 2;
            this.numericUpDownFieldLength.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownBaseXPos
            // 
            this.numericUpDownBaseXPos.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownBaseXPos.Location = new System.Drawing.Point(92, 67);
            this.numericUpDownBaseXPos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBaseXPos.Name = "numericUpDownBaseXPos";
            this.numericUpDownBaseXPos.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownBaseXPos.TabIndex = 4;
            this.numericUpDownBaseXPos.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Startpunkt:";
            // 
            // numericUpDownBaseYPos
            // 
            this.numericUpDownBaseYPos.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownBaseYPos.Location = new System.Drawing.Point(166, 67);
            this.numericUpDownBaseYPos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBaseYPos.Name = "numericUpDownBaseYPos";
            this.numericUpDownBaseYPos.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownBaseYPos.TabIndex = 5;
            this.numericUpDownBaseYPos.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(717, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Round Number:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelRoundNumber
            // 
            this.labelRoundNumber.AutoSize = true;
            this.labelRoundNumber.BackColor = System.Drawing.SystemColors.Info;
            this.labelRoundNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRoundNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelRoundNumber.Location = new System.Drawing.Point(805, 134);
            this.labelRoundNumber.Name = "labelRoundNumber";
            this.labelRoundNumber.Size = new System.Drawing.Size(34, 15);
            this.labelRoundNumber.TabIndex = 12;
            this.labelRoundNumber.Text = "RNbr";
            // 
            // labelMessageText
            // 
            this.labelMessageText.AutoSize = true;
            this.labelMessageText.BackColor = System.Drawing.SystemColors.Info;
            this.labelMessageText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMessageText.Location = new System.Drawing.Point(15, 27);
            this.labelMessageText.MinimumSize = new System.Drawing.Size(600, 250);
            this.labelMessageText.Name = "labelMessageText";
            this.labelMessageText.Size = new System.Drawing.Size(600, 250);
            this.labelMessageText.TabIndex = 8;
            this.labelMessageText.Text = "MessageText";
            this.labelMessageText.UseMnemonic = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelMessageText);
            this.groupBox1.Location = new System.Drawing.Point(33, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 296);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MessageBox";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(720, 185);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Protokoll öffnen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelRoundNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numericUpDownBaseYPos);
            this.Controls.Add(this.numericUpDownBaseXPos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownFieldLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "AntSim4";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFieldLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseXPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseYPos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownFieldLength;
        private System.Windows.Forms.NumericUpDown numericUpDownBaseXPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownBaseYPos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelRoundNumber;
        private System.Windows.Forms.Label labelMessageText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
    }
}

