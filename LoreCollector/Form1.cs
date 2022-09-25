using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace LoreCollector
{
    public partial class Form1 : Form
    {
        PrivateFontCollection pfc = new PrivateFontCollection(); //Шрифты
        List<String> loreParsed = new List<string>(); // Список строк лора
        Dictionary<string,string> nickNames = new Dictionary<string,string>();
        //Блок форматирования текста
        int lastY = 150;
        int spacing = 5;
        int charactersTonewLine = 60;
        string folderName = "PlayerHeads";
        string nicknamesFile = "nickname.txt";
        string prevLine = "";
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            nickNames.Clear();
            LoadPictures(folderName);

        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        private void LoadPictures(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            nickNames.Clear();
            var fstream = new StreamReader(nicknamesFile);
            while (!fstream.EndOfStream)
            {
                string s = fstream.ReadLine();
                var nick = s.Substring(0, s.IndexOf("@"));
                var charName = s.Substring(s.IndexOf("@")+1);
                nickNames.Add(nick, charName);
                textBox1.Text += charName;
            }
            fstream.Close();
            var files = Directory.GetFiles(folderName, "*.*")
                .ToList();
            imageList1.Images.Add("default", Properties.Resources.steave_head);
            foreach (var file in files) 
            {
                Image myImage = Image.FromFile(file);
                imageList1.Images.Add(file,new Bitmap(myImage));// Добавление картинок в image лист для дальнешйего подставления 
            }

        }
        
        public void InitCustomLabelFont(Control cc)
        {
            pfc.AddFontFile("D:\\minecraft.ttf");
            cc.Font = new Font(pfc.Families[0], 8, FontStyle.Regular);    // Заменяет шрифты у передаваемого контрола
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            lastY = 100;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                    //fileContent  = Encoding.GetEncoding(1251).GetString(Encoding.GetEncoding(1252).GetBytes(fileContent));
                    string[] arrayString = fileContent.Split(new string[] { Environment.NewLine },
        StringSplitOptions.None);
                    
                    var coolLore = CutToLogs(arrayString);
                    loreParsed = coolLore;
                    FillThePanel(loreParsed);

                }

            }
        }
       private List<string> CutToLogs(string[] fullContent)
        {
            int StartLine = 0;
            List<string> coolLore = new List<string>();
            for(int i = 0; i < fullContent.Length; i++)
            {
                if (!fullContent[i].Contains("Done")) // первое сообщение перед заходом на сервер
                    continue;
                StartLine = i;

            }

            for(int i = StartLine+1; i < fullContent.Length; i++)
            {
                var line = fullContent[i];
                if(line.Contains("[Not"))
                {
                    int pos = line.IndexOf("re]") +3; // Оффсет на конец сообщения [CHAT]

                    if (line.Contains("<") || line.Contains("*")) // СОобщения с ником или звездочкой в дейсвтии
                    {
                        if (!line.Substring(pos).Contains("> ("))
                        {
                            if (!line.Substring(pos).Contains("> 9"))
                            {
                                var needles = new string[] { "<", "#", ">" };
                                foreach (var needle in needles)
                                {
                                    line = line.Replace(needle, String.Empty);
                                }
                                line = line.Substring(pos);
                                if (line.Trim().Split()[0] != "*")
                                {

                                    int Place = line.Trim().IndexOf(" ");
                                    line = line.Trim().Remove(Place, " ".Length).Insert(Place, " : ");
                                    textBox1.Text = line;
                                }
                                coolLore.Add(line);
                            }
                        }
                    }
                }
            }
            return coolLore;
            
        }
       
        private void FillThePanel(List<String> completedLore)
        {
            
            int width = 700;
            mainPanel.AutoScroll = true;

            foreach (var line in completedLore)
            {
                SetupDialogBubble(width, line);
            }

            mainPanel.Height = lastY + spacing*3;
            this.AutoScroll = true;
        }
        private void SetupDialogBubble(int width,string line)
        {

            Panel newPanel = SetupPanel(width, lastY, spacing);
            Label newLabel = SetupLabel(width, line, charactersTonewLine, newPanel);
            SetupImage(newPanel, newLabel,line);
            prevLine = line;
            mainPanel.Controls.Add(newPanel);
        }
        private Panel SetupPanel( int width, int lastY,int spacing)
        {
            Panel newPanel = new Panel();
            newPanel.BackColor = Color.Transparent;
            newPanel.BorderStyle = BorderStyle.None;
            newPanel.Width = width-50;
            newPanel.BorderStyle = BorderStyle.None;
            newPanel.BackgroundImage = Properties.Resources.plate1;
            newPanel.BackgroundImageLayout = ImageLayout.Stretch;
          
            if (prevLine.Length > 60)
            {
                float multiplier = (prevLine.Length / 60f);
                textBox3.Text += multiplier*spacing + " | ";

                    newPanel.Location = new Point(20, lastY + (int)multiplier* spacing);
                
                Console.WriteLine($"Panel location.Y is { newPanel.Location.Y} at spacing having {spacing*multiplier} having LastY {lastY}");

            }
            else
            {
               
                textBox3.Text += spacing + " | ";
                newPanel.Location = new Point(20, lastY + spacing);
                Console.WriteLine($"Panel location.Y is { newPanel.Location.Y} at spacing having {spacing} having LastY {lastY}");

                
            }
            
            return newPanel;
        }
        private PictureBox SetupImage(Panel newPanel, Label newLine,string line)
        {
            PictureBox newPicture = new PictureBox();
            newPicture.Size = new Size(25, 25);
            newPicture.SizeMode =PictureBoxSizeMode.Zoom;
            newPicture.Location = new Point(15, (int)(newLine.Height / 1.5));
            newPanel.Controls.Add(newPicture);
            string name;
            if (line.Trim().Substring(0,3).Contains("*")) {
                name= line.Trim().Substring(2,line.Trim().IndexOf(" ",3)-2);
            }
            else
                 name = line.Trim().Substring(0, line.IndexOf(" "));

           
            newPicture = SetHeadPicture(newPicture, name);
            return newPicture;
        }
        private Label SetupLabel (int width,string line, int charactersToNewLine,Panel newPanel)
        {
            Label newLine = new Label();
            
            var lineWithSpaces = SplitToLower(line, charactersToNewLine);
            newLine.Text = lineWithSpaces;
            newLine.Width = width;

            
   
            SizeF MessageSize = newLine.CreateGraphics()
                            .MeasureString(newLine.Text,
                                            newLine.Font,
                                            newLine.Width,
                                            new StringFormat(0));

            if (line.Length > 60)
            {
                float multiplier = (float)(1 +(((line.Length / 60) + 1.5)/10));
                newLine.Height = (int)(MessageSize.Height * multiplier);
              
            }
            else
            {
                newLine.Height = (int)MessageSize.Height;
            }


            newPanel.Height = newLine.Height * 2;

            newPanel.MinimumSize = new Size(500, 50);
            Console.WriteLine($"Having Height at {newPanel.Height}");
            newLine.BorderStyle = BorderStyle.None;
            newLine.BackColor = Color.Transparent;
            newLine.ForeColor = Color.White;
            newLine.Location = new Point(50, (int)(newPanel.Height*0.3));
            lastY += spacing*3 + newPanel.Height;

            InitCustomLabelFont(newLine);
            newPanel.Controls.Add(newLine);

            return newLine;
        }
        private PictureBox SetHeadPicture(PictureBox pictureBox, String name)
        {
            if (nickNames.ContainsKey(name) || nickNames.ContainsValue(name)) {
                string charName = "";
                var u = imageList1.Images.Count;
                nickNames.TryGetValue(name, out charName);
                try
                {
                    if (charName != null)
                        pictureBox.Image = imageList1.Images[imageList1.Images.IndexOfKey(folderName + "\\" + charName + ".png")];
                    else
                        pictureBox.Image = imageList1.Images[imageList1.Images.IndexOfKey(folderName + "\\" + name + ".png")];

                }

                catch
                {
                    pictureBox.Image = Properties.Resources.steave_head;
                }
            } 
            else
            {
                pictureBox.Image = Properties.Resources.steave_head;
            }
            if (name  == "Root_Of_Tree")
            {
                pictureBox.Image = imageList1.Images[imageList1.Images.IndexOfKey(folderName + "\\" + "Рут" + ".png")];

            }


            pictureBox1.Image = pictureBox.Image;
            return pictureBox;
        }
        private string SplitToLower(string str, int n)
        {
            //return Regex.Replace(str, ".{" + n + "}(?!$)", "$0-\n");
            

            for(int i = 1; i < str.Length; i++)
            {
                var currentChar = str[i];
                if (i % n!= 0)
                    continue;
                var tempo = str.ToCharArray();
                var tempStr = new List<string>();
                foreach(var chara in tempo)
                {
                    tempStr.Add(chara.ToString());
                }
                 //tempStr = str.Split();

                for (int m = i;m>0 ; m--) {

                    if (tempStr[m] != " ")
                        continue;

                    tempStr[m] = "\r";
                    str = string.Join("", tempStr);
                    break;
                }
            }
            return str;
        }

        private void SaveAsImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            sf.ShowDialog();
            var path = sf.FileName;
            if (path == "")
                return;

            int width = mainPanel.Size.Width;
            int height = mainPanel.Size.Height;

            Bitmap bm = new Bitmap(width, height);
            mainPanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            bm.Save(path, ImageFormat.Bmp);

        }


        private void reloadBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            LoadPictures(folderName);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
