namespace CandyStore.Client.Forms
{
    partial class CategoriesForm
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
            this.categoriesList = new System.Windows.Forms.ListBox();
            this.selectCategoryBtn = new System.Windows.Forms.Button();
            this.shoppingCartBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.categoryPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.categoryPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // categoriesList
            // 
            this.categoriesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesList.FormattingEnabled = true;
            this.categoriesList.ItemHeight = 20;
            this.categoriesList.Location = new System.Drawing.Point(12, 12);
            this.categoriesList.Name = "categoriesList";
            this.categoriesList.Size = new System.Drawing.Size(245, 444);
            this.categoriesList.TabIndex = 0;
            this.categoriesList.SelectedIndexChanged += new System.EventHandler(this.categoriesList_SelectedIndexChanged);
            // 
            // selectCategoryBtn
            // 
            this.selectCategoryBtn.Location = new System.Drawing.Point(315, 347);
            this.selectCategoryBtn.Name = "selectCategoryBtn";
            this.selectCategoryBtn.Size = new System.Drawing.Size(245, 51);
            this.selectCategoryBtn.TabIndex = 2;
            this.selectCategoryBtn.Text = "Select from category...";
            this.selectCategoryBtn.UseVisualStyleBackColor = true;
            this.selectCategoryBtn.Click += new System.EventHandler(this.selectCategoryBtn_Click);
            // 
            // shoppingCartBtn
            // 
            this.shoppingCartBtn.Location = new System.Drawing.Point(315, 404);
            this.shoppingCartBtn.Name = "shoppingCartBtn";
            this.shoppingCartBtn.Size = new System.Drawing.Size(245, 51);
            this.shoppingCartBtn.TabIndex = 3;
            this.shoppingCartBtn.Text = "Shopping cart";
            this.shoppingCartBtn.UseVisualStyleBackColor = true;
            this.shoppingCartBtn.Click += new System.EventHandler(this.shoppingCartBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(674, 503);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(245, 51);
            this.backBtn.TabIndex = 4;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTextBox.Location = new System.Drawing.Point(658, 12);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(261, 163);
            this.infoTextBox.TabIndex = 5;
            this.infoTextBox.Text = "Click on a category to see its image.\r\nClick select from category to go to the pr" +
    "oducts of this category and choose\r\nyour candy!\r\n\r\n";
            // 
            // categoryPictureBox
            // 
            this.categoryPictureBox.Location = new System.Drawing.Point(278, 12);
            this.categoryPictureBox.Name = "categoryPictureBox";
            this.categoryPictureBox.Size = new System.Drawing.Size(335, 300);
            this.categoryPictureBox.TabIndex = 6;
            this.categoryPictureBox.TabStop = false;
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(965, 566);
            this.Controls.Add(this.categoryPictureBox);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.shoppingCartBtn);
            this.Controls.Add(this.selectCategoryBtn);
            this.Controls.Add(this.categoriesList);
            this.DoubleBuffered = true;
            this.Name = "CategoriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categories";
            this.Load += new System.EventHandler(this.CategoriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button selectCategoryBtn;
        private System.Windows.Forms.Button shoppingCartBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.ListBox categoriesList;
        private System.Windows.Forms.PictureBox categoryPictureBox;
    }
}