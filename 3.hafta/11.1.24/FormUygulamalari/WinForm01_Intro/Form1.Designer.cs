namespace WinForm01_Intro
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
            btnNext = new Button();
            cbAgree = new CheckBox();
            cmbCategoryList = new ComboBox();
            label1 = new Label();
            listBox1 = new ListBox();
            txtProductName = new TextBox();
            radioButton1 = new RadioButton();
            SuspendLayout();
            // 
            // btnNext
            // 
            btnNext.Location = new Point(110, 226);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(105, 23);
            btnNext.TabIndex = 0;
            btnNext.Text = "Korkma Bas";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += button1_Click;
            // 
            // cbAgree
            // 
            cbAgree.AutoSize = true;
            cbAgree.Location = new Point(618, 110);
            cbAgree.Name = "cbAgree";
            cbAgree.Size = new Size(110, 19);
            cbAgree.TabIndex = 1;
            cbAgree.Text = "Kabul Ediyorum";
            cbAgree.UseVisualStyleBackColor = true;
            cbAgree.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // cmbCategoryList
            // 
            cmbCategoryList.FormattingEnabled = true;
            cmbCategoryList.Location = new Point(618, 67);
            cmbCategoryList.Name = "cmbCategoryList";
            cmbCategoryList.Size = new Size(121, 23);
            cmbCategoryList.TabIndex = 2;
            cmbCategoryList.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 155);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 3;
            label1.Text = "Kafana Göre Bişiler Yaz";
            label1.Click += label1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(619, 155);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 94);
            listBox1.TabIndex = 4;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(101, 181);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(125, 23);
            txtProductName.TabIndex = 5;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(675, 276);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(53, 19);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "ZORT";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(radioButton1);
            Controls.Add(txtProductName);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(cmbCategoryList);
            Controls.Add(cbAgree);
            Controls.Add(btnNext);
            Name = "Form1";
            Text = "İlk Uygulamam";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNext;
        private CheckBox cbAgree;
        private ComboBox cmbCategoryList;
        private Label label1;
        private ListBox listBox1;
        private TextBox txtProductName;
        private RadioButton radioButton1;
    }
}
