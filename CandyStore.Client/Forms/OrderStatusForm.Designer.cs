namespace CandyStore.Client.Forms
{
    partial class OrderStatusForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.welcomeLbl = new System.Windows.Forms.Label();
            this.ordersGridView = new System.Windows.Forms.DataGridView();
            this.closeOrderButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.searchSuppliersTextBox = new System.Windows.Forms.TextBox();
            this.searchBySupplierLbl = new System.Windows.Forms.Label();
            this.productsGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalPriceLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1256, 2);
            this.label2.TabIndex = 28;
            this.label2.Tag = "Visible";
            // 
            // welcomeLbl
            // 
            this.welcomeLbl.AutoSize = true;
            this.welcomeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLbl.Location = new System.Drawing.Point(25, 24);
            this.welcomeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.welcomeLbl.Name = "welcomeLbl";
            this.welcomeLbl.Size = new System.Drawing.Size(177, 36);
            this.welcomeLbl.TabIndex = 27;
            this.welcomeLbl.Text = "Order status";
            // 
            // ordersGridView
            // 
            this.ordersGridView.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.ordersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGridView.Location = new System.Drawing.Point(15, 150);
            this.ordersGridView.Margin = new System.Windows.Forms.Padding(4);
            this.ordersGridView.Name = "ordersGridView";
            this.ordersGridView.ReadOnly = true;
            this.ordersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersGridView.Size = new System.Drawing.Size(609, 185);
            this.ordersGridView.TabIndex = 23;
            this.ordersGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordersGridView_CellClick);
            // 
            // closeOrderButton
            // 
            this.closeOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeOrderButton.Location = new System.Drawing.Point(17, 343);
            this.closeOrderButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeOrderButton.Name = "closeOrderButton";
            this.closeOrderButton.Size = new System.Drawing.Size(136, 38);
            this.closeOrderButton.TabIndex = 20;
            this.closeOrderButton.Text = "Close order";
            this.closeOrderButton.UseVisualStyleBackColor = true;
            this.closeOrderButton.Click += new System.EventHandler(this.closeOrderButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(727, 422);
            this.backButton.Margin = new System.Windows.Forms.Padding(4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(208, 50);
            this.backButton.TabIndex = 19;
            this.backButton.Text = "Back ";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // searchSuppliersTextBox
            // 
            this.searchSuppliersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchSuppliersTextBox.Location = new System.Drawing.Point(184, 116);
            this.searchSuppliersTextBox.Name = "searchSuppliersTextBox";
            this.searchSuppliersTextBox.Size = new System.Drawing.Size(351, 27);
            this.searchSuppliersTextBox.TabIndex = 29;
            this.searchSuppliersTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchSuppliersTextBox_KeyPress);
            // 
            // searchBySupplierLbl
            // 
            this.searchBySupplierLbl.AutoSize = true;
            this.searchBySupplierLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBySupplierLbl.Location = new System.Drawing.Point(13, 119);
            this.searchBySupplierLbl.Name = "searchBySupplierLbl";
            this.searchBySupplierLbl.Size = new System.Drawing.Size(148, 20);
            this.searchBySupplierLbl.TabIndex = 30;
            this.searchBySupplierLbl.Text = "Search by supplier";
            // 
            // productsGridView
            // 
            this.productsGridView.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.productsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsGridView.Location = new System.Drawing.Point(659, 150);
            this.productsGridView.Margin = new System.Windows.Forms.Padding(4);
            this.productsGridView.Name = "productsGridView";
            this.productsGridView.ReadOnly = true;
            this.productsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productsGridView.Size = new System.Drawing.Size(580, 185);
            this.productsGridView.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(655, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Products in order";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1093, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Total price:";
            // 
            // totalPriceLbl
            // 
            this.totalPriceLbl.AutoSize = true;
            this.totalPriceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLbl.Location = new System.Drawing.Point(1192, 339);
            this.totalPriceLbl.Name = "totalPriceLbl";
            this.totalPriceLbl.Size = new System.Drawing.Size(27, 20);
            this.totalPriceLbl.TabIndex = 34;
            this.totalPriceLbl.Text = "$0";
            // 
            // OrderStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284, 485);
            this.Controls.Add(this.totalPriceLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productsGridView);
            this.Controls.Add(this.searchBySupplierLbl);
            this.Controls.Add(this.searchSuppliersTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.welcomeLbl);
            this.Controls.Add(this.ordersGridView);
            this.Controls.Add(this.closeOrderButton);
            this.Controls.Add(this.backButton);
            this.DoubleBuffered = true;
            this.Name = "OrderStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders status";
            this.Load += new System.EventHandler(this.OrderStatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label welcomeLbl;
        private System.Windows.Forms.DataGridView ordersGridView;
        private System.Windows.Forms.Button closeOrderButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox searchSuppliersTextBox;
        private System.Windows.Forms.Label searchBySupplierLbl;
        private System.Windows.Forms.DataGridView productsGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalPriceLbl;
    }
}