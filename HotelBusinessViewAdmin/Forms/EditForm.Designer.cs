namespace HotelBusinessViewAdmin.Forms
{
    partial class EditForm
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
            this.textBoxFormName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelSpecification = new System.Windows.Forms.Label();
            this.richTextBoxSpecification = new System.Windows.Forms.RichTextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.buttonAddImage = new System.Windows.Forms.Button();
            this.buttonWatch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFormName
            // 
            this.textBoxFormName.Location = new System.Drawing.Point(71, 12);
            this.textBoxFormName.MaxLength = 16;
            this.textBoxFormName.Name = "textBoxFormName";
            this.textBoxFormName.Size = new System.Drawing.Size(208, 20);
            this.textBoxFormName.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Название";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(169, 154);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 36);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(11, 154);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(110, 36);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelSpecification
            // 
            this.labelSpecification.AutoSize = true;
            this.labelSpecification.Location = new System.Drawing.Point(305, 72);
            this.labelSpecification.Name = "labelSpecification";
            this.labelSpecification.Size = new System.Drawing.Size(60, 13);
            this.labelSpecification.TabIndex = 8;
            this.labelSpecification.Text = "Описание:";
            // 
            // richTextBoxSpecification
            // 
            this.richTextBoxSpecification.Location = new System.Drawing.Point(371, 15);
            this.richTextBoxSpecification.Name = "richTextBoxSpecification";
            this.richTextBoxSpecification.Size = new System.Drawing.Size(369, 175);
            this.richTextBoxSpecification.TabIndex = 10;
            this.richTextBoxSpecification.Text = "";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(71, 52);
            this.textBoxPrice.MaxLength = 16;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(208, 20);
            this.textBoxPrice.TabIndex = 12;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(8, 55);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(36, 13);
            this.labelPrice.TabIndex = 11;
            this.labelPrice.Text = "Цена:";
            // 
            // buttonAddImage
            // 
            this.buttonAddImage.Location = new System.Drawing.Point(12, 215);
            this.buttonAddImage.Name = "buttonAddImage";
            this.buttonAddImage.Size = new System.Drawing.Size(110, 36);
            this.buttonAddImage.TabIndex = 13;
            this.buttonAddImage.Text = "Добавить фото:";
            this.buttonAddImage.UseVisualStyleBackColor = true;
            this.buttonAddImage.Click += new System.EventHandler(this.buttonAddImage_Click);
            // 
            // buttonWatch
            // 
            this.buttonWatch.Location = new System.Drawing.Point(192, 355);
            this.buttonWatch.Name = "buttonWatch";
            this.buttonWatch.Size = new System.Drawing.Size(110, 36);
            this.buttonWatch.TabIndex = 14;
            this.buttonWatch.Text = "Смотреть";
            this.buttonWatch.UseVisualStyleBackColor = true;
            this.buttonWatch.Click += new System.EventHandler(this.buttonWatch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(308, 215);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(565, 324);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 551);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonWatch);
            this.Controls.Add(this.buttonAddImage);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.richTextBoxSpecification);
            this.Controls.Add(this.labelSpecification);
            this.Controls.Add(this.textBoxFormName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFormName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelSpecification;
        private System.Windows.Forms.RichTextBox richTextBoxSpecification;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Button buttonAddImage;
        private System.Windows.Forms.Button buttonWatch;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}