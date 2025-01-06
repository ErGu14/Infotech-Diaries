namespace StockMasterApp_Home.Forms
{
    partial class ProductsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            groupBox1 = new GroupBox();
            btnDelProd = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            rbWithStart = new RadioButton();
            rbContains = new RadioButton();
            label8 = new Label();
            cmbSupplier = new ComboBox();
            cmbCategory = new ComboBox();
            txtRecorder = new TextBox();
            txtSearch = new TextBox();
            txtStock = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            txtName = new TextBox();
            dgvProducts = new DataGridView();
            btnBack = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 57);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Ürün Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 132);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 0;
            label2.Text = "Birim Başına Miktarı:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 283);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 0;
            label3.Text = "Stok Miktarı:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 207);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 0;
            label4.Text = "Fiyatı:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 362);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 0;
            label5.Text = "Miktar Seviyesi:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(281, 57);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 0;
            label6.Text = "Kategori Adı:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(281, 114);
            label7.Name = "label7";
            label7.Size = new Size(74, 15);
            label7.TabIndex = 0;
            label7.Text = "Tedarikçi Adı";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelProd);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(rbWithStart);
            groupBox1.Controls.Add(rbContains);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(cmbSupplier);
            groupBox1.Controls.Add(cmbCategory);
            groupBox1.Controls.Add(txtRecorder);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(519, 426);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürün Ekle / Güncelle";
            // 
            // btnDelProd
            // 
            btnDelProd.Location = new Point(308, 259);
            btnDelProd.Name = "btnDelProd";
            btnDelProd.Size = new Size(75, 23);
            btnDelProd.TabIndex = 8;
            btnDelProd.Text = "SİL";
            btnDelProd.UseVisualStyleBackColor = true;
            btnDelProd.Click += btnDelProd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(308, 207);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "GÜNCELLE";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(308, 161);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "EKLE";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(400, 394);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Temizle";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(280, 394);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // rbWithStart
            // 
            rbWithStart.AutoSize = true;
            rbWithStart.Checked = true;
            rbWithStart.Location = new Point(281, 369);
            rbWithStart.Name = "rbWithStart";
            rbWithStart.Size = new Size(80, 19);
            rbWithStart.TabIndex = 5;
            rbWithStart.TabStop = true;
            rbWithStart.Text = "...İle Başlar";
            rbWithStart.UseVisualStyleBackColor = true;
            // 
            // rbContains
            // 
            rbContains.AutoSize = true;
            rbContains.Location = new Point(378, 369);
            rbContains.Name = "rbContains";
            rbContains.Size = new Size(69, 19);
            rbContains.TabIndex = 5;
            rbContains.Text = "...İçerir...";
            rbContains.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.Location = new Point(281, 316);
            label8.Name = "label8";
            label8.Size = new Size(102, 21);
            label8.TabIndex = 4;
            label8.Text = "Ürün Arama";
            // 
            // cmbSupplier
            // 
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(281, 132);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(166, 23);
            cmbSupplier.TabIndex = 3;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(281, 75);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(166, 23);
            cmbCategory.TabIndex = 3;
            // 
            // txtRecorder
            // 
            txtRecorder.Location = new Point(34, 380);
            txtRecorder.Name = "txtRecorder";
            txtRecorder.Size = new Size(180, 23);
            txtRecorder.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(281, 340);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(194, 23);
            txtSearch.TabIndex = 2;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(34, 301);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(180, 23);
            txtStock.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(34, 225);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(180, 23);
            txtPrice.TabIndex = 2;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(34, 150);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(180, 23);
            txtQuantity.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(34, 75);
            txtName.Name = "txtName";
            txtName.Size = new Size(180, 23);
            txtName.TabIndex = 1;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(507, 12);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.Size = new Size(498, 426);
            dgvProducts.TabIndex = 2;
            dgvProducts.CellEnter += dgvProducts_CellEnter;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(9, 444);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 32);
            btnBack.TabIndex = 3;
            btnBack.Text = "Geri Dön";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 483);
            Controls.Add(btnBack);
            Controls.Add(dgvProducts);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MaximumSize = new Size(1033, 522);
            MinimumSize = new Size(1033, 522);
            Name = "ProductsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock Master App - Ürünler";
            FormClosed += ProductsForm_FormClosed;
            Load += ProductsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private GroupBox groupBox1;
        private TextBox txtName;
        private TextBox txtQuantity;
        private TextBox txtStock;
        private TextBox txtPrice;
        private ComboBox cmbSupplier;
        private ComboBox cmbCategory;
        private TextBox txtRecorder;
        private Label label8;
        private RadioButton rbWithStart;
        private RadioButton rbContains;
        private TextBox txtSearch;
        private DataGridView dgvProducts;
        private Button btnBack;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnDelProd;
        private Button btnUpdate;
        private Button btnAdd;
    }
}