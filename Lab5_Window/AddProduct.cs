    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace Lab5_Window
    {
        public partial class AddProduct : Form
        {
            private string pName, pDescription;
            private DateTime pEntry, pExpiry;
            private int pQuantity;

            public AddProduct()
            {
                InitializeComponent();
            }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("The name can't be empty.");
                return;
            }

            // read the controls on the UI thread
            pName = txtName.Text;
            pDescription = txtDescription.Text;
            pEntry = dtpEntry.Value;
            pExpiry = dtpExpiry.Value;
            pQuantity = (int)numQuantity.Value;

            btnSave.Enabled = false;                     // stops double clicks
            Task.Run(new Action(SaveToDatabase));        // thread pool
        }
        // Runs on the thread pool
        private void SaveToDatabase()
            {
                using (StoreDbContext db = new StoreDbContext())
                {
                    Product p = new Product();
                    p.Name = pName;
                    p.Description = pDescription;
                    p.EntryDate = pEntry;
                    p.ExpiryDate = pExpiry;
                    p.Quantity = pQuantity;

                    db.Products.Add(p);
                    db.SaveChanges();
                }

                // notify the GUI thread
                Invoke(new MethodInvoker(Close));
            }
        }
    }