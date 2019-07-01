using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMin2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog() == DialogResult.OK)
            {
                string s = File.ReadAllText(file.FileName);
                string[] lines = s.Trim().Split('\n');
                for(int i=0; i<lines.Length;i++)
                {
                    string[] attributes = lines[i].Split(',');
                    
                   
                    dataGridView1.Rows.Add(attributes[0],attributes[1], attributes[2], attributes[3], attributes[4], attributes[5], attributes[6], attributes[7], attributes[8], attributes[9], attributes[10], attributes[11], attributes[12], attributes[13], attributes[14]);
                    
                }
                
            }
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {          

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Maritial_status");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Sex");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Age");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Workclass");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("fnlwgt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Education");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Education_num");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Occupation");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Relationship");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Race");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Capital_gain");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Capital_loss");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Hours_per_week");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Native_country");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("Wage");            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button19_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                int content0 = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                string content1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string content2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string content3 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string content4 = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string content5 = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string content6 = dataGridView1.Rows[i].Cells[6].Value.ToString();
                string content7 = dataGridView1.Rows[i].Cells[7].Value.ToString();
                string content8 = dataGridView1.Rows[i].Cells[8].Value.ToString();
                string content9 = dataGridView1.Rows[i].Cells[9].Value.ToString();
                string content10 = dataGridView1.Rows[i].Cells[10].Value.ToString();
                string content11 = dataGridView1.Rows[i].Cells[11].Value.ToString();
                string content12= dataGridView1.Rows[i].Cells[12].Value.ToString();
                string content13 = dataGridView1.Rows[i].Cells[13].Value.ToString();
                string content14 = dataGridView1.Rows[i].Cells[14].Value.ToString();

                if ((content1 == " ?"))
                {
                    if ((content1 == " ?") && (content0 > 30) && (content3 == " Bachelors") && (content14 == " >50K"))
                    {

                        dataGridView1.Rows[i].Cells[1].Value = " Federal-gov";
                    }
                    else if ((content1 == " ?") && (content0 < 30) && (content3 == " Bachelors") && (content14 == " >50K"))
                    {

                        dataGridView1.Rows[i].Cells[1].Value = " Local-gov";
                    }
                    else if ((content1 == " ?") && (content0 < 30) && (content3 == " Some-college"))
                    {

                        dataGridView1.Rows[i].Cells[1].Value = " Self-emp-inc";
                    }
                    else if ((content1 == " ?") && (content0 < 30) && (content3 == " HS-grad"))
                    {

                        dataGridView1.Rows[i].Cells[1].Value = " Self-emp-not-inc";
                    }
                    else if (content1 == " ?")
                    {
                        dataGridView1.Rows[i].Cells[1].Value = " Private";
                    }
                }

                if (content6 == " ?")
                {
                    if ((content6 == " ?") && (content0 < 30) && (content3 == " Some-college") && (content14 == " <=50K"))
                    {

                        dataGridView1.Rows[i].Cells[6].Value = " Sales";
                    }
                    else if ((content6 == " ?") && (content0 < 30) && (content3 == " Bachelors") && (content14 == " <=50K"))
                    {

                        dataGridView1.Rows[i].Cells[6].Value = " Protective-serv";
                    }
                    else if ((content6 == " ?") && (content0 < 30) && (content3 == " HS-grad") && (content14 == " <=50K"))
                    {

                        dataGridView1.Rows[i].Cells[6].Value = " Craft-repair";
                    }
                    else if ((content6 == " ?") && (content0 > 30) && (content3 == " Some-college") && (content14 == " >50K"))
                    {

                        dataGridView1.Rows[i].Cells[6].Value = " Tech-support";
                    }
                    else if ((content6 == " ?") && (content0 > 30) && (content3 == " Masters") && (content14 == " >50K"))
                    {

                        dataGridView1.Rows[i].Cells[6].Value = " Exec-managerial";
                    }
                    else if ((content6 == " ?") && (content0 > 30) && (content3 == " Doctorate") && (content14 == " >50K"))
                    {

                        dataGridView1.Rows[i].Cells[6].Value = " Prof-specialty";
                    }
                    else if (content6 == " ?")
                    {
                        dataGridView1.Rows[i].Cells[6].Value = " Other-service";
                    }

                }
                if (content13 == " ?")
                {
                    if ((content13 == " ?") && (content8 == " Black"))
                    {

                        dataGridView1.Rows[i].Cells[13].Value = " Puerto-Rico";
                    }
                    else if ((content13 == " ?") && (content8 == " White"))
                    {

                        dataGridView1.Rows[i].Cells[13].Value = " England";
                    }
                    else if ((content13 == " ?"))
                    {

                        dataGridView1.Rows[i].Cells[13].Value = " United-States";
                    }

                }


             }     
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string countries = dataGridView1.Rows[i].Cells[13].Value.ToString();
                if ((countries == " United-States") || (countries == " Canada"))
                {
                    dataGridView1.Rows[i].Cells[13].Value = " NA";
                }
                else if ((countries == " Puerto-Rico") || (countries == " Honduras") || (countries == " Jamaica") || (countries == " Mexico") || (countries == " Dominican-Republic") || (countries == " Laos") || (countries == " Ecuador"))
                {
                    dataGridView1.Rows[i].Cells[13].Value = " CA";
                }
                else if ((countries == " South") || (countries == " Cuba") || (countries == " Columbia") || (countries == " Guatemala") || (countries == " Nicaragua") || (countries == " El-Salvador") || (countries == " Peru"))
                {
                    dataGridView1.Rows[i].Cells[13].Value = " SA";
                }
                else if ((countries == " England") || (countries == " Germany") || (countries == " Greece") || (countries == " Italy") || (countries == " Poland") || (countries == " Portugal") || (countries == " Ireland") || (countries == " France") || (countries == " Hungary") || (countries == " Holand-Netherlands") || (countries == " Yugoslavia") || (countries == " Scotland"))
                {
                    dataGridView1.Rows[i].Cells[13].Value = " Europe";
                }
                else if ((countries == " Cambodia") || (countries == " Outlying-US(Guam-USVI-etc)") || (countries == " India") || (countries == " Japan") || (countries == " China") || (countries == " Iran") || (countries == " Philippines") || (countries == " Vietnam") || (countries == " Taiwan") || (countries == " Haiti") || (countries == " Thailand") || (countries == " Hong"))
                {
                    dataGridView1.Rows[i].Cells[13].Value = " Asia";
                }
                else { dataGridView1.Rows[i].Cells[13].Value = " Asia"; }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {

            int age_min = 999;
            int age_max = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int age = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                

                if (age > age_max)
                {
                    age_max = age;
                }
                if (age < age_min)
                {
                    age_min = age;
                }                
                
            }

            int fixed_k = (age_max - age_min) / Convert.ToInt32(textBox1.Text);
            int k = Convert.ToInt32(textBox1.Text);
            //textBox1.Text = Convert.ToString(fixed_k);

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int age2 = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                for(int j =0; j<k; j++)
                {
                    int minvalue = (fixed_k * j) + age_min;
                    int maxvalue = (fixed_k * (j + 1)) + age_min;
                    if (age2>= minvalue && age2 <= maxvalue)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = minvalue + " - " + maxvalue;
                    }
                }
                
            }


         }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int hours = Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);

                if (hours <=10)
                {
                    dataGridView1.Rows[i].Cells[12].Value = " 10";
                }
                else if(hours >= 45)
                {
                    dataGridView1.Rows[i].Cells[12].Value = " 45";
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            double hours_min = 999;
            double hours_max = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double hours_transformed = Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value);

                if (hours_transformed > hours_max)
                {
                    hours_max = hours_transformed;
                }
                if (hours_transformed < hours_min)
                {
                    hours_min = hours_transformed;
                }

            }

            double minvalue = Convert.ToInt32(textBox2.Text);
            double maxvalue = Convert.ToInt32(textBox3.Text);

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double hours_transformed = Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value);

                double new_hours = ((hours_transformed - hours_min) / (hours_max - hours_min));
                double new_hours2 = new_hours * (maxvalue - minvalue) + minvalue;
                dataGridView1.Rows[i].Cells[12].Value = Convert.ToDouble(new_hours2);

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            double sum =0;
            double mean;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double hours_transformed = Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value);

                sum += hours_transformed;             


            }
            mean = sum / dataGridView1.Rows.Count;
            double sd=0;
            double sd2=0;
            double z_score = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                double hours_transformed = Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value);

                sd += (hours_transformed - mean) * (hours_transformed - mean);
                sd2 = Math.Sqrt( sd / dataGridView1.Rows.Count - 1);
                z_score = (hours_transformed - mean) / sd2;
                dataGridView1.Rows[i].Cells[12].Value = Convert.ToDouble(z_score);


            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
