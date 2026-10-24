using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_Window
{
    public partial class SellProduct : Form
    {
        private int productId;
        private int amount;

        public SellProduct(Product p)
        {
            InitializeComponent();
            btnSell.Click -= btnSell_Click;
            btnSell.Click += btnSell_Click;

            productId = p.Id;
            lblInfo.Text = p.Name + " (available: " + p.Quantity + ")";
            numSell.Minimum = 1;
            numSell.Maximum = p.Quantity;
            numSell.Value = 1;
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            amount = (int)numSell.Value;
            btnSell.Enabled = false;
            Task.Run(new Action(SaveToDatabase));
        }

        private void SaveToDatabase()
        {
            using (StoreDbContext db = new StoreDbContext())
            {
                Product p = db.Products.Find(productId);
                if (p != null)
                {
                    p.Quantity = p.Quantity - amount;
                    if (p.Quantity <= 0)
                        db.Products.Remove(p);   // quantity 0: delete the product
                    db.SaveChanges();
                }
            }
            Invoke(new MethodInvoker(Close));
        }
    }
}