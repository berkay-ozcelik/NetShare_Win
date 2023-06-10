namespace NetShare_Win
{
    partial class ManageFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageFiles));
            label2 = new Label();
            listView1 = new ListView();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 8);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 7;
            label2.Text = "Sharing files";
            label2.Click += label2_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 36);
            listView1.Name = "listView1";
            listView1.Size = new Size(315, 237);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 279);
            button1.Name = "button1";
            button1.Size = new Size(147, 34);
            button1.TabIndex = 8;
            button1.Text = "Share File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(180, 279);
            button2.Name = "button2";
            button2.Size = new Size(147, 34);
            button2.TabIndex = 9;
            button2.Text = "Stop Share";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ManageFiles
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 332);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageFiles";
            Text = "Sharing Files";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ListView listView1;
        private Button button1;
        private Button button2;
    }
}