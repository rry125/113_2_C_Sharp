namespace Toturial_4_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox_KM = new TextBox();
            textBox_OIL = new TextBox();
            label3 = new Label();
            MSG = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 71);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "輸入行駛里程數";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 124);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 1;
            label2.Text = "消耗油量公升數";
            label2.Click += textBox_KM_TextChanged;
            // 
            // textBox_KM
            // 
            textBox_KM.Location = new Point(166, 68);
            textBox_KM.Name = "textBox_KM";
            textBox_KM.Size = new Size(109, 23);
            textBox_KM.TabIndex = 2;
            textBox_KM.TextChanged += textBox_KM_TextChanged;
            // 
            // textBox_OIL
            // 
            textBox_OIL.Location = new Point(166, 121);
            textBox_OIL.Name = "textBox_OIL";
            textBox_OIL.Size = new Size(109, 23);
            textBox_OIL.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 193);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 4;
            label3.Text = "您的平均油耗";
            // 
            // MSG
            // 
            MSG.BorderStyle = BorderStyle.Fixed3D;
            MSG.Location = new Point(143, 187);
            MSG.Name = "MSG";
            MSG.Size = new Size(159, 21);
            MSG.TabIndex = 5;
            MSG.Click += MSG_Click;
            // 
            // button1
            // 
            button1.Location = new Point(70, 238);
            button1.Name = "button1";
            button1.Size = new Size(86, 26);
            button1.TabIndex = 6;
            button1.Text = "計算";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(166, 238);
            button2.Name = "button2";
            button2.Size = new Size(86, 26);
            button2.TabIndex = 7;
            button2.Text = "離開";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 303);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(MSG);
            Controls.Add(label3);
            Controls.Add(textBox_OIL);
            Controls.Add(textBox_KM);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox_KM;
        private TextBox textBox_OIL;
        private Label label3;
        private Label MSG;
        private Button button1;
        private Button button2;
    }
}
