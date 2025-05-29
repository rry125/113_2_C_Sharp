using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // List to hold CellPhone objects
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        // The GetPhoneData method accepts a CellPhone object
        // as an argument. It assigns the data entered by the
        // user to the object's properties.
        private void GetPhoneData(CellPhone phone)
        {
            // Temporary variable to hold the price.
            decimal price;

            // Get the phone's brand.
            phone.Brand = brandTextBox.Text;

            // Get the phone's model.
            phone.Model = modelTextBox.Text;

            // Get the phone's price.
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // Display an error message.
                MessageBox.Show("Invalid price");
            }
        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone();

            GetPhoneData(myPhone);

            // Add the phone to the list.
            phoneList.Add(myPhone);

            //將新增手機的品牌與型號組成字串加入到 ListBox 中
            phoneListBox.Items.Add(myPhone.Brand + " " + myPhone.Model);

            // Clear the text boxes.
            brandTextBox.Clear();
            modelTextBox.Clear();
            priceTextBox.Clear();

            // Set the focus to the brand text box.
            brandTextBox.Focus();

        }

        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex;

            MessageBox.Show(phoneList[index].Price.ToString("c"));
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
