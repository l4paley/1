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
    public partial class Form2 : Form
    {
        //=============================
        public string Data 
        {
            get 
            {
                return textBox1.Text;
            }
        }
        //=============================
        public Form2()
        {
            InitializeComponent();
          //  double Date = Convert.ToDouble(textBox1.Text);
        }

        public void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = monthCalendar1.SelectionStart.Day.ToString() + "/" +
                monthCalendar1.SelectionStart.Month.ToString() + "/" +
                    monthCalendar1.SelectionStart.Year.ToString();

            textBox2.Text = monthCalendar1.SelectionStart.Month.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter Writer1 = new StreamWriter(@"C:\datastringer.txt", false))
            {

                //Writer.WriteLine(richTextBox1.Text);
                Writer1.WriteLine(textBox2.Text + " - TVOYA YOBANA DATA");
                

            }
            this.Close();

        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
