namespace Kurs
{
    partial class ClientPanel
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTakeAFile = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lFileInfo = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pDown = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbPort);
            this.panel1.Controls.Add(this.tbIP);
            this.panel1.Controls.Add(this.btnClientConnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 414);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(99)))), ((int)(((byte)(130)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(182, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 414);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 44);
            this.label4.TabIndex = 1;
            this.label4.Text = "Настройки \r\nсоединения";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "IPAddress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPort
            // 
            this.tbPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPort.ForeColor = System.Drawing.Color.SteelBlue;
            this.tbPort.Location = new System.Drawing.Point(7, 138);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(161, 20);
            this.tbPort.TabIndex = 1;
            this.tbPort.Tag = "1";
            this.tbPort.Text = "8001";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPort.Enter += new System.EventHandler(this.textBox1_Enter);
            this.tbPort.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // tbIP
            // 
            this.tbIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIP.ForeColor = System.Drawing.Color.SteelBlue;
            this.tbIP.Location = new System.Drawing.Point(8, 90);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(161, 20);
            this.tbIP.TabIndex = 1;
            this.tbIP.Tag = "0";
            this.tbIP.Text = "127.0.0.1";
            this.tbIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbIP.Enter += new System.EventHandler(this.textBox1_Enter);
            this.tbIP.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.FlatAppearance.BorderSize = 0;
            this.btnClientConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnClientConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientConnect.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnClientConnect.Image = global::Kurs.Properties.Resources.wifi;
            this.btnClientConnect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClientConnect.Location = new System.Drawing.Point(8, 166);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(161, 66);
            this.btnClientConnect.TabIndex = 0;
            this.btnClientConnect.Text = "Подключиться";
            this.btnClientConnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClientConnect.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.BackgroundImage = global::Kurs.Properties.Resources.download;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnTakeAFile);
            this.panel2.Controls.Add(this.btnPause);
            this.panel2.Controls.Add(this.lFileInfo);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.pDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(185, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 414);
            this.panel2.TabIndex = 1;
            this.panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel2_DragDrop);
            this.panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel2_DragEnter);
            this.panel2.DragLeave += new System.EventHandler(this.panel2_DragLeave);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = global::Kurs.Properties.Resources.refresh;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReset.Location = new System.Drawing.Point(278, 173);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(187, 67);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Сбросить";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            // 
            // btnTakeAFile
            // 
            this.btnTakeAFile.FlatAppearance.BorderSize = 0;
            this.btnTakeAFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeAFile.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnTakeAFile.ForeColor = System.Drawing.Color.White;
            this.btnTakeAFile.Image = global::Kurs.Properties.Resources.document;
            this.btnTakeAFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTakeAFile.Location = new System.Drawing.Point(193, 45);
            this.btnTakeAFile.Name = "btnTakeAFile";
            this.btnTakeAFile.Size = new System.Drawing.Size(160, 67);
            this.btnTakeAFile.TabIndex = 6;
            this.btnTakeAFile.Text = "Выбрать файл";
            this.btnTakeAFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTakeAFile.UseVisualStyleBackColor = true;
            this.btnTakeAFile.Click += new System.EventHandler(this.btnTakeAFile_Click);
            // 
            // btnPause
            // 
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Image = global::Kurs.Properties.Resources.play_button;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPause.Location = new System.Drawing.Point(88, 173);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(184, 67);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Передать";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            // 
            // lFileInfo
            // 
            this.lFileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lFileInfo.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.lFileInfo.ForeColor = System.Drawing.Color.White;
            this.lFileInfo.Location = new System.Drawing.Point(34, 148);
            this.lFileInfo.Name = "lFileInfo";
            this.lFileInfo.Size = new System.Drawing.Size(467, 22);
            this.lFileInfo.TabIndex = 1;
            this.lFileInfo.Text = "Или переместите файл сюда";
            this.lFileInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::Kurs.Properties.Resources.left_arrow_key;
            this.button2.Location = new System.Drawing.Point(-3, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 47);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pDown
            // 
            this.pDown.Controls.Add(this.progressBar1);
            this.pDown.Controls.Add(this.label3);
            this.pDown.Location = new System.Drawing.Point(34, 254);
            this.pDown.Margin = new System.Windows.Forms.Padding(0);
            this.pDown.Name = "pDown";
            this.pDown.Size = new System.Drawing.Size(467, 66);
            this.pDown.TabIndex = 7;
            this.pDown.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(467, 28);
            this.progressBar1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(467, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "В ожидании получения данных...";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ClientPanel";
            this.Size = new System.Drawing.Size(723, 414);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox tbPort;
        public System.Windows.Forms.TextBox tbIP;
        public System.Windows.Forms.Button btnClientConnect;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnPause;
        public System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Button btnTakeAFile;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel pDown;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label lFileInfo;
        public System.Windows.Forms.Panel panel2;
    }
}
