
namespace LoreCollector
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ChooseFile = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.startLogo = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SaveAsImage = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.reloadBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.стилиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обычныйсинийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ваншотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.логоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьЛогоНаКастомноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вернутьКИсходномуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ChooseFile
            // 
            this.ChooseFile.Location = new System.Drawing.Point(867, 27);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Size = new System.Drawing.Size(157, 23);
            this.ChooseFile.TabIndex = 0;
            this.ChooseFile.Text = "Выбрать файл логов";
            this.ChooseFile.UseVisualStyleBackColor = true;
            this.ChooseFile.Click += new System.EventHandler(this.chooseLog_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainPanel.BackgroundImage = global::LoreCollector.Properties.Resources.background2;
            this.mainPanel.Controls.Add(this.startLogo);
            this.mainPanel.Location = new System.Drawing.Point(69, 48);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(700, 300);
            this.mainPanel.TabIndex = 1;
            // 
            // startLogo
            // 
            this.startLogo.BackColor = System.Drawing.Color.Transparent;
            this.startLogo.BackgroundImage = global::LoreCollector.Properties.Resources.DiemensionSMP;
            this.startLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.startLogo.Location = new System.Drawing.Point(35, 18);
            this.startLogo.Name = "startLogo";
            this.startLogo.Size = new System.Drawing.Size(616, 90);
            this.startLogo.TabIndex = 7;
            this.startLogo.TabStop = false;
            // 
            // SaveAsImage
            // 
            this.SaveAsImage.Location = new System.Drawing.Point(867, 57);
            this.SaveAsImage.Name = "SaveAsImage";
            this.SaveAsImage.Size = new System.Drawing.Size(157, 23);
            this.SaveAsImage.TabIndex = 4;
            this.SaveAsImage.Text = "Сохранить картинкой";
            this.SaveAsImage.UseVisualStyleBackColor = true;
            this.SaveAsImage.Click += new System.EventHandler(this.SaveAsImage_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(256, 256);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(867, 119);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(157, 23);
            this.reloadBtn.TabIndex = 4;
            this.reloadBtn.Text = "Очистить всё";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(824, 379);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 113);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Головы персонажей загружать в дерикторию PlayerHeads, формат ИМЯБЕЗЗНАКОВ.png\r\nЛо" +
    "ги выбирать только с кодировкой UTF-8. \r\nПеред повторной загрузкой логов нажать " +
    "на кнопку очистки.\r\n";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стилиToolStripMenuItem,
            this.логоToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1058, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // стилиToolStripMenuItem
            // 
            this.стилиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обычныйсинийToolStripMenuItem,
            this.ваншотToolStripMenuItem});
            this.стилиToolStripMenuItem.Name = "стилиToolStripMenuItem";
            this.стилиToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.стилиToolStripMenuItem.Text = "Стили";
            // 
            // обычныйсинийToolStripMenuItem
            // 
            this.обычныйсинийToolStripMenuItem.Name = "обычныйсинийToolStripMenuItem";
            this.обычныйсинийToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.обычныйсинийToolStripMenuItem.Text = "Обычный (синий)";
            this.обычныйсинийToolStripMenuItem.Click += new System.EventHandler(this.MainStyleToolStripMenuItem_Click);
            // 
            // ваншотToolStripMenuItem
            // 
            this.ваншотToolStripMenuItem.Name = "ваншотToolStripMenuItem";
            this.ваншотToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ваншотToolStripMenuItem.Text = "Ваншот";
            this.ваншотToolStripMenuItem.Click += new System.EventHandler(this.OneShotToolStripMenuItem_Click);
            // 
            // логоToolStripMenuItem
            // 
            this.логоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сменитьЛогоНаКастомноеToolStripMenuItem,
            this.вернутьКИсходномуToolStripMenuItem});
            this.логоToolStripMenuItem.Name = "логоToolStripMenuItem";
            this.логоToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.логоToolStripMenuItem.Text = "Лого";
            // 
            // сменитьЛогоНаКастомноеToolStripMenuItem
            // 
            this.сменитьЛогоНаКастомноеToolStripMenuItem.Name = "сменитьЛогоНаКастомноеToolStripMenuItem";
            this.сменитьЛогоНаКастомноеToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.сменитьЛогоНаКастомноеToolStripMenuItem.Text = "Сменить лого на кастомное";
            this.сменитьЛогоНаКастомноеToolStripMenuItem.Click += new System.EventHandler(this.LogoChangeOnCustomToolStripMenuItem_Click);
            // 
            // вернутьКИсходномуToolStripMenuItem
            // 
            this.вернутьКИсходномуToolStripMenuItem.Name = "вернутьКИсходномуToolStripMenuItem";
            this.вернутьКИсходномуToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.вернутьКИсходномуToolStripMenuItem.Text = "Вернуть к исходному";
            this.вернутьКИсходномуToolStripMenuItem.Click += new System.EventHandler(this.вернутьКИсходномуToolStripMenuItem_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(824, 164);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(222, 130);
            this.checkedListBox1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 1061);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.SaveAsImage);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.ChooseFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Lore Collector";
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.startLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.Panel mainPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button SaveAsImage;
        private System.Windows.Forms.PictureBox startLogo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem стилиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обычныйсинийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ваншотToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem логоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьЛогоНаКастомноеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вернутьКИсходномуToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

