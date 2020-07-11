namespace pcPort
{
    partial class mainDisplay
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBoxtxCR = new System.Windows.Forms.CheckBox();
            this.tx = new System.Windows.Forms.TextBox();
            this.checkBoxHexSend = new System.Windows.Forms.CheckBox();
            this.txCount = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rx = new System.Windows.Forms.TextBox();
            this.rxCount = new System.Windows.Forms.Label();
            this.checkBoxrxCR = new System.Windows.Forms.CheckBox();
            this.checkBoxHexView = new System.Windows.Forms.CheckBox();
            this.btReset = new System.Windows.Forms.Button();
            this.btOpenClose = new System.Windows.Forms.Button();
            this.comboBaudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPortList = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.checkBoxtxCR);
            this.groupBox2.Controls.Add(this.tx);
            this.groupBox2.Controls.Add(this.checkBoxHexSend);
            this.groupBox2.Controls.Add(this.txCount);
            this.groupBox2.Controls.Add(this.buttonSend);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 456);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1029, 282);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送区";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(804, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 27;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBoxtxCR
            // 
            this.checkBoxtxCR.AutoSize = true;
            this.checkBoxtxCR.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxtxCR.Location = new System.Drawing.Point(723, 55);
            this.checkBoxtxCR.Name = "checkBoxtxCR";
            this.checkBoxtxCR.Size = new System.Drawing.Size(111, 24);
            this.checkBoxtxCR.TabIndex = 26;
            this.checkBoxtxCR.Text = "自动换行";
            this.checkBoxtxCR.UseVisualStyleBackColor = true;
            this.checkBoxtxCR.CheckedChanged += new System.EventHandler(this.checkBoxtxCR_CheckedChanged);
            // 
            // tx
            // 
            this.tx.Location = new System.Drawing.Point(0, 23);
            this.tx.Multiline = true;
            this.tx.Name = "tx";
            this.tx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tx.Size = new System.Drawing.Size(710, 266);
            this.tx.TabIndex = 16;
            // 
            // checkBoxHexSend
            // 
            this.checkBoxHexSend.AutoSize = true;
            this.checkBoxHexSend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHexSend.Location = new System.Drawing.Point(723, 25);
            this.checkBoxHexSend.Name = "checkBoxHexSend";
            this.checkBoxHexSend.Size = new System.Drawing.Size(131, 24);
            this.checkBoxHexSend.TabIndex = 11;
            this.checkBoxHexSend.Text = "16进制显示";
            this.checkBoxHexSend.UseVisualStyleBackColor = true;
            this.checkBoxHexSend.CheckedChanged += new System.EventHandler(this.checkBoxHexSend_CheckedChanged);
            // 
            // txCount
            // 
            this.txCount.AutoSize = true;
            this.txCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txCount.Location = new System.Drawing.Point(497, 0);
            this.txCount.Name = "txCount";
            this.txCount.Size = new System.Drawing.Size(99, 20);
            this.txCount.TabIndex = 15;
            this.txCount.Text = "发送统计:";
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSend.Location = new System.Drawing.Point(723, 245);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 37);
            this.buttonSend.TabIndex = 14;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rx);
            this.groupBox1.Controls.Add(this.rxCount);
            this.groupBox1.Controls.Add(this.checkBoxrxCR);
            this.groupBox1.Controls.Add(this.checkBoxHexView);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1030, 318);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接收区";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(724, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 26;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rx
            // 
            this.rx.Location = new System.Drawing.Point(1, 23);
            this.rx.Multiline = true;
            this.rx.Name = "rx";
            this.rx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rx.Size = new System.Drawing.Size(710, 295);
            this.rx.TabIndex = 5;
            // 
            // rxCount
            // 
            this.rxCount.AutoSize = true;
            this.rxCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rxCount.Location = new System.Drawing.Point(498, 0);
            this.rxCount.Name = "rxCount";
            this.rxCount.Size = new System.Drawing.Size(99, 20);
            this.rxCount.TabIndex = 6;
            this.rxCount.Text = "接收统计:";
            // 
            // checkBoxrxCR
            // 
            this.checkBoxrxCR.AutoSize = true;
            this.checkBoxrxCR.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxrxCR.Location = new System.Drawing.Point(724, 53);
            this.checkBoxrxCR.Name = "checkBoxrxCR";
            this.checkBoxrxCR.Size = new System.Drawing.Size(111, 24);
            this.checkBoxrxCR.TabIndex = 25;
            this.checkBoxrxCR.Text = "自动换行";
            this.checkBoxrxCR.UseVisualStyleBackColor = true;
            this.checkBoxrxCR.CheckedChanged += new System.EventHandler(this.checkBoxrxCR_CheckedChanged);
            // 
            // checkBoxHexView
            // 
            this.checkBoxHexView.AutoSize = true;
            this.checkBoxHexView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHexView.Location = new System.Drawing.Point(724, 23);
            this.checkBoxHexView.Name = "checkBoxHexView";
            this.checkBoxHexView.Size = new System.Drawing.Size(131, 24);
            this.checkBoxHexView.TabIndex = 22;
            this.checkBoxHexView.Text = "16进制显示";
            this.checkBoxHexView.UseVisualStyleBackColor = true;
            this.checkBoxHexView.CheckedChanged += new System.EventHandler(this.checkBoxHexView_CheckedChanged);
            // 
            // btReset
            // 
            this.btReset.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btReset.Location = new System.Drawing.Point(294, 70);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(75, 37);
            this.btReset.TabIndex = 24;
            this.btReset.Text = "重置";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // btOpenClose
            // 
            this.btOpenClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenClose.Location = new System.Drawing.Point(294, 12);
            this.btOpenClose.Name = "btOpenClose";
            this.btOpenClose.Size = new System.Drawing.Size(75, 37);
            this.btOpenClose.TabIndex = 23;
            this.btOpenClose.Text = "打开";
            this.btOpenClose.UseVisualStyleBackColor = true;
            this.btOpenClose.Click += new System.EventHandler(this.btOpenClose_Click);
            // 
            // comboBaudrate
            // 
            this.comboBaudrate.FormattingEnabled = true;
            this.comboBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.comboBaudrate.Location = new System.Drawing.Point(109, 71);
            this.comboBaudrate.Name = "comboBaudrate";
            this.comboBaudrate.Size = new System.Drawing.Size(121, 23);
            this.comboBaudrate.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "选择串口";
            // 
            // comboPortList
            // 
            this.comboPortList.FormattingEnabled = true;
            this.comboPortList.Location = new System.Drawing.Point(109, 21);
            this.comboPortList.Name = "comboPortList";
            this.comboPortList.Size = new System.Drawing.Size(121, 23);
            this.comboPortList.TabIndex = 18;
            // 
            // mainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 781);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btOpenClose);
            this.Controls.Add(this.comboBaudrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPortList);
            this.Name = "mainDisplay";
            this.Text = "pcPort";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxHexSend;
        private System.Windows.Forms.Label txCount;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox rx;
        private System.Windows.Forms.Label rxCount;
        private System.Windows.Forms.CheckBox checkBoxrxCR;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Button btOpenClose;
        private System.Windows.Forms.CheckBox checkBoxHexView;
        private System.Windows.Forms.ComboBox comboBaudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPortList;
        private System.Windows.Forms.TextBox tx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBoxtxCR;
    }
}