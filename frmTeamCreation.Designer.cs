namespace BRCSS_BasketballStats
{
    partial class frmLogin
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.lblConnectionValue = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F);
            this.lblUsername.Location = new System.Drawing.Point(12, 17);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(77, 18);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F);
            this.lblPassword.Location = new System.Drawing.Point(12, 48);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 18);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password :";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F);
            this.txtUsername.Location = new System.Drawing.Point(98, 15);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(196, 24);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F);
            this.txtPassword.Location = new System.Drawing.Point(98, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(196, 24);
            this.txtPassword.TabIndex = 1;
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F);
            this.lblConnection.Location = new System.Drawing.Point(11, 89);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(85, 18);
            this.lblConnection.TabIndex = 5;
            this.lblConnection.Text = "Connection :";
            // 
            // lblConnectionValue
            // 
            this.lblConnectionValue.AutoSize = true;
            this.lblConnectionValue.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F);
            this.lblConnectionValue.Location = new System.Drawing.Point(104, 89);
            this.lblConnectionValue.Name = "lblConnectionValue";
            this.lblConnectionValue.Size = new System.Drawing.Size(294, 18);
            this.lblConnectionValue.TabIndex = 6;
            this.lblConnectionValue.Text = "Disconnected / Unable to Establish Connection";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F);
            this.btnLogin.Location = new System.Drawing.Point(320, 17);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(139, 53);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 118);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblConnectionValue);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Name = "frmLogin";
            this.Text = "Royals Basketball Stats Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Label lblConnectionValue;
        private System.Windows.Forms.Button btnLogin;
    }
}

