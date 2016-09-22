using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = 121;
            int size2 = 9;
            double [,] Array1 = new double[size+1, size2+1];
            //========================================================= ПРОВЕРКА ЗАБИВА МАССИВА В ЯЧЕЙКИ
           /* for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size2; j++)
                {
                    Array1[i,j] = i*j;
                }
            }
            int m = Convert.ToInt16(textBox2.Text); //M
            int n = Convert.ToInt16(textBox3.Text); //F
            int Text = Array1[m, n];
            textBox4.Text = Convert.ToString(Text);*/
            //========================================================= ПРОВЕРКА ЗАБИВА МАССИВА В ЯЧЕЙКИ
            int DateOf = Convert.ToInt16(textBox4.Text);
            int zzz;
            int zz;
            zz = 100;
            zzz = 20;
            if (DateOf == 1)
            {
                //for (int i = 0; i <= 8; i++)
                //{
                //    Array1[i, 0] = i+1;
                // }
                Array1[0, 0] = 6.3 * zzz + zz;
                Array1[0, 1] = 5.2 * zzz + zz;
                Array1[0, 2] = 3.2 * zzz + zz;
                Array1[0, 3] = 6.2 * zzz + zz;
                Array1[0, 4] = 7.7 * zzz + zz;
                Array1[0, 5] = 6.2 * zzz + zz;
                Array1[0, 6] = 9.2 * zzz + zz;
                Array1[0, 7] = 5.0 * zzz + zz;

            }
            if (DateOf == 2)
            {
                Array1[0, 0] = 5.9 * zzz + zz;
                Array1[0, 1] = 4.3 * zzz + zz;
                Array1[0, 2] = 3.3 * zzz + zz;
                Array1[0, 3] = 9.1 * zzz + zz;
                Array1[0, 4] = 8.3 * zzz + zz;
                Array1[0, 5] = 5.2 * zzz + zz;
                Array1[0, 6] = 7.5 * zzz + zz;
                Array1[0, 7] = 5.3 * zzz + zz;
            }
            if (DateOf == 3)
            {
                Array1[0, 0] = 7.3 * zzz + zz;
                Array1[0, 1] = 5.5 * zzz + zz;
                Array1[0, 2] = 3.3 * zzz + zz;
                Array1[0, 3] = 5.8 * zzz + zz;
                Array1[0, 4] = 6.2 * zzz + zz;
                Array1[0, 5] = 4.4 * zzz + zz;
                Array1[0, 6] = 10.0 * zzz + zz;
                Array1[0, 7] = 7.4 * zzz + zz;
            }
            if (DateOf == 4)
            {
                Array1[0, 0] = 9.4 * zzz + zz;
                Array1[0, 1] = 5.3 * zzz + zz;
                Array1[0, 2] = 3.1 * zzz + zz;
                Array1[0, 3] = 5.4 * zzz + zz;
                Array1[0, 4] = 7.7 * zzz + zz;
                Array1[0, 5] = 4.5 * zzz + zz;
                Array1[0, 6] = 7.9 * zzz + zz;
                Array1[0, 7] = 6.3 * zzz + zz;
            }
            if (DateOf == 5)
            {
                Array1[0, 0] = 8.8 * zzz + zz;
                Array1[0, 1] = 7.9 * zzz + zz;
                Array1[0, 2] = 2.9 * zzz + zz;
                Array1[0, 3] = 3.4 * zzz + zz;
                Array1[0, 4] = 8.6 * zzz + zz;
                Array1[0, 5] = 3.2 * zzz + zz;
                Array1[0, 6] = 6.0 * zzz + zz;
                Array1[0, 7] = 4.9 * zzz + zz;
            }
            if (DateOf == 6)
            {
                Array1[0, 0] = 10.2 * zzz + zz;
                Array1[0, 1] = 7.8 * zzz + zz;
                Array1[0, 2] = 3.3 * zzz + zz;
                Array1[0, 3] = 3.1 * zzz + zz;
                Array1[0, 4] = 6.3 * zzz + zz;
                Array1[0, 5] = 7.1 * zzz + zz;
                Array1[0, 6] = 7.1 * zzz + zz;
                Array1[0, 7] = 6.4 * zzz + zz;
            }
            if (DateOf == 7)
            {
                Array1[0, 0] = 7.8 * zzz + zz;
                Array1[0, 1] = 7.5 * zzz + zz;
                Array1[0, 2] = 3.9 * zzz + zz;
                Array1[0, 3] = 3.5 * zzz + zz;
                Array1[0, 4] = 4.7 * zzz + zz;
                Array1[0, 5] = 3.5 * zzz + zz;
                Array1[0, 6] = 7.4 * zzz + zz;
                Array1[0, 7] = 8.4 * zzz + zz;
            }
            if (DateOf == 8)
            {
                Array1[0, 0] = 8.4 * zzz + zz;
                Array1[0, 1] = 5.8 * zzz + zz;
                Array1[0, 2] = 2.6 * zzz + zz;
                Array1[0, 3] = 2.4 * zzz + zz;
                Array1[0, 4] = 7.0 * zzz + zz;
                Array1[0, 5] = 5.0 * zzz + zz;
                Array1[0, 6] = 6.3 * zzz + zz;
                Array1[0, 7] = 7.7 * zzz + zz;
            }
            if (DateOf == 9)
            {
                Array1[0, 0] = 7.7 * zzz + zz;
                Array1[0, 1] = 6.7 * zzz + zz;
                Array1[0, 2] = 3.6 * zzz + zz;
                Array1[0, 3] = 2.8 * zzz + zz;
                Array1[0, 4] = 6.3 * zzz + zz;
                Array1[0, 5] = 3.4 * zzz + zz;
                Array1[0, 6] = 7.6 * zzz + zz;
                Array1[0, 7] = 8.0 * zzz + zz;
            }
            if (DateOf == 10)
            {
                Array1[0, 0] = 4.8 * zzz + zz;
                Array1[0, 1] = 5.5 * zzz + zz;
                Array1[0, 2] = 2.5 * zzz + zz;
                Array1[0, 3] = 2.9 * zzz + zz;
                Array1[0, 4] = 7.5 * zzz + zz;
                Array1[0, 5] = 6.3 * zzz + zz;
                Array1[0, 6] = 7.4 * zzz + zz;
                Array1[0, 7] = 6.1 * zzz + zz;
            }
            if (DateOf == 11)
            {
                Array1[0, 0] = 2.9 * zzz + zz;
                Array1[0, 1] = 2.9 * zzz + zz;
                Array1[0, 2] = 2.2 * zzz + zz;
                Array1[0, 3] = 8.0 * zzz + zz;
                Array1[0, 4] = 9.7 * zzz + zz;
                Array1[0, 5] = 7.7 * zzz + zz;
                Array1[0, 6] = 8.6 * zzz + zz;
                Array1[0, 7] = 5.8 * zzz + zz;
            }
            if (DateOf == 12)
            {
                Array1[0, 0] = 7.1 * zzz + zz;
                Array1[0, 1] = 3.6 * zzz + zz;
                Array1[0, 2] = 17.9 * zzz + zz;
                Array1[0, 3] = 3.6 * zzz + zz;
                Array1[0, 4] = 1.8 * zzz + zz;
                Array1[0, 5] = 7.1 * zzz + zz;
                Array1[0, 6] = 0.1 * zzz + zz;
                Array1[0, 7] = 3.6 * zzz + zz;
            }
           /* double a = Convert.ToDouble(textBox1.Text); //A
            double b = Convert.ToDouble(textBox2.Text); //M
            double c = Convert.ToDouble(textBox3.Text); //F
            double d = Convert.ToDouble(textBox4.Text); //nn
            double ez = Convert.ToDouble(textBox5.Text); //H
            double f = Convert.ToDouble(textBox6.Text); //D 
            double g = Convert.ToDouble(textBox7.Text); //W0
            double h = Convert.ToDouble(textBox8.Text); //dT*/
            //int monthTimer = 0;
           // int yearTimer = 0;
           // int m = Convert.ToInt16(textBox2.Text);// количество строк
            //string n = textBox3.Text;// дата
            //int n = Convert.ToInt16(textBox3.Text);
            //var x = dataGridView1.Rows[m].Cells[n].Value.ToString();// Rows - строка. Cells - ячейка ( 
           // textBox1.Text = x;
           /* string data = dataGridView1.Rows[m].Cells[0].Value.ToString();
            for (int i = 0; i <= m; i++) 
            {
                if (data == n) 
                {
                    MessageBox.Show("Ваша вибрана дата: "+ data);
                }
            }*/
           /* int size = 1;
            int size2 = 1;
            dataGridView1.RowCount = size;
            dataGridView1.ColumnCount = size2;
            MessageBox.Show(size + " " + size2);
            
            //int [,] A = new int[size, size2];

            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size2; j++)
                {
                    A[i, j] = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }*/

            
            chart1.Series[0].Points.Add(Array1[0, 0]);
            chart1.Series[0].Points.Add(Array1[0, 1]);
            chart1.Series[0].Points.Add(Array1[0, 2]);
            chart1.Series[0].Points.Add(Array1[0, 3]);
            chart1.Series[0].Points.Add(Array1[0, 4]);
            chart1.Series[0].Points.Add(Array1[0, 5]);
            chart1.Series[0].Points.Add(Array1[0, 6]);
            chart1.Series[0].Points.Add(Array1[0, 7]);
            //chart1.ChartAreas[0].InnerPlotPosition.Width = 50;
            //chart1.ChartAreas[0].InnerPlotPosition.
           // chart1.ChartAreas[0].AxisY.Minimum = 100;
           // chart1.ChartAreas[0].AxisX.Minimum = 100;
            //chart1.Scale = true;]
            //chart1.Height = 1000;

          
            chart1.Visible = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataBaseDataSet1.NapravlenieRV' table. You can move, or remove it, as needed.
            this.napravlenieRVTableAdapter1.Fill(this.dataBaseDataSet1.NapravlenieRV);
            // TODO: This line of code loads data into the 'dataBaseDataSet.NapravlenieRV' table. You can move, or remove it, as needed.
            this.napravlenieRVTableAdapter.Fill(this.dataBaseDataSet.NapravlenieRV);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader Reader = new StreamReader(@"C:\datastringer.txt"))
            {
                while (!Reader.EndOfStream)
                {
                    //============================================================
                    string buff = Reader.ReadLine();
                    if (buff.IndexOf(" ") != -1)
                        textBox4.AppendText(buff.Substring(0, buff.IndexOf(" ")));
                    else
                        textBox4.AppendText(buff);
                    //============================================================


                }

            }
            dataGridView1.Update();

        }
    }
}
