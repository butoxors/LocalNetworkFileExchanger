namespace Kurs
{
    partial class StatisticsPanel
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
            this.lServerStatus = new System.Windows.Forms.Label();
            this.lDirPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lClientStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lFileStatus = new System.Windows.Forms.Label();
            this.btnOpenExplorer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lServerStatus);
            this.panel1.Controls.Add(this.lDirPath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 143);
            this.panel1.TabIndex = 0;
            // 
            // lServerStatus
            // 
            this.lServerStatus.AutoSize = true;
            this.lServerStatus.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.lServerStatus.ForeColor = System.Drawing.Color.White;
            this.lServerStatus.Location = new System.Drawing.Point(42, 27);
            this.lServerStatus.Name = "lServerStatus";
            this.lServerStatus.Size = new System.Drawing.Size(22, 22);
            this.lServerStatus.TabIndex = 0;
            this.lServerStatus.Text = "--";
            // 
            // lDirPath
            // 
            this.lDirPath.AutoSize = true;
            this.lDirPath.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.lDirPath.ForeColor = System.Drawing.Color.White;
            this.lDirPath.Location = new System.Drawing.Point(42, 71);
            this.lDirPath.Name = "lDirPath";
            this.lDirPath.Size = new System.Drawing.Size(22, 22);
            this.lDirPath.TabIndex = 0;
            this.lDirPath.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Путь к файлам:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Статус сервера:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Статус клиента:";
            // 
            // lClientStatus
            // 
            this.lClientStatus.AutoSize = true;
            this.lClientStatus.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.lClientStatus.ForeColor = System.Drawing.Color.White;
            this.lClientStatus.Location = new System.Drawing.Point(367, 154);
            this.lClientStatus.Name = "lClientStatus";
            this.lClientStatus.Size = new System.Drawing.Size(22, 22);
            this.lClientStatus.TabIndex = 0;
            this.lClientStatus.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Статус отправки файла:";
            // 
            // lFileStatus
            // 
            this.lFileStatus.AutoSize = true;
            this.lFileStatus.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.lFileStatus.ForeColor = System.Drawing.Color.White;
            this.lFileStatus.Location = new System.Drawing.Point(367, 176);
            this.lFileStatus.Name = "lFileStatus";
            this.lFileStatus.Size = new System.Drawing.Size(22, 22);
            this.lFileStatus.TabIndex = 0;
            this.lFileStatus.Text = "--";
            // 
            // btnOpenExplorer
            // 
            this.btnOpenExplorer.FlatAppearance.BorderSize = 0;
            this.btnOpenExplorer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnOpenExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenExplorer.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnOpenExplorer.ForeColor = System.Drawing.Color.White;
            this.btnOpenExplorer.Location = new System.Drawing.Point(429, 378);
            this.btnOpenExplorer.Name = "btnOpenExplorer";
            this.btnOpenExplorer.Size = new System.Drawing.Size(291, 33);
            this.btnOpenExplorer.TabIndex = 1;
            this.btnOpenExplorer.Text = "Открыть папку с файлами";
            this.btnOpenExplorer.UseVisualStyleBackColor = true;
            this.btnOpenExplorer.Click += new System.EventHandler(this.btnOpenExplorer_Click);
            // 
            // StatisticsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.btnOpenExplorer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lFileStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lClientStatus);
            this.Controls.Add(this.label4);
            this.Name = "StatisticsPanel";
            this.Size = new System.Drawing.Size(723, 414);
            this.VisibleChanged += new System.EventHandler(this.SettingsPanel_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lClientStatus;
        public System.Windows.Forms.Label lFileStatus;
        public System.Windows.Forms.Label lDirPath;
        public System.Windows.Forms.Label lServerStatus;
        private System.Windows.Forms.Button btnOpenExplorer;
    }
}
