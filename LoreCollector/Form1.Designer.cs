
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
            this.серверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveViaSftpArchives = new System.Windows.Forms.ToolStripMenuItem();
            this.unzipZips = new System.Windows.Forms.ToolStripMenuItem();
            this.collectLogsToClear = new System.Windows.Forms.ToolStripMenuItem();
            this.DivideLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.charactersSelectList = new System.Windows.Forms.CheckedListBox();
            this.hoursComboBoxStart = new System.Windows.Forms.ComboBox();
            this.minutesComboBoxStart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hoursComboBoxEnd = new System.Windows.Forms.ComboBox();
            this.minutesComboBoxEnd = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timeSelectPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timeSelectCheckBox = new System.Windows.Forms.CheckBox();
            this.logoPrefab = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.timeSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPrefab)).BeginInit();
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
            this.textBox2.Location = new System.Drawing.Point(824, 428);
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
            this.логоToolStripMenuItem,
            this.серверToolStripMenuItem});
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
            this.обычныйсинийToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обычныйсинийToolStripMenuItem.Text = "Обычный (синий)";
            this.обычныйсинийToolStripMenuItem.Click += new System.EventHandler(this.MainStyleToolStripMenuItem_Click);
            // 
            // ваншотToolStripMenuItem
            // 
            this.ваншотToolStripMenuItem.Name = "ваншотToolStripMenuItem";
            this.ваншотToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            // серверToolStripMenuItem
            // 
            this.серверToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveViaSftpArchives,
            this.unzipZips,
            this.collectLogsToClear,
            this.DivideLogs});
            this.серверToolStripMenuItem.Name = "серверToolStripMenuItem";
            this.серверToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.серверToolStripMenuItem.Text = "Сервер";
            // 
            // saveViaSftpArchives
            // 
            this.saveViaSftpArchives.Name = "saveViaSftpArchives";
            this.saveViaSftpArchives.Size = new System.Drawing.Size(253, 22);
            this.saveViaSftpArchives.Text = "Скачать архивы по sftp";
            this.saveViaSftpArchives.Click += new System.EventHandler(this.saveViaSftpArchives_Click);
            // 
            // unzipZips
            // 
            this.unzipZips.Name = "unzipZips";
            this.unzipZips.Size = new System.Drawing.Size(253, 22);
            this.unzipZips.Text = "Разархивировать логи";
            this.unzipZips.Click += new System.EventHandler(this.unzipZips_Click);
            // 
            // collectLogsToClear
            // 
            this.collectLogsToClear.Name = "collectLogsToClear";
            this.collectLogsToClear.Size = new System.Drawing.Size(253, 22);
            this.collectLogsToClear.Text = "Собрать логи по дням чистовые";
            this.collectLogsToClear.Click += new System.EventHandler(this.collectLogsToClear_Click);
            // 
            // DivideLogs
            // 
            this.DivideLogs.Name = "DivideLogs";
            this.DivideLogs.Size = new System.Drawing.Size(253, 22);
            this.DivideLogs.Text = "Разбить избыточные логи";
            this.DivideLogs.Click += new System.EventHandler(this.DivideLogs_Click);
            // 
            // charactersSelectList
            // 
            this.charactersSelectList.FormattingEnabled = true;
            this.charactersSelectList.Location = new System.Drawing.Point(824, 164);
            this.charactersSelectList.Name = "charactersSelectList";
            this.charactersSelectList.Size = new System.Drawing.Size(222, 130);
            this.charactersSelectList.TabIndex = 9;
            // 
            // hoursComboBoxStart
            // 
            this.hoursComboBoxStart.FormattingEnabled = true;
            this.hoursComboBoxStart.Location = new System.Drawing.Point(34, 23);
            this.hoursComboBoxStart.Name = "hoursComboBoxStart";
            this.hoursComboBoxStart.Size = new System.Drawing.Size(36, 23);
            this.hoursComboBoxStart.TabIndex = 10;
            // 
            // minutesComboBoxStart
            // 
            this.minutesComboBoxStart.FormattingEnabled = true;
            this.minutesComboBoxStart.Location = new System.Drawing.Point(85, 23);
            this.minutesComboBoxStart.Name = "minutesComboBoxStart";
            this.minutesComboBoxStart.Size = new System.Drawing.Size(36, 23);
            this.minutesComboBoxStart.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Часы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Минуты";
            // 
            // hoursComboBoxEnd
            // 
            this.hoursComboBoxEnd.FormattingEnabled = true;
            this.hoursComboBoxEnd.Location = new System.Drawing.Point(34, 71);
            this.hoursComboBoxEnd.Name = "hoursComboBoxEnd";
            this.hoursComboBoxEnd.Size = new System.Drawing.Size(36, 23);
            this.hoursComboBoxEnd.TabIndex = 10;
            // 
            // minutesComboBoxEnd
            // 
            this.minutesComboBoxEnd.FormattingEnabled = true;
            this.minutesComboBoxEnd.Location = new System.Drawing.Point(85, 71);
            this.minutesComboBoxEnd.Name = "minutesComboBoxEnd";
            this.minutesComboBoxEnd.Size = new System.Drawing.Size(36, 23);
            this.minutesComboBoxEnd.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Часы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Минуты";
            // 
            // timeSelectPanel
            // 
            this.timeSelectPanel.Controls.Add(this.hoursComboBoxStart);
            this.timeSelectPanel.Controls.Add(this.label4);
            this.timeSelectPanel.Controls.Add(this.label7);
            this.timeSelectPanel.Controls.Add(this.label6);
            this.timeSelectPanel.Controls.Add(this.label5);
            this.timeSelectPanel.Controls.Add(this.minutesComboBoxStart);
            this.timeSelectPanel.Controls.Add(this.label3);
            this.timeSelectPanel.Controls.Add(this.label1);
            this.timeSelectPanel.Controls.Add(this.minutesComboBoxEnd);
            this.timeSelectPanel.Controls.Add(this.hoursComboBoxEnd);
            this.timeSelectPanel.Location = new System.Drawing.Point(824, 322);
            this.timeSelectPanel.Name = "timeSelectPanel";
            this.timeSelectPanel.Size = new System.Drawing.Size(188, 100);
            this.timeSelectPanel.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "по";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "с";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Минуты";
            // 
            // timeSelectCheckBox
            // 
            this.timeSelectCheckBox.AutoSize = true;
            this.timeSelectCheckBox.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeSelectCheckBox.Location = new System.Drawing.Point(824, 300);
            this.timeSelectCheckBox.Name = "timeSelectCheckBox";
            this.timeSelectCheckBox.Size = new System.Drawing.Size(212, 16);
            this.timeSelectCheckBox.TabIndex = 13;
            this.timeSelectCheckBox.Text = "Сортировка по времени (включительно)";
            this.timeSelectCheckBox.UseVisualStyleBackColor = true;
            this.timeSelectCheckBox.CheckedChanged += new System.EventHandler(this.timeSelectCheckBox_CheckedChanged);
            // 
            // logoPrefab
            // 
            this.logoPrefab.BackColor = System.Drawing.Color.Transparent;
            this.logoPrefab.BackgroundImage = global::LoreCollector.Properties.Resources.DiemensionSMP;
            this.logoPrefab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPrefab.Location = new System.Drawing.Point(104, 393);
            this.logoPrefab.Name = "logoPrefab";
            this.logoPrefab.Size = new System.Drawing.Size(616, 90);
            this.logoPrefab.TabIndex = 7;
            this.logoPrefab.TabStop = false;
            this.logoPrefab.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 1061);
            this.Controls.Add(this.logoPrefab);
            this.Controls.Add(this.timeSelectCheckBox);
            this.Controls.Add(this.timeSelectPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.charactersSelectList);
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
            this.timeSelectPanel.ResumeLayout(false);
            this.timeSelectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPrefab)).EndInit();
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
        private System.Windows.Forms.CheckedListBox charactersSelectList;
        private System.Windows.Forms.ComboBox hoursComboBoxStart;
        private System.Windows.Forms.ComboBox minutesComboBoxStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hoursComboBoxEnd;
        private System.Windows.Forms.ComboBox minutesComboBoxEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel timeSelectPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox timeSelectCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem серверToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveViaSftpArchives;
        private System.Windows.Forms.ToolStripMenuItem unzipZips;
        private System.Windows.Forms.ToolStripMenuItem collectLogsToClear;
        private System.Windows.Forms.ToolStripMenuItem DivideLogs;
        private System.Windows.Forms.PictureBox logoPrefab;
    }
}

