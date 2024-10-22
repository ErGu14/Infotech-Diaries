namespace NorthWindManagement
{
    partial class Form1Main
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
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtProductName = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            cmbCategories = new ComboBox();
            btnNew = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            rbWithStart = new RadioButton();
            rbContains = new RadioButton();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            cmbFilter = new ComboBox();
            dgvProducts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(192, 0, 192);
            label1.Location = new Point(107, 72);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 19);
            label1.TabIndex = 0;
            label1.Text = "Ürün Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.FromArgb(192, 0, 192);
            label2.Location = new Point(671, 122);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 19);
            label2.TabIndex = 1;
            label2.Text = "Stok:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.FromArgb(192, 0, 192);
            label3.Location = new Point(668, 72);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(55, 19);
            label3.TabIndex = 2;
            label3.Text = "Fiyat:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = Color.FromArgb(192, 0, 192);
            label4.Location = new Point(108, 272);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(113, 19);
            label4.TabIndex = 3;
            label4.Text = "Ürün Arama:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.ForeColor = Color.FromArgb(192, 0, 192);
            label6.Location = new Point(108, 118);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(85, 19);
            label6.TabIndex = 5;
            label6.Text = "Kategori:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 11F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(192, 0, 192);
            label7.Location = new Point(749, 272);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(189, 18);
            label7.TabIndex = 6;
            label7.Text = "Kategoriye Göre Filtrele";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Symbol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 2);
            txtProductName.Location = new Point(238, 72);
            txtProductName.Margin = new Padding(5, 4, 5, 4);
            txtProductName.Multiline = true;
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(349, 28);
            txtProductName.TabIndex = 0;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Symbol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 2);
            txtPrice.Location = new Point(749, 72);
            txtPrice.Margin = new Padding(5, 4, 5, 4);
            txtPrice.Multiline = true;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(192, 28);
            txtPrice.TabIndex = 2;
            // 
            // txtStock
            // 
            txtStock.Font = new Font("Symbol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 2);
            txtStock.Location = new Point(749, 122);
            txtStock.Margin = new Padding(5, 4, 5, 4);
            txtStock.Multiline = true;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(192, 28);
            txtStock.TabIndex = 3;
            // 
            // cmbCategories
            // 
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Items.AddRange(new object[] { "Telefon", "Bilgisayar", "Kitap" });
            cmbCategories.Location = new Point(238, 117);
            cmbCategories.Margin = new Padding(5, 4, 5, 4);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(349, 27);
            cmbCategories.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(0, 192, 0);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(185, 179);
            btnNew.Margin = new Padding(5, 4, 5, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(145, 60);
            btnNew.TabIndex = 4;
            btnNew.Text = "Yeni Ürün Ekle";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(338, 179);
            btnUpdate.Margin = new Padding(5, 4, 5, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 60);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Ürün Güncelle";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.Transparent;
            btnDelete.Location = new Point(491, 179);
            btnDelete.Margin = new Padding(5, 4, 5, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 60);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Ürün Sil";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // rbWithStart
            // 
            rbWithStart.AutoSize = true;
            rbWithStart.Font = new Font("Tahoma", 11F, FontStyle.Bold);
            rbWithStart.Location = new Point(238, 270);
            rbWithStart.Name = "rbWithStart";
            rbWithStart.Size = new Size(111, 22);
            rbWithStart.TabIndex = 7;
            rbWithStart.TabStop = true;
            rbWithStart.Text = "...ile başlar";
            rbWithStart.UseVisualStyleBackColor = true;
            // 
            // rbContains
            // 
            rbContains.AutoSize = true;
            rbContains.Font = new Font("Tahoma", 11F, FontStyle.Bold);
            rbContains.Location = new Point(361, 268);
            rbContains.Name = "rbContains";
            rbContains.Size = new Size(97, 22);
            rbContains.TabIndex = 8;
            rbContains.TabStop = true;
            rbContains.Text = "...içerir...";
            rbContains.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Symbol", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 2);
            txtSearch.Location = new Point(107, 307);
            txtSearch.Margin = new Padding(5, 4, 5, 4);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(502, 28);
            txtSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Blue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(619, 272);
            btnSearch.Margin = new Padding(5, 4, 5, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(104, 44);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "ARA";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 128, 0);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(619, 324);
            btnClear.Margin = new Padding(5, 4, 5, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(104, 44);
            btnClear.TabIndex = 1;
            btnClear.Text = "Temizle";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Telefon", "Bilgisayar", "Kitap" });
            cmbFilter.Location = new Point(749, 310);
            cmbFilter.Margin = new Padding(5, 4, 5, 4);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(189, 27);
            cmbFilter.TabIndex = 12;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Bottom;
            dgvProducts.Location = new Point(0, 393);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(985, 258);
            dgvProducts.TabIndex = 21;
            dgvProducts.TabStop = false;
            // 
            // Form1Main
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 651);
            Controls.Add(dgvProducts);
            Controls.Add(cmbFilter);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(rbContains);
            Controls.Add(rbWithStart);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnNew);
            Controls.Add(cmbCategories);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtProductName);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Tahoma", 12F, FontStyle.Bold);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1Main";
            Text = "NorthWind Management App";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private TextBox txtProductName;
        private TextBox txtPrice;
        private TextBox txtStock;
        private ComboBox cmbCategories;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnDelete;
        private RadioButton rbWithStart;
        private RadioButton rbContains;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClear;
        private ComboBox cmbFilter;
        private DataGridView dgvProducts;
    }
}
