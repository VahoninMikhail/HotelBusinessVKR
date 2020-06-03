namespace HotelBusinessViewAdmin
{
    partial class FormBase
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
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonForm = new System.Windows.Forms.Button();
            this.buttonServices = new System.Windows.Forms.Button();
            this.buttonRooms = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonAdmins = new System.Windows.Forms.Button();
            this.dataGridViewEntry = new System.Windows.Forms.DataGridView();
            this.buttonPayment = new System.Windows.Forms.Button();
            this.buttonCloseOrder = new System.Windows.Forms.Button();
            this.dateTimePickerEntry = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewExit = new System.Windows.Forms.DataGridView();
            this.dateTimePickerExit = new System.Windows.Forms.DateTimePicker();
            this.groupBoxEntry = new System.Windows.Forms.GroupBox();
            this.buttonSaveEntryPDF = new System.Windows.Forms.Button();
            this.buttonDetailEntry = new System.Windows.Forms.Button();
            this.groupBoxExit = new System.Windows.Forms.GroupBox();
            this.buttonSaveExitPDF = new System.Windows.Forms.Button();
            this.buttonDetailExit = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExit)).BeginInit();
            this.groupBoxEntry.SuspendLayout();
            this.groupBoxExit.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(578, 9);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(132, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Текущий пользователь: ";
            // 
            // buttonForm
            // 
            this.buttonForm.Location = new System.Drawing.Point(209, 56);
            this.buttonForm.Name = "buttonForm";
            this.buttonForm.Size = new System.Drawing.Size(152, 38);
            this.buttonForm.TabIndex = 1;
            this.buttonForm.Text = "Управление формами номеров";
            this.buttonForm.UseVisualStyleBackColor = true;
            this.buttonForm.Click += new System.EventHandler(this.buttonForm_Click);
            // 
            // buttonServices
            // 
            this.buttonServices.Location = new System.Drawing.Point(31, 12);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(152, 38);
            this.buttonServices.TabIndex = 2;
            this.buttonServices.Text = "Управление услугами";
            this.buttonServices.UseVisualStyleBackColor = true;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // buttonRooms
            // 
            this.buttonRooms.Location = new System.Drawing.Point(209, 12);
            this.buttonRooms.Name = "buttonRooms";
            this.buttonRooms.Size = new System.Drawing.Size(152, 38);
            this.buttonRooms.TabIndex = 3;
            this.buttonRooms.Text = "Управление номерами";
            this.buttonRooms.UseVisualStyleBackColor = true;
            this.buttonRooms.Click += new System.EventHandler(this.buttonRooms_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Location = new System.Drawing.Point(384, 12);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(152, 38);
            this.buttonUsers.TabIndex = 4;
            this.buttonUsers.Text = "Управление пользователями";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(31, 56);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(152, 38);
            this.buttonCreateOrder.TabIndex = 5;
            this.buttonCreateOrder.Text = "Создать заказ:";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonAdmins
            // 
            this.buttonAdmins.Location = new System.Drawing.Point(384, 56);
            this.buttonAdmins.Name = "buttonAdmins";
            this.buttonAdmins.Size = new System.Drawing.Size(152, 38);
            this.buttonAdmins.TabIndex = 6;
            this.buttonAdmins.Text = "Управление администраторами";
            this.buttonAdmins.UseVisualStyleBackColor = true;
            this.buttonAdmins.Click += new System.EventHandler(this.buttonAdmins_Click);
            // 
            // dataGridViewEntry
            // 
            this.dataGridViewEntry.AllowUserToAddRows = false;
            this.dataGridViewEntry.AllowUserToResizeColumns = false;
            this.dataGridViewEntry.AllowUserToResizeRows = false;
            this.dataGridViewEntry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntry.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewEntry.Location = new System.Drawing.Point(6, 45);
            this.dataGridViewEntry.MultiSelect = false;
            this.dataGridViewEntry.Name = "dataGridViewEntry";
            this.dataGridViewEntry.RowHeadersVisible = false;
            this.dataGridViewEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEntry.Size = new System.Drawing.Size(342, 386);
            this.dataGridViewEntry.TabIndex = 7;
            // 
            // buttonPayment
            // 
            this.buttonPayment.Location = new System.Drawing.Point(369, 106);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(78, 38);
            this.buttonPayment.TabIndex = 8;
            this.buttonPayment.Text = "Оплата";
            this.buttonPayment.UseVisualStyleBackColor = true;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // buttonCloseOrder
            // 
            this.buttonCloseOrder.Location = new System.Drawing.Point(369, 164);
            this.buttonCloseOrder.Name = "buttonCloseOrder";
            this.buttonCloseOrder.Size = new System.Drawing.Size(78, 38);
            this.buttonCloseOrder.TabIndex = 9;
            this.buttonCloseOrder.Text = "Завершить заказ";
            this.buttonCloseOrder.UseVisualStyleBackColor = true;
            this.buttonCloseOrder.Click += new System.EventHandler(this.buttonCloseOrder_Click);
            // 
            // dateTimePickerEntry
            // 
            this.dateTimePickerEntry.Location = new System.Drawing.Point(6, 19);
            this.dateTimePickerEntry.Name = "dateTimePickerEntry";
            this.dateTimePickerEntry.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEntry.TabIndex = 10;
            this.dateTimePickerEntry.ValueChanged += new System.EventHandler(this.dateTimePickerOrder_ValueChanged);
            // 
            // dataGridViewExit
            // 
            this.dataGridViewExit.AllowUserToAddRows = false;
            this.dataGridViewExit.AllowUserToResizeColumns = false;
            this.dataGridViewExit.AllowUserToResizeRows = false;
            this.dataGridViewExit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewExit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewExit.Location = new System.Drawing.Point(6, 45);
            this.dataGridViewExit.MultiSelect = false;
            this.dataGridViewExit.Name = "dataGridViewExit";
            this.dataGridViewExit.RowHeadersVisible = false;
            this.dataGridViewExit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExit.Size = new System.Drawing.Size(342, 386);
            this.dataGridViewExit.TabIndex = 11;
            // 
            // dateTimePickerExit
            // 
            this.dateTimePickerExit.Location = new System.Drawing.Point(6, 19);
            this.dateTimePickerExit.Name = "dateTimePickerExit";
            this.dateTimePickerExit.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerExit.TabIndex = 12;
            this.dateTimePickerExit.ValueChanged += new System.EventHandler(this.dateTimePickerExit_ValueChanged);
            // 
            // groupBoxEntry
            // 
            this.groupBoxEntry.Controls.Add(this.buttonSaveEntryPDF);
            this.groupBoxEntry.Controls.Add(this.buttonDetailEntry);
            this.groupBoxEntry.Controls.Add(this.dataGridViewEntry);
            this.groupBoxEntry.Controls.Add(this.dateTimePickerEntry);
            this.groupBoxEntry.Location = new System.Drawing.Point(12, 100);
            this.groupBoxEntry.Name = "groupBoxEntry";
            this.groupBoxEntry.Size = new System.Drawing.Size(444, 440);
            this.groupBoxEntry.TabIndex = 13;
            this.groupBoxEntry.TabStop = false;
            this.groupBoxEntry.Text = "Въезд:";
            // 
            // buttonSaveEntryPDF
            // 
            this.buttonSaveEntryPDF.Location = new System.Drawing.Point(354, 285);
            this.buttonSaveEntryPDF.Name = "buttonSaveEntryPDF";
            this.buttonSaveEntryPDF.Size = new System.Drawing.Size(78, 38);
            this.buttonSaveEntryPDF.TabIndex = 15;
            this.buttonSaveEntryPDF.Text = "Сохранить в PDF";
            this.buttonSaveEntryPDF.UseVisualStyleBackColor = true;
            this.buttonSaveEntryPDF.Click += new System.EventHandler(this.buttonSaveEntryPDF_Click);
            // 
            // buttonDetailEntry
            // 
            this.buttonDetailEntry.Location = new System.Drawing.Point(354, 393);
            this.buttonDetailEntry.Name = "buttonDetailEntry";
            this.buttonDetailEntry.Size = new System.Drawing.Size(78, 38);
            this.buttonDetailEntry.TabIndex = 14;
            this.buttonDetailEntry.Text = "Подробно о заказе";
            this.buttonDetailEntry.UseVisualStyleBackColor = true;
            this.buttonDetailEntry.Click += new System.EventHandler(this.buttonDetailEntry_Click);
            // 
            // groupBoxExit
            // 
            this.groupBoxExit.Controls.Add(this.buttonSaveExitPDF);
            this.groupBoxExit.Controls.Add(this.buttonDetailExit);
            this.groupBoxExit.Controls.Add(this.dataGridViewExit);
            this.groupBoxExit.Controls.Add(this.dateTimePickerExit);
            this.groupBoxExit.Controls.Add(this.buttonCloseOrder);
            this.groupBoxExit.Controls.Add(this.buttonPayment);
            this.groupBoxExit.Location = new System.Drawing.Point(462, 100);
            this.groupBoxExit.Name = "groupBoxExit";
            this.groupBoxExit.Size = new System.Drawing.Size(460, 440);
            this.groupBoxExit.TabIndex = 14;
            this.groupBoxExit.TabStop = false;
            this.groupBoxExit.Text = "Выезд";
            // 
            // buttonSaveExitPDF
            // 
            this.buttonSaveExitPDF.Location = new System.Drawing.Point(369, 229);
            this.buttonSaveExitPDF.Name = "buttonSaveExitPDF";
            this.buttonSaveExitPDF.Size = new System.Drawing.Size(78, 38);
            this.buttonSaveExitPDF.TabIndex = 14;
            this.buttonSaveExitPDF.Text = "Сохранить в PDF";
            this.buttonSaveExitPDF.UseVisualStyleBackColor = true;
            // 
            // buttonDetailExit
            // 
            this.buttonDetailExit.Location = new System.Drawing.Point(369, 393);
            this.buttonDetailExit.Name = "buttonDetailExit";
            this.buttonDetailExit.Size = new System.Drawing.Size(78, 38);
            this.buttonDetailExit.TabIndex = 13;
            this.buttonDetailExit.Text = "Подробно о заказе";
            this.buttonDetailExit.UseVisualStyleBackColor = true;
            this.buttonDetailExit.Click += new System.EventHandler(this.buttonDetailExit_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(558, 56);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(152, 38);
            this.buttonReport.TabIndex = 15;
            this.buttonReport.Text = "Отчеты";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 567);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.groupBoxExit);
            this.Controls.Add(this.groupBoxEntry);
            this.Controls.Add(this.buttonAdmins);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.buttonRooms);
            this.Controls.Add(this.buttonServices);
            this.Controls.Add(this.buttonForm);
            this.Controls.Add(this.labelUserName);
            this.Name = "FormBase";
            this.Text = "FormBase";
            this.Load += new System.EventHandler(this.FormBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExit)).EndInit();
            this.groupBoxEntry.ResumeLayout(false);
            this.groupBoxExit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonForm;
        private System.Windows.Forms.Button buttonServices;
        private System.Windows.Forms.Button buttonRooms;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonAdmins;
        private System.Windows.Forms.DataGridView dataGridViewEntry;
        private System.Windows.Forms.Button buttonPayment;
        private System.Windows.Forms.Button buttonCloseOrder;
        private System.Windows.Forms.DateTimePicker dateTimePickerEntry;
        private System.Windows.Forms.DataGridView dataGridViewExit;
        private System.Windows.Forms.DateTimePicker dateTimePickerExit;
        private System.Windows.Forms.GroupBox groupBoxEntry;
        private System.Windows.Forms.Button buttonDetailEntry;
        private System.Windows.Forms.GroupBox groupBoxExit;
        private System.Windows.Forms.Button buttonDetailExit;
        private System.Windows.Forms.Button buttonSaveEntryPDF;
        private System.Windows.Forms.Button buttonSaveExitPDF;
        private System.Windows.Forms.Button buttonReport;
    }
}