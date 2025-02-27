namespace Toturial_4_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MSG_Click(object sender, EventArgs e)
        {

        }

        private void textBox_KM_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double km, oil, ave;

            if (double.TryParse(textBox_KM.Text, out km))
            {
                if (double.TryParse(textBox_OIL.Text,out oil))
                {
                    ave = km / oil;
                    MSG .Text = "平均油耗：" + ave.ToString("f2") + "公里/公升";
                }
                else
                {
                    MessageBox.Show("請輸入數字");
                    textBox_OIL.Focus();
                    textBox_OIL.Text = "";
                }

            }

            else {
                MessageBox.Show("請輸入數字");
                textBox_KM.Focus();
                textBox_KM.Text = "";
                 }

            km = double.Parse(textBox_KM.Text);
            oil = double.Parse(textBox_OIL.Text);
        }
    }
}
