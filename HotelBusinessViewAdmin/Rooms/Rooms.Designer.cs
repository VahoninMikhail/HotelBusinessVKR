namespace HotelBusinessViewAdmin.Rooms
{
    partial class Rooms
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
            this.groupBoxRooms = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.dataGridViewRooms = new System.Windows.Forms.DataGridView();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxRooms
            // 
            this.groupBoxRooms.Controls.Add(this.buttonClose);
            this.groupBoxRooms.Controls.Add(this.buttonDel);
            this.groupBoxRooms.Controls.Add(this.dataGridViewRooms);
            this.groupBoxRooms.Controls.Add(this.buttonEdit);
            this.groupBoxRooms.Controls.Add(this.buttonAdd);
            this.groupBoxRooms.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRooms.Name = "groupBoxRooms";
            this.groupBoxRooms.Size = new System.Drawing.Size(420, 447);
            this.groupBoxRooms.TabIndex = 3;
            this.groupBoxRooms.TabStop = false;
            this.groupBoxRooms.Text = "Список номеров";
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
            // dataGridViewRooms
            // 
            this.dataGridViewRooms.AllowUserToAddRows = false;
            this.dataGridViewRooms.AllowUserToResizeColumns = false;
            this.dataGridViewRooms.AllowUserToResizeRows = false;
            this.dataGridViewRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRooms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewRooms.Location = new System.Drawing.Point(6, 26);
            this.dataGridViewRooms.MultiSelect = false;
            this.dataGridViewRooms.Name = "dataGridViewRooms";
            this.dataGridViewRooms.RowHeadersVisible = false;
            this.dataGridViewRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRooms.Size = new System.Drawing.Size(408, 338);
            this.dataGridViewRooms.TabIndex = 0;
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
            // Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 503);
            this.Controls.Add(this.groupBoxRooms);
            this.Name = "Rooms";
            this.Text = "Rooms";
            this.Load += new System.EventHandler(this.Rooms_Load);
            this.groupBoxRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRooms;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.DataGridView dataGridViewRooms;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
    }
}