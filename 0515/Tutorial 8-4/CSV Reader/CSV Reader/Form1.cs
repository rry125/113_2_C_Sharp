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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile;
                string line;
                int count = 0;
                int total = 0;
                double average;

                char[] delim = { ',' };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    inputFile = File.OpenText(openFileDialog1.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();
                        line = line.Trim();
                        string[] tokens = line.Split(delim);
                        total = 0;


                        for (int i = 0; i < tokens.Length; i++)
                        {
                            total += int.Parse(tokens[i]);
                        }
                        average = (double)total / tokens.Length;
                        averagesListBox.Items.Add("第 " + (++count) + " 位同學的平均分数是: " + average.ToString("F2"));
                    }
                }

                else
                {
                    MessageBox.Show("No file selected.");
                }
            }
            catch (Exception ex)
            {
                // Display an error message if the file cannot be opened.
                MessageBox.Show("Error " + ex.Message);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
