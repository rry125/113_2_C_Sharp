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
        // 在Form1類別內
        private string teamFilePath = "";
        private string winnerFilePath = "";
        private string addedWinnerFilePath = "";

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
                MessageBox.Show("請選擇隊伍檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "文字檔案 (*.txt)|*",
                    Title = "選擇隊伍檔案"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    teamFilePath = openFileDialog.FileName; // 記錄隊伍檔案路徑
                    using (StreamReader inputFile = File.OpenText(teamFilePath))
                    {
                        while (!inputFile.EndOfStream)
                        {
                            string line = inputFile.ReadLine();
                            listBox1.Items.Add(line);
                            team.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取隊伍資料時發生錯誤：" + ex.Message);
            }
        }

        private void readWinner()
        {
            try
            {
                MessageBox.Show("請選擇冠軍大賽資料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "文字檔案 (*.txt)|*",
                    Title = "選擇冠軍大賽資料"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    winnerFilePath = openFileDialog.FileName; // 記錄冠軍檔案路徑
                    using (StreamReader inputFile = File.OpenText(winnerFilePath))
                    {
                        int year = 1903;
                        while (!inputFile.EndOfStream)
                        {
                            string line = inputFile.ReadLine();
                            winner.Add(line);
                            years.Add(year);
                            year++;
                            if (year == 1904) year++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取冠軍資料時發生錯誤：" + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            string str = listBox1.SelectedItem.ToString();
            var data = teamDataList.FirstOrDefault(t => t.Name == str);

            if (string.IsNullOrEmpty(data.Name))
            {
                label1.Text = "查無此隊伍資料。";
                return;
            }

            label1.Text = $"{data.Name} 從 1903 年到 2009 年共贏得 {data.WinCount} 次世界大賽冠軍。\n" +
                          $"冠軍年份：" + string.Join(", ", data.WinYears);
        }

        // 重新整理隊伍清單，並更新listBox1顯示內容
        private void UpdateTeamList()
        {
            team = winner.Distinct().ToList();
            listBox1.Items.Clear();
            foreach (string t in team)
            {
                listBox1.Items.Add(t);
            }
            UpdateTeamDataList(); // 確保每次更新隊伍清單時也更新 teamDataList
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("請選擇2010年以後的MLB冠軍隊伍資料檔案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "文字檔案 (*.txt)|*",
                    Title = "選擇2010年以後冠軍資料檔案"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    addedWinnerFilePath = openFileDialog.FileName; // 記錄新增檔案路徑

                    using (StreamReader inputFile = File.OpenText(openFileDialog.FileName))
                    {
                        int year = 2010;
                        while (!inputFile.EndOfStream)
                        {
                            string line = inputFile.ReadLine();
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                winner.Add(line); // 加入冠軍隊伍
                                years.Add(year);  // 加入年份
                                year++;
                            }
                        }
                    }

                    UpdateTeamList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取2010年以後冠軍資料時發生錯誤：" + ex.Message);
            }
        }


        // 儲存所有球隊與冠軍資料的清單
        List<TeamData> teamDataList = new List<TeamData>();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 附加新增隊伍到隊伍檔案（只新增原本沒有的隊伍）
                if (!string.IsNullOrEmpty(teamFilePath) && !string.IsNullOrEmpty(addedWinnerFilePath))
                {
                    // 讀取原本隊伍檔案內容
                    var originalTeams = new HashSet<string>(File.ReadAllLines(teamFilePath));
                    // 取得2010年以後新增的隊伍
                    int startIndex = years.FindIndex(y => y == 2010);
                    if (startIndex >= 0)
                    {
                        var addedWinners = winner.Skip(startIndex).ToList();
                        var newTeams = addedWinners.Where(t => !originalTeams.Contains(t)).Distinct().ToList();
                        if (newTeams.Count > 0)
                            File.AppendAllLines(teamFilePath, newTeams);
                    }
                }

                // 2. 附加新增冠軍資料到冠軍檔案
                if (!string.IsNullOrEmpty(winnerFilePath) && !string.IsNullOrEmpty(addedWinnerFilePath))
                {
                    int startIndex = years.FindIndex(y => y == 2010);
                    if (startIndex >= 0)
                    {
                        var addedWinners = winner.Skip(startIndex).ToList();
                        File.AppendAllLines(winnerFilePath, addedWinners);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存資料時發生錯誤：" + ex.Message);
            }
            finally
            {
                Application.Exit();
            }
        }
        private void UpdateTeamDataList()
        {
            teamDataList.Clear();
            var allTeams = winner.Distinct().ToList();
            foreach (var teamName in allTeams)
            {
                TeamData data = new TeamData(teamName);
                for (int i = 0; i < winner.Count; i++)
                {
                    if (winner[i] == teamName)
                    {
                        data.WinCount++;
                        data.WinYears.Add(years[i]);
                    }
                }
                teamDataList.Add(data);
            }
        }
    }
    // 球隊資料結構
    public struct TeamData
    {
        public string Name;            // 球隊名稱
        public int WinCount;           // 獲勝次數
        public List<int> WinYears;     // 獲勝年份清單

        public TeamData(string name)
        {
            Name = name;
            WinCount = 0;
            WinYears = new List<int>();
        }
    }
}
