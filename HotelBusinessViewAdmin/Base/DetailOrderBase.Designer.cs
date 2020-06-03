namespace HotelBusinessViewAdmin.Base
{
    partial class DetailOrderBase
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
            this.dataGridViewRooms = new System.Windows.Forms.DataGridView();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.textBoxNumberOrder = new System.Windows.Forms.TextBox();
            this.labelNumberOrder = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.textBoxDateImplement = new System.Windows.Forms.TextBox();
            this.labelDateImplement = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.textBoxPayType = new System.Windows.Forms.TextBox();
            this.labelPayType = new System.Windows.Forms.Label();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.labelFrom = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxBefore = new System.Windows.Forms.TextBox();
            this.labelBefore = new System.Windows.Forms.Label();
            this.labelPaymentType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.groupBoxPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRooms
            // 
            this.dataGridViewRooms.AllowUserToAddRows = false;
            this.dataGridViewRooms.AllowUserToResizeColumns = false;
            this.dataGridViewRooms.AllowUserToResizeRows = false;
            this.dataGridViewRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRooms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewRooms.Location = new System.Drawing.Point(291, 28);
            this.dataGridViewRooms.MultiSelect = false;
            this.dataGridViewRooms.Name = "dataGridViewRooms";
            this.dataGridViewRooms.RowHeadersVisible = false;
            this.dataGridViewRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRooms.Size = new System.Drawing.Size(284, 386);
            this.dataGridViewRooms.TabIndex = 12;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.AllowUserToAddRows = false;
            this.dataGridViewServices.AllowUserToResizeColumns = false;
            this.dataGridViewServices.AllowUserToResizeRows = false;
            this.dataGridViewServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewServices.Location = new System.Drawing.Point(606, 28);
            this.dataGridViewServices.MultiSelect = false;
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.RowHeadersVisible = false;
            this.dataGridViewServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServices.Size = new System.Drawing.Size(284, 386);
            this.dataGridViewServices.TabIndex = 13;
            // 
            // textBoxNumberOrder
            // 
            this.textBoxNumberOrder.Enabled = false;
            this.textBoxNumberOrder.Location = new System.Drawing.Point(94, 66);
            this.textBoxNumberOrder.Name = "textBoxNumberOrder";
            this.textBoxNumberOrder.Size = new System.Drawing.Size(159, 20);
            this.textBoxNumberOrder.TabIndex = 14;
            this.textBoxNumberOrder.TextChanged += new System.EventHandler(this.textBoxNumberOrder_TextChanged);
            // 
            // labelNumberOrder
            // 
            this.labelNumberOrder.AutoSize = true;
            this.labelNumberOrder.Location = new System.Drawing.Point(12, 69);
            this.labelNumberOrder.Name = "labelNumberOrder";
            this.labelNumberOrder.Size = new System.Drawing.Size(41, 13);
            this.labelNumberOrder.TabIndex = 15;
            this.labelNumberOrder.Text = "Бронь:";
            this.labelNumberOrder.Click += new System.EventHandler(this.labelNumberOrder_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 104);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(83, 13);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "Статус заказа:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Location = new System.Drawing.Point(94, 101);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(159, 20);
            this.textBoxStatus.TabIndex = 17;
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.Controls.Add(this.textBoxPayType);
            this.groupBoxPayment.Controls.Add(this.labelPayType);
            this.groupBoxPayment.Controls.Add(this.textBoxSum);
            this.groupBoxPayment.Controls.Add(this.labelSum);
            this.groupBoxPayment.Controls.Add(this.labelDateImplement);
            this.groupBoxPayment.Controls.Add(this.textBoxDateImplement);
            this.groupBoxPayment.Location = new System.Drawing.Point(12, 237);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(237, 131);
            this.groupBoxPayment.TabIndex = 18;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Оплата:";
            // 
            // textBoxDateImplement
            // 
            this.textBoxDateImplement.Enabled = false;
            this.textBoxDateImplement.Location = new System.Drawing.Point(95, 28);
            this.textBoxDateImplement.Name = "textBoxDateImplement";
            this.textBoxDateImplement.Size = new System.Drawing.Size(124, 20);
            this.textBoxDateImplement.TabIndex = 15;
            // 
            // labelDateImplement
            // 
            this.labelDateImplement.AutoSize = true;
            this.labelDateImplement.Location = new System.Drawing.Point(6, 35);
            this.labelDateImplement.Name = "labelDateImplement";
            this.labelDateImplement.Size = new System.Drawing.Size(76, 13);
            this.labelDateImplement.TabIndex = 19;
            this.labelDateImplement.Text = "Дата оплаты:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(6, 64);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(84, 13);
            this.labelSum.TabIndex = 19;
            this.labelSum.Text = "Сумма оплаты:";
            // 
            // textBoxSum
            // 
            this.textBoxSum.Enabled = false;
            this.textBoxSum.Location = new System.Drawing.Point(95, 64);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(124, 20);
            this.textBoxSum.TabIndex = 19;
            // 
            // textBoxPayType
            // 
            this.textBoxPayType.Enabled = false;
            this.textBoxPayType.Location = new System.Drawing.Point(95, 92);
            this.textBoxPayType.Name = "textBoxPayType";
            this.textBoxPayType.Size = new System.Drawing.Size(124, 20);
            this.textBoxPayType.TabIndex = 20;
            // 
            // labelPayType
            // 
            this.labelPayType.AutoSize = true;
            this.labelPayType.Enabled = false;
            this.labelPayType.Location = new System.Drawing.Point(6, 92);
            this.labelPayType.Name = "labelPayType";
            this.labelPayType.Size = new System.Drawing.Size(69, 13);
            this.labelPayType.TabIndex = 21;
            this.labelPayType.Text = "Тип оплаты:";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Enabled = false;
            this.textBoxFrom.Location = new System.Drawing.Point(94, 156);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(159, 20);
            this.textBoxFrom.TabIndex = 20;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(10, 159);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(76, 13);
            this.labelFrom.TabIndex = 19;
            this.labelFrom.Text = "Дата въезда:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Enabled = false;
            this.textBoxUser.Location = new System.Drawing.Point(93, 28);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(159, 20);
            this.textBoxUser.TabIndex = 22;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 28);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(46, 13);
            this.labelUser.TabIndex = 21;
            this.labelUser.Text = "Клиент:";
            // 
            // textBoxBefore
            // 
            this.textBoxBefore.Enabled = false;
            this.textBoxBefore.Location = new System.Drawing.Point(93, 182);
            this.textBoxBefore.Name = "textBoxBefore";
            this.textBoxBefore.Size = new System.Drawing.Size(159, 20);
            this.textBoxBefore.TabIndex = 24;
            // 
            // labelBefore
            // 
            this.labelBefore.AutoSize = true;
            this.labelBefore.Location = new System.Drawing.Point(9, 185);
            this.labelBefore.Name = "labelBefore";
            this.labelBefore.Size = new System.Drawing.Size(77, 13);
            this.labelBefore.TabIndex = 23;
            this.labelBefore.Text = "Дата выезда:";
            // 
            // labelPaymentType
            // 
            this.labelPaymentType.AutoSize = true;
            this.labelPaymentType.Location = new System.Drawing.Point(81, 221);
            this.labelPaymentType.Name = "labelPaymentType";
            this.labelPaymentType.Size = new System.Drawing.Size(93, 13);
            this.labelPaymentType.TabIndex = 25;
            this.labelPaymentType.Text = "Тут будет оплата";
            // 
            // DetailOrderBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 438);
            this.Controls.Add(this.labelPaymentType);
            this.Controls.Add(this.textBoxBefore);
            this.Controls.Add(this.labelBefore);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.groupBoxPayment);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelNumberOrder);
            this.Controls.Add(this.textBoxNumberOrder);
            this.Controls.Add(this.dataGridViewServices);
            this.Controls.Add(this.dataGridViewRooms);
            this.Name = "DetailOrderBase";
            this.Text = "DetailOrderBase";
            this.Load += new System.EventHandler(this.DetailOrderBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRooms;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.TextBox textBoxNumberOrder;
        private System.Windows.Forms.Label labelNumberOrder;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.GroupBox groupBoxPayment;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.Label labelDateImplement;
        private System.Windows.Forms.TextBox textBoxDateImplement;
        private System.Windows.Forms.TextBox textBoxPayType;
        private System.Windows.Forms.Label labelPayType;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxBefore;
        private System.Windows.Forms.Label labelBefore;
        private System.Windows.Forms.Label labelPaymentType;
    }
}