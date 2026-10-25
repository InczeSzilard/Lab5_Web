using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_Window
{
    public partial class AddQuantity : Form
    {
        private int productId;
        private int amount;
        private bool found;
        private string productName;

        public AddQuantity()
        {
            InitializeComponent();
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // read the controls on the UI thread
            productId = (int)numId.Value;
            amount = (int)numAmount.Value;

            btnAdd.Enabled = false;
            Task.Run(new Action(SaveToDatabase));   // thread pool
        }

        // Runs on the thread pool
        private void SaveToDatabase()
        {
            using (StoreDbContext db = new StoreDbContext())
            {
                Product p = db.Products.Find(productId);
                found = (p != null);

                if (found)
                {
                    p.Quantity = p.Quantity + amount;
                    productName = p.Name;
                    db.SaveChanges();
                }
            }

            // notify the GUI thread with the result
            Invoke(new MethodInvoker(ShowResult));
        }

        // Runs on the UI thread
        private void ShowResult()
        {
            if (found)
            {
                MessageBox.Show("Added " + amount + " to " + productName + ".");
                Close();
            }
            else
            {
                MessageBox.Show("No product with ID " + productId + ".");
                btnAdd.Enabled = true;
            }
        }
    }
}