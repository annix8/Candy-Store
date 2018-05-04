namespace CandyStore.Client
{
    partial class Main
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
            this.customerGroupBox = new System.Windows.Forms.GroupBox();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.firstnameLabel = new System.Windows.Forms.Label();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.customerContinueBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.adminGroupBox = new System.Windows.Forms.GroupBox();
            this.identificationNumberLbl = new System.Windows.Forms.Label();
            this.identificationNumberBox = new System.Windows.Forms.TextBox();
            this.adminLoginButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customerGroupBox.SuspendLayout();
            this.adminGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerGroupBox
            // 
            this.customerGroupBox.Controls.Add(this.lastnameLabel);
            this.customerGroupBox.Controls.Add(this.firstnameLabel);
            this.customerGroupBox.Controls.Add(this.lastNameBox);
            this.customerGroupBox.Controls.Add(this.firstNameBox);
            this.customerGroupBox.Controls.Add(this.customerContinueBtn);
            this.customerGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerGroupBox.Location = new System.Drawing.Point(16, 334);
            this.customerGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.customerGroupBox.Name = "customerGroupBox";
            this.customerGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.customerGroupBox.Size = new System.Drawing.Size(675, 310);
            this.customerGroupBox.TabIndex = 0;
            this.customerGroupBox.TabStop = false;
            this.customerGroupBox.Text = "Enter names to browse sweets";
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lastnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastnameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lastnameLabel.Location = new System.Drawing.Point(273, 138);
            this.lastnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(103, 25);
            this.lastnameLabel.TabIndex = 11;
            this.lastnameLabel.Text = "Last name";
            // 
            // firstnameLabel
            // 
            this.firstnameLabel.AutoSize = true;
            this.firstnameLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.firstnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstnameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.firstnameLabel.Location = new System.Drawing.Point(273, 50);
            this.firstnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstnameLabel.Name = "firstnameLabel";
            this.firstnameLabel.Size = new System.Drawing.Size(103, 25);
            this.firstnameLabel.TabIndex = 10;
            this.firstnameLabel.Text = "First name";
            // 
            // lastNameBox
            // 
            this.lastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameBox.Location = new System.Drawing.Point(227, 166);
            this.lastNameBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(216, 34);
            this.lastNameBox.TabIndex = 9;
            // 
            // firstNameBox
            // 
            this.firstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameBox.Location = new System.Drawing.Point(227, 79);
            this.firstNameBox.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(216, 34);
            this.firstNameBox.TabIndex = 8;
            // 
            // customerContinueBtn
            // 
            this.customerContinueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customerContinueBtn.Location = new System.Drawing.Point(225, 234);
            this.customerContinueBtn.Margin = new System.Windows.Forms.Padding(4);
            this.customerContinueBtn.Name = "customerContinueBtn";
            this.customerContinueBtn.Size = new System.Drawing.Size(219, 39);
            this.customerContinueBtn.TabIndex = 7;
            this.customerContinueBtn.Text = "Continue";
            this.customerContinueBtn.UseVisualStyleBackColor = true;
            this.customerContinueBtn.Click += new System.EventHandler(this.customerContinueBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(455, 748);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(239, 54);
            this.exitBtn.TabIndex = 13;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // adminGroupBox
            // 
            this.adminGroupBox.Controls.Add(this.identificationNumberLbl);
            this.adminGroupBox.Controls.Add(this.identificationNumberBox);
            this.adminGroupBox.Controls.Add(this.adminLoginButton);
            this.adminGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminGroupBox.Location = new System.Drawing.Point(16, 34);
            this.adminGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.adminGroupBox.Name = "adminGroupBox";
            this.adminGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.adminGroupBox.Size = new System.Drawing.Size(675, 190);
            this.adminGroupBox.TabIndex = 14;
            this.adminGroupBox.TabStop = false;
            this.adminGroupBox.Text = "Login as administrator";
            // 
            // identificationNumberLbl
            // 
            this.identificationNumberLbl.AutoSize = true;
            this.identificationNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.identificationNumberLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.identificationNumberLbl.Location = new System.Drawing.Point(234, 41);
            this.identificationNumberLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.identificationNumberLbl.Name = "identificationNumberLbl";
            this.identificationNumberLbl.Size = new System.Drawing.Size(191, 25);
            this.identificationNumberLbl.TabIndex = 7;
            this.identificationNumberLbl.Text = "Identification number";
            // 
            // identificationNumberBox
            // 
            this.identificationNumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identificationNumberBox.Location = new System.Drawing.Point(185, 70);
            this.identificationNumberBox.Margin = new System.Windows.Forms.Padding(4);
            this.identificationNumberBox.Name = "identificationNumberBox";
            this.identificationNumberBox.PasswordChar = '*';
            this.identificationNumberBox.Size = new System.Drawing.Size(292, 30);
            this.identificationNumberBox.TabIndex = 5;
            // 
            // adminLoginButton
            // 
            this.adminLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminLoginButton.Location = new System.Drawing.Point(227, 124);
            this.adminLoginButton.Margin = new System.Windows.Forms.Padding(4);
            this.adminLoginButton.Name = "adminLoginButton";
            this.adminLoginButton.Size = new System.Drawing.Size(217, 37);
            this.adminLoginButton.TabIndex = 4;
            this.adminLoginButton.Text = "Login";
            this.adminLoginButton.UseVisualStyleBackColor = true;
            this.adminLoginButton.Click += new System.EventHandler(this.adminLoginButton_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(31, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(647, 2);
            this.label2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(31, 670);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(647, 2);
            this.label3.TabIndex = 16;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::CandyStore.Client.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(709, 828);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adminGroupBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.customerGroupBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Main_Load);
            this.customerGroupBox.ResumeLayout(false);
            this.customerGroupBox.PerformLayout();
            this.adminGroupBox.ResumeLayout(false);
            this.adminGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox customerGroupBox;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.Label firstnameLabel;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Button customerContinueBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.GroupBox adminGroupBox;
        private System.Windows.Forms.Label identificationNumberLbl;
        private System.Windows.Forms.TextBox identificationNumberBox;
        private System.Windows.Forms.Button adminLoginButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}