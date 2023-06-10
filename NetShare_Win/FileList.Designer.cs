namespace NetShare_Win
{
    partial class FileList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileList));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            listView1 = new ListView();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 0;
            label1.Text = "Device Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 9);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 1;
            label2.Text = "DEVICENAME";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 34);
            label3.Name = "label3";
            label3.Size = new Size(40, 25);
            label3.TabIndex = 2;
            label3.Text = "OS:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 34);
            label4.Name = "label4";
            label4.Size = new Size(251, 25);
            label4.TabIndex = 3;
            label4.Text = "Microsoft Windows NT 1.1.1.1";
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 115);
            listView1.Name = "listView1";
            listView1.Size = new Size(368, 237);
            listView1.TabIndex = 11;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 87);
            label5.Name = "label5";
            label5.Size = new Size(108, 25);
            label5.TabIndex = 12;
            label5.Text = "Sharing files";
            label5.Click += label5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 372);
            button1.Name = "button1";
            button1.Size = new Size(169, 34);
            button1.TabIndex = 13;
            button1.Text = "Start Download";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(211, 372);
            button2.Name = "button2";
            button2.Size = new Size(169, 34);
            button2.TabIndex = 14;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FileList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 448);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(listView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FileList";
            Text = "Browse Files";
            Load += FileList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListView listView1;
        private Label label5;
        private Button button1;
        private Button button2;
    }
}