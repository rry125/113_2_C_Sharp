using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 使用 List<string> 來存放球隊名稱
        List<string> team = new List<string>();

        // 使用 List<string> 來存放冠軍資料
        List<string> winner = new List<string>();

        // 使用 List<int> 來存放冠軍年份
        List<int> years = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // 執行程式時依序提示選擇隊伍檔案和冠軍大賽資料
            readTeams();
            readWinner();
        }

        private void readTeams()
        {
            try
            {
                // 顯示提示訊息，要求使用者選擇隊伍檔案
                MessageBox.Show("請選擇隊伍檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 使用 OpenFileDialog 讓使用者選擇 Teams.txt 檔案
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "文字檔案 (*.txt)|*",
                    Title = "選擇隊伍檔案"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader inputFile = File.OpenText(openFileDialog.FileName))
                    {
                        while (!inputFile.EndOfStream)
                        {
                            string line = inputFile.ReadLine();
                            listBox1.Items.Add(line); // 將球隊名稱加入 listBox1
                            team.Add(line);          // 將球隊名稱加入 team List
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 如果發生錯誤，顯示錯誤訊息
                MessageBox.Show("讀取隊伍資料時發生錯誤：" + ex.Message);
            }
        }

        private void readWinner()
        {
            try
            {
                // 顯示提示訊息，要求使用者選擇冠軍大賽資料
                MessageBox.Show("請選擇冠軍大賽資料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 使用 OpenFileDialog 讓使用者選擇 WorldSeries.txt 檔案
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "文字檔案 (*.txt)|*",
                    Title = "選擇冠軍大賽資料"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader inputFile = File.OpenText(openFileDialog.FileName))
                    {
                        int year = 1903; // MLB 冠軍年份從 1903 年開始
                        while (!inputFile.EndOfStream)
                        {
                            string line = inputFile.ReadLine();
                            winner.Add(line); // 將冠軍資料加入 winner List
                            years.Add(year); // 將年份加入 years List
                            year++;
                            if (year == 1904) year++; // 跳過 1904 年（未舉辦冠軍賽）
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 如果發生錯誤，顯示錯誤訊息
                MessageBox.Show("讀取冠軍資料時發生錯誤：" + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 取得使用者選擇的球隊名稱
            string str = listBox1.SelectedItem.ToString();
            int numWin = 0;
            List<int> winningYears = new List<int>();

            // 計算該球隊在冠軍資料中出現的次數，並記錄年份
            for (int i = 0; i < winner.Count; i++)
            {
                if (str == winner[i])
                {
                    numWin++;
                    winningYears.Add(years[i]);
                }
            }

            // 顯示該球隊的冠軍次數及年份
            label1.Text = str + " 從 1903 年到 2009 年共贏得 " + numWin + " 次世界大賽冠軍。\n"
                        + "冠軍年份：" + string.Join(", ", winningYears);
        }
    }
}
