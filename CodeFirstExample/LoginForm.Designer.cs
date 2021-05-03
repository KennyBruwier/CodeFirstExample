
namespace CodeFirstExample
{
    partial class LoginForm
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
            this.tbLogPassword = new System.Windows.Forms.TextBox();
            this.tbLogEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.btRegister = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRegPassword = new System.Windows.Forms.TextBox();
            this.tbRegLastName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRegEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRegFirstName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbLogPassword
            // 
            this.tbLogPassword.Location = new System.Drawing.Point(338, 121);
            this.tbLogPassword.Name = "tbLogPassword";
            this.tbLogPassword.Size = new System.Drawing.Size(174, 20);
            this.tbLogPassword.TabIndex = 6;
            // 
            // tbLogEmail
            // 
            this.tbLogEmail.Location = new System.Drawing.Point(338, 95);
            this.tbLogEmail.Name = "tbLogEmail";
            this.tbLogEmail.Size = new System.Drawing.Size(174, 20);
            this.tbLogEmail.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Existing User";
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(437, 147);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 7;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btRegister
            // 
            this.btRegister.Location = new System.Drawing.Point(174, 147);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(75, 23);
            this.btRegister.TabIndex = 13;
            this.btRegister.Text = "Register";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "New User";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Last name";
            // 
            // tbRegPassword
            // 
            this.tbRegPassword.Location = new System.Drawing.Point(75, 121);
            this.tbRegPassword.Name = "tbRegPassword";
            this.tbRegPassword.Size = new System.Drawing.Size(174, 20);
            this.tbRegPassword.TabIndex = 4;
            // 
            // tbRegLastName
            // 
            this.tbRegLastName.Location = new System.Drawing.Point(75, 69);
            this.tbRegLastName.Name = "tbRegLastName";
            this.tbRegLastName.Size = new System.Drawing.Size(174, 20);
            this.tbRegLastName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Email";
            // 
            // tbRegEmail
            // 
            this.tbRegEmail.Location = new System.Drawing.Point(75, 95);
            this.tbRegEmail.Name = "tbRegEmail";
            this.tbRegEmail.Size = new System.Drawing.Size(174, 20);
            this.tbRegEmail.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "First name";
            // 
            // tbRegFirstName
            // 
            this.tbRegFirstName.Location = new System.Drawing.Point(75, 44);
            this.tbRegFirstName.Name = "tbRegFirstName";
            this.tbRegFirstName.Size = new System.Drawing.Size(174, 20);
            this.tbRegFirstName.TabIndex = 1;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 182);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbRegFirstName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbRegEmail);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbRegPassword);
            this.Controls.Add(this.tbRegLastName);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLogPassword);
            this.Controls.Add(this.tbLogEmail);
            this.Name = "LoginForm";
            this.Text = "Music app login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogPassword;
        private System.Windows.Forms.TextBox tbLogEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRegPassword;
        private System.Windows.Forms.TextBox tbRegLastName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRegEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRegFirstName;
    }
}