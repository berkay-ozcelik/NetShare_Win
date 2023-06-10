namespace NetShare_Win
{
    partial class NetShareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetShareForm));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            button4 = new Button();
            label3 = new Label();
            button5 = new Button();
            button6 = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 0;
            label1.Text = "Status: ";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 357);
            button1.Name = "button1";
            button1.Size = new Size(315, 34);
            button1.TabIndex = 1;
            button1.Text = "Manage Sharing Files";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(168, 317);
            button2.Name = "button2";
            button2.Size = new Size(159, 34);
            button2.TabIndex = 3;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 317);
            button3.Name = "button3";
            button3.Size = new Size(150, 34);
            button3.TabIndex = 4;
            button3.Text = "Select";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 5;
            label2.Text = "Active devices";
            // 
            // button4
            // 
            button4.Location = new Point(12, 394);
            button4.Name = "button4";
            button4.Size = new Size(315, 34);
            button4.TabIndex = 6;
            button4.Text = "Set Download Folder";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(76, 9);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 7;
            label3.Text = "Active";
            // 
            // button5
            // 
            button5.Location = new Point(12, 434);
            button5.Name = "button5";
            button5.Size = new Size(150, 34);
            button5.TabIndex = 8;
            button5.Text = "Downloads";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(168, 434);
            button6.Name = "button6";
            button6.Size = new Size(159, 34);
            button6.TabIndex = 9;
            button6.Text = "About";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 74);
            listView1.Name = "listView1";
            listView1.Size = new Size(315, 237);
            listView1.TabIndex = 10;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // NetShareForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 483);
            Controls.Add(listView1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NetShareForm";
            Text = "NetShare";
            Load += NetShareForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Button button4;
        private Label label3;
        private Button button5;
        private Button button6;
        private ListView listView1;
    }
}