using StockMasterApp.Data.Dal;
using StockMasterApp.Models.StockTransactionModels;
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

    public partial class TransactionsForm : Form
    {
        private StockTransactionDal stockTransactionDal;
        private ProductDal productDal;
        public int? ProductId { get; set; } = null;


        public TransactionsForm()
        {
            InitializeComponent();
            stockTransactionDal = new StockTransactionDal();
            productDal = new ProductDal();
            



        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            var type = rbIn.Checked ? "IN" : "OUT";
            AddStockTransactionModel model = new()
            {
                ProductId = Convert.ToInt32(cmbProducts.SelectedValue),
                Quantity = Convert.ToInt32(txtQuantity.Text),
                TransactionType = type
            };
            bool result = stockTransactionDal.AddTransaction(model);


            if (result)
            {
                if (MessageBox.Show("Stok hareketi başarıyla kaydedilmiştir! Yeni stok hareketi eklemek istiyor musunuz?", "Başarılı!", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Stok miktarı yeterli değildir!");
            }
        }

        private void TransactionsForm_Load(object sender, EventArgs e)
        {
            var products = productDal.GetAll();
            cmbProducts.DataSource = products;
            cmbProducts.ValueMember = "Id";
            cmbProducts.DisplayMember = "Name";

             if(ProductId != null)cmbProducts.SelectedValue = ProductId;

        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(cmbProducts.SelectedValue);
                var currentStock = productDal.GetCurrentStockById(id);
                lblCurrentStock.Text = currentStock.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        private void cmbProducts_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
    //public partial class TransactionsForm : Form
    //{
    //    private StockTransactionDal stockTransactionDal;
    //    private ProductDal productDal;
    //    private int? productId;

    //    public TransactionsForm(int? ProductId = null)
    //    {
    //        InitializeComponent();
    //        stockTransactionDal = new StockTransactionDal();
    //        productDal = new ProductDal();
    //        this.productId = ProductId;



    //    }


    //    private void btnSave_Click(object sender, EventArgs e)
    //    {
    //        var type = rbIn.Checked ? "IN" : "OUT";
    //        AddStockTransactionModel model = new()
    //        {
    //            ProductId = Convert.ToInt32(cmbProducts.SelectedValue),
    //            Quantity = Convert.ToInt32(txtQuantity.Text),
    //            TransactionType = type
    //        };
    //        bool result = stockTransactionDal.AddTransaction(model);


    //        if (result)
    //        {
    //            if (MessageBox.Show("Stok hareketi başarıyla kaydedilmiştir! Yeni stok hareketi eklemek istiyor musunuz?", "Başarılı!", MessageBoxButtons.YesNo) == DialogResult.No)
    //            {
    //                this.Hide();
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Stok miktarı yeterli değildir!");
    //        }
    //    }

    //    private void TransactionsForm_Load(object sender, EventArgs e)
    //    {
    //        var products = productDal.GetAll();
    //        cmbProducts.DataSource = products;
    //        cmbProducts.ValueMember = "Id";
    //        cmbProducts.DisplayMember = "Name";

    //        if(productId != null) cmbProducts.SelectedValue = productId;

    //    }

    //    private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        int id;
    //        try
    //        {
    //            id = Convert.ToInt32(cmbProducts.SelectedValue);
    //            var currentStock = productDal.GetCurrentStockById(id);
    //            lblCurrentStock.Text = currentStock.ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }



    //    }

    //    private void cmbProducts_SelectedValueChanged(object sender, EventArgs e)
    //    {

    //    }
    //}
}
