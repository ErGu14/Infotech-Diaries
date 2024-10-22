namespace StockMasterApp.Forms
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            btnStock = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cmbSuppliers = new ComboBox();
            cmbCategories = new ComboBox();
            rbFalse = new RadioButton();
            rbTrue = new RadioButton();
            txtReorderLevel = new TextBox();
            textBox1 = new TextBox();
            txtStock = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            txtName = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label6 = new Label();
            label3 = new Label();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            gridProducts = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridProducts).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnStock);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(cmbSuppliers);
            groupBox1.Controls.Add(cmbCategories);
            groupBox1.Controls.Add(rbFalse);
            groupBox1.Controls.Add(rbTrue);
            groupBox1.Controls.Add(txtReorderLevel);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(txtStock);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            groupBox1.ForeColor = Color.DodgerBlue;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(479, 481);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürün Ekle/Güncelle";
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.Cyan;
            btnStock.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnStock.ForeColor = Color.White;
            btnStock.Location = new Point(324, 174);
            btnStock.Margin = new Padding(3, 2, 3, 2);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(132, 42);
            btnStock.TabIndex = 4;
            btnStock.Text = "Stok Hareketi Ekle";
            btnStock.UseVisualStyleBackColor = false;
            btnStock.Click += btnStock_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(324, 422);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(132, 42);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(170, 422);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(132, 42);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LimeGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(11, 422);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(132, 42);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // cmbSuppliers
            // 
            cmbSuppliers.Font = new Font("Segoe UI", 14F);
            cmbSuppliers.FormattingEnabled = true;
            cmbSuppliers.Location = new Point(189, 351);
            cmbSuppliers.Margin = new Padding(3, 2, 3, 2);
            cmbSuppliers.Name = "cmbSuppliers";
            cmbSuppliers.Size = new Size(267, 33);
            cmbSuppliers.TabIndex = 3;
            // 
            // cmbCategories
            // 
            cmbCategories.Font = new Font("Segoe UI", 14F);
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(189, 307);
            cmbCategories.Margin = new Padding(3, 2, 3, 2);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(267, 33);
            cmbCategories.TabIndex = 3;
            // 
            // rbFalse
            // 
            rbFalse.AutoSize = true;
            rbFalse.Font = new Font("Segoe UI", 14F);
            rbFalse.Location = new Point(276, 224);
            rbFalse.Margin = new Padding(3, 2, 3, 2);
            rbFalse.Name = "rbFalse";
            rbFalse.Size = new Size(59, 29);
            rbFalse.TabIndex = 2;
            rbFalse.Text = "Yok";
            rbFalse.UseVisualStyleBackColor = true;
            // 
            // rbTrue
            // 
            rbTrue.AutoSize = true;
            rbTrue.Checked = true;
            rbTrue.Font = new Font("Segoe UI", 14F);
            rbTrue.Location = new Point(189, 224);
            rbTrue.Margin = new Padding(3, 2, 3, 2);
            rbTrue.Name = "rbTrue";
            rbTrue.Size = new Size(58, 29);
            rbTrue.TabIndex = 2;
            rbTrue.TabStop = true;
            rbTrue.Text = "Var";
            rbTrue.UseVisualStyleBackColor = true;
            // 
            // txtReorderLevel
            // 
            txtReorderLevel.Font = new Font("Segoe UI", 14F);
            txtReorderLevel.Location = new Point(189, 264);
            txtReorderLevel.Margin = new Padding(3, 2, 3, 2);
            txtReorderLevel.Name = "txtReorderLevel";
            txtReorderLevel.Size = new Size(267, 32);
            txtReorderLevel.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(170, -73);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(113, 32);
            textBox1.TabIndex = 1;
            // 
            // txtStock
            // 
            txtStock.Font = new Font("Segoe UI", 14F);
            txtStock.Location = new Point(189, 176);
            txtStock.Margin = new Padding(3, 2, 3, 2);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(113, 32);
            txtStock.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 14F);
            txtPrice.Location = new Point(189, 131);
            txtPrice.Margin = new Padding(3, 2, 3, 2);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(267, 32);
            txtPrice.TabIndex = 1;
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 14F);
            txtQuantity.Location = new Point(189, 87);
            txtQuantity.Margin = new Padding(3, 2, 3, 2);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(267, 32);
            txtQuantity.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 14F);
            txtName.Location = new Point(189, 46);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(267, 32);
            txtName.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ForeColor = Color.Crimson;
            label8.Location = new Point(11, 364);
            label8.Name = "label8";
            label8.Size = new Size(83, 21);
            label8.TabIndex = 0;
            label8.Text = "Tedarikçi:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = Color.Crimson;
            label7.Location = new Point(11, 320);
            label7.Name = "label7";
            label7.Size = new Size(79, 21);
            label7.TabIndex = 0;
            label7.Text = "Kategori:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Crimson;
            label4.Location = new Point(11, 187);
            label4.Name = "label4";
            label4.Size = new Size(107, 21);
            label4.TabIndex = 0;
            label4.Text = "Stok Miktarı:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.Crimson;
            label6.Location = new Point(11, 275);
            label6.Name = "label6";
            label6.Size = new Size(146, 21);
            label6.TabIndex = 0;
            label6.Text = "Stok Seviye Sınırı:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(11, 142);
            label3.Name = "label3";
            label3.Size = new Size(96, 21);
            label3.TabIndex = 0;
            label3.Text = "Birim Fiyat:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.Crimson;
            label5.Location = new Point(11, 231);
            label5.Name = "label5";
            label5.Size = new Size(129, 21);
            label5.TabIndex = 0;
            label5.Text = "İndirim var mı?:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(11, 98);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 0;
            label2.Text = "Birim Adet:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(11, 54);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 0;
            label1.Text = "Ürün:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridProducts);
            groupBox2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            groupBox2.ForeColor = Color.DodgerBlue;
            groupBox2.Location = new Point(492, 0);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(800, 481);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ürünler";
            // 
            // gridProducts
            // 
            gridProducts.AllowUserToAddRows = false;
            gridProducts.AllowUserToDeleteRows = false;
            gridProducts.AllowUserToResizeColumns = false;
            gridProducts.AllowUserToResizeRows = false;
            gridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProducts.Dock = DockStyle.Bottom;
            gridProducts.Location = new Point(3, 32);
            gridProducts.Margin = new Padding(3, 2, 3, 2);
            gridProducts.Name = "gridProducts";
            gridProducts.ReadOnly = true;
            gridProducts.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            gridProducts.RowsDefaultCellStyle = dataGridViewCellStyle1;
            gridProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridProducts.Size = new Size(794, 447);
            gridProducts.TabIndex = 0;
            gridProducts.CellEnter += gridProducts_CellEnter;
            gridProducts.DoubleClick += gridProducts_DoubleClick;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1360, 514);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProductsForm";
            Text = "ProductsForm";
            Load += ProductsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label6;
        private Label label3;
        private Label label5;
        private Label label2;
        private Label label1;
        private ComboBox cmbCategories;
        private RadioButton rbFalse;
        private RadioButton rbTrue;
        private TextBox txtReorderLevel;
        private TextBox txtStock;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtName;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private ComboBox cmbSuppliers;
        private GroupBox groupBox2;
        private DataGridView gridProducts;
        private Button btnStock;
        private TextBox textBox1;
    }
}