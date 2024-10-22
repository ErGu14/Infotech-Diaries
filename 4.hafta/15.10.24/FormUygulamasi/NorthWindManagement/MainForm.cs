using NorthwindManagement.DataAccessLayer;
using NorthwindManagement.Models;
using System.Data;

namespace NorthwindManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProductDAL productDAL = new ProductDAL();
            DataTable products = productDAL.GetAll();
            LoadProducts(products);

            CategoryDAL categoryDAL = new CategoryDAL();
            LinkedList<Category> categories = categoryDAL.GetAll();
            LoadCategories(categories);

        }

        private void LoadCategories(LinkedList<Category> categories)
        {
            cmbCategories.DataSource = categories.ToList();
            cmbCategories.ValueMember = "Id";
            cmbCategories.DisplayMember = "Name";

            categories.AddFirst(new Category { Id = 0, Name = "Hepsi" });
            cmbFilter.DataSource = categories.ToList();
            cmbFilter.ValueMember = "Id";
            cmbFilter.DisplayMember = "Name";
        }

        private void LoadProducts(DataTable products)
        {
            dgvProducts.DataSource = products;
            dgvProducts.Columns["Id"].Width = 50;

            dgvProducts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProducts.Columns["Name"].HeaderText = "Ürün";

            dgvProducts.Columns["Price"].Width = 80;
            dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["Price"].HeaderText = "Fiyat";

            dgvProducts.Columns["Stock"].Width = 70;
            dgvProducts.Columns["Stock"].HeaderText = "Stok";

            dgvProducts.Columns["CategoryId"].Visible = false;

            dgvProducts.Columns["Category"].Width = 150;
            dgvProducts.Columns["Category"].HeaderText = "Kategori";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (searchText.Length > 0)
            {
                ProductDAL product = new ProductDAL();
                DataTable products = product.GetAll(searchText, rbWithStart.Checked);
                LoadProducts(products);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            rbWithStart.Checked = true;
            txtSearch.Focus();
            ProductDAL productDAL = new ProductDAL();
            DataTable products = productDAL.GetAll();
            LoadProducts(products);
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDAL productDal = new ProductDAL();
            DataTable products;
            if (cmbFilter.SelectedIndex == 0)
            {
                products = productDal.GetAll();
            }
            else
            {
                int categoryId = Convert.ToInt32(cmbFilter.SelectedValue);
                products = productDal.GetAll(categoryId);
            }
            LoadProducts(products);
        }

        private void dgvProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = Convert.ToDouble(dgvProducts.CurrentRow.Cells[2].Value).ToString("N2");
            txtStock.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            cmbCategories.SelectedValue = dgvProducts.CurrentRow.Cells["CategoryId"].Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Kaydet")
            {
                if (
                    String.IsNullOrEmpty(txtName.Text.Trim()) ||
                    String.IsNullOrEmpty(txtPrice.Text.Trim()) ||
                    String.IsNullOrEmpty(txtStock.Text.Trim())
                    )
                {
                    MessageBox.Show("Lütfen bilgileri eksiksiz þekilde doldurunuz");
                    return;
                }
                AddProductModel addProductModel = new AddProductModel
                {
                    Name = txtName.Text.Trim(),
                    Price = Convert.ToDouble(txtPrice.Text.Trim()),
                    Stock = Convert.ToInt32(txtStock.Text.Trim()),
                    CategoryId = Convert.ToInt32(cmbCategories.SelectedValue)
                };
                ProductDAL productDAL = new ProductDAL();
                productDAL.Create(addProductModel);

                btnAdd.Text = "Yeni Ürün Ekle";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                allControls.Enabled = true;
                var products = productDAL.GetAll();
                LoadProducts(products);
            }
            else
            {
                btnAdd.Text = "Kaydet";
                txtName.Clear();
                txtPrice.Clear();
                txtStock.Clear();
                cmbCategories.SelectedIndex = 0;
                txtName.Focus();
                allControls.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProductModel updateProductModel = new UpdateProductModel
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value),
                Name = txtName.Text.Trim(),
                Price = Convert.ToDouble(txtPrice.Text.Trim()),
                Stock = Convert.ToInt32(txtStock.Text.Trim()),
                CategoryId = Convert.ToInt32(cmbCategories.SelectedValue)
            };
            ProductDAL productDAL = new ProductDAL();
            productDAL.Update(updateProductModel);
            var products = productDAL.GetAll();
            LoadProducts(products);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Silmek Ýstediðinden Emin Misin?", "Dikkat!",MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes) {
                int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["Id"].Value);
                ProductDAL productDAL = new ProductDAL();
                productDAL.Delete(productId);
                var products = productDAL.GetAll();
                LoadProducts(products);
            }
            
        }
    }
}
