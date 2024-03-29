﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using File = System.IO.File;
using System.IO.Compression;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using System.Reflection.Emit;
using Label = System.Windows.Forms.Label;

namespace LoreCollector
{
    public partial class Form1 : Form
    {
        PrivateFontCollection pfc = new PrivateFontCollection(); //Шрифты
        List<String> loreParsed = new List<string>(); // Список строк лора
        Dictionary<string, string> nickNames = new Dictionary<string, string>();
        static int startY = 100;
        int startHeight;
        int lastY = startY; // Координаты последнего контрола (окна с текстом) внутри Panel
        int spacing = 5; // Отступ
        float charactersTonewLine = 60f; // Символов в строке текстового окна
        string folderName = "PlayerHeads"; //Имя папки с головами
        string nicknamesFile = "nickname.txt"; //Текстовый документ с именами@Никами персонажей
        string prevLine = ""; //Предыдущая строка
        string connDataFilePath = "conn.txt";
        string logsPath = "logs";
        string rawLogsPath = "textsRaw";
        string endLogsPath = "loreEnd";
        PictureBox currentLogo;
        Control LogoPos = new Control();
        string OpenedFileName;
        int OpenedFileCount;
        private static readonly HttpClient client = new HttpClient();
        public Form1(bool auto = false)
        {
            InitializeComponent();
            startHeight = mainPanel.Height;
            AllocConsole();//Подключение консоли для дебаггинга
            pfc.AddFontFile("fonts\\minecraft.ttf"); // Подключение шрифта кастомного
            nickNames.Clear(); // Очищение спииска ников
            LoadPictures(folderName); // Загрузка картинок голов из папки
            SetupComboBoxes();
            currentLogo = startLogo;
            LogoPos.Location = startLogo.Location;
            CreateIfMissing(logsPath);
            CreateIfMissing($"{logsPath}/{rawLogsPath}");
            CreateIfMissing($"{logsPath}/{rawLogsPath}/{endLogsPath}");
            if (auto)
                StartAutoFill();

            SelectDateToCut.Checked = true;
            SelectDateToCut.Checked = false;
        }
        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
        private void SetupComboBoxes()
        {
            for (int i = 0; i < 60; i++)
            {
                if (i < 24)
                {
                    hoursComboBoxStart.Items.Add(i);
                    hoursComboBoxEnd.Items.Add(i);
                }
                minutesComboBoxStart.Items.Add(i);
                minutesComboBoxEnd.Items.Add(i);
            }
            hoursComboBoxStart.SelectedIndex = 0;
            hoursComboBoxEnd.SelectedIndex = hoursComboBoxEnd.Items.Count - 1;
            minutesComboBoxStart.SelectedIndex = 0;
            minutesComboBoxEnd.SelectedIndex = minutesComboBoxEnd.Items.Count - 1;
            timeSelectPanel.Enabled = false;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void LoadPictures(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName); // Если папки с никами нет - создается 
            }
            nickNames.Clear();
            var fstream = new StreamReader(nicknamesFile);
            while (!fstream.EndOfStream)
            {
                string s = fstream.ReadLine();
                var nick = s.Substring(0, s.IndexOf("@"));
                var charName = s.Substring(s.IndexOf("@") + 1);
                nickNames.Add(nick, charName); // В список ников добавляется пара ник-имя персонажа
            }
            foreach (var nick in nickNames)
            {
                charactersSelectList.Items.Add(nick.Value);
            }
            fstream.Close();
            var files = Directory.GetFiles(folderName, "*.*")
                .ToList(); // Создает список всех файлов из указанной дериктории с любым именем/расширением
            imageList1.Images.Add("default", Properties.Resources.steave_head); // Добавление заглушки для отсутствующих скинов
            foreach (var file in files)
            {
                Image myImage = Image.FromFile(file);
                imageList1.Images.Add(file, new Bitmap(myImage));// Добавление картинок в image лист для дальнешйего подставления 
            }

        }

        public void InitCustomLabelFont(Control cc)
        {
            cc.Font = new Font(pfc.Families[0], 8, FontStyle.Regular);    // Заменяет шрифты у передаваемого контрола
        }

