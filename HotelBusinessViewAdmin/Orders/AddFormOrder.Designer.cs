namespace HotelBusinessViewAdmin.Orders
{
    partial class AddFormOrder
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
            this.labelForm = new System.Windows.Forms.Label();
            this.comboBoxForms = new System.Windows.Forms.ComboBox();
            this.buttonAddForm = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelForm
            // 
            this.labelForm.AutoSize = true;
            this.labelForm.Location = new System.Drawing.Point(12, 14);
            this.labelForm.Name = "labelForm";
            this.labelForm.Size = new System.Drawing.Size(129, 13);
            this.labelForm.TabIndex = 5;
            this.labelForm.Text = "Выберите вид комнаты:";
            // 
            // comboBoxForms
            // 
            this.comboBoxForms.FormattingEnabled = true;
            this.comboBoxForms.Location = new System.Drawing.Point(147, 11);
            this.comboBoxForms.Name = "comboBoxForms";
            this.comboBoxForms.Size = new System.Drawing.Size(138, 21);
            this.comboBoxForms.TabIndex = 4;
            // 
            // buttonAddForm
            // 
            this.buttonAddForm.Location = new System.Drawing.Point(61, 83);
            this.buttonAddForm.Name = "buttonAddForm";
            this.buttonAddForm.Size = new System.Drawing.Size(80, 30);
            this.buttonAddForm.TabIndex = 6;
            this.buttonAddForm.Text = "Добавить";
            this.buttonAddForm.UseVisualStyleBackColor = true;
            this.buttonAddForm.Click += new System.EventHandler(this.buttonAddForm_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(177, 83);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 30);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(147, 43);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(138, 20);
            this.textBoxCount.TabIndex = 16;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(28, 43);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(113, 13);
            this.labelCount.TabIndex = 15;
            this.labelCount.Text = "Введите количество:";
            // 
            // AddFormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 123);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelForm);
            this.Controls.Add(this.comboBoxForms);
            this.Controls.Add(this.buttonAddForm);
            this.Controls.Add(this.buttonClose);
            this.Name = "AddFormOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление комнаты";
            this.Load += new System.EventHandler(this.AddFormOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelForm;
        private System.Windows.Forms.ComboBox comboBoxForms;
        private System.Windows.Forms.Button buttonAddForm;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelCount;
    }
}