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
            this.productsGridView = new System.Windows.Forms.DataGridView();
            this.closeOrderButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.searchBySupplierLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(900, 2);
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
            // productsGridView
            // 
            this.productsGridView.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.productsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsGridView.Location = new System.Drawing.Point(15, 150);
            this.productsGridView.Margin = new System.Windows.Forms.Padding(4);
            this.productsGridView.Name = "productsGridView";
            this.productsGridView.ReadOnly = true;
            this.productsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productsGridView.Size = new System.Drawing.Size(494, 185);
            this.productsGridView.TabIndex = 23;
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(184, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 27);
            this.textBox1.TabIndex = 29;
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
            // OrderStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(946, 485);
            this.Controls.Add(this.searchBySupplierLbl);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.welcomeLbl);
            this.Controls.Add(this.productsGridView);
            this.Controls.Add(this.closeOrderButton);
            this.Controls.Add(this.backButton);
            this.DoubleBuffered = true;
            this.Name = "OrderStatusForm";
            this.Text = "Orders status";
            this.Load += new System.EventHandler(this.OrderStatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label welcomeLbl;
        private System.Windows.Forms.DataGridView productsGridView;
        private System.Windows.Forms.Button closeOrderButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label searchBySupplierLbl;
    }
}