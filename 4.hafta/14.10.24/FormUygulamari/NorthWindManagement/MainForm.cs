using NorthWindManagement.DataAccessLayer;
using NorthWindManagement.Models;
using System.Data;

namespace NorthWindManagement
{
    public partial class Form1Main : Form
    {
        public Form1Main()
        {
            InitializeComponent();
        }

        private void Form1Main_Load(object sender, EventArgs e)
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

            categories.AddFirst(new Category { Id = 0, Name = "Hepsi", Description = "Tüm Ürünler" });
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
            dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["Price"].HeaderText = "Fiyat";
            dgvProducts.Columns["Stock"].Width = 70;
            dgvProducts.Columns["CategoryId"].Visible = false;
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (searchText.Length > 0)
            {
                ProductDAL productDAL = new ProductDAL();
                DataTable products = productDAL.GetAll(searchText, rbWithStart.Checked);
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
            ProductDAL productDAL = new ProductDAL();
            DataTable products;

            if (cmbFilter.SelectedIndex == 0)
            {
                products = productDAL.GetAll();
            }
            else {
                int categoryId = Convert.ToInt32(cmbFilter.SelectedValue);
                products = productDAL.GetAll(categoryId);
                

            }
            LoadProducts(products);

        }
    }
}
