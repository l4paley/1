using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {




        private readonly string TemplateFileName = @"E:\reportyes.doc";
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public double m;
         public double n;
           public double CoefX;
           public double GDK = 0;
            

        
        private void button1_Click(object sender, EventArgs e)
{

    double Stratification = 0; //A
    if (comboBox3.Text == "250")
    {
        Stratification = 250;
    }
    if (comboBox3.Text == "200")
    {
        Stratification = 200;
    }
    if (comboBox3.Text == "180")
    {
        Stratification = 180;
    }
    if (comboBox3.Text == "160")
    {
        Stratification = 160;
    }
    //textBox1.Text = comboBox3.Text;
    //textBox1.Text = comboBox3.SelectedItem.ToString();
    double MassChemicalAgent = Convert.ToDouble(textBox2.Text); //M
    double Subsidence = 0; //F
    if (comboBox4.Text == "3")
    {
        Stratification = 3;
    }
    if (comboBox4.Text == "2.5")
    {
        Stratification = 2.5;
    }
    if (comboBox4.Text == "2")
    {
        Stratification = 2;
    }
    if (comboBox4.Text == "1")
    {
        Stratification = 1;
    }
    //textBox3.Text = comboBox4.Text;
    double Relief = Convert.ToDouble(textBox4.Text); //nn
    double Highest = Convert.ToDouble(textBox5.Text); //H
    double Speed = Convert.ToDouble(textBox6.Text); //D 
    double Diameter = Convert.ToDouble(textBox7.Text); //W0
    double TemperatureMax = Convert.ToDouble(textBox8.Text); //dT
    double TemperatureCurrent = Convert.ToDouble(textBox9.Text); //Th
    double Temperature = TemperatureMax - TemperatureCurrent;

    double V1 = 3.14 * Diameter * Diameter * Speed / 4; // Первые 4 формулы просчитывают основные значения для последующих формул
    textBox12.Text = Convert.ToString(V1);
    double f = (1000 * Speed * Speed * Diameter) / ((Highest * Highest) * Temperature);
    double Kf = Math.Sqrt(f); //double Kf = pow(f, 1.0 / 2.0);
    double KKf = Math.Pow(f, 1.0 / 3.0); //double KKf = pow(f, 1.0 / 3.0);
    double dTV1H = (Temperature * V1) / Highest;
    double KKdTV1H = Math.Pow(dTV1H, 1.0 / 3.0); // «----
    double Vm = 0.65 * KKdTV1H;
    double V1m = (1.3 * Speed * Diameter) / Highest;
    double fe = V1m * V1m * V1m * 800;
    double dTV1 = Temperature * V1;
    double KKdTV1 = Math.Pow(dTV1, 1.0 / 3.0);
    double KVm = Math.Sqrt(Vm); //double KVm = pow(Vm, 1.0 / 2.0);
    double KV1m = Math.Sqrt(V1m); // double KV1m = pow(V1m, 1.0 / 2.0); // Последуйщие 10 формул вычисляют другорядные значения для просчета основной формулы Cm



    if (f < 100)
    {
        m = 1 / (0.67 + 0.1 * Kf + 0.34 * KKf);
    }
    else
    {
        m = 1.47 * KKf;
    }
    if ((Vm >= 0.5) & (Vm <= 2))    // ((Vm >= 0.5) & (Vm <= 2))
    {
        CoefX = 0.532 * (Vm * Vm) - 2.13 * Vm + 3.13;
    }
    else
    {
        CoefX = 4.4 * Vm;
    }
    if (f < 100)
    {
        CoefX = n;
    }
    else
    {
        n = 1;
    }

    double MN = m * n;
    
    double Cm = (Stratification * MassChemicalAgent * MN * Subsidence + Relief) / (Highest * Highest * KKdTV1); // Основная формула,за которой будет вычисляться,загрязнена ли атмосфера в данной точек или нет
    double Xm = Highest * (5 - Subsidence) / 4;
    textBox21.Text = Convert.ToString(Xm);
    if (comboBox1.Text == "Оксид Нитрогена" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.085;
    }
    else if (comboBox1.Text == "Оксид Нитрогена" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.085;
    }
    if (comboBox1.Text == "Амиак" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.2;
    }
    if (comboBox1.Text == "Амиак" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.2;
    }
    if (comboBox1.Text == "Ацетон" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.35;
    }
    if (comboBox1.Text == "Ацетон" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.35;
    }
    if (comboBox1.Text == "Бензин" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 5.0;
    }
    if (comboBox1.Text == "Бензин" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 1.5;
    }
    if (comboBox1.Text == "Бензпирен" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0;
    }
    if (comboBox1.Text == "Бензпирен" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.1;
    }
    if (comboBox1.Text == "Бутиловый спирт" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.1;
    }
    if (comboBox1.Text == "Бутиловый спирт" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.1;
    }
    if (comboBox1.Text == "Оксид Ванадия" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0;
    }
    if (comboBox1.Text == "Оксид Ванадия" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.002;
    }
    if (comboBox1.Text == "Дихлоретан" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 3;
    }
    if (comboBox1.Text == "Дихлоретан" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 1;
    }
    if (comboBox1.Text == "Метанол" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 1;
    }
    if (comboBox1.Text == "Метанол" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 1;
    }
    if (comboBox1.Text == "Нитробензол" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.008;
    }
    if (comboBox1.Text == "Нитробензол" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.5;
    }
    if (comboBox1.Text == "Ртуть металическая" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0;
    }
    if (comboBox1.Text == "Ртуть металическая" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.008;
    }
    if (comboBox1.Text == "Сажа" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.15;
    }
    if (comboBox1.Text == "Сажа" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.0003;
    }
    if (comboBox1.Text == "Свинец" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0;
    }
    if (comboBox1.Text == "Свинец" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.05;
    }
    if (comboBox1.Text == "Серчастый андигрид" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.5;
    }
    if (comboBox1.Text == "Серчастый андигрид" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.0007;
    }
    if (comboBox1.Text == "Гидрогенсульфит" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.008;
    }
    if (comboBox1.Text == "Гидрогенсульфит" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.05;
    }
    if (comboBox1.Text == "Карбондисульфит" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.03;
    }
    if (comboBox1.Text == "Карбондисульфит" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.008;
    }
    if (comboBox1.Text == "Цианидная кислота" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0;
    }
    if (comboBox1.Text == "Цианидная кислота" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.005;
    }
    if (comboBox1.Text == "Хлор.кислота" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.2;
    }
    if (comboBox1.Text == "Хлор.кислота" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.01;
    }
    if (comboBox1.Text == "Оксид карбона" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 3;
    }
    if (comboBox1.Text == "Оксид карбона" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.2;
    }
    if (comboBox1.Text == "Фенол" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.01;
    }
    if (comboBox1.Text == "Фенол" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 1;
    }
    if (comboBox1.Text == "Хром" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 0.0015;
    }
    if (comboBox1.Text == "Хром" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.01;
    }
    if (comboBox1.Text == "Эталон" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 5;
    }
    if (comboBox1.Text == "Эталон" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 0.0015;
    }
    if (comboBox1.Text == "Этилен" && comboBox2.Text == "Максимально разовая")
    {
        GDK = 3;
    }
    if (comboBox1.Text == "Этилен" && comboBox2.Text == "Среднесуточная")
    {
        GDK = 3;
    }
    textBox13.Text = Convert.ToString(Cm);
    textBox14.Text = Convert.ToString(GDK);
    double CmvsGDK = Cm - GDK;
    if (GDK < Cm)
    {
        richTextBox1.Text = "Викид шкідливих газів з одиночного точкового джерела з круглим гирлом дорівнює :" + Cm + "мг/м" + "\nСанітарно Захисна Зона вашого підприємства є рівною :" + Xm + "м".ToString();
        
      //  richTextBox1.Text = " :" + Cm.ToString();
        //Xm = Alpha * H * (5 - F) / 4;
    }
    else
    {
        richTextBox1.Text = "Шановний, під вами атмосфера в нормі і дорівнює:" + Cm + "мг/м" + "\nСанітарно Захисна Зона вашого підприємства є рівною :" + Xm + "м".ToString();
    }
}

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void saveInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            /*System.IO.StreamWriter textFile = new System.IO.StreamWriter(@"E:\textfile.txt");
            textFile.WriteLine(richTextBox1);
            textFile.Close();*/
            //Test of StreamWriter
            using (StreamReader Reader = new StreamReader(@"C:\SavedInform.txt")) 
            {
                while (!Reader.EndOfStream) 
                {
                    //============================================================
                    string buff = Reader.ReadLine();
                    if (buff.IndexOf(" ") != -1)
                        textBox1.AppendText(buff.Substring(0, buff.IndexOf(" ")));
                    else
                        textBox1.AppendText(buff);
                    //============================================================
                    string buff2 = Reader.ReadLine();
                    if (buff2.IndexOf(" ") != -1)
                        textBox2.AppendText(buff2.Substring(0, buff2.IndexOf(" ")));
                    else
                        textBox2.AppendText(buff2);
                    //============================================================
                    string buff3 = Reader.ReadLine();
                    if (buff3.IndexOf(" ") != -1)
                        textBox3.AppendText(buff3.Substring(0, buff3.IndexOf(" ")));
                    else
                        textBox3.AppendText(buff3);
                    //============================================================
                    string buff4 = Reader.ReadLine();
                    if (buff4.IndexOf(" ") != -1)
                        textBox4.AppendText(buff4.Substring(0, buff4.IndexOf(" ")));
                    else
                        textBox4.AppendText(buff4);
                    //============================================================
                    string buff5 = Reader.ReadLine();
                    if (buff5.IndexOf(" ") != -1)
                        textBox5.AppendText(buff5.Substring(0, buff5.IndexOf(" ")));
                    else
                        textBox5.AppendText(buff5);
                    //============================================================
                    string buff6 = Reader.ReadLine();
                    if (buff6.IndexOf(" ") != -1)
                        textBox6.AppendText(buff6.Substring(0, buff6.IndexOf(" ")));
                    else
                        textBox6.AppendText(buff6);
                    //============================================================
                    string buff7 = Reader.ReadLine();
                    if (buff7.IndexOf(" ") != -1)
                        textBox7.AppendText(buff7.Substring(0, buff7.IndexOf(" ")));
                    else
                        textBox7.AppendText(buff7);
                    //============================================================
                    string buff8 = Reader.ReadLine();
                    if (buff8.IndexOf(" ") != -1)
                        textBox8.AppendText(buff8.Substring(0, buff8.IndexOf(" ")));
                    else
                        textBox8.AppendText(buff8);
                    //============================================================
                    string buff9 = Reader.ReadLine();
                    if (buff9.IndexOf(" ") != -1)
                        textBox9.AppendText(buff9.Substring(0, buff9.IndexOf(" ")));
                    else
                        textBox9.AppendText(buff9);
                    //============================================================
                    //richTextBox1.AppendText(Reader.ReadLine());
                    //textBox1.AppendText(Reader.ReadLine());
                    //textBox2.AppendText(Reader.ReadLine());
                    //textBox3.AppendText(Reader.ReadLine());
                    //textBox4.AppendText(Reader.ReadLine());
                    //textBox5.AppendText(Reader.ReadLine());
                    //textBox6.AppendText(Reader.ReadLine());
                    //textBox7.AppendText(Reader.ReadLine());
                    //textBox8.AppendText(Reader.ReadLine());
                    //textBox9.AppendText(Reader.ReadLine());

                }
                
            }


        }

        private void typeInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter Writer = new StreamWriter(@"C:\SavedInform.txt", false)) 
            {

                //Writer.WriteLine(richTextBox1.Text);
                Writer.WriteLine(textBox1.Text + " - Stratification");
                Writer.WriteLine(textBox2.Text + " - MassChemicalAgent");
                Writer.WriteLine(textBox3.Text + " - Subsidence");
                Writer.WriteLine(textBox4.Text + " - Relief");
                Writer.WriteLine(textBox5.Text + " - Highest");
                Writer.WriteLine(textBox6.Text + " - Speed");
                Writer.WriteLine(textBox7.Text + " - Diameter");
                Writer.WriteLine(textBox8.Text + " - TemperatureMax");
                Writer.WriteLine(textBox9.Text + " - TemperatureCurrent");
            
            }

        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
        }

        private void aboutMyselfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello,My name is Olexander Lakhman and its my DUPLOMNAROBOTA","About Myself");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          /*  try
            {
                int L = 40;
                double Value = Convert.ToDouble(textBox5.Text);
            }
            catch 
            {
                MessageBox.Show("U'r need to change dat value", "The biggest mistake in your life");
            }
           // if (Value < L)*/
                
            

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
t.SetToolTip(textBox1, "Vasia,eto pervaya peremennaya");
/*ToolTip t2 = new ToolTip();
t2.SetToolTip(textBox2, "Vasia,eto vtoraya peremennaya");
ToolTip t3 = new ToolTip();
t3.SetToolTip(textBox3, "Vasia,eto tretya peremennaya");
ToolTip t4 = new ToolTip();
t4.SetToolTip(textBox4, "Vasia,eto chetvertaya peremennaya");
ToolTip t5 = new ToolTip();
t5.SetToolTip(textBox5, "Vasia,eto pyataya peremennaya");
ToolTip t6 = new ToolTip();
t6.SetToolTip(textBox6, "Vasia,eto shestaya peremennaya");
ToolTip t7 = new ToolTip();
t7.SetToolTip(textBox7, "Vasia,eto sedmaya peremennaya");
ToolTip t8 = new ToolTip();
t8.SetToolTip(textBox8, "Vasia,eto vosmaya peremennaya");
ToolTip t9 = new ToolTip();
t9.SetToolTip(textBox9, "Vasia,eto deviataya peremennaya");*/
        }

        public void changeTheDayOfTheCompassRoseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.textBox10.Text = f2.Data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double StratificationNew = Convert.ToDouble(textBox1.Text); //A
            double MassChemicalAgentNew = Convert.ToDouble(textBox2.Text); //M
            double SubsidenceNew = Convert.ToDouble(textBox3.Text); //F
            double DiameterNew = Convert.ToDouble(textBox7.Text); //W0
            double ReliefNew = Convert.ToDouble(textBox4.Text); //nn
            double HighestNew = Convert.ToDouble(textBox5.Text);
            double TemperatureMaxNew = Convert.ToDouble(textBox8.Text); //dT
            double TemperatureCurrentNew = Convert.ToDouble(textBox9.Text); //Th
            double V1New = Convert.ToDouble(textBox12.Text);
            double CmNew = Convert.ToDouble(textBox13.Text);
            double GDKNew = Convert.ToDouble(textBox14.Text);
           // richTextBox2.Text = StratificationNew + " " + MassChemicalAgentNew + " " + SubsidenceNew + " " + DiameterNew + " " + ReliefNew + " " + V1New + " " + CmNew + " " + GDKNew.ToString();
            
            

            // Minimize H ===========================================
            double MinH = 0;
            double DifferenceH = 0;
            double TemperatureNew = TemperatureMaxNew - TemperatureCurrentNew;
            if (V1New >= 2)
            {
                MinH = (StratificationNew * MassChemicalAgentNew * SubsidenceNew * DiameterNew * ReliefNew) / (8 * V1New * CmNew - GDKNew);
                DifferenceH = HighestNew / MinH;
            }
            else
            {
                MinH = 40;
            }
            // Minimize D ===========================================
            double MinD = 1.4;
            double DifferenceD = DiameterNew / MinD;
            // Minimize M ===========================================
            double MinM = GDK;
            double DifferenceM = MassChemicalAgentNew / GDK;
            // Minimize T  ==========================================
            double MinT = 80;
            double DifferenceT = TemperatureNew / MinT;
            if (checkBox1.Checked) 
            {
                richTextBox2.AppendText("Ваша нормована висота труби становить : " + MinH + " м " + "\nВаша різниця висоти труби становить : " + DifferenceH + " м ");
            }
            if (checkBox2.Checked)
            {
                richTextBox2.AppendText("\nВаш нормований діаметр труби становить : " + MinD + " м " + "\nВаша різниця діаметрів труби становить : " + DifferenceD + " м ");
            }
            if (checkBox3.Checked)
            {
                richTextBox2.AppendText("\nВаша нормована маса речовини становить : " + MinM + " м " + "\nВаша різниця мас речовин становить : " + DifferenceM + " м ");
            }
            if (checkBox4.Checked)
            {
                richTextBox2.AppendText("\nВаша нормована температура становить : " + MinT + " м " + "\nВаша різниця температур становить : " + DifferenceT + " м ");
            }
            textBox17.Text = Convert.ToString(MinH);
            textBox18.Text = Convert.ToString(MinD);
            textBox19.Text = Convert.ToString(MinM);
            textBox20.Text = Convert.ToString(MinT);

        }

        private void graphFormalizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            //this.textBox10.Text = f2.Data;
        }

        private void exportIntoWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           double RepGDK = Convert.ToDouble(textBox14.Text);
           double RepCm = Convert.ToDouble(textBox13.Text);

            
                var ReportA = Convert.ToString(textBox1.Text);
                var ReportM = Convert.ToString(textBox2.Text);
                var ReportF = Convert.ToString(textBox3.Text);
                var ReportH = Convert.ToString(textBox5.Text);
                var Reportnn = Convert.ToString(textBox4.Text);
                var ReportT = Convert.ToString(textBox8.Text);
                var ReportD = Convert.ToString(textBox7.Text);
                var ReportGDK = Convert.ToString(textBox14.Text);
                var comboBox3Item = Convert.ToString(textBox16.Text);
                var ReportMinH = Convert.ToString(textBox17.Text);
                var ReportMinD = Convert.ToString(textBox18.Text);
                var ReportMinM = Convert.ToString(textBox19.Text);
                var ReportMinT = Convert.ToString(textBox20.Text);
                var ReportXm = Convert.ToString(textBox21.Text);

                var wordApp = new Word.Application();
                wordApp.Visible = false;
               // try
               // {
                    var wordDocument = wordApp.Documents.Open(TemplateFileName);
                    ReplaceWordStub("{ReportA}", ReportA, wordDocument);
                    ReplaceWordStub("{ReportM}", ReportM, wordDocument);
                    ReplaceWordStub("{ReportF}", ReportF, wordDocument);
                    ReplaceWordStub("{ReportH}", ReportH, wordDocument);
                    ReplaceWordStub("{Reportnn}", Reportnn, wordDocument);
                    ReplaceWordStub("{ReportT}", ReportT, wordDocument);
                    ReplaceWordStub("{ReportD}", ReportD, wordDocument);
                    ReplaceWordStub("{ReportGDK}", ReportGDK, wordDocument);
                    ReplaceWordStub("{comboBox3Item}", comboBox3Item, wordDocument);
                    ReplaceWordStub("{comboBox3Item}", comboBox3Item, wordDocument);
                    ReplaceWordStub("{comboBox3Item}", comboBox3Item, wordDocument);
                    ReplaceWordStub("{ReportMinH}", ReportMinH, wordDocument);
                    ReplaceWordStub("{ReportMinD}", ReportMinD, wordDocument);
                    ReplaceWordStub("{ReportMinM}", ReportMinM, wordDocument);
                    ReplaceWordStub("{ReportMinT}", ReportMinT, wordDocument);
                    ReplaceWordStub("{ReportXm}", ReportXm, wordDocument);

                  //  if (RepGDK < RepCm)
                   // {
                        wordDocument.SaveAs(@"E:\result.doc");
                   // }
                   // else 
                   // {
                   //     wordDocument.SaveAs(@"E:\reportno.docx");
                    //}
                    
                        
                    
                    
                    wordApp.Visible = true;
                   // }
                  //  catch
                   // {
                  //  MessageBox.Show("Произошла ошибка");
                   // }
        
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument) 
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                textBox16.Text = string.Empty;
            }
            else
            {
                textBox16.Text = comboBox1.SelectedItem.ToString();
            } 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                textBox1.Text = string.Empty;
            }
            else
            {
                textBox1.Text = comboBox3.SelectedItem.ToString();
            } 
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == -1)
            {
                textBox3.Text = string.Empty;
            }
            else
            {
                textBox3.Text = comboBox4.SelectedItem.ToString();
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.textBox10.Text = f2.Data;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }


    }

}








        
      
       


