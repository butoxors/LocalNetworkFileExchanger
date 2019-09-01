namespace Kurs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbClient = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.режимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.серверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеПодключенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDragDrop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileDatas = new System.Windows.Forms.TextBox();
            this.userFileControl1 = new Kurs.UserFileControl();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pDragDrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(12, 27);
            this.tbServer.Multiline = true;
            this.tbServer.Name = "tbServer";
            this.tbServer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbServer.Size = new System.Drawing.Size(279, 91);
            this.tbServer.TabIndex = 0;
            // 
            // tbClient
            // 
            this.tbClient.Location = new System.Drawing.Point(297, 27);
            this.tbClient.Multiline = true;
            this.tbClient.Name = "tbClient";
            this.tbClient.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbClient.Size = new System.Drawing.Size(279, 91);
            this.tbClient.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pDragDrop);
            this.groupBox1.Controls.Add(this.userFileControl1);
            this.groupBox1.Location = new System.Drawing.Point(13, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 220);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 349);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(590, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.режимToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // режимToolStripMenuItem
            // 
            this.режимToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.режимToolStripMenuItem1,
            this.данныеПодключенияToolStripMenuItem});
            this.режимToolStripMenuItem.Name = "режимToolStripMenuItem";
            this.режимToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.режимToolStripMenuItem.Text = "Настройки";
            // 
            // режимToolStripMenuItem1
            // 
            this.режимToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.серверToolStripMenuItem,
            this.клиентToolStripMenuItem});
            this.режимToolStripMenuItem1.Name = "режимToolStripMenuItem1";
            this.режимToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.режимToolStripMenuItem1.Text = "Режим";
            // 
            // серверToolStripMenuItem
            // 
            this.серверToolStripMenuItem.Name = "серверToolStripMenuItem";
            this.серверToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.серверToolStripMenuItem.Text = "Сервер";
            this.серверToolStripMenuItem.Click += new System.EventHandler(this.серверToolStripMenuItem_Click);
            // 
            // клиентToolStripMenuItem
            // 
            this.клиентToolStripMenuItem.Name = "клиентToolStripMenuItem";
            this.клиентToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.клиентToolStripMenuItem.Text = "Клиент";
            this.клиентToolStripMenuItem.Click += new System.EventHandler(this.клиентToolStripMenuItem_Click);
            // 
            // данныеПодключенияToolStripMenuItem
            // 
            this.данныеПодключенияToolStripMenuItem.Name = "данныеПодключенияToolStripMenuItem";
            this.данныеПодключенияToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.данныеПодключенияToolStripMenuItem.Text = "Данные подключения";
            this.данныеПодключенияToolStripMenuItem.Click += new System.EventHandler(this.данныеПодключенияToolStripMenuItem_Click);
            // 
            // pDragDrop
            // 
            this.pDragDrop.AllowDrop = true;
            this.pDragDrop.Controls.Add(this.tbFileDatas);
            this.pDragDrop.Controls.Add(this.label1);
            this.pDragDrop.Location = new System.Drawing.Point(12, 75);
            this.pDragDrop.Name = "pDragDrop";
            this.pDragDrop.Size = new System.Drawing.Size(545, 139);
            this.pDragDrop.TabIndex = 4;
            this.pDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.pDragDrop_DragDrop);
            this.pDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.pDragDrop_DragEnter);
            this.pDragDrop.DragLeave += new System.EventHandler(this.pDragDrop_DragLeave);
            this.pDragDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.pDragDrop_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(112, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите файл или претащите его сюда";
            // 
            // tbFileDatas
            // 
            this.tbFileDatas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFileDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFileDatas.Location = new System.Drawing.Point(0, 0);
            this.tbFileDatas.Multiline = true;
            this.tbFileDatas.Name = "tbFileDatas";
            this.tbFileDatas.Size = new System.Drawing.Size(545, 139);
            this.tbFileDatas.TabIndex = 1;
            this.tbFileDatas.Visible = false;
            this.tbFileDatas.DragDrop += new System.Windows.Forms.DragEventHandler(this.pDragDrop_DragDrop);
            this.tbFileDatas.DragEnter += new System.Windows.Forms.DragEventHandler(this.pDragDrop_DragEnter);
            this.tbFileDatas.DragLeave += new System.EventHandler(this.pDragDrop_DragLeave);
            // 
            // userFileControl1
            // 
            this.userFileControl1.Location = new System.Drawing.Point(12, 21);
            this.userFileControl1.Name = "userFileControl1";
            this.userFileControl1.Size = new System.Drawing.Size(449, 48);
            this.userFileControl1.TabIndex = 3;
            this.userFileControl1.Load += new System.EventHandler(this.userFileControl1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 371);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbClient);
            this.Controls.Add(this.tbServer);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ClientServerApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pDragDrop.ResumeLayout(false);
            this.pDragDrop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbServer;
        public System.Windows.Forms.TextBox tbClient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private UserFileControl userFileControl1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem режимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem серверToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem данныеПодключенияToolStripMenuItem;
        private System.Windows.Forms.Panel pDragDrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileDatas;
    }
}

