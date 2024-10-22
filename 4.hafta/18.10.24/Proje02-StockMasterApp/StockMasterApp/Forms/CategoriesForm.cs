using StockMasterApp.Data.Dal;
using StockMasterApp.Models.CategoryModels;
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
    public partial class CategoriesForm : Form
    {
        private CategoryDal categoryDal;
        private bool isEditMode = true;
        public CategoriesForm()
        {
            InitializeComponent();
            categoryDal = new CategoryDal();
        }
        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            List<CategoryModel> categories = categoryDal.GetAll();
            gridCategories.DataSource = categories;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                isEditMode = false;
                btnAdd.Text = "Kaydet";
                txtName.Clear();
                txtDescription.Clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                gridCategories.Enabled = false;
                txtName.Focus();
            }
            else
            {
                //Kaydetme işlemi yapılıyor
                AddCategoryModel model = new()
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };
                var result = categoryDal.CreateOrUpdate(model);
                if (result)
                {
                    MessageBox.Show("Kayıt işlemi başarıyla tamamlanmıştır!");
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Bir sorun oluştu, tekrar deneyiniz!");
                }
                isEditMode = true;
                btnAdd.Text = "Ekle";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                gridCategories.Enabled = true;
            }
        }

        private void gridCategories_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = gridCategories.CurrentRow.Cells[1].Value.ToString();
            txtDescription.Text = gridCategories.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCategoryModel model = new()
            {
                Id = (int)gridCategories.CurrentRow.Cells[0].Value,
                Name = txtName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };
            var result = categoryDal.CreateOrUpdate(model, model.Id);
            if (result)
            {
                MessageBox.Show("Güncelleme işlemi başarıyla tamamlanmıştır!");
                LoadCategories();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = (int)gridCategories.CurrentRow.Cells[0].Value;
            var result = categoryDal.Delete(id);
            if (result)
            {
                MessageBox.Show("Kayıt başarıyla silinmiştir!");
                LoadCategories();
            }
        }
    }
}
