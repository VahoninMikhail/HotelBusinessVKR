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
            this.buttonReviews = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.управлениеВидамиНомеровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеНомерамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеУслугамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеКлиентамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администраторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.созданиеЗаказаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётОВыручкеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётОЗанятыхКомнатахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётОбОплатахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отзывыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExit)).BeginInit();
            this.groupBoxEntry.SuspendLayout();
            this.groupBoxExit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(639, 7);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(132, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Текущий пользователь: ";
            // 
            // buttonForm
            // 
            this.buttonForm.Location = new System.Drawing.Point(291, 51);
            this.buttonForm.Name = "buttonForm";
            this.buttonForm.Size = new System.Drawing.Size(165, 30);
            this.buttonForm.TabIndex = 1;
            this.buttonForm.Text = "Управление видами номеров";
            this.buttonForm.UseVisualStyleBackColor = true;
            this.buttonForm.Click += new System.EventHandler(this.buttonForm_Click);
            // 
            // buttonServices
            // 
            this.buttonServices.Location = new System.Drawing.Point(12, 51);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(130, 30);
            this.buttonServices.TabIndex = 2;
            this.buttonServices.Text = "Управление услугами";
            this.buttonServices.UseVisualStyleBackColor = true;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // buttonRooms
            // 
            this.buttonRooms.Location = new System.Drawing.Point(148, 51);
            this.buttonRooms.Name = "buttonRooms";
            this.buttonRooms.Size = new System.Drawing.Size(137, 30);
            this.buttonRooms.TabIndex = 3;
            this.buttonRooms.Text = "Управление номерами";
            this.buttonRooms.UseVisualStyleBackColor = true;
            this.buttonRooms.Click += new System.EventHandler(this.buttonRooms_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Location = new System.Drawing.Point(462, 51);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(152, 30);
            this.buttonUsers.TabIndex = 4;
            this.buttonUsers.Text = "Управление клиентами";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(12, 87);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(130, 28);
            this.buttonCreateOrder.TabIndex = 5;
            this.buttonCreateOrder.Text = "Создать заказ:";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonAdmins
            // 
            this.buttonAdmins.Location = new System.Drawing.Point(620, 51);
            this.buttonAdmins.Name = "buttonAdmins";
            this.buttonAdmins.Size = new System.Drawing.Size(190, 30);
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
            this.dataGridViewEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntry.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewEntry.Location = new System.Drawing.Point(6, 45);
            this.dataGridViewEntry.MultiSelect = false;
            this.dataGridViewEntry.Name = "dataGridViewEntry";
            this.dataGridViewEntry.RowHeadersVisible = false;
            this.dataGridViewEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewEntry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEntry.Size = new System.Drawing.Size(565, 335);
            this.dataGridViewEntry.TabIndex = 7;
            // 
            // buttonPayment
            // 
            this.buttonPayment.Location = new System.Drawing.Point(142, 386);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(130, 30);
            this.buttonPayment.TabIndex = 8;
            this.buttonPayment.Text = "Оплата";
            this.buttonPayment.UseVisualStyleBackColor = true;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // buttonCloseOrder
            // 
            this.buttonCloseOrder.Location = new System.Drawing.Point(278, 386);
            this.buttonCloseOrder.Name = "buttonCloseOrder";
            this.buttonCloseOrder.Size = new System.Drawing.Size(130, 30);
            this.buttonCloseOrder.TabIndex = 9;
            this.buttonCloseOrder.Text = "Завершить заказ";
            this.buttonCloseOrder.UseVisualStyleBackColor = true;
            this.buttonCloseOrder.Click += new System.EventHandler(this.buttonCloseOrder_Click);
            // 
            // dateTimePickerEntry
            // 
            this.dateTimePickerEntry.Location = new System.Drawing.Point(6, 19);
            this.dateTimePickerEntry.Name = "dateTimePickerEntry";
            this.dateTimePickerEntry.Size = new System.Drawing.Size(160, 20);
            this.dateTimePickerEntry.TabIndex = 10;
            this.dateTimePickerEntry.ValueChanged += new System.EventHandler(this.dateTimePickerOrder_ValueChanged);
            // 
            // dataGridViewExit
            // 
            this.dataGridViewExit.AllowUserToAddRows = false;
            this.dataGridViewExit.AllowUserToResizeColumns = false;
            this.dataGridViewExit.AllowUserToResizeRows = false;
            this.dataGridViewExit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewExit.Location = new System.Drawing.Point(6, 45);
            this.dataGridViewExit.MultiSelect = false;
            this.dataGridViewExit.Name = "dataGridViewExit";
            this.dataGridViewExit.RowHeadersVisible = false;
            this.dataGridViewExit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewExit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExit.Size = new System.Drawing.Size(565, 335);
            this.dataGridViewExit.TabIndex = 11;
            // 
            // dateTimePickerExit
            // 
            this.dateTimePickerExit.Location = new System.Drawing.Point(6, 19);
            this.dateTimePickerExit.Name = "dateTimePickerExit";
            this.dateTimePickerExit.Size = new System.Drawing.Size(160, 20);
            this.dateTimePickerExit.TabIndex = 12;
            this.dateTimePickerExit.ValueChanged += new System.EventHandler(this.dateTimePickerExit_ValueChanged);
            // 
            // groupBoxEntry
            // 
            this.groupBoxEntry.Controls.Add(this.buttonSaveEntryPDF);
            this.groupBoxEntry.Controls.Add(this.buttonDetailEntry);
            this.groupBoxEntry.Controls.Add(this.dataGridViewEntry);
            this.groupBoxEntry.Controls.Add(this.dateTimePickerEntry);
            this.groupBoxEntry.Location = new System.Drawing.Point(12, 121);
            this.groupBoxEntry.Name = "groupBoxEntry";
            this.groupBoxEntry.Size = new System.Drawing.Size(577, 424);
            this.groupBoxEntry.TabIndex = 13;
            this.groupBoxEntry.TabStop = false;
            this.groupBoxEntry.Text = "Въезд:";
            // 
            // buttonSaveEntryPDF
            // 
            this.buttonSaveEntryPDF.Location = new System.Drawing.Point(316, 386);
            this.buttonSaveEntryPDF.Name = "buttonSaveEntryPDF";
            this.buttonSaveEntryPDF.Size = new System.Drawing.Size(165, 30);
            this.buttonSaveEntryPDF.TabIndex = 15;
            this.buttonSaveEntryPDF.Text = "Сохранить в формате PDF";
            this.buttonSaveEntryPDF.UseVisualStyleBackColor = true;
            this.buttonSaveEntryPDF.Click += new System.EventHandler(this.buttonSaveEntryPDF_Click);
            // 
            // buttonDetailEntry
            // 
            this.buttonDetailEntry.Location = new System.Drawing.Point(122, 386);
            this.buttonDetailEntry.Name = "buttonDetailEntry";
            this.buttonDetailEntry.Size = new System.Drawing.Size(130, 30);
            this.buttonDetailEntry.TabIndex = 14;
            this.buttonDetailEntry.Text = "Детали заказа";
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
            this.groupBoxExit.Location = new System.Drawing.Point(589, 121);
            this.groupBoxExit.Name = "groupBoxExit";
            this.groupBoxExit.Size = new System.Drawing.Size(578, 424);
            this.groupBoxExit.TabIndex = 14;
            this.groupBoxExit.TabStop = false;
            this.groupBoxExit.Text = "Выезд";
            // 
            // buttonSaveExitPDF
            // 
            this.buttonSaveExitPDF.Location = new System.Drawing.Point(414, 386);
            this.buttonSaveExitPDF.Name = "buttonSaveExitPDF";
            this.buttonSaveExitPDF.Size = new System.Drawing.Size(157, 30);
            this.buttonSaveExitPDF.TabIndex = 14;
            this.buttonSaveExitPDF.Text = "Сохранить в формате PDF";
            this.buttonSaveExitPDF.UseVisualStyleBackColor = true;
            // 
            // buttonDetailExit
            // 
            this.buttonDetailExit.Location = new System.Drawing.Point(6, 386);
            this.buttonDetailExit.Name = "buttonDetailExit";
            this.buttonDetailExit.Size = new System.Drawing.Size(130, 30);
            this.buttonDetailExit.TabIndex = 13;
            this.buttonDetailExit.Text = "Детали заказа";
            this.buttonDetailExit.UseVisualStyleBackColor = true;
            this.buttonDetailExit.Click += new System.EventHandler(this.buttonDetailExit_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(148, 87);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(137, 28);
            this.buttonReport.TabIndex = 15;
            this.buttonReport.Text = "Отчеты";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonReviews
            // 
            this.buttonReviews.Location = new System.Drawing.Point(291, 87);
            this.buttonReviews.Name = "buttonReviews";
            this.buttonReviews.Size = new System.Drawing.Size(165, 28);
            this.buttonReviews.TabIndex = 16;
            this.buttonReviews.Text = "Отзывы";
            this.buttonReviews.UseVisualStyleBackColor = true;
            this.buttonReviews.Click += new System.EventHandler(this.buttonReviews_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.управлениеВидамиНомеровToolStripMenuItem,
            this.управлениеНомерамиToolStripMenuItem,
            this.управлениеУслугамиToolStripMenuItem,
            this.управлениеКлиентамиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // управлениеВидамиНомеровToolStripMenuItem
            // 
            this.управлениеВидамиНомеровToolStripMenuItem.Name = "управлениеВидамиНомеровToolStripMenuItem";
            this.управлениеВидамиНомеровToolStripMenuItem.Size = new System.Drawing.Size(172, 20);
            this.управлениеВидамиНомеровToolStripMenuItem.Text = "Управление видами комнат";
            this.управлениеВидамиНомеровToolStripMenuItem.Click += new System.EventHandler(this.управлениеВидамиНомеровToolStripMenuItem_Click);
            // 
            // управлениеНомерамиToolStripMenuItem
            // 
            this.управлениеНомерамиToolStripMenuItem.Name = "управлениеНомерамиToolStripMenuItem";
            this.управлениеНомерамиToolStripMenuItem.Size = new System.Drawing.Size(150, 20);
            this.управлениеНомерамиToolStripMenuItem.Text = "Управление комнатами";
            this.управлениеНомерамиToolStripMenuItem.Click += new System.EventHandler(this.управлениеНомерамиToolStripMenuItem_Click);
            // 
            // управлениеУслугамиToolStripMenuItem
            // 
            this.управлениеУслугамиToolStripMenuItem.Name = "управлениеУслугамиToolStripMenuItem";
            this.управлениеУслугамиToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.управлениеУслугамиToolStripMenuItem.Text = "Управление услугами";
            this.управлениеУслугамиToolStripMenuItem.Click += new System.EventHandler(this.управлениеУслугамиToolStripMenuItem_Click);
            // 
            // управлениеКлиентамиToolStripMenuItem
            // 
            this.управлениеКлиентамиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.администраторыToolStripMenuItem});
            this.управлениеКлиентамиToolStripMenuItem.Name = "управлениеКлиентамиToolStripMenuItem";
            this.управлениеКлиентамиToolStripMenuItem.Size = new System.Drawing.Size(179, 20);
            this.управлениеКлиентамиToolStripMenuItem.Text = "Управление пользователями";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // администраторыToolStripMenuItem
            // 
            this.администраторыToolStripMenuItem.Name = "администраторыToolStripMenuItem";
            this.администраторыToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.администраторыToolStripMenuItem.Text = "Администраторы";
            this.администраторыToolStripMenuItem.Click += new System.EventHandler(this.администраторыToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.созданиеЗаказаToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.отзывыToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1176, 24);
            this.menuStrip2.TabIndex = 18;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // созданиеЗаказаToolStripMenuItem
            // 
            this.созданиеЗаказаToolStripMenuItem.Name = "созданиеЗаказаToolStripMenuItem";
            this.созданиеЗаказаToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.созданиеЗаказаToolStripMenuItem.Text = "Создание заказа";
            this.созданиеЗаказаToolStripMenuItem.Click += new System.EventHandler(this.созданиеЗаказаToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчётОВыручкеToolStripMenuItem,
            this.отчётОЗанятыхКомнатахToolStripMenuItem,
            this.отчётОбОплатахToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // отчётОВыручкеToolStripMenuItem
            // 
            this.отчётОВыручкеToolStripMenuItem.Name = "отчётОВыручкеToolStripMenuItem";
            this.отчётОВыручкеToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.отчётОВыручкеToolStripMenuItem.Text = "Отчёт о выручке";
            this.отчётОВыручкеToolStripMenuItem.Click += new System.EventHandler(this.отчётОВыручкеToolStripMenuItem_Click);
            // 
            // отчётОЗанятыхКомнатахToolStripMenuItem
            // 
            this.отчётОЗанятыхКомнатахToolStripMenuItem.Name = "отчётОЗанятыхКомнатахToolStripMenuItem";
            this.отчётОЗанятыхКомнатахToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.отчётОЗанятыхКомнатахToolStripMenuItem.Text = "Отчёт о занятых комнатах";
            this.отчётОЗанятыхКомнатахToolStripMenuItem.Click += new System.EventHandler(this.отчётОЗанятыхКомнатахToolStripMenuItem_Click);
            // 
            // отчётОбОплатахToolStripMenuItem
            // 
            this.отчётОбОплатахToolStripMenuItem.Name = "отчётОбОплатахToolStripMenuItem";
            this.отчётОбОплатахToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.отчётОбОплатахToolStripMenuItem.Text = "Отчёт об оплатах";
            this.отчётОбОплатахToolStripMenuItem.Click += new System.EventHandler(this.отчётОбОплатахToolStripMenuItem_Click);
            // 
            // отзывыToolStripMenuItem
            // 
            this.отзывыToolStripMenuItem.Name = "отзывыToolStripMenuItem";
            this.отзывыToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.отзывыToolStripMenuItem.Text = "Отзывы";
            this.отзывыToolStripMenuItem.Click += new System.EventHandler(this.отзывыToolStripMenuItem_Click);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 550);
            this.Controls.Add(this.buttonReviews);
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
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.FormBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExit)).EndInit();
            this.groupBoxEntry.ResumeLayout(false);
            this.groupBoxExit.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
        private System.Windows.Forms.Button buttonReviews;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem управлениеВидамиНомеровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеНомерамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеУслугамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеКлиентамиToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem созданиеЗаказаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отзывыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётОВыручкеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётОЗанятыхКомнатахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётОбОплатахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem администраторыToolStripMenuItem;
    }
}