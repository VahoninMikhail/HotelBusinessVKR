namespace HotelBusinessViewAdmin.Autorization
{
    partial class FormAuthorization
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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.sign_Up = new System.Windows.Forms.Button();
            this.sign_In = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(85, 58);
            this.textBoxPassword.MaxLength = 32;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(167, 20);
            this.textBoxPassword.TabIndex = 11;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(85, 22);
            this.textBoxLogin.MaxLength = 32;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(167, 20);
            this.textBoxLogin.TabIndex = 10;
            // 
            // sign_Up
            // 
            this.sign_Up.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sign_Up.Location = new System.Drawing.Point(85, 137);
            this.sign_Up.Name = "sign_Up";
            this.sign_Up.Size = new System.Drawing.Size(132, 29);
            this.sign_Up.TabIndex = 9;
            this.sign_Up.Text = "Регистрация";
            this.sign_Up.UseVisualStyleBackColor = true;
            this.sign_Up.Click += new System.EventHandler(this.sign_Up_Click);
            // 
            // sign_In
            // 
            this.sign_In.AutoSize = true;
            this.sign_In.Location = new System.Drawing.Point(85, 99);
            this.sign_In.Name = "sign_In";
            this.sign_In.Size = new System.Drawing.Size(132, 29);
            this.sign_In.TabIndex = 8;
            this.sign_In.Text = "Войти";
            this.sign_In.UseVisualStyleBackColor = true;
            this.sign_In.Click += new System.EventHandler(this.sign_In_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Логин:";
            // 
            // FormAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 187);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.sign_Up);
            this.Controls.Add(this.sign_In);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAuthorization";
            this.Text = "FormAuthorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button sign_Up;
        private System.Windows.Forms.Button sign_In;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}