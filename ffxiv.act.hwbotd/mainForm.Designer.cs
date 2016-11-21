namespace ffxiv.act.hwbotd
{
    partial class mainForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_safeToDrop = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_safeToGS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_timeAccuracy = new System.Windows.Forms.TextBox();
            this.txt_toSpeak = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_activeBuff = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_GSCooldown = new System.Windows.Forms.Label();
            this.chk_overlay = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_overlay);
            this.groupBox1.Controls.Add(this.txt_safeToDrop);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_safeToGS);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_timeAccuracy);
            this.groupBox1.Controls.Add(this.txt_toSpeak);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_activeBuff);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbl_GSCooldown);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 229);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gierskogul";
            // 
            // txt_safeToDrop
            // 
            this.txt_safeToDrop.Location = new System.Drawing.Point(148, 129);
            this.txt_safeToDrop.Name = "txt_safeToDrop";
            this.txt_safeToDrop.Size = new System.Drawing.Size(57, 20);
            this.txt_safeToDrop.TabIndex = 12;
            this.txt_safeToDrop.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Active Buff:";
            // 
            // txt_safeToGS
            // 
            this.txt_safeToGS.Location = new System.Drawing.Point(148, 77);
            this.txt_safeToGS.Name = "txt_safeToGS";
            this.txt_safeToGS.Size = new System.Drawing.Size(57, 20);
            this.txt_safeToGS.TabIndex = 1;
            this.txt_safeToGS.Text = "22";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "GS Cooldown:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Safe to Gierskogul (s)";
            // 
            // txt_timeAccuracy
            // 
            this.txt_timeAccuracy.Location = new System.Drawing.Point(148, 155);
            this.txt_timeAccuracy.Name = "txt_timeAccuracy";
            this.txt_timeAccuracy.Size = new System.Drawing.Size(57, 20);
            this.txt_timeAccuracy.TabIndex = 14;
            this.txt_timeAccuracy.Text = "500";
            this.txt_timeAccuracy.TextChanged += new System.EventHandler(this.txt_timeAccuracy_TextChanged);
            // 
            // txt_toSpeak
            // 
            this.txt_toSpeak.Location = new System.Drawing.Point(148, 103);
            this.txt_toSpeak.Name = "txt_toSpeak";
            this.txt_toSpeak.Size = new System.Drawing.Size(57, 20);
            this.txt_toSpeak.TabIndex = 4;
            this.txt_toSpeak.Text = "giers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Timer Accuracy (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To Speak";
            // 
            // lbl_activeBuff
            // 
            this.lbl_activeBuff.AutoSize = true;
            this.lbl_activeBuff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_activeBuff.Location = new System.Drawing.Point(148, 19);
            this.lbl_activeBuff.Name = "lbl_activeBuff";
            this.lbl_activeBuff.Size = new System.Drawing.Size(15, 15);
            this.lbl_activeBuff.TabIndex = 6;
            this.lbl_activeBuff.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Safe remaining time to drop";
            // 
            // lbl_GSCooldown
            // 
            this.lbl_GSCooldown.AutoSize = true;
            this.lbl_GSCooldown.Location = new System.Drawing.Point(148, 45);
            this.lbl_GSCooldown.Name = "lbl_GSCooldown";
            this.lbl_GSCooldown.Size = new System.Drawing.Size(13, 13);
            this.lbl_GSCooldown.TabIndex = 10;
            this.lbl_GSCooldown.Text = "0";
            // 
            // chk_overlay
            // 
            this.chk_overlay.AutoSize = true;
            this.chk_overlay.Location = new System.Drawing.Point(10, 191);
            this.chk_overlay.Name = "chk_overlay";
            this.chk_overlay.Size = new System.Drawing.Size(203, 17);
            this.chk_overlay.TabIndex = 17;
            this.chk_overlay.Text = "Full Screen Dim Overlay (on progress)";
            this.chk_overlay.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "mainForm";
            this.Size = new System.Drawing.Size(428, 303);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_safeToDrop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_safeToGS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_timeAccuracy;
        private System.Windows.Forms.TextBox txt_toSpeak;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_activeBuff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_GSCooldown;
        private System.Windows.Forms.CheckBox chk_overlay;
    }
}
