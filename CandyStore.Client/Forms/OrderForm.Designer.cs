namespace CandyStore.Client.Forms
{
    partial class OrderForm
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
            this.suppliersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.productsComboBox = new System.Windows.Forms.ComboBox();
            this.productQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.makeOrderBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.addProductBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.categoriesTextLbl = new System.Windows.Forms.Label();
            this.productsGridView = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.minusButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.totalPriceText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // suppliersComboBox
            // 
            this.suppliersComboBox.FormattingEnabled = true;
            this.suppliersComboBox.Location = new System.Drawing.Point(46, 102);
            this.suppliersComboBox.Name = "suppliersComboBox";
            this.suppliersComboBox.Size = new System.Drawing.Size(163, 24);
            this.suppliersComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Supplier\'s address";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(273, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(163, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(475, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(160, 22);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Supplier\'s telephone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Product";
            // 
            // productsComboBox
            // 
            this.productsComboBox.FormattingEnabled = true;
            this.productsComboBox.Location = new System.Drawing.Point(46, 186);
            this.productsComboBox.Name = "productsComboBox";
            this.productsComboBox.Size = new System.Drawing.Size(163, 24);
            this.productsComboBox.TabIndex = 6;
            // 
            // productQuantity
            // 
            this.productQuantity.Location = new System.Drawing.Point(230, 186);
            this.productQuantity.Name = "productQuantity";
            this.productQuantity.Size = new System.Drawing.Size(58, 22);
            this.productQuantity.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Quantity";
            // 
            // makeOrderBtn
            // 
            this.makeOrderBtn.Location = new System.Drawing.Point(658, 450);
            this.makeOrderBtn.Name = "makeOrderBtn";
            this.makeOrderBtn.Size = new System.Drawing.Size(168, 51);
            this.makeOrderBtn.TabIndex = 12;
            this.makeOrderBtn.Text = "Make order";
            this.makeOrderBtn.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(832, 450);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(168, 51);
            this.backBtn.TabIndex = 14;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // addProductBtn
            // 
            this.addProductBtn.Location = new System.Drawing.Point(46, 226);
            this.addProductBtn.Name = "addProductBtn";
            this.addProductBtn.Size = new System.Drawing.Size(128, 42);
            this.addProductBtn.TabIndex = 15;
            this.addProductBtn.Text = "Add product";
            this.addProductBtn.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(17, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(940, 2);
            this.label7.TabIndex = 18;
            this.label7.Tag = "Visible";
            // 
            // categoriesTextLbl
            // 
            this.categoriesTextLbl.AutoSize = true;
            this.categoriesTextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesTextLbl.Location = new System.Drawing.Point(40, 9);
            this.categoriesTextLbl.Name = "categoriesTextLbl";
            this.categoriesTextLbl.Size = new System.Drawing.Size(90, 36);
            this.categoriesTextLbl.TabIndex = 17;
            this.categoriesTextLbl.Text = "Order";
            // 
            // productsGridView
            // 
            this.productsGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.productsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsGridView.Location = new System.Drawing.Point(20, 328);
            this.productsGridView.Name = "productsGridView";
            this.productsGridView.RowTemplate.Height = 24;
            this.productsGridView.Size = new System.Drawing.Size(569, 150);
            this.productsGridView.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Products added to order";
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(489, 293);
            this.minusButton.Margin = new System.Windows.Forms.Padding(4);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(100, 28);
            this.minusButton.TabIndex = 25;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(381, 293);
            this.plusButton.Margin = new System.Windows.Forms.Padding(4);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(100, 28);
            this.plusButton.TabIndex = 24;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalPriceLabel.Location = new System.Drawing.Point(559, 479);
            this.totalPriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(30, 24);
            this.totalPriceLabel.TabIndex = 23;
            this.totalPriceLabel.Text = "$0";
            // 
            // totalPriceText
            // 
            this.totalPriceText.AutoSize = true;
            this.totalPriceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalPriceText.Location = new System.Drawing.Point(448, 479);
            this.totalPriceText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalPriceText.Name = "totalPriceText";
            this.totalPriceText.Size = new System.Drawing.Size(103, 24);
            this.totalPriceText.TabIndex = 22;
            this.totalPriceText.Text = "Total price:";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1012, 550);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.totalPriceText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productsGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.categoriesTextLbl);
            this.Controls.Add(this.addProductBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.makeOrderBtn);
            this.Controls.Add(this.productQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.productsComboBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.suppliersComboBox);
            this.DoubleBuffered = true;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Make order";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox suppliersComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox productsComboBox;
        private System.Windows.Forms.TextBox productQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button makeOrderBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button addProductBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label categoriesTextLbl;
        private System.Windows.Forms.DataGridView productsGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label totalPriceText;
    }
}