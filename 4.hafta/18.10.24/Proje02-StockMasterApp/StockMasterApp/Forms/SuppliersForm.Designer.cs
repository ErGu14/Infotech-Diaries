namespace StockMasterApp.Forms
{
    partial class SuppliersForm
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
            txtContactName = new TextBox();
            txtName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            gridSuppliers = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).BeginInit();
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
            label1.Text = "Tedarikçiler";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(txtContactName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 250);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tedarikçi Ekle/Düzenle";
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
            // txtContactName
            // 
            txtContactName.Location = new Point(25, 144);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(155, 27);
            txtContactName.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(25, 74);
            txtName.Name = "txtName";
            txtName.Size = new Size(155, 27);
            txtName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 110);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 1;
            label3.Text = "Kontak Kişi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 42);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 0;
            label2.Text = "Tedarikçi Adı:";
            // 
            // gridSuppliers
            // 
            gridSuppliers.AllowUserToAddRows = false;
            gridSuppliers.AllowUserToDeleteRows = false;
            gridSuppliers.AllowUserToResizeColumns = false;
            gridSuppliers.AllowUserToResizeRows = false;
            gridSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSuppliers.Location = new Point(430, 66);
            gridSuppliers.Name = "gridSuppliers";
            gridSuppliers.ReadOnly = true;
            gridSuppliers.RowHeadersWidth = 51;
            gridSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSuppliers.Size = new Size(434, 240);
            gridSuppliers.TabIndex = 2;
            gridSuppliers.CellEnter += gridSuppliers_CellEnter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(201, 42);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 0;
            label4.Text = "Telefon:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(201, 110);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 1;
            label5.Text = "Adres:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(205, 74);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(155, 27);
            txtPhone.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(205, 144);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(155, 27);
            txtAddress.TabIndex = 2;
            // 
            // SuppliersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 332);
            Controls.Add(gridSuppliers);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "SuppliersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StockMasterApp-Kategoriler";
            Load += SuppliersForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtContactName;
        private TextBox txtName;
        private Label label3;
        private Label label2;
        private DataGridView gridSuppliers;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private Label label5;
        private Label label4;
    }
}