using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Question_1.Models;

namespace Question_1
{
    public partial class AddProductForm : Form
    {

        private List<Product> products;

        // constructor
        public AddProductForm()
        {
            InitializeComponent();
            products = new List<Product>();
        }

        /// <summary>
        /// Load data from List to data grid view
        /// </summary>
        private void LoadData()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = products;

            dgvProduct.DataSource = bindingSource;
        }

        /// <summary>
        /// Read all product infos in form, and return the created product
        /// Co che hoat dong cua Radio Button: Chi chon duoc 1 radio button cho 1 parent (groupbox, etc. )
        /// </summary>
        /// <returns></returns>
        private Product ReadProduct()
        {
            int productID = int.Parse(txtId.Text);
            string productName = txtName.Text;
            double price = double.Parse(txtPrice.Text);
            bool isActive = false;
            if (rdTrue.Checked)
            {
                isActive = true;
            }

            Product product = new Product
            {
                ProductId = productID,
                ProductName = productName,
                Price = price,
                IsActive = isActive
            };

            return product;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = ReadProduct();
            products.Add(product);
            LoadData();
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if(products.Count == 0)
            {
                MessageBox.Show("Empty list");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextWriter writer = new StreamWriter(saveFileDialog.FileName);
                writer.WriteLine(readDatabase());
                MessageBox.Show("Ghi file thanh cong");
                writer.Close();
            }
        }

        private string readDatabase()
        {
            string str = "";
            for(int i = 0; i < products.Count; i++)
            {
                str += products[i].ToString();
                str += '\n';
            }
            return str;
        }
    }
}
