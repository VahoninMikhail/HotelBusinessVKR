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
            this.dataGridViewForms = new System.Windows.Forms.DataGridView();
            this.buttonAddForm = new System.Windows.Forms.Button();
            this.buttonEditForm = new System.Windows.Forms.Button();
            this.buttonDelForm = new System.Windows.Forms.Button();
            this.groupBoxServices = new System.Windows.Forms.GroupBox();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.buttonEditService = new System.Windows.Forms.Button();
            this.buttonDelService = new System.Windows.Forms.Button();
            this.dataGridViewFreeService = new System.Windows.Forms.DataGridView();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonSaveOrder = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelBefore = new System.Windows.Forms.Label();
            this.dateTimePickerBefore = new System.Windows.Forms.DateTimePicker();
            this.textBoxSumRoom = new System.Windows.Forms.TextBox();
            this.labelSumRoom = new System.Windows.Forms.Label();
            this.textBoxSumService = new System.Windows.Forms.TextBox();
            this.labelSumService = new System.Windows.Forms.Label();
            this.groupBoxForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForms)).BeginInit();
            this.groupBoxServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreeService)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(123, 10);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(138, 21);
            this.comboBoxUsers.TabIndex = 0;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(13, 13);
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
            this.groupBoxForms.Controls.Add(this.buttonEditForm);
            this.groupBoxForms.Controls.Add(this.buttonDelForm);
            this.groupBoxForms.Location = new System.Drawing.Point(16, 43);
            this.groupBoxForms.Name = "groupBoxForms";
            this.groupBoxForms.Size = new System.Drawing.Size(313, 425);
            this.groupBoxForms.TabIndex = 10;
            this.groupBoxForms.TabStop = false;
            this.groupBoxForms.Text = "Выбранные номера:";
            // 
            // dataGridViewForms
            // 
            this.dataGridViewForms.AllowUserToAddRows = false;
            this.dataGridViewForms.AllowUserToResizeColumns = false;
            this.dataGridViewForms.AllowUserToResizeRows = false;
            this.dataGridViewForms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewForms.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewForms.MultiSelect = false;
            this.dataGridViewForms.Name = "dataGridViewForms";
            this.dataGridViewForms.RowHeadersVisible = false;
            this.dataGridViewForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewForms.Size = new System.Drawing.Size(287, 321);
            this.dataGridViewForms.TabIndex = 1;
            // 
            // buttonAddForm
            // 
            this.buttonAddForm.Location = new System.Drawing.Point(6, 351);
            this.buttonAddForm.Name = "buttonAddForm";
            this.buttonAddForm.Size = new System.Drawing.Size(85, 33);
            this.buttonAddForm.TabIndex = 2;
            this.buttonAddForm.Text = "Добавить";
            this.buttonAddForm.UseVisualStyleBackColor = true;
            this.buttonAddForm.Click += new System.EventHandler(this.buttonAddForm_Click);
            // 
            // buttonEditForm
            // 
            this.buttonEditForm.Location = new System.Drawing.Point(97, 351);
            this.buttonEditForm.Name = "buttonEditForm";
            this.buttonEditForm.Size = new System.Drawing.Size(80, 33);
            this.buttonEditForm.TabIndex = 3;
            this.buttonEditForm.Text = "Изменить";
            this.buttonEditForm.UseVisualStyleBackColor = true;
            this.buttonEditForm.Click += new System.EventHandler(this.buttonEditForm_Click);
            // 
            // buttonDelForm
            // 
            this.buttonDelForm.Location = new System.Drawing.Point(183, 351);
            this.buttonDelForm.Name = "buttonDelForm";
            this.buttonDelForm.Size = new System.Drawing.Size(97, 33);
            this.buttonDelForm.TabIndex = 4;
            this.buttonDelForm.Text = "Удалить";
            this.buttonDelForm.UseVisualStyleBackColor = true;
            this.buttonDelForm.Click += new System.EventHandler(this.buttonDelForm_Click);
            // 
            // groupBoxServices
            // 
            this.groupBoxServices.Controls.Add(this.textBoxSumService);
            this.groupBoxServices.Controls.Add(this.labelSumService);
            this.groupBoxServices.Controls.Add(this.dataGridViewService);
            this.groupBoxServices.Controls.Add(this.buttonAddService);
            this.groupBoxServices.Controls.Add(this.buttonEditService);
            this.groupBoxServices.Controls.Add(this.buttonDelService);
            this.groupBoxServices.Location = new System.Drawing.Point(345, 43);
            this.groupBoxServices.Name = "groupBoxServices";
            this.groupBoxServices.Size = new System.Drawing.Size(313, 425);
            this.groupBoxServices.TabIndex = 11;
            this.groupBoxServices.TabStop = false;
            this.groupBoxServices.Text = "Выбранные услуги:";
            // 
            // dataGridViewService
            // 
            this.dataGridViewService.AllowUserToAddRows = false;
            this.dataGridViewService.AllowUserToResizeColumns = false;
            this.dataGridViewService.AllowUserToResizeRows = false;
            this.dataGridViewService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewService.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewService.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewService.MultiSelect = false;
            this.dataGridViewService.Name = "dataGridViewService";
            this.dataGridViewService.RowHeadersVisible = false;
            this.dataGridViewService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewService.Size = new System.Drawing.Size(287, 321);
            this.dataGridViewService.TabIndex = 1;
            // 
            // buttonAddService
            // 
            this.buttonAddService.Location = new System.Drawing.Point(6, 351);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(85, 33);
            this.buttonAddService.TabIndex = 2;
            this.buttonAddService.Text = "Добавить";
            this.buttonAddService.UseVisualStyleBackColor = true;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);
            // 
            // buttonEditService
            // 
            this.buttonEditService.Location = new System.Drawing.Point(97, 351);
            this.buttonEditService.Name = "buttonEditService";
            this.buttonEditService.Size = new System.Drawing.Size(80, 33);
            this.buttonEditService.TabIndex = 3;
            this.buttonEditService.Text = "Изменить";
            this.buttonEditService.UseVisualStyleBackColor = true;
            this.buttonEditService.Click += new System.EventHandler(this.buttonEditService_Click);
            // 
            // buttonDelService
            // 
            this.buttonDelService.Location = new System.Drawing.Point(183, 351);
            this.buttonDelService.Name = "buttonDelService";
            this.buttonDelService.Size = new System.Drawing.Size(97, 33);
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
            this.dataGridViewFreeService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFreeService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFreeService.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewFreeService.Location = new System.Drawing.Point(664, 62);
            this.dataGridViewFreeService.MultiSelect = false;
            this.dataGridViewFreeService.Name = "dataGridViewFreeService";
            this.dataGridViewFreeService.RowHeadersVisible = false;
            this.dataGridViewFreeService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFreeService.Size = new System.Drawing.Size(287, 321);
            this.dataGridViewFreeService.TabIndex = 12;
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(19, 484);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(40, 13);
            this.labelSum.TabIndex = 13;
            this.labelSum.Text = "Итого:";
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(65, 481);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(110, 20);
            this.textBoxSum.TabIndex = 14;
            // 
            // buttonSaveOrder
            // 
            this.buttonSaveOrder.Location = new System.Drawing.Point(211, 474);
            this.buttonSaveOrder.Name = "buttonSaveOrder";
            this.buttonSaveOrder.Size = new System.Drawing.Size(118, 33);
            this.buttonSaveOrder.TabIndex = 5;
            this.buttonSaveOrder.Text = "Оформить заказ";
            this.buttonSaveOrder.UseVisualStyleBackColor = true;
            this.buttonSaveOrder.Click += new System.EventHandler(this.buttonSaveOrder_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(371, 11);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerFrom.TabIndex = 16;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(288, 13);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(76, 13);
            this.labelFrom.TabIndex = 15;
            this.labelFrom.Text = "Дата въезда:";
            // 
            // labelBefore
            // 
            this.labelBefore.AutoSize = true;
            this.labelBefore.Location = new System.Drawing.Point(525, 15);
            this.labelBefore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBefore.Name = "labelBefore";
            this.labelBefore.Size = new System.Drawing.Size(77, 13);
            this.labelBefore.TabIndex = 17;
            this.labelBefore.Text = "Дата выезда:";
            // 
            // dateTimePickerBefore
            // 
            this.dateTimePickerBefore.Location = new System.Drawing.Point(603, 12);
            this.dateTimePickerBefore.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerBefore.Name = "dateTimePickerBefore";
            this.dateTimePickerBefore.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerBefore.TabIndex = 18;
            // 
            // textBoxSumRoom
            // 
            this.textBoxSumRoom.Location = new System.Drawing.Point(116, 395);
            this.textBoxSumRoom.Name = "textBoxSumRoom";
            this.textBoxSumRoom.Size = new System.Drawing.Size(110, 20);
            this.textBoxSumRoom.TabIndex = 16;
            // 
            // labelSumRoom
            // 
            this.labelSumRoom.AutoSize = true;
            this.labelSumRoom.Location = new System.Drawing.Point(6, 397);
            this.labelSumRoom.Name = "labelSumRoom";
            this.labelSumRoom.Size = new System.Drawing.Size(104, 13);
            this.labelSumRoom.TabIndex = 15;
            this.labelSumRoom.Text = "Итого по номерам:";
            // 
            // textBoxSumService
            // 
            this.textBoxSumService.Location = new System.Drawing.Point(126, 399);
            this.textBoxSumService.Name = "textBoxSumService";
            this.textBoxSumService.Size = new System.Drawing.Size(110, 20);
            this.textBoxSumService.TabIndex = 16;
            // 
            // labelSumService
            // 
            this.labelSumService.AutoSize = true;
            this.labelSumService.Location = new System.Drawing.Point(21, 402);
            this.labelSumService.Name = "labelSumService";
            this.labelSumService.Size = new System.Drawing.Size(99, 13);
            this.labelSumService.TabIndex = 15;
            this.labelSumService.Text = "Итого по услугам:";
            // 
            // CreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 519);
            this.Controls.Add(this.dateTimePickerBefore);
            this.Controls.Add(this.labelBefore);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.buttonSaveOrder);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.dataGridViewFreeService);
            this.Controls.Add(this.groupBoxServices);
            this.Controls.Add(this.groupBoxForms);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Name = "CreateOrder";
            this.Text = "CreateOrder";
            this.Load += new System.EventHandler(this.CreateOrder_Load);
            this.groupBoxForms.ResumeLayout(false);
            this.groupBoxForms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForms)).EndInit();
            this.groupBoxServices.ResumeLayout(false);
            this.groupBoxServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreeService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.GroupBox groupBoxForms;
        private System.Windows.Forms.DataGridView dataGridViewForms;
        private System.Windows.Forms.Button buttonAddForm;
        private System.Windows.Forms.Button buttonEditForm;
        private System.Windows.Forms.Button buttonDelForm;
        private System.Windows.Forms.GroupBox groupBoxServices;
        private System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonEditService;
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
    }
}