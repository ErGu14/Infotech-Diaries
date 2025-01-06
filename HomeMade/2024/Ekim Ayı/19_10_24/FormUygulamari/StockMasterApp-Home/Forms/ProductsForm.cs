using Microsoft.VisualStudio.Shell.Interop;
using StockMasterApp_Home.DataS.DAL;
using StockMasterApp_Home.Models.CategoryModels;
using StockMasterApp_Home.Models.ProductModels;
using StockMasterApp_Home.Models.SupplierModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMasterApp_Home.Forms
{
    public partial class ProductsForm : Form
    {
        private bool name;

        public ProductsForm()
        {
            InitializeComponent();
            txtSearch.Text = "Ürün Adını Giriniz";
            txtSearch.ForeColor = Color.LightGray;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Ürün Adını Giriniz")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Ürün Adını Giriniz";
                txtSearch.ForeColor = Color.LightGray;
            }
        }

        private void ProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            ProductDAL productDAL = new ProductDAL();
            List<ProductModel> products = productDAL.GetAll();
            LoadProducts(products);

            CategoryDAL categoryDAL = new CategoryDAL();
            List<CategoryModel> categories = categoryDAL.GetAll();
            LoadCategories(categories);

            SupplierDAL supplierDAL = new SupplierDAL();
            List<SupplierModel> suppliers = supplierDAL.GetAll();
            LoadSupplier(suppliers);

        }
        private void LoadProducts(List<ProductModel> product) // load yapacağım şeyin TİPİ de önemli (tip veya tür baştaki değer)
        {
            dgvProducts.DataSource = product;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Columns[0].Visible = false;
            dgvProducts.Columns[7].Visible = false;
            dgvProducts.Columns[9].Visible = false;
            dgvProducts.Columns[1].HeaderText = "Ürün Adı";
            dgvProducts.Columns[2].HeaderText = "Birim Başına Miktarı";
            dgvProducts.Columns[3].HeaderText = "Fiyatı";
            dgvProducts.Columns[4].HeaderText = "Stok Miktarı";
            dgvProducts.Columns[5].HeaderText = "İndirimde Mi?";
            dgvProducts.Columns[6].HeaderText = "Miktar Seviyesi";
            dgvProducts.Columns[8].HeaderText = "Kategori Adı";
            dgvProducts.Columns[10].HeaderText = "Tedarikçi Adı";

        }
        private void dgvProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            txtName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtQuantity.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = Convert.ToDouble(dgvProducts.CurrentRow.Cells[3].Value).ToString("N2");
            txtStock.Text = Convert.ToInt32(dgvProducts.CurrentRow.Cells[4].Value).ToString();
            txtRecorder.Text = Convert.ToInt32(dgvProducts.CurrentRow.Cells[6].Value).ToString();
            cmbCategory.SelectedValue = Convert.ToInt32(dgvProducts.CurrentRow.Cells[7].Value); // seçilen kategorinin ıd sini int tipinden alıyoruz aşağıdaki tanımlamada ise ıd yi name ile değiştir yaptık.
            cmbSupplier.SelectedValue = Convert.ToInt32(dgvProducts.CurrentRow.Cells[9].Value);
        }

        private void LoadCategories(List<CategoryModel> model)
        {
            cmbCategory.DataSource = model.ToList();
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";

        }
        private void LoadSupplier(List<SupplierModel> model)
        {
            cmbSupplier.DataSource = model.ToList();
            cmbSupplier.ValueMember = "Id";
            cmbSupplier.DisplayMember = "Name";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string textSearch = txtSearch.Text.Trim();
            if (textSearch.Length > 0)
            {
                ProductDAL productDAL = new ProductDAL();
                List<ProductModel> products = productDAL.GetAll(textSearch, rbWithStart.Checked);
                LoadProducts(products);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            rbWithStart.Checked = true;
            txtSearch.Text = "Ürün Adını Giriniz";
            txtSearch.ForeColor = Color.LightGray;
            ProductDAL productDAL = new ProductDAL();
            List<ProductModel> products = productDAL.GetAll();
            LoadProducts(products);
            txtName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtQuantity.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = Convert.ToDouble(dgvProducts.CurrentRow.Cells[3].Value).ToString("N2");
            txtStock.Text = Convert.ToInt32(dgvProducts.CurrentRow.Cells[4].Value).ToString();
            txtRecorder.Text = Convert.ToInt32(dgvProducts.CurrentRow.Cells[6].Value).ToString();
            cmbCategory.SelectedValue = Convert.ToInt32(dgvProducts.CurrentRow.Cells[7].Value); // seçilen kategorinin ıd sini int tipinden alıyoruz aşağıdaki tanımlamada ise ıd yi name ile değiştir yaptık.


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "EKLE")
            {
                btnAdd.Text = "KAYDET";
                btnUpdate.Enabled = false;
                btnDelProd.Enabled = false;
                txtSearch.Enabled = false;
                rbWithStart.Enabled = false;
                rbContains.Enabled = false;
                btnSearch.Enabled = false;
                btnDelete.Enabled = false;
                btnBack.Enabled = false;
                txtName.Clear();
                txtQuantity.Clear();
                txtPrice.Clear();
                txtStock.Clear();
                txtRecorder.Clear();
                cmbCategory.SelectedIndex = 0;
                cmbSupplier.SelectedIndex = 0;

            }
            else if (btnAdd.Text == "KAYDET")
            {
                btnAdd.Text = "EKLE";
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtQuantity.Text.Trim())
                    || string.IsNullOrEmpty(txtPrice.Text.Trim())
                    || string.IsNullOrEmpty(txtStock.Text.Trim())
                    || string.IsNullOrEmpty(txtRecorder.Text.Trim()))
                {

                    MessageBox.Show("Lütfen Bilgileri Boş Bırakmayınız!", "Uyarı");
                }
                btnUpdate.Enabled = true;
                btnDelProd.Enabled = true;
                txtSearch.Enabled = true;
                rbWithStart.Enabled = true;
                rbContains.Enabled = true;
                btnSearch.Enabled = true;
                btnDelete.Enabled = true;
                btnBack.Enabled = true;
                ProductDAL productDAL = new ProductDAL();
                AddProductModel addproductModel = new AddProductModel
                {

                    Name = txtName.Text.Trim(),
                    QuantityPerUnit = txtQuantity.Text.Trim(),
                    UnitPrice = Convert.ToDecimal(txtPrice.Text.Trim()),
                    UnitsInStock = Convert.ToInt32(txtStock.Text.Trim()),
                    Discounted = false,
                    ReorderLevel = Convert.ToInt32(txtRecorder.Text.Trim()),
                    CategoryId = Convert.ToInt32(cmbCategory.SelectedValue),

                    SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue),




                };
                productDAL.Create(addproductModel);
                var result = productDAL.GetAll();
                LoadProducts(result);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductDAL productDAL = new ProductDAL();
            UpdateProductModel updateProductModel = new UpdateProductModel
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value),
                Name = txtName.Text.Trim(),
                QuantityPerUnit = txtQuantity.Text.Trim(),
                UnitPrice = Convert.ToDecimal(txtPrice.Text.Trim()),
                UnitsInStock = Convert.ToInt32(txtStock.Text.Trim()),
                Discounted = false,
                ReorderLevel = Convert.ToInt32(txtRecorder.Text.Trim()),
                CategoryId = Convert.ToInt32(cmbCategory.SelectedValue), // parantez içindeki cmb kategorideki seçilen değeri int e çevir ve kategori ID olarak tanımla
                SupplierId = Convert.ToInt32(cmbSupplier.SelectedValue),

            };
            productDAL.Update(updateProductModel);
            var result = productDAL.GetAll();
            LoadProducts(result);
        }

        private void btnDelProd_Click(object sender, EventArgs e)
        {
            var mesasage = MessageBox.Show("Seçtiğiniz Ürün Kalıcı Olarak Silinecektir Emin Misiniz?", "Uyarı",MessageBoxButtons.YesNo);
            if (mesasage == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
                ProductDAL productDAL = new ProductDAL();
                productDAL.Delete(id);
                var products = productDAL.GetAll();
                LoadProducts(products);

            }
        
    }
    }
}
