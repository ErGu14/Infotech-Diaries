namespace StockMasterApp_Home
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnCategory = new Button();
            btnProduct = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.Transparent;
            btnCategory.Cursor = Cursors.Hand;
            btnCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCategory.ForeColor = Color.White;
            btnCategory.Image = (Image)resources.GetObject("btnCategory.Image");
            btnCategory.Location = new Point(597, 23);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(160, 77);
            btnCategory.TabIndex = 0;
            btnCategory.Text = "Kategoriler";
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnProduct
            // 
            btnProduct.Cursor = Cursors.Hand;
            btnProduct.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnProduct.ForeColor = Color.White;
            btnProduct.Image = (Image)resources.GetObject("btnProduct.Image");
            btnProduct.Location = new Point(597, 116);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(160, 77);
            btnProduct.TabIndex = 0;
            btnProduct.Text = "Ürünler";
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-2, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(801, 450);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 411);
            Controls.Add(btnProduct);
            Controls.Add(btnCategory);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            MaximumSize = new Size(801, 450);
            MinimumSize = new Size(801, 450);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock Master App Home Page";
            FormClosed += MainForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCategory;
        private Button btnProduct;
        private PictureBox pictureBox1;
    }
}
