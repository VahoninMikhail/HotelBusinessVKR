namespace HotelBusinessViewAdmin.Services
{
    partial class Services
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
            this.groupBoxService = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxService
            // 
            this.groupBoxService.Controls.Add(this.buttonClose);
            this.groupBoxService.Controls.Add(this.buttonDel);
            this.groupBoxService.Controls.Add(this.dataGridViewService);
            this.groupBoxService.Controls.Add(this.buttonEdit);
            this.groupBoxService.Controls.Add(this.buttonAdd);
            this.groupBoxService.Location = new System.Drawing.Point(12, 12);
            this.groupBoxService.Name = "groupBoxService";
            this.groupBoxService.Size = new System.Drawing.Size(420, 447);
            this.groupBoxService.TabIndex = 2;
            this.groupBoxService.TabStop = false;
            this.groupBoxService.Text = "Список услуг:";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(341, 411);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(79, 30);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(147, 411);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(140, 30);
            this.buttonDel.TabIndex = 3;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // dataGridViewService
            // 
            this.dataGridViewService.AllowUserToAddRows = false;
            this.dataGridViewService.AllowUserToResizeColumns = false;
            this.dataGridViewService.AllowUserToResizeRows = false;
            this.dataGridViewService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewService.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewService.Location = new System.Drawing.Point(6, 26);
            this.dataGridViewService.MultiSelect = false;
            this.dataGridViewService.Name = "dataGridViewService";
            this.dataGridViewService.RowHeadersVisible = false;
            this.dataGridViewService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewService.Size = new System.Drawing.Size(408, 338);
            this.dataGridViewService.TabIndex = 0;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(245, 373);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(140, 30);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(56, 370);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(140, 30);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 459);
            this.Controls.Add(this.groupBoxService);
            this.Name = "Services";
            this.Text = "Services";
            this.Load += new System.EventHandler(this.Services_Load);
            this.groupBoxService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxService;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
    }
}