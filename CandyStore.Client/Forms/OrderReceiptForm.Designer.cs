namespace CandyStore.Client.Forms
{
    partial class OrderReceiptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderReceiptForm));
            this.nextCustomerButton = new System.Windows.Forms.Button();
            this.receiptTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // nextCustomerButton
            // 
            this.nextCustomerButton.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextCustomerButton.Location = new System.Drawing.Point(121, 290);
            this.nextCustomerButton.Name = "nextCustomerButton";
            this.nextCustomerButton.Size = new System.Drawing.Size(98, 40);
            this.nextCustomerButton.TabIndex = 0;
            this.nextCustomerButton.Text = "OK";
            this.nextCustomerButton.UseVisualStyleBackColor = true;
            this.nextCustomerButton.Click += new System.EventHandler(this.nextCustomerButton_Click);
            // 
            // receiptTextBox
            // 
            this.receiptTextBox.Location = new System.Drawing.Point(30, 32);
            this.receiptTextBox.Name = "receiptTextBox";
            this.receiptTextBox.Size = new System.Drawing.Size(278, 210);
            this.receiptTextBox.TabIndex = 1;
            this.receiptTextBox.Text = "";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(335, 366);
            this.Controls.Add(this.receiptTextBox);
            this.Controls.Add(this.nextCustomerButton);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nextCustomerButton;
        private System.Windows.Forms.RichTextBox receiptTextBox;
    }
}