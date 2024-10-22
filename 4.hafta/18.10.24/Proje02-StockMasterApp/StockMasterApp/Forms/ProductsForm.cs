using StockMasterApp.Data.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMasterApp.Forms
{
    public partial class ProductsForm : Form
    {
        private ProductDal productDal;
        private CategoryDal categoryDal;
        private SupplierDal supplierDal;

        private bool isEditMode = true;
        public ProductsForm()
        {
            InitializeComponent();
            productDal = new ProductDal();
            categoryDal = new CategoryDal();
            supplierDal = new SupplierDal();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
            LoadSuppliers();
        }

        private void LoadProducts()
        {
            var products = productDal.GetAll();
            gridProducts.DataSource = products;
            gridProducts.Columns[0].Visible = false;
            gridProducts.Columns[3].Visible = false;
            gridProducts.Columns[5].Visible = false;

            gridProducts.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridProducts.Columns["Category"].Width = 180;
            gridProducts.Columns["Supplier"].Width = 180;
            gridProducts.Columns["UnitPrice"].Width = 100;

            gridProducts.Columns["Name"].HeaderText = "Ürün";
            gridProducts.Columns["UnitPrice"].HeaderText = "Fiyat";
            gridProducts.Columns["Category"].HeaderText = "Kategori";
            gridProducts.Columns["Supplier"].HeaderText = "Tedarikçi";

            foreach (DataGridViewRow row in gridProducts.Rows)
            {
                int reorder = (int)row.Cells["Reorder"].Value;
                if (reorder < 0)
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
            gridProducts.CurrentCell = gridProducts.Rows[0].Cells[1];
        }

        private void gridProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)gridProducts.CurrentRow.Cells[0].Value;
            var product = productDal.GetById(id);

            txtName.Text = product.Name;
            txtPrice.Text = product.UnitPrice.ToString("N2");
            txtQuantity.Text = product.QuantityPerUnit;
            txtReorderLevel.Text = product.ReorderLevel.ToString();
            txtStock.Text = product.UnitsInStock.ToString();

            rbTrue.Checked = product.Discounted;
            rbFalse.Checked = !product.Discounted;

            cmbCategories.SelectedValue = gridProducts.CurrentRow.Cells["CategoryId"].Value;
            cmbSuppliers.SelectedValue = gridProducts.CurrentRow.Cells["SupplierId"].Value;

        }

        private void LoadCategories()
        {
            var categories = categoryDal.GetAll();
            cmbCategories.DataSource = categories;
            cmbCategories.ValueMember = "Id";
            cmbCategories.DisplayMember = "Name";
        }

        private void LoadSuppliers()
        {
            var suppliers = supplierDal.GetAll();
            cmbSuppliers.DataSource = suppliers;
            cmbSuppliers.ValueMember = "Id";
            cmbSuppliers.DisplayMember = "Name";
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            
            //TransactionsForm transactionsForm = new TransactionsForm(productId);
            TransactionsForm transactionsForm = new TransactionsForm();
            int productId = Convert.ToInt32(gridProducts.CurrentRow.Cells[0].Value);
            transactionsForm.Show();
            transactionsForm.ProductId = productId;






        }

        private void gridProducts_DoubleClick(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(gridProducts.CurrentRow.Cells[0].Value);
            MessageBox.Show(productId.ToString());
            //btnStock.Click +=
        }
    }
}
