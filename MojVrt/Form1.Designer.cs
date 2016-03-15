namespace MojVrt
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.cb_rastline = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_razdalja = new System.Windows.Forms.Label();
            this.label_povpKaljivost = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_dobriSosedje = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_slabiSosedje = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_sajenja = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label_presajanja = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label_pobiranja = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label_zalivanje = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rastilna:";
            // 
            // cb_rastline
            // 
            this.cb_rastline.FormattingEnabled = true;
            this.cb_rastline.Items.AddRange(new object[] {
            "Blitva",
            "Bob",
            "Brokoli",
            "Brstični Ohrovt",
            "Bučke",
            "Buče",
            "Cvetača",
            "Čebula",
            "Endivija",
            "Fižol nizki",
            "Fižol visoki",
            "Grah",
            "Jajčevec",
            "Kitajsko zelje",
            "Koleraba",
            "Kolerabica",
            "Korenček",
            "Kumare",
            "Motovilec",
            "Ohrovt",
            "Paprika",
            "Paradižnik",
            "Peteršilj",
            "Por",
            "Radič",
            "Rdeča pesa",
            "Redkvica",
            "Repa",
            "Sladka koruza",
            "Solata",
            "Špinača",
            "Zelena gomoljna",
            "Zelje"});
            this.cb_rastline.Location = new System.Drawing.Point(70, 42);
            this.cb_rastline.Name = "cb_rastline";
            this.cb_rastline.Size = new System.Drawing.Size(205, 21);
            this.cb_rastline.TabIndex = 3;
            this.cb_rastline.SelectedIndexChanged += new System.EventHandler(this.cb_rastline_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_razdalja);
            this.groupBox1.Controls.Add(this.label_povpKaljivost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 67);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacije:";
            // 
            // label_razdalja
            // 
            this.label_razdalja.AutoSize = true;
            this.label_razdalja.Location = new System.Drawing.Point(100, 42);
            this.label_razdalja.Name = "label_razdalja";
            this.label_razdalja.Size = new System.Drawing.Size(0, 13);
            this.label_razdalja.TabIndex = 6;
            // 
            // label_povpKaljivost
            // 
            this.label_povpKaljivost.AutoSize = true;
            this.label_povpKaljivost.Location = new System.Drawing.Point(138, 20);
            this.label_povpKaljivost.Name = "label_povpKaljivost";
            this.label_povpKaljivost.Size = new System.Drawing.Size(0, 13);
            this.label_povpKaljivost.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Razdalja sajenja:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Povprečen čas kaljivosti:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_dobriSosedje);
            this.groupBox2.Location = new System.Drawing.Point(306, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 97);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dobri sosedje:";
            // 
            // label_dobriSosedje
            // 
            this.label_dobriSosedje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_dobriSosedje.Location = new System.Drawing.Point(3, 16);
            this.label_dobriSosedje.Name = "label_dobriSosedje";
            this.label_dobriSosedje.ReadOnly = true;
            this.label_dobriSosedje.Size = new System.Drawing.Size(250, 78);
            this.label_dobriSosedje.TabIndex = 0;
            this.label_dobriSosedje.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_slabiSosedje);
            this.groupBox3.Location = new System.Drawing.Point(306, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 97);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Slabi sosedje:";
            // 
            // label_slabiSosedje
            // 
            this.label_slabiSosedje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_slabiSosedje.Location = new System.Drawing.Point(3, 16);
            this.label_slabiSosedje.Name = "label_slabiSosedje";
            this.label_slabiSosedje.ReadOnly = true;
            this.label_slabiSosedje.Size = new System.Drawing.Size(250, 78);
            this.label_slabiSosedje.TabIndex = 0;
            this.label_slabiSosedje.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_sajenja);
            this.groupBox4.Location = new System.Drawing.Point(18, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(256, 97);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Obdobje sajenja:";
            // 
            // label_sajenja
            // 
            this.label_sajenja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_sajenja.Location = new System.Drawing.Point(3, 16);
            this.label_sajenja.Name = "label_sajenja";
            this.label_sajenja.ReadOnly = true;
            this.label_sajenja.Size = new System.Drawing.Size(250, 78);
            this.label_sajenja.TabIndex = 0;
            this.label_sajenja.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label_presajanja);
            this.groupBox5.Location = new System.Drawing.Point(19, 245);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(256, 97);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Obdobje presajanja:";
            // 
            // label_presajanja
            // 
            this.label_presajanja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_presajanja.Location = new System.Drawing.Point(3, 16);
            this.label_presajanja.Name = "label_presajanja";
            this.label_presajanja.ReadOnly = true;
            this.label_presajanja.Size = new System.Drawing.Size(250, 78);
            this.label_presajanja.TabIndex = 0;
            this.label_presajanja.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label_pobiranja);
            this.groupBox6.Location = new System.Drawing.Point(19, 348);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(256, 97);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Obdobje pobiranja:";
            // 
            // label_pobiranja
            // 
            this.label_pobiranja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_pobiranja.Location = new System.Drawing.Point(3, 16);
            this.label_pobiranja.Name = "label_pobiranja";
            this.label_pobiranja.ReadOnly = true;
            this.label_pobiranja.Size = new System.Drawing.Size(250, 78);
            this.label_pobiranja.TabIndex = 0;
            this.label_pobiranja.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label_zalivanje);
            this.groupBox7.Location = new System.Drawing.Point(306, 348);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(256, 97);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Zalivanje:";
            // 
            // label_zalivanje
            // 
            this.label_zalivanje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_zalivanje.Location = new System.Drawing.Point(3, 16);
            this.label_zalivanje.Name = "label_zalivanje";
            this.label_zalivanje.ReadOnly = true;
            this.label_zalivanje.Size = new System.Drawing.Size(250, 78);
            this.label_zalivanje.TabIndex = 0;
            this.label_zalivanje.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 451);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Nazaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Zdaj je primeren čas za zalivanje vrta.";
            this.notifyIcon1.BalloonTipTitle = "MojVrt";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MojVrt";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem1.Text = "Pokaži aplikacijo";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem2.Text = "Izhod";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cb_rastline);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MojVrt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_rastline;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_razdalja;
        private System.Windows.Forms.Label label_povpKaljivost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox label_sajenja;
        private System.Windows.Forms.RichTextBox label_presajanja;
        private System.Windows.Forms.RichTextBox label_pobiranja;
        private System.Windows.Forms.RichTextBox label_dobriSosedje;
        private System.Windows.Forms.RichTextBox label_slabiSosedje;
        private System.Windows.Forms.RichTextBox label_zalivanje;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

