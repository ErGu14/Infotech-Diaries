using StockMasterApp_Home.DataS.DAL;
using StockMasterApp_Home.Models.CategoryModels;
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
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();


        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();

        }
        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            CategoryDAL categoryDAL = new CategoryDAL();
            List<CategoryModel> categories = categoryDAL.GetAll();
            LoadCategories(categories);
        }
        private void LoadCategories(List<CategoryModel> model)
        {
            dgvCategories.DataSource = model;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Columns[0].Visible = false;
            dgvCategories.Columns[1].HeaderText = "Kategori Adı";
            dgvCategories.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCategories.Columns[2].HeaderText = "Açıklama";

        }

        private void dgvCategories_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvCategories.CurrentRow.Cells[1].Value.ToString();
            txtDesc.Text = dgvCategories.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "EKLE")
            {
                btnAdd.Text = "KAYDET";
                txtName.Clear();
                txtDesc.Clear();
                txtName.Focus();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (btnAdd.Text == "KAYDET")
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtDesc.Text.Trim()))
                {
                    MessageBox.Show("Lütfen Bilgilerinizi Kontrol ediniz");
                    return;
                }

                AddCategoryModel model = new AddCategoryModel // değerli modele at
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDesc.Text.Trim()
                };

                CategoryDAL categoryDAL = new CategoryDAL(); // create komudunu çağır
                categoryDAL.Create(model); // createnin içine at

                btnAdd.Text = "EKLE";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                var category = categoryDAL.GetAll(); // kategoriyi getir
                LoadCategories(category);// getirilenleri yazdır

                txtName.Text = dgvCategories.CurrentRow.Cells[1].Value.ToString();
                txtDesc.Text = dgvCategories.CurrentRow.Cells[2].Value.ToString();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "GÜNCELLE")
            {
                btnUpdate.Text = "KAYDET";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                txtName.Focus();
            }
            else if (btnUpdate.Text == "KAYDET")
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtDesc.Text.Trim()))
                {
                    MessageBox.Show("Lütfen Bilgilerinizi Kontrol ediniz");
                    return;
                }
                UpdateCategoryModel model = new UpdateCategoryModel //model kemiğine değerleri ata
                {
                    Id = Convert.ToInt32(dgvCategories.CurrentRow.Cells[0].Value),
                    Name = txtName.Text.Trim(),
                    Description = txtDesc.Text.Trim(),
                };
                CategoryDAL categoryDAL = new CategoryDAL(); // update metodunu getir
                categoryDAL.Update(model);
                var category = categoryDAL.GetAll(); //güncellenen ürünleri getir
                LoadCategories(category);//getirilen ürünleri yansıt

                btnUpdate.Text = "GÜNCELLE";
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                txtName.Text = dgvCategories.CurrentRow.Cells[1].Value.ToString();
                txtDesc.Text = dgvCategories.CurrentRow.Cells[2].Value.ToString();



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Silmek İstediğinden Emin Misin?", "Dikkat", MessageBoxButtons.YesNo);// ilk mesaj sonra hata mesajı kutusu başlığı sonra evet hayır.
            if (message == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells[0].Value); // ilk olarak delete metodu için bir id tanımla sonra tanımlı id yi sil komudu ver.
                CategoryDAL categoryDAL = new CategoryDAL();
                //delete de model olmadığı için direkt DAL çağırabilirsin o DAL ın içine de id yi yaz
                categoryDAL.Delete(id);  // seçili id sil
                var category = categoryDAL.GetAll();// güncellenen ürünleri getir.
                LoadCategories(category);// getirilen ürünleri yansıt.
            }
        }

        private void CategoriesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
