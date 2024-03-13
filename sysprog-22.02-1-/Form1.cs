using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sysprog_22._02_1_
{
    public partial class Form1 : Form
    {
        DB db;
        Product product;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB db = new DB("Host=localhost;Port=5432;Username=postgres;Password=11111;Database=product;");
            List<Product> product = db.getProduct();

            foreach (Product row in product)
            {
                string image = row.image.ToString();
                string vendor = row.vendor.ToString();
                string name = row.name.ToString();
                string price = row.price.ToString();

                UserControl1 UserControl1 = new UserControl1(image, vendor, name, price);
                flowLayoutPanel1.Controls.Add(UserControl1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB("Host=localhost;Port=5432;Username=postgres;Password=11111;Database=product;");

            string searchKeyword = textBox1.Text.Trim().ToLower(); 
            flowLayoutPanel1.Controls.Clear();
            List<Product> product = db.getProduct();

            foreach (Product row in product)
            {
                string name = row.name.ToString().ToLower(); 
                if (name.Contains(searchKeyword))
                {
                    string imagePath = row.image.ToString();
                    string article = row.vendor.ToString();
                    string price = row.price.ToString();
                    UserControl1 productControl = new UserControl1(imagePath, article, row.name.ToString(), price);
                    flowLayoutPanel1.Controls.Add(productControl);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB("Host=localhost;Port=5432;Username=postgres;Password=11111;Database=product;");

            string selectedSorting = comboBox1.SelectedItem.ToString();
            List<Product> product;


            if (selectedSorting == "А-Я")
            {
                product = db.getProduct().OrderBy(p => p.name).ToList();
            }

            else if (selectedSorting == "Я-А")
            {
                product = db.getProduct().OrderByDescending(p => p.name).ToList();
            }
            else
            {
                product = db.getProduct().ToList();
            }

            flowLayoutPanel1.Controls.Clear();
            foreach (Product prod in product)
            {
                string image = prod.image.ToString();
                string vendor = prod.vendor.ToString();
                string price = prod.price.ToString();
                UserControl1 productControl = new UserControl1(image, vendor, prod.name.ToString(), price);
                flowLayoutPanel1.Controls.Add(productControl);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB("Host=localhost;Port=5432;Username=postgres;Password=11111;Database=product;");

            string selectedSorting = comboBox2.SelectedItem.ToString();
            List<Product> products;

            
            products = db.getProduct().ToList();

            
            if (selectedSorting == "По убыванию")
            {
                products = products.OrderBy(p => p.price).ToList(); 
            }
            else if (selectedSorting == "По возрастанию")
            {
                products = products.OrderByDescending(p => p.price).ToList(); 
            }

            flowLayoutPanel1.Controls.Clear();

            foreach (Product prod in products)
            {
                string image = prod.image.ToString();
                string vendor = prod.vendor.ToString();
                string price = prod.price.ToString();
                UserControl1 productControl = new UserControl1(image, vendor, prod.name.ToString(), price);
                flowLayoutPanel1.Controls.Add(productControl);
            }
        }
    }
}




