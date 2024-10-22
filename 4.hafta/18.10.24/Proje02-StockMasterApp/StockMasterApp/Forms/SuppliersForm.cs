using StockMasterApp.Data.Dal;
using StockMasterApp.Models.SupplierModels;
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
    public partial class SuppliersForm : Form
    {
        private SupplierDal supplierDal;
        private bool isEditMode = true;
        public SuppliersForm()
        {
            InitializeComponent();
            supplierDal = new SupplierDal();
        }
        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            List<SupplierModel> suppliers = supplierDal.GetAll();
            gridSuppliers.DataSource = suppliers;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                isEditMode = false;
                btnAdd.Text = "Kaydet";
                txtName.Clear();
                txtContactName.Clear();
                txtPhone.Clear();
                txtAddress.Clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                gridSuppliers.Enabled = false;
                txtName.Focus();
            }
            else
            {
                //Kaydetme işlemi yapılıyor
                AddSupplierModel model = new()
                {
                    Name = txtName.Text.Trim(),
                    ContactName = txtContactName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };
                var result = supplierDal.Create(model);
                if (result)
                {
                    MessageBox.Show("Kayıt işlemi başarıyla tamamlanmıştır!");
                    LoadSuppliers();
                }
                else
                {
                    MessageBox.Show("Bir sorun oluştu, tekrar deneyiniz!");
                }
                isEditMode = true;
                btnAdd.Text = "Ekle";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                gridSuppliers.Enabled = true;
            }
        }

        private void gridSuppliers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = gridSuppliers.CurrentRow.Cells[1].Value.ToString();
            txtContactName.Text = gridSuppliers.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = gridSuppliers.CurrentRow.Cells[3].Value.ToString();
            txtAddress.Text = gridSuppliers.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateSupplierModel model = new()
            {
                Id = (int)gridSuppliers.CurrentRow.Cells[0].Value,
                Name = txtName.Text.Trim(),
                ContactName = txtContactName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
            };
            var result = supplierDal.Update(model);
            if (result)
            {
                MessageBox.Show("Güncelleme işlemi başarıyla tamamlanmıştır!");
                LoadSuppliers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = (int)gridSuppliers.CurrentRow.Cells[0].Value;
            var result = supplierDal.Delete(id);
            if (result)
            {
                MessageBox.Show("Kayıt başarıyla silinmiştir!");
                LoadSuppliers();
            }
        }
    }
}
