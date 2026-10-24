namespace Lab5_Window
{
    partial class SellProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.numSell = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numSell)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(30, 23);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 16);
            this.lblInfo.TabIndex = 0;
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(109, 152);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(116, 36);
            this.btnSell.TabIndex = 1;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            // 
            // numSell
            // 
            this.numSell.Location = new System.Drawing.Point(24, 71);
            this.numSell.Name = "numSell";
            this.numSell.Size = new System.Drawing.Size(201, 22);
            this.numSell.TabIndex = 2;
            // 
            // SellProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 200);
            this.Controls.Add(this.numSell);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.lblInfo);
            this.Name = "SellProduct";
            this.Text = "SellProduct";
            ((System.ComponentModel.ISupportInitialize)(this.numSell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.NumericUpDown numSell;
    }
}