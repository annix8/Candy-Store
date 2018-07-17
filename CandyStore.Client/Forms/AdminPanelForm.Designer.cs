namespace CandyStore.Client.Views
{
    partial class AdminPanelForm
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
            this.categoryNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.choosePictureButton = new System.Windows.Forms.Button();
            this.categorySave = new System.Windows.Forms.Button();
            this.categoryImageSelectedLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteCategory = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.categoryDiscard = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.productQuantityToAdd = new System.Windows.Forms.TextBox();
            this.productInsertStock = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.productDiscard = new System.Windows.Forms.Button();
            this.productSave = new System.Windows.Forms.Button();
            this.imageSelectedLabelProduct = new System.Windows.Forms.Label();
            this.choosePictureButtonProduct = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.productNameBox = new System.Windows.Forms.TextBox();
            this.productPriceBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.productCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoryNameBox
            // 
            this.categoryNameBox.Location = new System.Drawing.Point(163, 42);
            this.categoryNameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.categoryNameBox.Name = "categoryNameBox";
            this.categoryNameBox.Size = new System.Drawing.Size(155, 30);
            this.categoryNameBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Category name";
            // 
            // choosePictureButton
            // 
            this.choosePictureButton.Location = new System.Drawing.Point(344, 74);
            this.choosePictureButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.choosePictureButton.Name = "choosePictureButton";
            this.choosePictureButton.Size = new System.Drawing.Size(136, 33);
            this.choosePictureButton.TabIndex = 4;
            this.choosePictureButton.Text = "Choose picture...";
            this.choosePictureButton.UseVisualStyleBackColor = true;
            this.choosePictureButton.Click += new System.EventHandler(this.choosePictureButton_Click);
            // 
            // categorySave
            // 
            this.categorySave.Location = new System.Drawing.Point(183, 101);
            this.categorySave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.categorySave.Name = "categorySave";
            this.categorySave.Size = new System.Drawing.Size(136, 34);
            this.categorySave.TabIndex = 5;
            this.categorySave.Text = "Save";
            this.categorySave.UseVisualStyleBackColor = true;
            this.categorySave.Click += new System.EventHandler(this.saveCategoryButton_Click);
            // 
            // categoryImageSelectedLabel
            // 
            this.categoryImageSelectedLabel.AutoSize = true;
            this.categoryImageSelectedLabel.Location = new System.Drawing.Point(339, 42);
            this.categoryImageSelectedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.categoryImageSelectedLabel.Name = "categoryImageSelectedLabel";
            this.categoryImageSelectedLabel.Size = new System.Drawing.Size(188, 25);
            this.categoryImageSelectedLabel.TabIndex = 6;
            this.categoryImageSelectedLabel.Text = "No image selected...";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(565, 367);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(132, 41);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(612, 345);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category panel";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.deleteCategory);
            this.groupBox3.Controls.Add(this.categoryComboBox);
            this.groupBox3.Location = new System.Drawing.Point(25, 178);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(319, 128);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Delete category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select...";
            // 
            // deleteCategory
            // 
            this.deleteCategory.Location = new System.Drawing.Point(93, 84);
            this.deleteCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteCategory.Name = "deleteCategory";
            this.deleteCategory.Size = new System.Drawing.Size(100, 32);
            this.deleteCategory.TabIndex = 1;
            this.deleteCategory.Text = "Delete";
            this.deleteCategory.UseVisualStyleBackColor = true;
            this.deleteCategory.Click += new System.EventHandler(this.deleteCategory_Click);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(104, 33);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(180, 33);
            this.categoryComboBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.categoryDiscard);
            this.groupBox2.Controls.Add(this.categoryNameBox);
            this.groupBox2.Controls.Add(this.categorySave);
            this.groupBox2.Controls.Add(this.categoryImageSelectedLabel);
            this.groupBox2.Controls.Add(this.choosePictureButton);
            this.groupBox2.Location = new System.Drawing.Point(25, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(549, 148);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add category";
            // 
            // categoryDiscard
            // 
            this.categoryDiscard.Location = new System.Drawing.Point(43, 101);
            this.categoryDiscard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.categoryDiscard.Name = "categoryDiscard";
            this.categoryDiscard.Size = new System.Drawing.Size(132, 34);
            this.categoryDiscard.TabIndex = 9;
            this.categoryDiscard.Text = "Discard";
            this.categoryDiscard.UseVisualStyleBackColor = true;
            this.categoryDiscard.Click += new System.EventHandler(this.categoryDiscard_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(652, 15);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(621, 345);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Product panel";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button1);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.productQuantityToAdd);
            this.groupBox7.Controls.Add(this.productInsertStock);
            this.groupBox7.Location = new System.Drawing.Point(351, 207);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Size = new System.Drawing.Size(263, 130);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Insert stock";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 91);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Quantity:";
            // 
            // productQuantityToAdd
            // 
            this.productQuantityToAdd.Location = new System.Drawing.Point(112, 59);
            this.productQuantityToAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productQuantityToAdd.Name = "productQuantityToAdd";
            this.productQuantityToAdd.Size = new System.Drawing.Size(69, 30);
            this.productQuantityToAdd.TabIndex = 3;
            // 
            // productInsertStock
            // 
            this.productInsertStock.FormattingEnabled = true;
            this.productInsertStock.Location = new System.Drawing.Point(8, 23);
            this.productInsertStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productInsertStock.Name = "productInsertStock";
            this.productInsertStock.Size = new System.Drawing.Size(228, 33);
            this.productInsertStock.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.productComboBox);
            this.groupBox6.Location = new System.Drawing.Point(8, 207);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(319, 130);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Delete product";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Select...";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 89);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 34);
            this.button2.TabIndex = 11;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // productComboBox
            // 
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(104, 23);
            this.productComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(180, 33);
            this.productComboBox.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.productDiscard);
            this.groupBox5.Controls.Add(this.productSave);
            this.groupBox5.Controls.Add(this.imageSelectedLabelProduct);
            this.groupBox5.Controls.Add(this.choosePictureButtonProduct);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.productNameBox);
            this.groupBox5.Controls.Add(this.productPriceBox);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.productCategoryComboBox);
            this.groupBox5.Location = new System.Drawing.Point(8, 30);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(605, 162);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Add product";
            // 
            // productDiscard
            // 
            this.productDiscard.Location = new System.Drawing.Point(8, 113);
            this.productDiscard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productDiscard.Name = "productDiscard";
            this.productDiscard.Size = new System.Drawing.Size(133, 34);
            this.productDiscard.TabIndex = 13;
            this.productDiscard.Text = "Discard";
            this.productDiscard.UseVisualStyleBackColor = true;
            this.productDiscard.Click += new System.EventHandler(this.productDiscard_Click);
            // 
            // productSave
            // 
            this.productSave.Location = new System.Drawing.Point(151, 113);
            this.productSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productSave.Name = "productSave";
            this.productSave.Size = new System.Drawing.Size(133, 34);
            this.productSave.TabIndex = 12;
            this.productSave.Text = "Save";
            this.productSave.UseVisualStyleBackColor = true;
            this.productSave.Click += new System.EventHandler(this.productSave_Click);
            // 
            // imageSelectedLabelProduct
            // 
            this.imageSelectedLabelProduct.AutoSize = true;
            this.imageSelectedLabelProduct.Location = new System.Drawing.Point(351, 75);
            this.imageSelectedLabelProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.imageSelectedLabelProduct.Name = "imageSelectedLabelProduct";
            this.imageSelectedLabelProduct.Size = new System.Drawing.Size(188, 25);
            this.imageSelectedLabelProduct.TabIndex = 11;
            this.imageSelectedLabelProduct.Text = "No image selected...";
            // 
            // choosePictureButtonProduct
            // 
            this.choosePictureButtonProduct.Location = new System.Drawing.Point(351, 113);
            this.choosePictureButtonProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.choosePictureButtonProduct.Name = "choosePictureButtonProduct";
            this.choosePictureButtonProduct.Size = new System.Drawing.Size(136, 34);
            this.choosePictureButtonProduct.TabIndex = 10;
            this.choosePictureButtonProduct.Text = "Choose picture...";
            this.choosePictureButtonProduct.UseVisualStyleBackColor = true;
            this.choosePictureButtonProduct.Click += new System.EventHandler(this.choosePictureButtonProduct_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Product name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Price";
            // 
            // productNameBox
            // 
            this.productNameBox.Location = new System.Drawing.Point(151, 21);
            this.productNameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productNameBox.Name = "productNameBox";
            this.productNameBox.Size = new System.Drawing.Size(132, 30);
            this.productNameBox.TabIndex = 3;
            // 
            // productPriceBox
            // 
            this.productPriceBox.Location = new System.Drawing.Point(151, 68);
            this.productPriceBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productPriceBox.Name = "productPriceBox";
            this.productPriceBox.Size = new System.Drawing.Size(61, 30);
            this.productPriceBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category";
            // 
            // productCategoryComboBox
            // 
            this.productCategoryComboBox.FormattingEnabled = true;
            this.productCategoryComboBox.Location = new System.Drawing.Point(397, 25);
            this.productCategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productCategoryComboBox.Name = "productCategoryComboBox";
            this.productCategoryComboBox.Size = new System.Drawing.Size(160, 33);
            this.productCategoryComboBox.TabIndex = 1;
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1324, 502);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.backButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin panel";
            this.Load += new System.EventHandler(this.AdminPanelForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox categoryNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button choosePictureButton;
        private System.Windows.Forms.Button categorySave;
        private System.Windows.Forms.Label categoryImageSelectedLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button categoryDiscard;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button deleteCategory;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.Button productDiscard;
        private System.Windows.Forms.Button productSave;
        private System.Windows.Forms.Label imageSelectedLabelProduct;
        private System.Windows.Forms.Button choosePictureButtonProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox productNameBox;
        private System.Windows.Forms.TextBox productPriceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox productCategoryComboBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox productQuantityToAdd;
        private System.Windows.Forms.ComboBox productInsertStock;
        private System.Windows.Forms.Button button1;
    }
}