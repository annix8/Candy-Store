namespace CandyStore.Client.Forms
{
    partial class ReceiptForm
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
            this.nextCustomerButton = new System.Windows.Forms.Button();
            this.receiptTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.categoriesTextLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nextCustomerButton
            // 
            this.nextCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextCustomerButton.Location = new System.Drawing.Point(148, 435);
            this.nextCustomerButton.Margin = new System.Windows.Forms.Padding(4);
            this.nextCustomerButton.Name = "nextCustomerButton";
            this.nextCustomerButton.Size = new System.Drawing.Size(131, 49);
            this.nextCustomerButton.TabIndex = 0;
            this.nextCustomerButton.Text = "OK";
            this.nextCustomerButton.UseVisualStyleBackColor = true;
            this.nextCustomerButton.Click += new System.EventHandler(this.nextCustomerButton_Click);
            // 
            // receiptTextBox
            // 
            this.receiptTextBox.Location = new System.Drawing.Point(38, 117);
            this.receiptTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.receiptTextBox.Name = "receiptTextBox";
            this.receiptTextBox.Size = new System.Drawing.Size(369, 258);
            this.receiptTextBox.TabIndex = 1;
            this.receiptTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 2);
            this.label2.TabIndex = 18;
            this.label2.Tag = "Visible";
            // 
            // categoriesTextLbl
            // 
            this.categoriesTextLbl.AutoSize = true;
            this.categoriesTextLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesTextLbl.Location = new System.Drawing.Point(12, 9);
            this.categoriesTextLbl.Name = "categoriesTextLbl";
            this.categoriesTextLbl.Size = new System.Drawing.Size(116, 36);
            this.categoriesTextLbl.TabIndex = 17;
            this.categoriesTextLbl.Text = "Receipt";
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(447, 517);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoriesTextLbl);
            this.Controls.Add(this.receiptTextBox);
            this.Controls.Add(this.nextCustomerButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextCustomerButton;
        private System.Windows.Forms.RichTextBox receiptTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label categoriesTextLbl;
    }
}