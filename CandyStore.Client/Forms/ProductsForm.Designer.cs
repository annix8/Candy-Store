namespace CandyStore.Client.Views
{
    partial class ProductsForm
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
            this.productPictureBox = new System.Windows.Forms.PictureBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.productsList = new System.Windows.Forms.ListBox();
            this.priceTextLbl = new System.Windows.Forms.Label();
            this.quantityLbl = new System.Windows.Forms.Label();
            this.productQuantityBox = new System.Windows.Forms.TextBox();
            this.onStockLbl = new System.Windows.Forms.Label();
            this.onStock = new System.Windows.Forms.Label();
            this.productPrice = new System.Windows.Forms.Label();
            this.categoryNameLbl = new System.Windows.Forms.Label();
            this.addToCartBtn = new System.Windows.Forms.Button();
            this.noProductsLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // productPictureBox
            // 
            this.productPictureBox.Location = new System.Drawing.Point(298, 85);
            this.productPictureBox.Name = "productPictureBox";
            this.productPictureBox.Size = new System.Drawing.Size(335, 300);
            this.productPictureBox.TabIndex = 12;
            this.productPictureBox.TabStop = false;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(765, 539);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(245, 51);
            this.backBtn.TabIndex = 10;
            this.backBtn.Text = "Back to Categories";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // productsList
            // 
            this.productsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsList.FormattingEnabled = true;
            this.productsList.ItemHeight = 20;
            this.productsList.Location = new System.Drawing.Point(23, 85);
            this.productsList.Name = "productsList";
            this.productsList.Size = new System.Drawing.Size(245, 464);
            this.productsList.TabIndex = 7;
            this.productsList.SelectedIndexChanged += new System.EventHandler(this.productsList_SelectedIndexChanged);
            // 
            // priceTextLbl
            // 
            this.priceTextLbl.AutoSize = true;
            this.priceTextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceTextLbl.Location = new System.Drawing.Point(373, 388);
            this.priceTextLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceTextLbl.Name = "priceTextLbl";
            this.priceTextLbl.Size = new System.Drawing.Size(62, 25);
            this.priceTextLbl.TabIndex = 18;
            this.priceTextLbl.Text = "Price:";
            // 
            // quantityLbl
            // 
            this.quantityLbl.AutoSize = true;
            this.quantityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityLbl.Location = new System.Drawing.Point(373, 473);
            this.quantityLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.quantityLbl.Name = "quantityLbl";
            this.quantityLbl.Size = new System.Drawing.Size(91, 25);
            this.quantityLbl.TabIndex = 17;
            this.quantityLbl.Text = "Quantity:";
            // 
            // productQuantityBox
            // 
            this.productQuantityBox.Location = new System.Drawing.Point(474, 473);
            this.productQuantityBox.Margin = new System.Windows.Forms.Padding(4);
            this.productQuantityBox.Name = "productQuantityBox";
            this.productQuantityBox.Size = new System.Drawing.Size(57, 22);
            this.productQuantityBox.TabIndex = 16;
            // 
            // onStockLbl
            // 
            this.onStockLbl.AutoSize = true;
            this.onStockLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.onStockLbl.Location = new System.Drawing.Point(373, 430);
            this.onStockLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.onStockLbl.Name = "onStockLbl";
            this.onStockLbl.Size = new System.Drawing.Size(96, 25);
            this.onStockLbl.TabIndex = 15;
            this.onStockLbl.Text = "On stock:";
            // 
            // onStock
            // 
            this.onStock.AutoSize = true;
            this.onStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.onStock.Location = new System.Drawing.Point(470, 430);
            this.onStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.onStock.Name = "onStock";
            this.onStock.Size = new System.Drawing.Size(23, 25);
            this.onStock.TabIndex = 14;
            this.onStock.Text = "0";
            // 
            // productPrice
            // 
            this.productPrice.AutoSize = true;
            this.productPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productPrice.Location = new System.Drawing.Point(469, 388);
            this.productPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.productPrice.Name = "productPrice";
            this.productPrice.Size = new System.Drawing.Size(23, 25);
            this.productPrice.TabIndex = 13;
            this.productPrice.Text = "0";
            // 
            // categoryNameLbl
            // 
            this.categoryNameLbl.AutoSize = true;
            this.categoryNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryNameLbl.Location = new System.Drawing.Point(13, 18);
            this.categoryNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.categoryNameLbl.Name = "categoryNameLbl";
            this.categoryNameLbl.Size = new System.Drawing.Size(255, 36);
            this.categoryNameLbl.TabIndex = 20;
            this.categoryNameLbl.Text = "{{Category name}}";
            // 
            // addToCartBtn
            // 
            this.addToCartBtn.Location = new System.Drawing.Point(341, 513);
            this.addToCartBtn.Name = "addToCartBtn";
            this.addToCartBtn.Size = new System.Drawing.Size(245, 51);
            this.addToCartBtn.TabIndex = 21;
            this.addToCartBtn.Text = "Add to cart";
            this.addToCartBtn.UseVisualStyleBackColor = true;
            this.addToCartBtn.Click += new System.EventHandler(this.addToCartBtn_Click);
            // 
            // noProductsLbl
            // 
            this.noProductsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.noProductsLbl.ForeColor = System.Drawing.Color.Red;
            this.noProductsLbl.Location = new System.Drawing.Point(683, 320);
            this.noProductsLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noProductsLbl.Name = "noProductsLbl";
            this.noProductsLbl.Size = new System.Drawing.Size(326, 93);
            this.noProductsLbl.TabIndex = 22;
            this.noProductsLbl.Text = "Currently, there are no products on stock for this category.";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(989, 2);
            this.label2.TabIndex = 23;
            this.label2.Tag = "Visible";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(705, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 139);
            this.label1.TabIndex = 24;
            this.label1.Text = "Click on a product to see its image.\r\nUpon clicked, you will see the price and on" +
    " stock information for the product.\r\n";
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1022, 602);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.noProductsLbl);
            this.Controls.Add(this.addToCartBtn);
            this.Controls.Add(this.categoryNameLbl);
            this.Controls.Add(this.priceTextLbl);
            this.Controls.Add(this.quantityLbl);
            this.Controls.Add(this.productQuantityBox);
            this.Controls.Add(this.onStockLbl);
            this.Controls.Add(this.onStock);
            this.Controls.Add(this.productPrice);
            this.Controls.Add(this.productPictureBox);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.productsList);
            this.DoubleBuffered = true;
            this.Name = "ProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox productPictureBox;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.ListBox productsList;
        private System.Windows.Forms.Label priceTextLbl;
        private System.Windows.Forms.Label quantityLbl;
        private System.Windows.Forms.TextBox productQuantityBox;
        private System.Windows.Forms.Label onStockLbl;
        private System.Windows.Forms.Label onStock;
        private System.Windows.Forms.Label productPrice;
        private System.Windows.Forms.Label categoryNameLbl;
        private System.Windows.Forms.Button addToCartBtn;
        private System.Windows.Forms.Label noProductsLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}