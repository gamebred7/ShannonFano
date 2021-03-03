using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShannonFano
{
    public partial class ShannonFano : Form
    {
        private OpenFileDialog openFileDialog1; //открытие файла
        int N; //число символов
        public List<symbol> Alf; //алфавит
        char[] messfile;

        public class Tree<T>
        {
            public int weight = 0;
            public Tree<T> Left, Right;
            public T leave = default(T);
            public Tree<T> parent;
        }

        Tree<symbol> tree;

        /// <summary>
        /// Класс, содержащий байт, вероятность его встречи и его код
        /// </summary>
        public class symbol
        {
            public char ch; //символ
            public int probability = 0; //вероятность
            public string code = "";
            public List<Byte> byteList = new List<Byte>();
            public BitArray[] bitArray = new BitArray[8];
        }

        public ShannonFano()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Выбор файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                Opening();
            }
        }

        private void button1_Click(object sender, EventArgs e) //открытие файла
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                Opening();
            }
        }

        void Opening()
        {
            Alf = new List<symbol>();
            System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
            N = Convert.ToInt32(sr.BaseStream.Length); //получение числа символов в файле                                                          
            sr.BaseStream.Position = 0;
            messfile = new char[N];
            label3.Text = "";
            for (int i = 0; i < N; i++)
            {
                messfile[i] = Convert.ToChar(sr.Read());
                label3.Text += messfile[i];
                if (Alf.Count == 0)
                {
                    symbol c = new symbol();
                    c.ch = messfile[i];
                    c.code = null;
                    c.probability = 1;
                    Alf.Add(c);
                }
                else
                {
                    bool done = false;
                    for (int j = 0; j < Alf.Count; j++)
                    {

                        if (!done)
                        {
                            if (Alf[j].ch == messfile[i])
                            {
                                Alf[j].probability++;
                                done = true;
                            }
                            else
                            if (j == Alf.Count - 1)
                            {
                                symbol c = new symbol();
                                c.ch = messfile[i];
                                c.code = null;
                                c.probability = 1;
                                Alf.Add(c);
                                done = true;
                            }
                        }
                    }
                }
            }

            sr.Close();
            Sort();

        }

        public class NameComparer : IComparer<symbol>
        {
            public int Compare(symbol s1, symbol s2)
            {
                if (s1.probability > s2.probability)
                {
                    return -1;
                }
                else if (s1.probability < s2.probability)
                {
                    return 1;
                }

                return 0;
            }
        }
        void Sort()
        {
            NameComparer cn = new NameComparer();
            Alf.Sort(cn);
            CreateTree();
            Packing();
            Decoder();
        }

        void CreateTree()
        {
            tree = new Tree<symbol>();

            int sum = 0;
            for (int i = 0; i < Alf.Count; i++)
            {
                sum += Alf[i].probability;
            }
            tree.weight = sum;
            tree.parent = null;
            BuildingTree(0, Alf.Count - 1, sum, tree);
        }

        void BuildingTree(int LeftIndex, int RightIndex, int sum, Tree<symbol> node)
        {
            int LeftBorder = LeftIndex;
            int RightBorder = RightIndex;
            int sumL = Alf[LeftIndex].probability;
            int sumR = sum - Alf[LeftIndex].probability;

            for (int LeftInd = LeftIndex + 1; (LeftInd < Alf.Count) && (sumL + Alf[LeftInd].probability <= sumR - Alf[LeftInd].probability); LeftInd++)
            {
                sumL += Alf[LeftInd].probability;
                sumR -= Alf[LeftInd].probability;

                LeftIndex++;
            }
            Tree<symbol> node1 = new Tree<symbol>();
            node1.weight = sumL;
            Console.WriteLine("SumL - " + sumL);
            Tree<symbol> node2 = new Tree<symbol>();
            node2.weight = sumR;
            Console.WriteLine("SumR - " + sumR);
            node.Left = node1;
            node.Right = node2;
            node1.parent = node;
            node2.parent = node;
            if (LeftIndex < Alf.Count && RightBorder < Alf.Count)
            {
                if (sumL > 0)
                    if (LeftIndex - LeftBorder == 0) //if consists of one element
                    {
                        node1.leave = Alf[LeftBorder];
                        node1.leave.code += "0";
                        node1.leave.byteList.Add(0);
                        Console.WriteLine("leave L - " + node1.leave.ch + " " + node1.leave.code + " byte " + Encoding.ASCII.GetString(node1.leave.byteList.ToArray()));
                    }
                    else
                    {
                        Console.WriteLine("Recursion L -");
                        for (int i = LeftBorder; i <= LeftIndex; i++)
                        {
                            Alf[i].code += "0";
                            Alf[i].byteList.Add(0);
                        }
                        BuildingTree(LeftBorder, LeftIndex, sumL, node1);

                    }
                if (sumR > 0)
                    if (RightBorder - (LeftIndex + 1) == 0) //if consists of one element
                    {

                        node2.leave = Alf[RightBorder];
                        node2.leave.code += "1";
                        node2.leave.byteList.Add(1);
                        Console.WriteLine("Leave R - " + node2.leave.ch + " " + node2.leave.code + " byte " + Encoding.ASCII.GetString(node2.leave.byteList.ToArray()));
                    }
                    else
                    {
                        Console.WriteLine("Recursion R - ");
                        for (int i = LeftIndex + 1; i <= RightBorder; i++)
                        {
                            Alf[i].code += "1";
                            Alf[i].byteList.Add(1);
                        }
                        BuildingTree(LeftIndex + 1, RightBorder, sumR, node2);

                    }
            }
        }

        void Packing()
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "output.bin");
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    int b = 0;
                    int count = 0;
                    foreach (char c in messfile)
                    {

                        for (int i = 0; i < Alf.Count; i++)
                        {

                            if (c == Alf[i].ch)
                            {
                                for (int j = 0; j < Alf[i].code.Length; j++)
                                {
                                    b += Convert.ToInt32(Alf[i].code[j]) - 48;
                                    count++;
                                    if (count == 8)
                                    {
                                        byte k = Convert.ToByte(b % 256);
                                        fs.WriteByte(k);
                                        count = 0;
                                        b = 0;
                                    }
                                    else
                                    {
                                        b = Convert.ToInt32(b) << 1;
                                    }
                                }
                                break;
                            }


                        }

                    }
                    if (count != 0)
                    {
                        byte k = Convert.ToByte(b % 256);
                        fs.WriteByte(k);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void Decoder()
        {

            FileStream fs = new FileStream("output.bin", FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            byte b = 0;
            string str = "";
            int k;
            int count = 0;
            Tree<symbol> current = tree;

            while (str.Length < N)
            {
                if (count == 0)
                {
                    b = r.ReadByte();
                    count = 8;
                }


                count--;
                k = ((Convert.ToInt32(b)) >> count) & 1;
                if (k == 0)
                {
                    current = current.Left;
                }
                else current = current.Right;
                if (current.leave != null)
                {
                    str = str + Convert.ToString(current.leave.ch);
                    current = tree;
                }

            }

            StreamWriter SW = new StreamWriter(new FileStream("Dec.txt", FileMode.Create, FileAccess.Write));
            SW.Write(str);
            SW.Close();

        }
    }
}

