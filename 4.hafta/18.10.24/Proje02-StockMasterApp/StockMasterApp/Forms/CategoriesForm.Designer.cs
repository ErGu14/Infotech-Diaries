namespace StockMasterApp.Forms
{
    partial class CategoriesForm
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
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtDescription = new TextBox();
            txtName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            gridCategories = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCategories).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(885, 53);
            label1.TabIndex = 0;
            label1.Text = "Kategoriler";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 250);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kategori Ekle/Düzenle";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(280, 200);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(155, 200);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 200);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(25, 144);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(349, 27);
            txtDescription.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(25, 74);
            txtName.Name = "txtName";
            txtName.Size = new Size(349, 27);
            txtName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 110);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 1;
            label3.Text = "Açıklama:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 42);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 0;
            label2.Text = "Kategori Adı:";
            // 
            // gridCategories
            // 
            gridCategories.AllowUserToAddRows = false;
            gridCategories.AllowUserToDeleteRows = false;
            gridCategories.AllowUserToResizeColumns = false;
            gridCategories.AllowUserToResizeRows = false;
            gridCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCategories.Location = new Point(430, 66);
            gridCategories.Name = "gridCategories";
            gridCategories.ReadOnly = true;
            gridCategories.RowHeadersWidth = 51;
            gridCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCategories.Size = new Size(434, 240);
            gridCategories.TabIndex = 2;
            gridCategories.CellEnter += gridCategories_CellEnter;
            // 
            // CategoriesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 332);
            Controls.Add(gridCategories);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "CategoriesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockMasterApp-Kategoriler";
            Load += CategoriesForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridCategories).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtDescription;
        private TextBox txtName;
        private Label label3;
        private Label label2;
        private DataGridView gridCategories;
    }
}