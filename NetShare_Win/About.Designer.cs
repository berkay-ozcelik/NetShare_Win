namespace NetShare_Win
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 9);
            label1.Name = "label1";
            label1.Size = new Size(255, 25);
            label1.TabIndex = 0;
            label1.Text = "NetShare Windows Client 1.1.2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 114);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 9);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(85, 170);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 46);
            label4.Name = "label4";
            label4.Size = new Size(174, 25);
            label4.TabIndex = 4;
            label4.Text = "Graduation Project II";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 89);
            label5.Name = "label5";
            label5.Size = new Size(179, 25);
            label5.TabIndex = 5;
            label5.Text = "Celal Bayar University";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 126);
            label6.Name = "label6";
            label6.Size = new Size(232, 25);
            label6.TabIndex = 6;
            label6.Text = "Berkay Ozcelik - 190315054";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 230);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}