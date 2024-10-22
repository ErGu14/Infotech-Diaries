namespace StockMasterApp.Forms
{
    partial class TransactionsForm
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
            cmbProducts = new ComboBox();
            label1 = new Label();
            rbIn = new RadioButton();
            rbOut = new RadioButton();
            label2 = new Label();
            txtQuantity = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            lblCurrentStock = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(12, 43);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(249, 28);
            cmbProducts.TabIndex = 0;
            cmbProducts.SelectedIndexChanged += cmbProducts_SelectedIndexChanged;
            cmbProducts.SelectedValueChanged += cmbProducts_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 1;
            label1.Text = "Ürün";
            // 
            // rbIn
            // 
            rbIn.AutoSize = true;
            rbIn.Checked = true;
            rbIn.Location = new Point(12, 113);
            rbIn.Name = "rbIn";
            rbIn.Size = new Size(59, 24);
            rbIn.TabIndex = 2;
            rbIn.TabStop = true;
            rbIn.Text = "Giriş";
            rbIn.UseVisualStyleBackColor = true;
            // 
            // rbOut
            // 
            rbOut.AutoSize = true;
            rbOut.Location = new Point(77, 113);
            rbOut.Name = "rbOut";
            rbOut.Size = new Size(60, 24);
            rbOut.TabIndex = 2;
            rbOut.Text = "Çıkış";
            rbOut.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(154, 117);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 1;
            label2.Text = "Adet:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(204, 112);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(57, 27);
            txtQuantity.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 176);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Vazgeç";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(167, 176);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblCurrentStock
            // 
            lblCurrentStock.AutoSize = true;
            lblCurrentStock.ForeColor = Color.Crimson;
            lblCurrentStock.Location = new Point(106, 80);
            lblCurrentStock.Name = "lblCurrentStock";
            lblCurrentStock.Size = new Size(17, 20);
            lblCurrentStock.TabIndex = 1;
            lblCurrentStock.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(12, 80);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 1;
            label3.Text = "Geçerli Stok";
            // 
            // TransactionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 240);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtQuantity);
            Controls.Add(rbOut);
            Controls.Add(rbIn);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(lblCurrentStock);
            Controls.Add(label1);
            Controls.Add(cmbProducts);
            Name = "TransactionsForm";
            Text = "Stok Hareketi Ekle";
            Load += TransactionsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbProducts;
        private Label label1;
        private RadioButton rbIn;
        private RadioButton rbOut;
        private Label label2;
        private TextBox txtQuantity;
        private Button btnCancel;
        private Button btnSave;
        private Label lblCurrentStock;
        private Label label3;
    }
}