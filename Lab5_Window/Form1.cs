using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_Window
{
    public partial class Form1 : Form
    {
        private string currentFilter = "";
        private List<Product> loadedProducts = new List<Product>();

        public Form1()
        {
            InitializeComponent();
            btnRefresh.Click -= btnRefresh_Click;
            btnRefresh.Click += btnRefresh_Click;

            sellProductsToolStripMenuItem.Click -= sellProductsToolStripMenuItem_Click;
            sellProductsToolStripMenuItem.Click += sellProductsToolStripMenuItem_Click;

            searchToolStripMenuItem.Click -= searchToolStripMenuItem_Click;
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;

            dataGridView1.CellDoubleClick -= dataGridView1_CellDoubleClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            txtSearch.TextChanged -= txtSearch_TextChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts("");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text);
        }

        

        // Starts the database work on a thread pool thread
        public void LoadProducts(string filter)
        {
            currentFilter = filter;
            Task.Run(new Action(ReadProductsFromDatabase));
        }

        // Runs on the thread pool, not the UI thread
        private void ReadProductsFromDatabase()
        {
            using (StoreDbContext db = new StoreDbContext())
            {
                string f = currentFilter;
                var res = from p in db.Products
                          where f == "" || p.Name.Contains(f)
                          orderby p.Id
                          select p;
                loadedProducts = res.ToList();
            }

            // notify the GUI thread
            Invoke(new MethodInvoker(ShowProducts));
        }

        // Runs on the UI thread
        private void ShowProducts()
        {
            dataGridView1.DataSource = loadedProducts;
        }

        private void newProductToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct();
            form.ShowDialog();
            LoadProducts(txtSearch.Text);
        }


        private void sellProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a product in the list first.");
                return;
            }

            Product p = (Product)dataGridView1.CurrentRow.DataBoundItem;
            SellProduct form = new SellProduct(p);
            form.ShowDialog();
            LoadProducts(txtSearch.Text);
        }
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Product p = (Product)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            SellProduct form = new SellProduct(p);
            form.ShowDialog();
            LoadProducts(txtSearch.Text);
        }
    }
}