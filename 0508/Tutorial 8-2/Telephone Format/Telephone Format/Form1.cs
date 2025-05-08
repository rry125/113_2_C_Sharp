using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The IsValidNumber method accepts a string and
        // returns true if it contains 10 digits, or false
        // otherwise.
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10;
            if (str.Length != VALID_LENGTH)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        // The TelephoneFormat method accepts a string argument
        // by reference and formats it as a telephone number.
        private void TelephoneFormat(ref string str)
        {
            // Format the string as (XXX) XXX-XXXX
            //str = $"({str.Substring(0, 2)}) {str.Substring(2, 4)}-{str.Substring(6, 4)}";

            str = str.Insert(0, "(");
            str = str.Insert(3, ") ");
            str = str.Insert(9, "-");


        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;   

            if ( IsValidNumber(input))
            {
                TelephoneFormat(ref input);
                MessageBox.Show(input , "格式化結果" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                 MessageBox.Show("請輸入10位數字", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
