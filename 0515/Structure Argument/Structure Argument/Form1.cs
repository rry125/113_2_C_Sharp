using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Structure_Argument
{
    // 定義一個Automobile結構，包含車輛品牌、年份與里程數
    struct Automobile
    {
        public string make;    // 車輛品牌
        public int year;       // 車輛年份
        public double mileage; // 車輛里程數
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 將所有元件的Text屬性設為繁體中文
            this.Text = "結構作為引數範例";
            // 假設有三個按鈕：auto1Button, auto2Button, auto3Button
            // 這裡直接設定Text屬性為繁體中文
            auto1Button.Text = "跑車";
            auto2Button.Text = "皮卡";
            auto3Button.Text = "轎車";
        }

        /// <summary>
        /// 顯示汽車資訊的方法，接受一個Automobile結構作為引數，並顯示其欄位內容。
        /// </summary>
        /// <param name="auto">Automobile結構，包含車輛品牌、年份與里程數</param>
        private void DisplayAuto(Automobile auto)
        {
            // 使用MessageBox顯示汽車的年份、品牌與里程數，訊息內容為繁體中文
            MessageBox.Show(
                auto.year + " 年的 " + auto.make +
                "，里程數為 " + auto.mileage + " 英里。"
            );
        }

        /// <summary>
        /// 當使用者點擊「跑車」按鈕時，建立一個Automobile結構的實例，並指定其欄位值，最後顯示其內容。
        /// </summary>
        private void auto1Button_Click(object sender, EventArgs e)
        {
            // 建立Automobile結構的實例，代表一台跑車
            Automobile sportsCar = new Automobile();

            // 指定跑車的品牌、年份與里程數
            sportsCar.make = "雪佛蘭 Corvette";
            sportsCar.year = 1970;
            sportsCar.mileage = 50000.0;

            // 顯示跑車的詳細資訊
            DisplayAuto(sportsCar);
        }

        /// <summary>
        /// 當使用者點擊「皮卡」按鈕時，建立一個Automobile結構的實例，並指定其欄位值，最後顯示其內容。
        /// </summary>
        private void auto2Button_Click(object sender, EventArgs e)
        {
            // 建立Automobile結構的實例，代表一台皮卡
            Automobile pickupTruck = new Automobile();

            // 指定皮卡的品牌、年份與里程數
            pickupTruck.make = "福特 Ranger";
            pickupTruck.year = 1985;
            pickupTruck.mileage = 75000.0;

            // 顯示皮卡的詳細資訊
            DisplayAuto(pickupTruck);
        }

        /// <summary>
        /// 當使用者點擊「轎車」按鈕時，建立一個Automobile結構的實例，並指定其欄位值，最後顯示其內容。
        /// </summary>
        private void auto3Button_Click(object sender, EventArgs e)
        {
            // 建立Automobile結構的實例，代表一台轎車
            Automobile sedan = new Automobile();

            // 指定轎車的品牌、年份與里程數
            sedan.make = "本田 Accord";
            sedan.year = 2000;
            sedan.mileage = 80000.0;

            // 顯示轎車的詳細資訊
            DisplayAuto(sedan);
        }

        /// <summary>
        /// 表單載入事件，目前未執行任何動作。
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