        private void chooseLog_Click(object sender, EventArgs e)
        {
            LogFill();
           
        }
        void LogFill(bool auto = false, string _filePath = "")
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            lastY = 100; // Очищение значения к исходному

            Stream fileStream;
            if (!auto)
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                string path = $"{logsPath}\\{rawLogsPath}\\{endLogsPath}"; // this is the path that you are checking.
                if (Directory.Exists(path))
                {
                    openFileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory + path;
                }
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                //openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK) // Если в окне выбора файла нажали ОК, то
                {
                    filePath = openFileDialog.FileName;
                    fileStream = openFileDialog.OpenFile();
                }
            }
            else
            {
                filePath = _filePath;
            }
            try { 
            
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        fileContent = reader.ReadToEnd(); //Файл считывается в переменную string
                    }
            }
            catch
            {

            }
                    string[] arrayString = fileContent.Split(new string[] { Environment.NewLine },
        StringSplitOptions.None); //Файл разбивается в string массив по новым строкам
            OpenedFileName = filePath;
            if (OpenedFileName.Contains("_"))
            {
                OpenedFileCount = Convert.ToInt32(OpenedFileName.Substring(OpenedFileName.IndexOf("_") + 1, 1));
            }
            else
            {
                OpenedFileCount = 1;
            }
            loreParsed = CutToLogs(arrayString); // Присвоение отсортированного лора (без мусора) в глобальную переменную.
                    FillThePanel(loreParsed); // Заполнение панелек с текстом, используя массив строк без мусора
                    try
                    {
                        OpenedFileName = OpenedFileName.Substring(OpenedFileName.LastIndexOf('-') - 2, 5);
                    }
                    catch
                    {

                    };
                    Console.WriteLine(OpenedFileName);
                

            }
        
        private List<string> CutToLogs(string[] fullContent)
        {
            int StartLine = 0; // Строка, с которой начинается поиск сообщений
            List<string> coolLore = new List<string>();
            //for(int i = 0; i < fullContent.Length; i++)
            //{
            //    if (!fullContent[i].Contains("Done")) // первое сообщение перед заходом на сервер
            //        continue;
            //    StartLine = i;
            //}

            for (int i = StartLine; i < fullContent.Length; i++)
            {
                var line = fullContent[i];
                int lineHour, lineMinute;
                try
                {
                    int.TryParse(line.Substring(1, 2), out lineHour);
                    int.TryParse(line.Substring(4, 2), out lineMinute);
                }
                catch
                {
                    continue;
                }
                int beforeHour, afterHour, beforeMinute, afterMinute;

                if (timeSelectCheckBox.Checked)
                {
                    int.TryParse(hoursComboBoxStart.Text, out beforeHour);
                    int.TryParse(hoursComboBoxEnd.Text, out afterHour);
                    int.TryParse(minutesComboBoxStart.Text, out beforeMinute);
                    int.TryParse(minutesComboBoxEnd.Text, out afterMinute);
                    var nullDateTime = new DateTime();
                    var lineTime = new DateTime();
                    var startTime = new DateTime();
                    var endTime = new DateTime();
                    lineTime = nullDateTime.AddHours(lineHour).AddMinutes(lineMinute);
                    startTime = nullDateTime.AddHours(beforeHour).AddMinutes(beforeMinute);
                    endTime = nullDateTime.AddHours(afterHour).AddMinutes(afterMinute);

                    if (!(lineTime >= startTime && lineTime <= endTime))
                        continue;

                }
                coolLore.Add(line); // Добавление отформатированной строки к общему массиву строк





            }
            return coolLore; //Возвращение крутых строк 

        }

        private void FillThePanel(List<String> completedLore)
        {
            int width = flowLayoutPanel1.Width; // Присаивание значения ширины панели для текстовых сообщений.

            foreach (var line in completedLore)
            {
                SetupDialogBubble(width, line); // Для каждой строки крутого лора (отформатированные строки) создается текстовое окно
            }

            flowLayoutPanel1.Width = currentLogo.Width;
            mainPanel.Height = flowLayoutPanel1.Height; // Выставляется ширина панели по Y последнего сообщения + оффсет
            this.AutoScroll = true; // Разрашает прокрутку основной формы
        }

        private void SetupDialogBubble(int width, string line)
        {
            string name = GetName(line);
            if (charactersSelectList.CheckedItems.Count != 0 && !CheckName(name))
                return;
            Panel newPanel = SetupPanel(width, lastY, spacing); // Создается панель для содержания в себе элементов
            Label newLabel = SetupLabel(width, line, charactersTonewLine, newPanel); // Создается текстовый лейбл внутри панели
            var image = SetupImage(newPanel, newLabel, line); //Устанавливается картинка в панель
            if (image == null)
                return;
            prevLine = line; // Сохраняем предыдущую строку для проверки оффсета
            Panel outerPanel = new Panel();
            outerPanel.Controls.Add(newPanel);
            outerPanel.Width = mainPanel.Width;
            outerPanel.Height = newPanel.Height;
            newPanel.Left = (outerPanel.Width - newPanel.Width) / 2;
            newPanel.Top = (outerPanel.Height - newPanel.Height) / 2;
            try
            {
                flowLayoutPanel1.Controls.Add(outerPanel); //Добавляем созданную панель внутрь основной панели
            }
            catch
            {
                StartAutoFill();
            }
        }
        private Panel SetupPanel(int width, int lastY, int spacing)
        {
            Panel newPanel = new Panel(); // Создается пустая панель
            newPanel.BackColor = Color.Transparent; //Цвет заднего фона - прозрачный
            newPanel.BorderStyle = BorderStyle.None; // Без рамки
            newPanel.Width = width - 50; //Ширина меньше ширины панели, в которой будет располагаться
            newPanel.BackgroundImage = Properties.Resources.plate1; // Берем картинку из ресурсов проекта и ставим на задний фон панели
            newPanel.BackgroundImageLayout = ImageLayout.Stretch; // Выставляем растягивание картинки в панели.

            if (prevLine.Length > charactersTonewLine) //Проверка кол-ва символов в строке для корректного отступа
            {
                float multiplier = (prevLine.Length / charactersTonewLine); // Получаем множитель размера текста (сколько строк занимает с остатком)
                newPanel.Location = new Point(20, lastY + (int)multiplier * spacing); // Выставляем координаты панели с учетом корректного отступа
                Console.WriteLine($"Panel location.Y is {newPanel.Location.Y} at spacing having {spacing * multiplier} having LastY {lastY}");
            }
            else
            {
                newPanel.Location = new Point(20, lastY + spacing); // Иначе, если сообщение короткое, используем обычный отступ
                Console.WriteLine($"Panel location.Y is {newPanel.Location.Y} at spacing having {spacing} having LastY {lastY}");
            }

            
            return newPanel; // Возвращаем панель
        }
        private PictureBox SetupImage(Panel newPanel, Label newLine, string line)
        {
            PictureBox newPicture = new PictureBox(); //Создается картинка
            newPicture.Size = new Size(25, 25); //Выставляется размер картинки
            newPicture.SizeMode = PictureBoxSizeMode.Zoom; // Выставляется режим масштабирования картинки
                                                           //newPicture.Location = new Point(15, (int)(newLine.Height / 1.5)); //Выставляется позиция картинки относительно текстового поля



            newPicture.Left = 15;
            newPicture.Top = newPanel.Height / 2 - newPicture.Height / 2;

            newPanel.Controls.Add(newPicture); //На панель добавляется картинка
            if (line.Contains("Сильванни"))
            {

            }
            string name = GetName(line);


            bool isChecked = false;
            if (charactersSelectList.CheckedItems.Count != 0)
                isChecked = CheckName(name);

            newPicture = SetHeadPicture(newPicture, name); // Присваивается изображение внутрь контрола с картинкой по имени

            return charactersSelectList.CheckedItems.Count == 0 ? newPicture : (isChecked) ? newPicture : null; //Возвращаем картинку
        }
        bool CheckName(string name)
        {
            return charactersSelectList.CheckedItems.Contains(name);
        }
        string GetName(string line)
        {
            string name;
            int Place = new int();

            string localNeedle = line.Trim().StartsWith("*") ? line.Substring(3) : line;
            foreach (var localName in nickNames)
            {
                if (line.Trim().StartsWith("*") && line.Contains("Херотч"))
                {

                }
                if (localNeedle.Trim().StartsWith(localName.Value))
                {
                    Place = localName.Value.Length;
                    break;
                }
                if (localNeedle.Trim().StartsWith(localName.Key))
                {
                    Place = localName.Key.Length;
                    break;
                }
            }

            if (line.Trim().Substring(0, 3).Contains("*"))
            {
                if(line.Contains("Херотч Сильванни"))
                {

                }
                name = line.Trim().Substring(2, Place); //Если сообщение пишется через /me (имеет звездочку вначале), то отрабатывает обрезание ника по одной последовательности
              
            }
            else {
             
                    name = line.Trim().Substring(0, Place); // Если сообщение обычное, то по другой

               
                }
                return name;
        }
        private Label SetupLabel(int width, string line, float charactersToNewLine, Panel newPanel)
        {
            Label newLine = new Label(); // Создаем текстовый лейбл для сообщения
            var lineWithSpaces = SplitToLower(line, charactersToNewLine); // Разбиваем сообщение на многострчоное, используя исходную строку и кол-во символов до новой строки
            newLine.Text = lineWithSpaces; // Выставояем лейблу текст с переносами.
            newLine.Width = width; //Выставляем лейблу ширину
            InitCustomLabelFont(newLine); // Меняем шрифт строке
            newPanel.MinimumSize = new Size(600, 50);// Задаем минимальную ширину панели, чтобы маленькие не схлопывались
            Size maxSize = new Size(495, int.MaxValue);
            newLine.Height = TextRenderer.MeasureText(newLine.Text, newLine.Font, maxSize).Height;

            //newLine.BackColor = Color.Black;
            
          
         
            Console.WriteLine($"Having line Height at {newLine.Height}");
            newLine.BorderStyle = BorderStyle.None; // Убираем рамки у строки
            newLine.BackColor = Color.Transparent; // Ставим прозрачный фон строке
            newLine.ForeColor = Color.White; // Ставим цвет шрифта строке
            newLine.Top = 20;
            newLine.Left = 50;

            newPanel.Height = newLine.Top * 2 + newLine.Height;
            newPanel.Controls.Add(newLine); // Добавляем строку в Панель текстового окна
            Console.WriteLine($"Having panel Height at {newPanel.Height}");
            return newLine; //Возвращаем панельку
        }
        private PictureBox SetHeadPicture(PictureBox pictureBox, String name)
        {
            if (nickNames.ContainsKey(name) || nickNames.ContainsValue(name))
            { //Если список имен@Ников содержит в себе имя, переданное в функцию (имя на строке), то
                string charName;
                nickNames.TryGetValue(name, out charName); //Пытаемся найти значение в массиве имен@Ников
                try // Если nickNames существует, то назначается картинка по имени или по нику
                {
                    if (charName != null)
                        pictureBox.Image = imageList1.Images[imageList1.Images.IndexOfKey(folderName + "\\" + charName + ".png")];
                    else
                        pictureBox.Image = imageList1.Images[imageList1.Images.IndexOfKey(folderName + "\\" + name + ".png")];
                }

                catch //Иначе, если возникает какой-то exception, ставитс яголова стива
                {
                    pictureBox.Image = Properties.Resources.steave_head;
                }
            }
            else
                pictureBox.Image = Properties.Resources.steave_head; //Также, если ника нет в списке имен@ников, ставится стив

            if (name == "Root_Of_Tree") //Костыль на ник Рут, потому что он не читался из файла корректно
                pictureBox.Image = imageList1.Images[imageList1.Images.IndexOfKey(folderName + "\\" + "Рут Сильванни" + ".png")];

            return pictureBox; // Возвращаем картинку
        }
        private string SplitToLower(string str, float charToNewLine)
        {
            for (int i = 1; i < str.Length; i++)
            {
                if (i % charToNewLine != 0) // Получаем остаток от деления на кол-во символов до новой строки, тем самым начиная проверку только на определенных символах. Можно зарефракторить цикл, чтобы не перебирать все символы а только 50е, но пока лень
                    continue;

                var tempo = str.ToCharArray(); // Разбиваем всю строку на массив
                var tempStr = new List<string>(); // А также создаем временный список символов
                foreach (var chara in tempo)
                {
                    tempStr.Add(chara.ToString());// Каждый символ добавляем в список
                }

                for (int m = i; m > 0; m--)
                { // Начинаем перебирать список

                    if (tempStr[m] != " ") // Если символ не пробел, то пропускаем его и идём к предыдущему
                        continue;

                    tempStr[m] = "\r"; // Заменяем символ-пробел на перенос строки
                    str = string.Join("", tempStr); // Склеиваем список символов в единую строку
                    break;
                }
            }
            return str; // Возвращаем её
        }

        private void SaveAsImage_Click(object sender, EventArgs e) //Кнопка сохранения картинки
        {
            SaveLogImage();
        }
        void SaveLogImage(bool auto = false)
        {
            string path;
            if (!auto)
            {
                SaveFileDialog sf = new SaveFileDialog(); //Создаем новое окно сохранения файла
                sf.Filter = "Png Image (.png)|*.png|Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf"; //Задаем перечень фильтров для сохранения
                ChangeWindowColorState(true);
                var directoryName = OpenedFileName.Substring(OpenedFileName.IndexOf("-") + 1) + "." + OpenedFileName.Substring(0, 2);
                if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), directoryName)))
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), directoryName));
                Console.WriteLine(directoryName);
                sf.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), directoryName);
                sf.ShowDialog(); //Отображаем окно как диалоговое (нельзя нажать никуда кроме него, пока открыто)
                path = sf.FileName; // Получаем путь, который пользователь указал в окне в переменную
                if (path == "") //Если путь пустой - прекращаем работу функции
                {
                    ChangeWindowColorState(false);
                    MessageBox.Show("Выберите путь и название файла.");
                    return;
                }
            }
            else
            {
                var directoryName = OpenedFileName.Substring(OpenedFileName.IndexOf("-") + 1) + "." + OpenedFileName.Substring(0, 2);
                if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), directoryName)))
                     Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), directoryName));
                path = Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), directoryName)).ToString();
            }
            int width = mainPanel.Size.Width; //Задаем ширину основной панели в ширину будущей картинки
            int height = mainPanel.Size.Height; //Задаем ширину основной панели в ширину будущей картинки
            Bitmap bm = new Bitmap(width, height); //Создаем новый битмап заданных размеров

            mainPanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height)); //Перерисовываем панель со всеми фонами как Битмап в нашу переменную.
            bm.Save(path+$"/{OpenedFileCount}.png", ImageFormat.Png); //Сохраняем картинку как png по заданному пользователем ранее пути 
            ChangeWindowColorState(false);
        }
        private void ChangeWindowColorState(bool busy)
        {
            if (busy)
                this.BackColor = Color.IndianRed;
            else
                this.BackColor = SystemColors.Control;
        }
        private void reloadBtn_Click(object sender, EventArgs e) //Кнопка очистки формы
        {
            ClearWindow();
        }
        void ClearWindow()
        {
            var newLogo = new PictureBox();
            newLogo.BackColor = logoPrefab.BackColor;
            newLogo.BackgroundImage = logoPrefab.BackgroundImage;
            newLogo.Size = logoPrefab.Size;
            newLogo.Location = LogoPos.Location;
            newLogo.BackgroundImageLayout = logoPrefab.BackgroundImageLayout;
            try {
            foreach(Control ctr in flowLayoutPanel1.Controls)
                {
                    DisposeControl(ctr);
                }

            flowLayoutPanel1.Controls.Clear();
                
            flowLayoutPanel1.Controls.Add(newLogo);
            currentLogo = newLogo;
            mainPanel.Height = startHeight;
            flowLayoutPanel1.Height = startHeight;
            }
            catch
            {
                StartAutoFill();
            }
        }
        void DisposeControl(Control ctrl)
        {
            if (ctrl.Controls.Count > 0)
            {
                foreach (Control val in ctrl.Controls)
                {
                    DisposeControl(val);
                }

            }
            ctrl.Dispose();

        }
        private void ResetLogo()
        {
            currentLogo.BackgroundImage = Properties.Resources.DiemensionSMP;
            currentLogo.BackgroundImageLayout = ImageLayout.Center;
        }

        private void вернутьКИсходномуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetLogo();
        }

        private void MainStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.BackgroundImage = Properties.Resources.background2;
        }

        private void OneShotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.BackgroundImage = Properties.Resources.backgroundred;
        }

        private void LogoChangeOnCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) // Сложная мешанина из интернета с считыванием файла с интернета
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK) // Если в окне выбора файла нажали ОК, то
                {
                    filePath = openFileDialog.FileName;
                    if (File.Exists(filePath))
                    {
                        currentLogo.BackgroundImage = Image.FromFile(filePath);
                        currentLogo.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else
                        ResetLogo();
                }

            }
        }

        private void timeSelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timeSelectPanel.Enabled = timeSelectCheckBox.Checked;
        }

        private void GetFiles(ConnectionInfo connectionInfo, string remoteDirectory)
        {
            if (connectionInfo == null)
                return;
            ChangeWindowColorState(true);
            using (var sftp = new SftpClient(connectionInfo))
            {
                try
                {
                    sftp.Connect();

                    DownloadDirectory(sftp, remoteDirectory, "logs");

                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                    MessageBox.Show("Ошибка при подключении по SFTP протоколу.");
                    ChangeWindowColorState(false);
                }
            }
            ChangeWindowColorState(false);
        }
        private void DownloadDirectory(SftpClient client, string source, string destination, bool recursive = false)
        {

            var files = client.ListDirectory(source);


            foreach (SftpFile file in files)
            {
                if (!file.IsDirectory && !file.IsSymbolicLink)
                {
                    DownloadFile(client, file, destination);
                }

                else if (file.IsSymbolicLink)
                {
                    Console.WriteLine("Symbolic link ignored: {0}", file.FullName);
                }

                else if (file.Name != "." && file.Name != "..")
                {
                    var dir = Directory.CreateDirectory(Path.Combine(destination, file.Name));
                    if (recursive)
                    {
                        DownloadDirectory(client, file.FullName, dir.FullName);
                    }
                }
            }
        }


        private void DownloadFile(SftpClient client, SftpFile file, string directory)
        {
            Console.WriteLine("Downloading {0}", file.FullName);
            if (File.Exists(Path.Combine(directory, file.Name)))
            {
                Console.WriteLine("{0} already exist! Skipping ", file.FullName);
                return;
            }
            using (Stream fileStream = File.OpenWrite(Path.Combine(directory, file.Name)))
            {
                client.DownloadFile(file.FullName, fileStream);
            }
        }
        private ConnectionInfo GetConnInfo(string dataFile)
        {
            string host = "", username = "", password = "", line = "";
            int port = 0;
            try
            {
                using (StreamReader reader = new StreamReader(dataFile))
                {
                    host = reader.ReadLine();
                    username = reader.ReadLine();
                    password = reader.ReadLine();
                    int.TryParse(reader.ReadLine(), out port);
                }
            }
            catch
            {
                MessageBox.Show("Нет файла авторизации!");
                return null;
            }
            KeyboardInteractiveAuthenticationMethod kauth = new KeyboardInteractiveAuthenticationMethod(username);
            PasswordAuthenticationMethod pauth = new PasswordAuthenticationMethod(username, password);

            kauth.AuthenticationPrompt += new EventHandler<Renci.SshNet.Common.AuthenticationPromptEventArgs>(HandleKeyEvent);

            ConnectionInfo connectionInfo = new ConnectionInfo(host, port, username, pauth, kauth);

            void HandleKeyEvent(Object sender, Renci.SshNet.Common.AuthenticationPromptEventArgs e)
            {
                foreach (Renci.SshNet.Common.AuthenticationPrompt prompt in e.Prompts)
                {
                    if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                    {
                        prompt.Response = password;
                    }
                }
            }
            return connectionInfo;

        }

        private void saveViaSftpArchives_Click(object sender, EventArgs e)
        {

            GetFiles(GetConnInfo(connDataFilePath), logsPath);
        }

        private void unzipZips_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(logsPath);
            FileInfo[] Files = d.GetFiles("*.gz");
            DirectoryInfo directory = new DirectoryInfo($"{logsPath}/{rawLogsPath}");
            foreach (FileInfo file in directory.GetFiles()) file.Delete();

            foreach (FileInfo file in Files)
            {
                Decompress(file, rawLogsPath);
            }
        }



        public static void Decompress(FileInfo fileToDecompress, string rawText)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.Name;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
                newFileName = fileToDecompress.FullName.Substring(0, fileToDecompress.FullName.Length - currentFileName.Length) + $"{rawText}\\\\" + newFileName;
                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }

        private void collectLogsToClear_Click(object sender, EventArgs e)
        {


            DirectoryInfo directory = new DirectoryInfo($"{logsPath}/{rawLogsPath}/{endLogsPath}");
            foreach (FileInfo file in directory.GetFiles()) file.Delete();

            foreach (string fileName in Directory.GetFiles($"{logsPath}/{rawLogsPath}", "*.log"))
            {
                string cutName = fileName.Substring(14, fileName.Substring(14).Length - 6);
                string[] fileLines = File.ReadAllLines(fileName);
                string[] winLines = new string[fileLines.Length];
                for (int i = 0; i < fileLines.Length; i++)
                {
                    winLines[i] = fileLines[i].Replace("\n", "\r\n");
                }
                LinkedList<string> lines = new LinkedList<string>(winLines);
                LinkedList<string> finalLines = new LinkedList<string>();
                string path = $"{logsPath}/{rawLogsPath}/{endLogsPath}/" + cutName + ".txt";
                using (StreamWriter sw = File.AppendText(path)) {

                    foreach (var line in lines)
                    {
                        bool messageWereRemoved = false;
                        string newLine = CheckOfftopicMessage(line);
                        if (newLine != null)
                        {
                            if (line.ToLower().Contains("@удалить@"))
                            {
                                messageWereRemoved = true;
                                string localLineName = GetName(newLine);
                                foreach (string localLine in finalLines.Reverse())
                                    {
                                 
                                    string localnewLineName = GetName(localLine);
                                    if (localnewLineName == localLineName)
                                        {
                                        finalLines.Remove(finalLines.Find(localLine));
                                        break;
                                        }
                                    }
                            }
                            if(!messageWereRemoved)
                                finalLines.AddLast(newLine);
                        }
                    }
                    foreach (string line in finalLines) sw.Write(line+"\n");
                }
            } }
        

        private void DivideLogs_Click(object sender, EventArgs e)
        {
            foreach (string fileName in Directory.GetFiles($"{logsPath}/{rawLogsPath}/{endLogsPath}", "*.txt"))
            {
                var lines = File.ReadAllLines(fileName);
                if (lines.Length < 350)
                {
                    continue;
                }
                else
                {
                    // build sample data with 1200 Strings
                    string[] items = lines;
                    String[][] chunks = items
                                        .Select((s, i) => new { Value = s, Index = i })
                                        .GroupBy(x => x.Index / 350)
                                        .Select(grp => grp.Select(x => x.Value).ToArray())
                                        .ToArray();
                    for (int i = 0; i < chunks.Length; i++)
                    {
                        string newFileName = fileName.Substring(0, fileName.Length - 4) + "_" + i + ".txt";
                        System.IO.File.WriteAllLines(newFileName, chunks[i]);
                    }

                }
                File.Delete(fileName);
            }
        }

        private void очиститьАрхивыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo($"{logsPath}");
            foreach (FileInfo file in directory.GetFiles()) file.Delete();

        }
        private void объединитьФлудToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (string fileName in Directory.GetFiles($"{logsPath}/{rawLogsPath}/{endLogsPath}", "*.txt")) 
            {
                Console.WriteLine($"Start parsed {fileName}");
                List<string> newContent = new List<string>();
                var lines = File.ReadAllLines(fileName);
                for (int i = 0; i < lines.Length - 1; i++)
                {

                    string curName = GetName(lines[i]);
                    string nextName = GetName(lines[i + 1]);

                    if (curName == nextName)
                    {
                        string newLine = "";
                        newLine += lines[i];
                        while (nextName == curName)
                        {
                            newLine += ". " + lines[i + 1].Replace($"{curName} : ", String.Empty);
                            i++;
                            try
                            {
                                curName = GetName(lines[i]);
                                nextName = GetName(lines[i + 1]);
                            }
                            catch
                            {
                                Console.WriteLine($"Error on {fileName}");
                                break;
                            }
                        }
                        newContent.Add(newLine);
                    }
                    else
                    {
                        newContent.Add(lines[i]);
                    }

                }
                Console.WriteLine($"Parsed successfuly {fileName}");
                File.WriteAllLines(fileName, newContent);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string CheckOfftopicMessage(string line)
        {
            if (line.Contains("[Not")) //Поиск серверного сообщения [Not Secure], им помечаются сообщения игроков.
            {
                int pos = line.IndexOf("re]") + 3; // Оффсет на конец сообщения [Not Secure]

                if (line.Contains("<") || line.Contains("*")) // СОобщения с ником или звездочкой в дейсвтии
                {
                    if (!line.Substring(pos).Contains("> (")) // Обходи сообщений оффтопа
                    {
                        if (!line.Substring(pos).Contains("> 9")) // И ещё
                        {
                            if (!line.Substring(pos).Contains("> )")) // И ещё
                            {

                                var needles = new string[] { "<", "#", ">" }; // Массив символов, которые нужно убрать из конечного сообщения
                                foreach (var needle in needles)
                                {
                                    line = line.Replace(needle, String.Empty); // Если на строке происходит совпадение с одной из needlе (элемент массива), то заменяется на пустоту.
                                }
                                line = line.Substring(pos); // Обрезается сообщение к Никнейму
                                if (line.Trim().Split()[0] != "*") //Если сообщение пишется черезе /me
                                {
                                    int Place = line.Trim().IndexOf(" ");
                                    foreach (var name in nickNames)
                                    {
                                        if (line.Trim().StartsWith(name.Value))
                                        {
                                            Place = name.Value.Length;
                                            break;
                                        }
                                        if (line.Trim().StartsWith(name.Key))
                                        {
                                            Place = name.Key.Length ;
                                            break;
                                        }
                                    }
                                    
                                    try
                                    {

                                        if (line.Contains("Херотч Сильванни "))
                                        {
                                            line = line.Trim().Remove(Place + "Херотч Сильванни".Length - 1, " ".Length).Insert(Place, " : ");
                                        }
                                        else { 
                                        line = line.Trim().Remove(Place, " ".Length).Insert(Place, " : ");
                                        }
                                    }// Заменяется символ пробела и ставится : для сообщения в итогового
                                    catch
                                    {

                                    }
                                }
                                return line; // Добавление отформатированной строки к общему массиву строк
                            }
                        }
                    }
                }
            }
            return null;
        }

        private void серверToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartAutoFill(); 
        }
        private void StartAutoFill()
        {
            DateTime myDt = new DateTime();
            if (SelectDateToCut.Checked)
            {
                myDt = DateFrom.Value.Date;
            }

            ClearWindow();
            foreach (string fileName in Directory.GetFiles($"{logsPath}/{rawLogsPath}/{endLogsPath}", "*.txt"))
            {
                DateTime logDate = new DateTime();
                DateTime NullDateTime = new DateTime();
                if (SelectDateToCut.Checked)
                {
                    int indexDate = fileName.IndexOf("\\") + 1;
                    string Years = fileName.Substring(indexDate, 4);
                    string Months = fileName.Substring(indexDate + 5, 2);
                    string days = fileName.Substring(indexDate + 8, 2);
                    logDate = NullDateTime.AddYears(Convert.ToInt32(Years)-1).AddMonths(Convert.ToInt32(Months)-1).AddDays(Convert.ToInt32(days)-1);
                }

                if(!SelectDateToCut.Checked || logDate>=myDt) { 
                LogFill(true,fileName);
                SaveLogImage(true);
                ClearWindow();
                File.Delete(fileName);
                GC.Collect();
                }
                else
                {
                    continue;
                }
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            datePanel.Enabled = SelectDateToCut.Checked;
        }

        private void logoPrefab_Click(object sender, EventArgs e)
        {

        }

        private void автоматонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveViaSftpArchives_Click(null, null);
            unzipZips_Click(null, null);
            collectLogsToClear_Click(null, null);
            объединитьФлудToolStripMenuItem_Click(null, null);
            DivideLogs_Click(null, null);
        }
    }
}
    





