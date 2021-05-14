using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShannonFano
{
    public partial class ShannonFano : Form
    {
        public class Tree<T>
        {
            public int weight = 0;
            public Tree<T> Left, Right;
            public Tree<T> parent;
            public T leave = default(T);
        }

        // Класс, содержащий байт, вероятность его встречи и его код
        public class symbol
        {
            public byte sym; // Cимвол
            public int probability = 0; // Вероятность
            public string code = ""; // Код символа
        }

        private OpenFileDialog openFileDialog; // Открытие файла
        int N; // Число символов
        public List<symbol> Cfile; // Символы в файле
        int[] alphabet = new int[256]; // Алфавит
        Tree<symbol> tree;

        //string FileName; 

        Stopwatch stopWatch = new Stopwatch();

        public ShannonFano()
        {
            InitializeComponent();

            for (int i = 0; i < 256; i++)
                alphabet[i] = 0;
        }

        // Обработка события при выборе кодирования
        private void CoderButtonClick(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            coderTextBox.Text = "";
            decoderTextBox.Text = "";
            resultLabel.Text = "";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) // Открытие файла по кнопке
            {
                coderTextBox.Text = openFileDialog.FileName;
                Opening();
            }

            //FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
        }

        // Обработка события при выборе декодирования
        private void DecoderButtonClick(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            coderTextBox.Text = "";
            decoderTextBox.Text = "";
            resultLabel.Text = "";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                decoderTextBox.Text = openFileDialog.FileName;

            Decoding(openFileDialog.FileName);
        }

        // Считывание файла и заполнение алфавита
        void Opening()
        {
            stopWatch.Start();      //начало отсчета времени выполнения
            Thread.Sleep(10000);
            Cfile = new List<symbol>();

            // Получение файла для кодирования
            System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open)); 
            N = Convert.ToInt32(binaryReader.BaseStream.Length); // Число символов в файле для кодирования 

            long length = new System.IO.FileInfo(openFileDialog.FileName).Length / 1024;      //вычисление размера стартового файла
            startsize.Text = Convert.ToString(length) + " КБ";        

            binaryReader.BaseStream.Position = 0;
            byte buf;

            for (int i = 0; i < N; i++)
            {
                buf = binaryReader.ReadByte();
                alphabet[(int)buf]++;

                if (Cfile.Count == 0)
                {
                    symbol c = new symbol();

                    c.sym = buf;
                    c.code = "";
                    c.probability = 1;
                    Cfile.Add(c);
                }
                else
                {
                    bool isAlphabetUpdated = false; // Если алфавит был обновлен

                    for (int j = 0; j < Cfile.Count; j++) // Получение алфавита
                    {
                        if (!isAlphabetUpdated)
                        {
                            if (Cfile[j].sym == buf) // Если символ существует в алфавите, увеличиваем вероятность на 1
                            {
                                Cfile[j].probability++;
                                isAlphabetUpdated = true;
                            }
                            else if (j == Cfile.Count - 1) // Если символа нет, то добавляем его в алфавит
                            {
                                symbol c = new symbol();
                                c.sym = buf;
                                c.code = null;
                                c.probability = 1;
                                Cfile.Add(c);

                                isAlphabetUpdated = true;
                            }
                        }
                    }
                }
            }
            progressBar1.Maximum = N * 2;
            binaryReader.Close();
            SortAlphabetByFrequency();
            Coding();
            progressBar1.Value = 0;
        }

        // Функция сравнения алфавита по частоте
        public class ComparisonByFrequency : IComparer<symbol>
        {
            public int Compare(symbol firstSymbol, symbol secondSymbol)
            {
                if (firstSymbol.probability > secondSymbol.probability)
                    return -1; // Меньше
                else if (firstSymbol.probability < secondSymbol.probability)
                    return 1;  // Больше
                else 
                    return 0;  // Равно
            }
        }

        // Функция сравнения алфавита по байту
        public class ComparisonByByte : IComparer<symbol>
        {
            public int Compare(symbol firstSymbol, symbol secondSymbol)
            {
                if (firstSymbol.sym > secondSymbol.sym)
                    return 1;  // Больше
                else if (firstSymbol.sym < secondSymbol.sym)
                    return -1; // Меньше
                else 
                    return 0;  // Равно
            }
        }

        // Сортировка алфавита по частоте
        void SortAlphabetByFrequency()
        {
            ComparisonByByte comparisonByByte = new ComparisonByByte();
            Cfile.Sort(comparisonByByte);

            ComparisonByFrequency comparisonByFrequency = new ComparisonByFrequency();
            Cfile.Sort(comparisonByFrequency);

            CreateTree();
        }

        // Cоздание дерева и его корня
        void CreateTree()
        {
            tree = new Tree<symbol>();
            int sum = 0;

            for (int i = 0; i < Cfile.Count; i++)
            {
                sum += Cfile[i].probability; // Подсчет суммы вероятностей всех символов
            }

            tree.weight = sum;
            tree.parent = null;

            BuildTree(0, Cfile.Count - 1, sum, tree);
        }

        // Построение дерева рекурсивно
        void BuildTree(int LeftIndex, int RightIndex, int sum, Tree<symbol> node) // index Left, Right, Sum of all elements, parent
        {
            int LeftBorder = LeftIndex;
            int RightBorder = RightIndex;
            int sumLeft = Cfile[LeftIndex].probability;
            int sumRight = sum - Cfile[LeftIndex].probability; // int sumR = sum - sumL;

            for (int li = LeftIndex + 1; (li < Cfile.Count) && (sumLeft + Cfile[li].probability <= sumRight - Cfile[li].probability); li++) //пока сумма вероятностей левого и правого поддерева не сойдется
            {
                sumLeft += Cfile[li].probability;
                sumRight -= Cfile[li].probability;

                LeftIndex++;
            }

            Tree<symbol> firstNode = new Tree<symbol>(); // Создание левого поддерева
            firstNode.weight = sumLeft;

            Tree<symbol> secondNode = new Tree<symbol>(); // Создание правого дерева
            secondNode.weight = sumRight;

            node.Left = firstNode;
            node.Right = secondNode;

            firstNode.parent = node;
            secondNode.parent = node;

            if (LeftIndex < Cfile.Count && RightBorder < Cfile.Count)
            {
                if (sumLeft > 0)
                    if (LeftIndex - LeftBorder == 0) // Если в поддереве содержиться один элемент
                    {
                        firstNode.leave = Cfile[LeftBorder];
                        firstNode.leave.code += "0";
                        progressBar1.Value++;
                    }
                    else
                    {
                        for (int i = LeftBorder; i <= LeftIndex; i++)
                        {
                            Cfile[i].code += "0";
                        }

                        BuildTree(LeftBorder, LeftIndex, sumLeft, firstNode); // Рекурсивно создаем коды для оставшихся символов
                    }

                if (sumRight > 0)
                    if (RightBorder - (LeftIndex + 1) == 0) // Если в поддереве содержиться один элемент
                    {
                        secondNode.leave = Cfile[RightBorder];
                        secondNode.leave.code += "1";
                        progressBar1.Value++;
                    }
                    else // Если в поддереве больше одного элемента
                    {
                        for (int i = LeftIndex + 1; i <= RightBorder; i++)
                        {
                            Cfile[i].code += "1";
                        }

                        BuildTree(LeftIndex + 1, RightBorder, sumRight, secondNode); // Рекурсивно создаем коды для оставшихся символов
                    }
            }
        }

        // Кодер
        void Coding()
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, openFileDialog.FileName + ".bin");
            //string path = System.IO.Path.Combine(Environment.CurrentDirectory, "coder.bin");

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open));

                N = Convert.ToInt32(binaryReader.BaseStream.Length);
                binaryReader.BaseStream.Position = 0;

                using (FileStream fileStream = File.Create(path)) // Создание файла
                {
                    // Длина входного потока
                    byte[] bytes = BitConverter.GetBytes(N);
                    fileStream.Write(bytes, 0, bytes.Length);

                    // Модель кодирования
                    for (int i = 0; i < 256; i++)
                    {
                        bytes = BitConverter.GetBytes(alphabet[i]);
                        fileStream.Write(bytes, 0, bytes.Length);
                    }

                    int b = 0;
                    int count = 0;

                    for (int t = 0; t < N; t++)
                    {
                        progressBar1.Value++;
                        byte buf = binaryReader.ReadByte();

                        for (int i = 0; i < Cfile.Count; i++)
                        {
                            if (buf == Cfile[i].sym)
                            {
                                for (int j = 0; j < Cfile[i].code.Length; j++)   // Длина кода
                                {
                                    b += Convert.ToInt32(Cfile[i].code[j]) - 48;
                                    count++;

                                    if (count == 8)
                                    {
                                        byte k = Convert.ToByte(b % 256);
                                        fileStream.WriteByte(k);
                                        count = 0;
                                        b = 0;
                                    }
                                    else
                                        b = Convert.ToInt32(b) << 1; // Преобразование кода переменной длины
                                }
                                break;
                            }
                        }
                    }

                    if (count != 0)
                    {
                        byte k = Convert.ToByte(b % 256);
                        fileStream.WriteByte(k);
                    }
                }
                double length = new System.IO.FileInfo(openFileDialog.FileName).Length / 1024;

                double endlength = new System.IO.FileInfo(openFileDialog.FileName + ".bin").Length / 1024;
                endfilesize.Text = Convert.ToString(endlength) + " КБ";


                double proc = ((length - endlength) / length) * 100;
                procent.Text = Convert.ToString(proc) + "%";

                stopWatch.Stop();
                var resultTime = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                        resultTime.Hours,
                        resultTime.Minutes,
                        resultTime.Seconds);
                timelabel.Text = elapsedTime;

                binaryReader.Close();

                resultLabel.Text = "Файл успешно закодирован!";
                Task.Delay(2000);
                progressBar1.Value = 0;
            } catch (Exception exeption) {
                Console.WriteLine(exeption.ToString());
            }
            
        }

        // Декодер
        void Decoding(string name)
        {
            FileStream fileStream = new FileStream(name, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            int k;
            byte b = 0;
            int count = 0;

            int per;
            N = binaryReader.ReadInt32();
            progressBar1.Maximum = N;

            Cfile = new List<symbol>();

            for (int i = 0; i < 256; i++)
            {
                    per = binaryReader.ReadInt32();
                    if (per != 0)
                    {
                        symbol c = new symbol();
                        c.sym = (byte)i;
                        c.probability = per;
                        Cfile.Add(c);
                    }
            }

            tree = null;

            SortAlphabetByFrequency();

            Tree<symbol> current = tree;
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory,"decoder.bin");
            var filePathName = name.Substring(0, name.Length - 4);
            //string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, filePathName);

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                int g = 0;
                progressBar1.Value = 0;
                using (FileStream stream = File.Create(filePath))
                {
                    while (g < N)
                    {
                        if (count == 0)
                        {
                            b = binaryReader.ReadByte();
                            count = 8;
                        }

                        count--;
                        k = ((Convert.ToInt32(b)) >> count) & 1;

                        if (k == 0) // В левое поддерево
                            current = current.Left;
                        else
                            current = current.Right;

                        if (current.leave != null)
                        {
                            stream.WriteByte(current.leave.sym);
                            current = tree;
                            g++;
                            progressBar1.Value = N;
                        }
                    }                    
                }

                var oldname = Environment.CurrentDirectory + "\\decoder.bin";
                var newname = filePathName;
                if (File.Exists(newname))
                {
                    File.Delete(newname);
                }
                System.IO.File.Move(oldname, newname);

                resultLabel.Text = "Файл успешно декодирован!";
                Task.Delay(2000);
                progressBar1.Value = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}


