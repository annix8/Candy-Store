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
            this.nextCustomerButton = new System.Windows.Forms.Button();
            this.receiptTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // nextCustomerButton
            // 
            this.nextCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextCustomerButton.Location = new System.Drawing.Point(161, 357);
            this.nextCustomerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nextCustomerButton.Name = "nextCustomerButton";
            this.nextCustomerButton.Size = new System.Drawing.Size(131, 49);
            this.nextCustomerButton.TabIndex = 0;
            this.nextCustomerButton.Text = "OK";
            this.nextCustomerButton.UseVisualStyleBackColor = true;
            this.nextCustomerButton.Click += new System.EventHandler(this.nextCustomerButton_Click);
            // 
            // receiptTextBox
            // 
            this.receiptTextBox.Location = new System.Drawing.Point(40, 39);
            this.receiptTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.receiptTextBox.Name = "receiptTextBox";
            this.receiptTextBox.Size = new System.Drawing.Size(369, 258);
            this.receiptTextBox.TabIndex = 1;
            this.receiptTextBox.Text = "";
            // 
            // OrderReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(447, 450);
            this.Controls.Add(this.receiptTextBox);
            this.Controls.Add(this.nextCustomerButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OrderReceiptForm";
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