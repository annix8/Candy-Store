namespace CandyStore.Client.Forms
{
    partial class AdminManagerForm
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
            this.inventoryPanelBtn = new System.Windows.Forms.Button();
            this.makeOrderBtn = new System.Windows.Forms.Button();
            this.ordersBtn = new System.Windows.Forms.Button();
            this.inventoryPictureBox = new System.Windows.Forms.PictureBox();
            this.makeOrderPictureBox = new System.Windows.Forms.PictureBox();
            this.ordersPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.adminPanelLbl = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.makeOrderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // inventoryPanelBtn
            // 
            this.inventoryPanelBtn.Location = new System.Drawing.Point(10, 467);
            this.inventoryPanelBtn.Name = "inventoryPanelBtn";
            this.inventoryPanelBtn.Size = new System.Drawing.Size(391, 67);
            this.inventoryPanelBtn.TabIndex = 0;
            this.inventoryPanelBtn.Text = "Inventory panel";
            this.inventoryPanelBtn.UseVisualStyleBackColor = true;
            this.inventoryPanelBtn.Click += new System.EventHandler(this.inventoryPanelBtn_Click);
            // 
            // makeOrderBtn
            // 
            this.makeOrderBtn.Location = new System.Drawing.Point(407, 467);
            this.makeOrderBtn.Name = "makeOrderBtn";
            this.makeOrderBtn.Size = new System.Drawing.Size(391, 65);
            this.makeOrderBtn.TabIndex = 1;
            this.makeOrderBtn.Text = "Make order";
            this.makeOrderBtn.UseVisualStyleBackColor = true;
            this.makeOrderBtn.Click += new System.EventHandler(this.makeOrderBtn_Click);
            // 
            // ordersBtn
            // 
            this.ordersBtn.Location = new System.Drawing.Point(804, 465);
            this.ordersBtn.Name = "ordersBtn";
            this.ordersBtn.Size = new System.Drawing.Size(391, 67);
            this.ordersBtn.TabIndex = 2;
            this.ordersBtn.Text = "Orders";
            this.ordersBtn.UseVisualStyleBackColor = true;
            this.ordersBtn.Click += new System.EventHandler(this.ordersBtn_Click);
            // 
            // inventoryPictureBox
            // 
            this.inventoryPictureBox.Location = new System.Drawing.Point(10, 116);
            this.inventoryPictureBox.Name = "inventoryPictureBox";
            this.inventoryPictureBox.Size = new System.Drawing.Size(391, 345);
            this.inventoryPictureBox.TabIndex = 4;
            this.inventoryPictureBox.TabStop = false;
            // 
            // makeOrderPictureBox
            // 
            this.makeOrderPictureBox.Location = new System.Drawing.Point(407, 116);
            this.makeOrderPictureBox.Name = "makeOrderPictureBox";
            this.makeOrderPictureBox.Size = new System.Drawing.Size(391, 345);
            this.makeOrderPictureBox.TabIndex = 5;
            this.makeOrderPictureBox.TabStop = false;
            // 
            // ordersPictureBox
            // 
            this.ordersPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ordersPictureBox.Location = new System.Drawing.Point(804, 114);
            this.ordersPictureBox.Name = "ordersPictureBox";
            this.ordersPictureBox.Size = new System.Drawing.Size(391, 345);
            this.ordersPictureBox.TabIndex = 6;
            this.ordersPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1188, 2);
            this.label2.TabIndex = 18;
            this.label2.Tag = "Visible";
            // 
            // adminPanelLbl
            // 
            this.adminPanelLbl.AutoSize = true;
            this.adminPanelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPanelLbl.Location = new System.Drawing.Point(12, 26);
            this.adminPanelLbl.Name = "adminPanelLbl";
            this.adminPanelLbl.Size = new System.Drawing.Size(395, 36);
            this.adminPanelLbl.TabIndex = 17;
            this.adminPanelLbl.Text = "Administrator manager panel";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(971, 604);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(224, 54);
            this.backBtn.TabIndex = 19;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // AdminManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1207, 670);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adminPanelLbl);
            this.Controls.Add(this.ordersPictureBox);
            this.Controls.Add(this.makeOrderPictureBox);
            this.Controls.Add(this.inventoryPictureBox);
            this.Controls.Add(this.ordersBtn);
            this.Controls.Add(this.makeOrderBtn);
            this.Controls.Add(this.inventoryPanelBtn);
            this.DoubleBuffered = true;
            this.Name = "AdminManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator manager";
            this.Load += new System.EventHandler(this.AdminManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.makeOrderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inventoryPanelBtn;
        private System.Windows.Forms.Button makeOrderBtn;
        private System.Windows.Forms.Button ordersBtn;
        private System.Windows.Forms.PictureBox inventoryPictureBox;
        private System.Windows.Forms.PictureBox makeOrderPictureBox;
        private System.Windows.Forms.PictureBox ordersPictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label adminPanelLbl;
        private System.Windows.Forms.Button backBtn;
    }
}