namespace HotelBusinessViewAdmin.Base
{
    partial class PaymentOrder
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
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.checkBoxCard = new System.Windows.Forms.CheckBox();
            this.checkBoxCash = new System.Windows.Forms.CheckBox();
            this.buttonPayment = new System.Windows.Forms.Button();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.labelSum = new System.Windows.Forms.Label();
            this.groupBoxPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.Controls.Add(this.checkBoxCard);
            this.groupBoxPayment.Controls.Add(this.checkBoxCash);
            this.groupBoxPayment.Controls.Add(this.buttonPayment);
            this.groupBoxPayment.Location = new System.Drawing.Point(28, 46);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(148, 77);
            this.groupBoxPayment.TabIndex = 22;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Вид оплаты:";
            // 
            // checkBoxCard
            // 
            this.checkBoxCard.AutoSize = true;
            this.checkBoxCard.Location = new System.Drawing.Point(91, 15);
            this.checkBoxCard.Name = "checkBoxCard";
            this.checkBoxCard.Size = new System.Drawing.Size(56, 17);
            this.checkBoxCard.TabIndex = 1;
            this.checkBoxCard.Text = "Карта";
            this.checkBoxCard.UseVisualStyleBackColor = true;
            // 
            // checkBoxCash
            // 
            this.checkBoxCash.AutoSize = true;
            this.checkBoxCash.Location = new System.Drawing.Point(7, 15);
            this.checkBoxCash.Name = "checkBoxCash";
            this.checkBoxCash.Size = new System.Drawing.Size(77, 17);
            this.checkBoxCash.TabIndex = 0;
            this.checkBoxCash.Text = "Наличные";
            this.checkBoxCash.UseVisualStyleBackColor = true;
            // 
            // buttonPayment
            // 
            this.buttonPayment.Location = new System.Drawing.Point(10, 31);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(118, 40);
            this.buttonPayment.TabIndex = 5;
            this.buttonPayment.Text = "Оплатить";
            this.buttonPayment.UseVisualStyleBackColor = true;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Enabled = false;
            this.textBoxSum.Location = new System.Drawing.Point(82, 20);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(110, 20);
            this.textBoxSum.TabIndex = 21;
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(11, 20);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(65, 13);
            this.labelSum.TabIndex = 20;
            this.labelSum.Text = "Стоимость:";
            // 
            // PaymentOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 160);
            this.Controls.Add(this.groupBoxPayment);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelSum);
            this.Name = "PaymentOrder";
            this.Text = "PaymentOrder";
            this.Load += new System.EventHandler(this.PaymentOrder_Load);
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayment;
        private System.Windows.Forms.CheckBox checkBoxCard;
        private System.Windows.Forms.CheckBox checkBoxCash;
        private System.Windows.Forms.Button buttonPayment;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label labelSum;
    }
}