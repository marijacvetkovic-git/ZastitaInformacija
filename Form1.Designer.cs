
namespace ProjekatZastita18039
{
    partial class Form1
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
            this.cBAlogoritmi = new System.Windows.Forms.ComboBox();
            this.richTextBoxKey = new System.Windows.Forms.RichTextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnFajl = new System.Windows.Forms.Button();
            this.richTextBoxFajl = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEncrypt = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDecrypt = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.lblKey = new System.Windows.Forms.Label();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.gBkey = new System.Windows.Forms.GroupBox();
            this.GBCBC = new System.Windows.Forms.GroupBox();
            this.rTBVektor = new System.Windows.Forms.RichTextBox();
            this.gBSlike = new System.Windows.Forms.GroupBox();
            this.pB2 = new System.Windows.Forms.PictureBox();
            this.pB1 = new System.Windows.Forms.PictureBox();
            this.gBkey.SuspendLayout();
            this.GBCBC.SuspendLayout();
            this.gBSlike.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).BeginInit();
            this.SuspendLayout();
            // 
            // cBAlogoritmi
            // 
            this.cBAlogoritmi.FormattingEnabled = true;
            this.cBAlogoritmi.Items.AddRange(new object[] {
            "RC4",
            "ENIGMA",
            "TEA",
            "TEA CBC",
            "RC4 BMP",
            "TEA CRC"});
            this.cBAlogoritmi.Location = new System.Drawing.Point(12, 12);
            this.cBAlogoritmi.Name = "cBAlogoritmi";
            this.cBAlogoritmi.Size = new System.Drawing.Size(121, 24);
            this.cBAlogoritmi.TabIndex = 0;
            this.cBAlogoritmi.SelectedIndexChanged += new System.EventHandler(this.cBAlogoritmi_SelectedIndexChanged);
            // 
            // richTextBoxKey
            // 
            this.richTextBoxKey.Location = new System.Drawing.Point(40, 18);
            this.richTextBoxKey.Name = "richTextBoxKey";
            this.richTextBoxKey.Size = new System.Drawing.Size(100, 96);
            this.richTextBoxKey.TabIndex = 2;
            this.richTextBoxKey.Text = "";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(347, 212);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(112, 40);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(521, 212);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(90, 40);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnFajl
            // 
            this.btnFajl.Location = new System.Drawing.Point(182, 212);
            this.btnFajl.Name = "btnFajl";
            this.btnFajl.Size = new System.Drawing.Size(92, 40);
            this.btnFajl.TabIndex = 5;
            this.btnFajl.Text = "Izaberite fajl";
            this.btnFajl.UseVisualStyleBackColor = true;
            this.btnFajl.Click += new System.EventHandler(this.btnFajl_Click);
            // 
            // richTextBoxFajl
            // 
            this.richTextBoxFajl.Location = new System.Drawing.Point(182, 100);
            this.richTextBoxFajl.Name = "richTextBoxFajl";
            this.richTextBoxFajl.Size = new System.Drawing.Size(100, 96);
            this.richTextBoxFajl.TabIndex = 6;
            this.richTextBoxFajl.Text = "";
            // 
            // richTextBoxEncrypt
            // 
            this.richTextBoxEncrypt.Location = new System.Drawing.Point(347, 100);
            this.richTextBoxEncrypt.Name = "richTextBoxEncrypt";
            this.richTextBoxEncrypt.Size = new System.Drawing.Size(100, 96);
            this.richTextBoxEncrypt.TabIndex = 7;
            this.richTextBoxEncrypt.Text = "";
            // 
            // richTextBoxDecrypt
            // 
            this.richTextBoxDecrypt.Location = new System.Drawing.Point(521, 100);
            this.richTextBoxDecrypt.Name = "richTextBoxDecrypt";
            this.richTextBoxDecrypt.Size = new System.Drawing.Size(100, 96);
            this.richTextBoxDecrypt.TabIndex = 8;
            this.richTextBoxDecrypt.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(68, 123);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(32, 17);
            this.lblKey.TabIndex = 9;
            this.lblKey.Text = "Key";
            this.lblKey.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // gBkey
            // 
            this.gBkey.Controls.Add(this.richTextBoxKey);
            this.gBkey.Controls.Add(this.lblKey);
            this.gBkey.Location = new System.Drawing.Point(12, 86);
            this.gBkey.Name = "gBkey";
            this.gBkey.Size = new System.Drawing.Size(164, 143);
            this.gBkey.TabIndex = 12;
            this.gBkey.TabStop = false;
            // 
            // GBCBC
            // 
            this.GBCBC.Controls.Add(this.rTBVektor);
            this.GBCBC.Location = new System.Drawing.Point(52, 282);
            this.GBCBC.Name = "GBCBC";
            this.GBCBC.Size = new System.Drawing.Size(124, 128);
            this.GBCBC.TabIndex = 13;
            this.GBCBC.TabStop = false;
            this.GBCBC.Text = "Inicijalizacioni vektor";
            this.GBCBC.Visible = false;
            // 
            // rTBVektor
            // 
            this.rTBVektor.Location = new System.Drawing.Point(6, 35);
            this.rTBVektor.Name = "rTBVektor";
            this.rTBVektor.Size = new System.Drawing.Size(100, 72);
            this.rTBVektor.TabIndex = 14;
            this.rTBVektor.Text = "";
            // 
            // gBSlike
            // 
            this.gBSlike.Controls.Add(this.pB2);
            this.gBSlike.Controls.Add(this.pB1);
            this.gBSlike.Location = new System.Drawing.Point(277, 282);
            this.gBSlike.Name = "gBSlike";
            this.gBSlike.Size = new System.Drawing.Size(382, 234);
            this.gBSlike.TabIndex = 14;
            this.gBSlike.TabStop = false;
            this.gBSlike.Text = "Slika";
            this.gBSlike.Visible = false;
            // 
            // pB2
            // 
            this.pB2.Location = new System.Drawing.Point(207, 57);
            this.pB2.Name = "pB2";
            this.pB2.Size = new System.Drawing.Size(169, 157);
            this.pB2.TabIndex = 1;
            this.pB2.TabStop = false;
            // 
            // pB1
            // 
            this.pB1.Location = new System.Drawing.Point(15, 57);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(167, 157);
            this.pB1.TabIndex = 0;
            this.pB1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 591);
            this.Controls.Add(this.gBSlike);
            this.Controls.Add(this.GBCBC);
            this.Controls.Add(this.gBkey);
            this.Controls.Add(this.richTextBoxDecrypt);
            this.Controls.Add(this.richTextBoxEncrypt);
            this.Controls.Add(this.richTextBoxFajl);
            this.Controls.Add(this.btnFajl);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.cBAlogoritmi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gBkey.ResumeLayout(false);
            this.gBkey.PerformLayout();
            this.GBCBC.ResumeLayout(false);
            this.gBSlike.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBAlogoritmi;
        private System.Windows.Forms.RichTextBox richTextBoxKey;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnFajl;
        private System.Windows.Forms.RichTextBox richTextBoxFajl;
        private System.Windows.Forms.RichTextBox richTextBoxEncrypt;
        private System.Windows.Forms.RichTextBox richTextBoxDecrypt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.GroupBox gBkey;
        private System.Windows.Forms.GroupBox GBCBC;
        private System.Windows.Forms.RichTextBox rTBVektor;
        private System.Windows.Forms.GroupBox gBSlike;
        private System.Windows.Forms.PictureBox pB2;
        private System.Windows.Forms.PictureBox pB1;
    }
}

