using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ThreeDArray1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,,] covidPositiveData = new int[1, 7, 2];
        int[,,] covidPositiveDataDiff = new int[1, 7, 2];
        string[] days = new string[7];
        string[] months = new string[2];
        bool doubleData = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            string StartUpPath = Application.StartupPath;
            string fileLocation = StartUpPath + @"\covid_data.txt";

            string[] fileData = { "8", "8", "11", "14", "8", "13", "19", "214",
                "187", "186", "177", "148", "122", "112", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "April", "May" };

            File.WriteAllLines(@fileLocation, fileData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            string StartUpPath = Application.StartupPath;
            string fileLocation = StartUpPath + @"\covid_data.txt";

            // Add Data to 3D Array
            using (StreamReader read = new StreamReader(fileLocation))
            {
                for (int slice = 0; slice <= 1; slice++)
                {
                    for (int row = 0; row <= 0; row++)
                    {
                        for (int col = 0; col < 7; col++)
                        {
                            covidPositiveData[row, col, slice] = Convert.ToInt32(read.ReadLine());
                        }
                    }
                }

                // Add Days to 2D Array
                for (int i = 0; i <= 6; i++)
                {
                    days[i] = read.ReadLine();
                }

                // Add Months to Array
                for (int i = 0; i <= 1; i++)
                {
                    months[i] = read.ReadLine();
                }
                read.Close();

                displayBasicData();
                button1.Enabled = true;
            }
        }

        private void displayBasicData(bool doubling = false)
        {
            textBox1.Clear();
            if (doubling == false)
            {
                textBox1.Text += "King County COVID-19 Confirmed Cases for 1st Week of Month [2020]";
            }
            else
            {
                textBox1.Text += "King County COVID-19 Confirmed Cases for 1st Week of Month [2020] DOUBLED";
            }

            for (int slice = 0; slice <= 1; slice++)
            {
                int counter = 0;
                textBox1.Text += Environment.NewLine;
                textBox1.Text += Environment.NewLine;
                textBox1.Text += months[slice] + "\t";

                do
                {
                    textBox1.Text += days[counter] + "\t";
                    counter++;
                } while (counter != 7);

                for (int row = 0; row <= 0; row++)
                {
                    textBox1.Text += Environment.NewLine;
                    textBox1.Text += "\t";
                    for (int col = 0; col < 7; col++)
                    {
                        if (doubleData == false)
                        {
                            textBox1.Text += covidPositiveData[row, col, slice].ToString() + "\t";
                        }
                        else if (doubleData == true)
                        {
                            int value = covidPositiveData[row, col, slice] * 2;
                            textBox1.Text += value.ToString() + "\t";
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            doubleData = true;
            displayBasicData(doubleData);
            doubleData = false;
        }
    }
}
