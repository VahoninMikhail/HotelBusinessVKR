namespace HotelBusinessViewAdmin.Orders
{
    partial class CreateOrder
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
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.groupBoxForms = new System.Windows.Forms.GroupBox();
            this.textBoxSumRoom = new System.Windows.Forms.TextBox();
            this.labelSumRoom = new System.Windows.Forms.Label();
            this.dataGridViewForms = new System.Windows.Forms.DataGridView();
            this.buttonAddForm = new System.Windows.Forms.Button();
            this.buttonDelForm = new System.Windows.Forms.Button();
            this.groupBoxServices = new System.Windows.Forms.GroupBox();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.textBoxSumService = new System.Windows.Forms.TextBox();
            this.labelSumService = new System.Windows.Forms.Label();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.buttonDelService = new System.Windows.Forms.Button();
            this.dataGridViewFreeService = new System.Windows.Forms.DataGridView();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonSaveOrder = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelBefore = new System.Windows.Forms.Label();
            this.dateTimePickerBefore = new System.Windows.Forms.DateTimePicker();
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.checkBoxCard = new System.Windows.Forms.CheckBox();
            this.checkBoxCash = new System.Windows.Forms.CheckBox();
            this.groupBoxUserPeriod = new System.Windows.Forms.GroupBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelFreeServices = new System.Windows.Forms.Label();
            this.groupBoxForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForms)).BeginInit();
            this.groupBoxServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreeService)).BeginInit();
            this.groupBoxPayment.SuspendLayout();
            this.groupBoxUserPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(111, 13);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(138, 21);
            this.comboBoxUsers.TabIndex = 0;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(6, 16);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(104, 13);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "Выберите клиента:";
            // 
            // groupBoxForms
            // 
            this.groupBoxForms.Controls.Add(this.textBoxSumRoom);
            this.groupBoxForms.Controls.Add(this.labelSumRoom);
            this.groupBoxForms.Controls.Add(this.dataGridViewForms);
            this.groupBoxForms.Controls.Add(this.buttonAddForm);
            this.groupBoxForms.Controls.Add(this.buttonDelForm);
            this.groupBoxForms.Enabled = false;
            this.groupBoxForms.Location = new System.Drawing.Point(16, 50);
            this.groupBoxForms.Name = "groupBoxForms";
            this.groupBoxForms.Size = new System.Drawing.Size(264, 395);
            this.groupBoxForms.TabIndex = 10;
            this.groupBoxForms.TabStop = false;
            this.groupBoxForms.Text = "Выбранные номера:";
            // 
            // textBoxSumRoom
            // 
            this.textBoxSumRoom.Enabled = false;
            this.textBoxSumRoom.Location = new System.Drawing.Point(139, 361);
            this.textBoxSumRoom.Name = "textBoxSumRoom";
            this.textBoxSumRoom.Size = new System.Drawing.Size(110, 20);
            this.textBoxSumRoom.TabIndex = 16;
            // 
            // labelSumRoom
            // 
            this.labelSumRoom.AutoSize = true;
            this.labelSumRoom.Location = new System.Drawing.Point(29, 368);
            this.labelSumRoom.Name = "labelSumRoom";
            this.labelSumRoom.Size = new System.Drawing.Size(104, 13);
            this.labelSumRoom.TabIndex = 15;
            this.labelSumRoom.Text = "Итого по номерам:";
            // 
            // dataGridViewForms
            // 
            this.dataGridViewForms.AllowUserToAddRows = false;
            this.dataGridViewForms.AllowUserToResizeColumns = false;
            this.dataGridViewForms.AllowUserToResizeRows = false;
            this.dataGridViewForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewForms.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewForms.MultiSelect = false;
            this.dataGridViewForms.Name = "dataGridViewForms";
            this.dataGridViewForms.RowHeadersVisible = false;
            this.dataGridViewForms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewForms.Size = new System.Drawing.Size(250, 300);
            this.dataGridViewForms.TabIndex = 1;
            this.dataGridViewForms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewForms_CellClick);
            // 
            // buttonAddForm
            // 
            this.buttonAddForm.Location = new System.Drawing.Point(6, 325);
            this.buttonAddForm.Name = "buttonAddForm";
            this.buttonAddForm.Size = new System.Drawing.Size(110, 30);
            this.buttonAddForm.TabIndex = 2;
            this.buttonAddForm.Text = "Выбрать комнату";
            this.buttonAddForm.UseVisualStyleBackColor = true;
            this.buttonAddForm.Click += new System.EventHandler(this.buttonAddForm_Click);
            // 
            // buttonDelForm
            // 
            this.buttonDelForm.Location = new System.Drawing.Point(146, 325);
            this.buttonDelForm.Name = "buttonDelForm";
            this.buttonDelForm.Size = new System.Drawing.Size(110, 30);
            this.buttonDelForm.TabIndex = 4;
            this.buttonDelForm.Text = "Удалить";
            this.buttonDelForm.UseVisualStyleBackColor = true;
            this.buttonDelForm.Click += new System.EventHandler(this.buttonDelForm_Click);
            // 
            // groupBoxServices
            // 
            this.groupBoxServices.Controls.Add(this.dataGridViewService);
            this.groupBoxServices.Controls.Add(this.textBoxSumService);
            this.groupBoxServices.Controls.Add(this.labelSumService);
            this.groupBoxServices.Controls.Add(this.buttonAddService);
            this.groupBoxServices.Controls.Add(this.buttonDelService);
            this.groupBoxServices.Enabled = false;
            this.groupBoxServices.Location = new System.Drawing.Point(286, 50);
            this.groupBoxServices.Name = "groupBoxServices";
            this.groupBoxServices.Size = new System.Drawing.Size(367, 395);
            this.groupBoxServices.TabIndex = 11;
            this.groupBoxServices.TabStop = false;
            this.groupBoxServices.Text = "Выбранные услуги:";
            // 
            // dataGridViewService
            // 
            this.dataGridViewService.AllowUserToAddRows = false;
            this.dataGridViewService.AllowUserToResizeColumns = false;
            this.dataGridViewService.AllowUserToResizeRows = false;
            this.dataGridViewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewService.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewService.Location = new System.Drawing.Point(8, 19);
            this.dataGridViewService.MultiSelect = false;
            this.dataGridViewService.Name = "dataGridViewService";
            this.dataGridViewService.RowHeadersVisible = false;
            this.dataGridViewService.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewService.Size = new System.Drawing.Size(350, 300);
            this.dataGridViewService.TabIndex = 17;
            // 
            // textBoxSumService
            // 
            this.textBoxSumService.Enabled = false;
            this.textBoxSumService.Location = new System.Drawing.Point(148, 365);
            this.textBoxSumService.Name = "textBoxSumService";
            this.textBoxSumService.Size = new System.Drawing.Size(110, 20);
            this.textBoxSumService.TabIndex = 16;
            // 
            // labelSumService
            // 
            this.labelSumService.AutoSize = true;
            this.labelSumService.Location = new System.Drawing.Point(43, 368);
            this.labelSumService.Name = "labelSumService";
            this.labelSumService.Size = new System.Drawing.Size(99, 13);
            this.labelSumService.TabIndex = 15;
            this.labelSumService.Text = "Итого по услугам:";
            // 
            // buttonAddService
            // 
            this.buttonAddService.Location = new System.Drawing.Point(6, 325);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(110, 30);
            this.buttonAddService.TabIndex = 2;
            this.buttonAddService.Text = "Добавить услугу";
            this.buttonAddService.UseVisualStyleBackColor = true;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);
            // 
            // buttonDelService
            // 
            this.buttonDelService.Location = new System.Drawing.Point(248, 325);
            this.buttonDelService.Name = "buttonDelService";
            this.buttonDelService.Size = new System.Drawing.Size(110, 30);
            this.buttonDelService.TabIndex = 4;
            this.buttonDelService.Text = "Удалить";
            this.buttonDelService.UseVisualStyleBackColor = true;
            this.buttonDelService.Click += new System.EventHandler(this.buttonDelService_Click);
            // 
            // dataGridViewFreeService
            // 
            this.dataGridViewFreeService.AllowUserToAddRows = false;
            this.dataGridViewFreeService.AllowUserToResizeColumns = false;
            this.dataGridViewFreeService.AllowUserToResizeRows = false;
            this.dataGridViewFreeService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFreeService.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewFreeService.Location = new System.Drawing.Point(662, 69);
            this.dataGridViewFreeService.MultiSelect = false;
            this.dataGridViewFreeService.Name = "dataGridViewFreeService";
            this.dataGridViewFreeService.RowHeadersVisible = false;
            this.dataGridViewFreeService.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewFreeService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFreeService.Size = new System.Drawing.Size(210, 303);
            this.dataGridViewFreeService.TabIndex = 12;
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(22, 448);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(40, 13);
            this.labelSum.TabIndex = 13;
            this.labelSum.Text = "Итого:";
            // 
            // textBoxSum
            // 
            this.textBoxSum.Enabled = false;
            this.textBoxSum.Location = new System.Drawing.Point(68, 445);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(110, 20);
            this.textBoxSum.TabIndex = 14;
            // 
            // buttonSaveOrder
            // 
            this.buttonSaveOrder.Location = new System.Drawing.Point(15, 31);
            this.buttonSaveOrder.Name = "buttonSaveOrder";
            this.buttonSaveOrder.Size = new System.Drawing.Size(118, 40);
            this.buttonSaveOrder.TabIndex = 5;
            this.buttonSaveOrder.Text = "Оформить заказ";
            this.buttonSaveOrder.UseVisualStyleBackColor = true;
            this.buttonSaveOrder.Click += new System.EventHandler(this.buttonSaveOrder_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(333, 14);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerFrom.TabIndex = 16;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(253, 16);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(76, 13);
            this.labelFrom.TabIndex = 15;
            this.labelFrom.Text = "Дата въезда:";
            // 
            // labelBefore
            // 
            this.labelBefore.AutoSize = true;
            this.labelBefore.Location = new System.Drawing.Point(488, 16);
            this.labelBefore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBefore.Name = "labelBefore";
            this.labelBefore.Size = new System.Drawing.Size(77, 13);
            this.labelBefore.TabIndex = 17;
            this.labelBefore.Text = "Дата выезда:";
            // 
            // dateTimePickerBefore
            // 
            this.dateTimePickerBefore.Location = new System.Drawing.Point(569, 14);
            this.dateTimePickerBefore.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerBefore.Name = "dateTimePickerBefore";
            this.dateTimePickerBefore.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerBefore.TabIndex = 18;
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.Controls.Add(this.checkBoxCard);
            this.groupBoxPayment.Controls.Add(this.checkBoxCash);
            this.groupBoxPayment.Controls.Add(this.buttonSaveOrder);
            this.groupBoxPayment.Enabled = false;
            this.groupBoxPayment.Location = new System.Drawing.Point(184, 448);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(148, 77);
            this.groupBoxPayment.TabIndex = 19;
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
            // groupBoxUserPeriod
            // 
            this.groupBoxUserPeriod.Controls.Add(this.labelUser);
            this.groupBoxUserPeriod.Controls.Add(this.comboBoxUsers);
            this.groupBoxUserPeriod.Controls.Add(this.dateTimePickerBefore);
            this.groupBoxUserPeriod.Controls.Add(this.labelFrom);
            this.groupBoxUserPeriod.Controls.Add(this.labelBefore);
            this.groupBoxUserPeriod.Controls.Add(this.dateTimePickerFrom);
            this.groupBoxUserPeriod.Location = new System.Drawing.Point(16, 3);
            this.groupBoxUserPeriod.Name = "groupBoxUserPeriod";
            this.groupBoxUserPeriod.Size = new System.Drawing.Size(725, 44);
            this.groupBoxUserPeriod.TabIndex = 20;
            this.groupBoxUserPeriod.TabStop = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(837, 8);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(102, 39);
            this.buttonEdit.TabIndex = 17;
            this.buttonEdit.Text = "Изменить даты и пользователя";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(747, 10);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(80, 30);
            this.buttonOk.TabIndex = 21;
            this.buttonOk.Text = "Применить";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelFreeServices
            // 
            this.labelFreeServices.AutoSize = true;
            this.labelFreeServices.Location = new System.Drawing.Point(659, 50);
            this.labelFreeServices.Name = "labelFreeServices";
            this.labelFreeServices.Size = new System.Drawing.Size(108, 13);
            this.labelFreeServices.TabIndex = 22;
            this.labelFreeServices.Text = "Бесплатные услуги:";
            // 
            // CreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 555);
            this.Controls.Add(this.labelFreeServices);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.groupBoxUserPeriod);
            this.Controls.Add(this.groupBoxPayment);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.dataGridViewFreeService);
            this.Controls.Add(this.groupBoxServices);
            this.Controls.Add(this.groupBoxForms);
            this.Name = "CreateOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание заказа";
            this.Load += new System.EventHandler(this.CreateOrder_Load);
            this.groupBoxForms.ResumeLayout(false);
            this.groupBoxForms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForms)).EndInit();
            this.groupBoxServices.ResumeLayout(false);
            this.groupBoxServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreeService)).EndInit();
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            this.groupBoxUserPeriod.ResumeLayout(false);
            this.groupBoxUserPeriod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.GroupBox groupBoxForms;
        private System.Windows.Forms.DataGridView dataGridViewForms;
        private System.Windows.Forms.Button buttonAddForm;
        private System.Windows.Forms.Button buttonDelForm;
        private System.Windows.Forms.GroupBox groupBoxServices;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonDelService;
        private System.Windows.Forms.DataGridView dataGridViewFreeService;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button buttonSaveOrder;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelBefore;
        private System.Windows.Forms.DateTimePicker dateTimePickerBefore;
        private System.Windows.Forms.TextBox textBoxSumRoom;
        private System.Windows.Forms.Label labelSumRoom;
        private System.Windows.Forms.TextBox textBoxSumService;
        private System.Windows.Forms.Label labelSumService;
        private System.Windows.Forms.GroupBox groupBoxPayment;
        private System.Windows.Forms.CheckBox checkBoxCard;
        private System.Windows.Forms.CheckBox checkBoxCash;
        private System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.GroupBox groupBoxUserPeriod;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelFreeServices;
    }
}