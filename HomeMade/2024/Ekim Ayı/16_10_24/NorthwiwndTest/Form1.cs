using NorthwiwndTest.DataAccessLayer;
using NorthwiwndTest.Models;
using System.Data;
using System.DirectoryServices.ActiveDirectory;

namespace NorthwiwndTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Productdal içinde verilerimiz var
            ProductDAL productDAL = new ProductDAL();
            DataTable product = productDAL.GetAll();
            LoadProducts(product);

            CategoryDAL categoryDAL = new CategoryDAL();
            LinkedList<Category> categories = categoryDAL.GetAll();
            LoadCategories(categories);


        }
        private void LoadProducts(DataTable product)
        {

            dgvProducts.DataSource = product; //dgv nin data kaynaðýný productsdan al
            dgvProducts.Columns["Id"].Width = 150;
            dgvProducts.Columns["Ürün"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProducts.Columns["Fiyat"].Width = 80;
            dgvProducts.Columns["Fiyat"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["Fiyat"].HeaderText = "Price";
            dgvProducts.Columns["Stok"].Width = 60;
            dgvProducts.Columns["KategoriId"].Visible = false;
            dgvProducts.Columns["Kategori"].Width = 150;


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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();

            if (search.Length > 0)
            {
                ProductDAL productDAL = new ProductDAL();
                DataTable product = productDAL.GetAll(search, rbWithStart.Checked);
                LoadProducts(product);



            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            // rbWithStart.Checked = true;   -- en baþa yani ...ile baþlar a çekmek için yapýlýr.
            txtSearch.Focus();
            ProductDAL productDAL = new ProductDAL();
            DataTable product = productDAL.GetAll();
            LoadProducts(product);
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDAL productDAL = new ProductDAL();
            DataTable product;
            if (cmbFilter.SelectedIndex == 0)
            {
                product = productDAL.GetAll();
            }
            else
            {
                int categoryId = Convert.ToInt32(cmbFilter.SelectedValue);
                product = productDAL.GetAll(categoryId);
            }
            LoadProducts(product);
        }

        private void dgvProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = Convert.ToDouble(dgvProducts.CurrentRow.Cells[2].Value).ToString("N2");
            txtStock.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            cmbCategories.SelectedValue = dgvProducts.CurrentRow.Cells["KategoriId"].Value;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Kaydet")
            {
                if (String.IsNullOrEmpty(txtName.Text.Trim()) || String.IsNullOrEmpty(txtPrice.Text.Trim()) || String.IsNullOrEmpty(txtStock.Text.Trim()) ) {
                    MessageBox.Show("Boþ Alanlarý Doldurun");
                    return;
                
                }
                AddProduct addProduct = new AddProduct {
                    Name = txtName.Text.Trim(),
                    Price = Convert.ToDouble(txtPrice.Text),
                    Stock = Convert.ToInt32(txtStock.Text.Trim()),
                    CategoryId = Convert.ToInt32(cmbCategories.SelectedValue)
                };
                ProductDAL productDAL = new ProductDAL();
                productDAL.Create(addProduct);


                btnAdd.Text = "Yeni Ürün Ekle";
                btnUptade.Enabled = true;
                btnDelete.Enabled = true;

            }
            else
            {
                btnAdd.Text = "Kaydet";
                txtName.Clear();
                txtPrice.Clear();
                txtStock.Clear();
                cmbCategories.SelectedIndex = 0;
                txtName.Focus();
                btnUptade.Enabled = false;
                btnDelete.Enabled = false;

            }
        }
    }
}
