namespace NorthwiwndTest
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnAdd = new Button();
            btnUptade = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            btnClear = new Button();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            txtSearch = new TextBox();
            rbWithStart = new RadioButton();
            rbContains = new RadioButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            cmbCategories = new ComboBox();
            cmbFilter = new ComboBox();
            dgvProducts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 22);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Ürün Adı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 60);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 0;
            label2.Text = "Kategori :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(370, 28);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 1;
            label3.Text = "Fiyat :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 66);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 2;
            label4.Text = "Stok :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 181);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 3;
            label5.Text = "Ürün Arama";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(448, 172);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 4;
            label6.Text = "Kategori Seç";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(43, 104);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 52);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Yeni Ürün Ekleme";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUptade
            // 
            btnUptade.Location = new Point(228, 104);
            btnUptade.Margin = new Padding(3, 2, 3, 2);
            btnUptade.Name = "btnUptade";
            btnUptade.Size = new Size(139, 52);
            btnUptade.TabIndex = 6;
            btnUptade.Text = "Ürün Güncelleme";
            btnUptade.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(417, 104);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 52);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Ürünü Sil";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(330, 172);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(81, 29);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "ARA";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(330, 207);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(81, 32);
            btnClear.TabIndex = 12;
            btnClear.Text = "TEMİZLE";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(107, 23);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(178, 23);
            txtName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(448, 26);
            txtPrice.Margin = new Padding(3, 2, 3, 2);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(110, 23);
            txtPrice.TabIndex = 3;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(448, 60);
            txtStock.Margin = new Padding(3, 2, 3, 2);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(110, 23);
            txtStock.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(33, 213);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(252, 23);
            txtSearch.TabIndex = 10;
            // 
            // rbWithStart
            // 
            rbWithStart.AutoSize = true;
            rbWithStart.Checked = true;
            rbWithStart.Location = new Point(107, 179);
            rbWithStart.Margin = new Padding(3, 2, 3, 2);
            rbWithStart.Name = "rbWithStart";
            rbWithStart.Size = new Size(80, 19);
            rbWithStart.TabIndex = 8;
            rbWithStart.TabStop = true;
            rbWithStart.Text = "...ile başlar";
            rbWithStart.UseVisualStyleBackColor = true;
            // 
            // rbContains
            // 
            rbContains.AutoSize = true;
            rbContains.Location = new Point(216, 178);
            rbContains.Margin = new Padding(3, 2, 3, 2);
            rbContains.Name = "rbContains";
            rbContains.Size = new Size(66, 19);
            rbContains.TabIndex = 9;
            rbContains.Text = "..içerir...";
            rbContains.UseVisualStyleBackColor = true;
            // 
            // cmbCategories
            // 
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(107, 60);
            cmbCategories.Margin = new Padding(3, 2, 3, 2);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(178, 23);
            cmbCategories.TabIndex = 2;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(436, 207);
            cmbFilter.Margin = new Padding(3, 2, 3, 2);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(133, 23);
            cmbFilter.TabIndex = 13;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeColumns = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Bottom;
            dgvProducts.ImeMode = ImeMode.NoControl;
            dgvProducts.Location = new Point(0, 256);
            dgvProducts.Margin = new Padding(3, 2, 3, 2);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(700, 145);
            dgvProducts.TabIndex = 11;
            dgvProducts.CellEnter += dgvProducts_CellEnter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 401);
            Controls.Add(dgvProducts);
            Controls.Add(cmbFilter);
            Controls.Add(cmbCategories);
            Controls.Add(rbContains);
            Controls.Add(rbWithStart);
            Controls.Add(txtSearch);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnUptade);
            Controls.Add(btnAdd);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "+";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnAdd;
        private Button btnUptade;
        private Button btnDelete;
        private Button btnSearch;
        private Button btnClear;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtStock;
        private TextBox txtSearch;
        private RadioButton rbWithStart;
        private RadioButton rbContains;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox cmbCategories;
        private ComboBox cmbFilter;
        private DataGridView dgvProducts;
    }
}
