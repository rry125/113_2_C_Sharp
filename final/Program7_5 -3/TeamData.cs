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

// 儲存所有球隊與冠軍資料的清單
List<TeamData> teamDataList = new List<TeamData>();
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
UpdateTeamDataList();
private void UpdateTeamList()
{
    team = winner.Distinct().ToList();
    listBox1.Items.Clear();
    foreach (string t in team)
    {
        listBox1.Items.Add(t);
    }
    UpdateTeamDataList(); // 新增這行
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
}
