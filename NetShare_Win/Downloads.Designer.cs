namespace NetShare_Win
{
    partial class Downloads
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloads));
            label5 = new Label();
            listView1 = new ListView();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 13);
            label5.Name = "label5";
            label5.Size = new Size(150, 25);
            label5.TabIndex = 14;
            label5.Text = "Downloaded files";
            label5.Click += label5_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 41);
            listView1.Name = "listView1";
            listView1.Size = new Size(368, 237);
            listView1.TabIndex = 13;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(50, 284);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 15;
            button1.Text = "Manage";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(211, 284);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 16;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Downloads
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 334);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Downloads";
            Text = "Downloads";
            Load += Downloads_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private ListView listView1;
        private Button button1;
        private Button button2;
    }
}