namespace WinFormsApp_WORK_01
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
            userBox = new TextBox();
            passBox = new TextBox();
            girisButton = new Button();
            panel1 = new Panel();
            sonucLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Snap ITC", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(181, 9);
            label1.Name = "label1";
            label1.Size = new Size(432, 35);
            label1.TabIndex = 0;
            label1.Text = "LÜTFEN GİRİŞ YAPINIZ";
            label1.Click += label1_Click_1;
            // 
            // userBox
            // 
            userBox.ForeColor = SystemColors.GrayText;
            userBox.Location = new Point(181, 122);
            userBox.Multiline = true;
            userBox.Name = "userBox";
            userBox.Size = new Size(444, 39);
            userBox.TabIndex = 1;
            userBox.Text = "KULLANICI ADI";
            userBox.TextAlign = HorizontalAlignment.Center;
            userBox.TextChanged += textBox1_TextChanged;
            // 
            // passBox
            // 
            passBox.AccessibleRole = AccessibleRole.SplitButton;
            passBox.ForeColor = SystemColors.WindowFrame;
            passBox.Location = new Point(181, 211);
            passBox.Multiline = true;
            passBox.Name = "passBox";
            passBox.Size = new Size(444, 37);
            passBox.TabIndex = 2;
            passBox.Text = "ŞİFRE";
            passBox.TextAlign = HorizontalAlignment.Center;
            // 
            // girisButton
            // 
            girisButton.Font = new Font("SimSun", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            girisButton.ForeColor = Color.Navy;
            girisButton.Location = new Point(181, 289);
            girisButton.Name = "girisButton";
            girisButton.Size = new Size(444, 43);
            girisButton.TabIndex = 3;
            girisButton.Text = "GİRİŞ";
            girisButton.UseVisualStyleBackColor = true;
            girisButton.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LawnGreen;
            panel1.Controls.Add(sonucLabel);
            panel1.Location = new Point(181, 338);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 100);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // sonucLabel
            // 
            sonucLabel.AutoSize = true;
            sonucLabel.Location = new Point(101, 37);
            sonucLabel.Name = "sonucLabel";
            sonucLabel.Size = new Size(0, 15);
            sonucLabel.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGoldenrod;
            ClientSize = new Size(800, 450);
            Controls.Add(girisButton);
            Controls.Add(panel1);
            Controls.Add(passBox);
            Controls.Add(userBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "DENEME";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox userBox;
        private TextBox passBox;
        private Button girisButton;
        private Panel panel1;
        private Label sonucLabel;
    }
}
