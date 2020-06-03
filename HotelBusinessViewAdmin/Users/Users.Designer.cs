namespace HotelBusinessViewAdmin.Users
{
    partial class Users
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
            this.groupBoxUsers = new System.Windows.Forms.GroupBox();
            this.buttonUnblock = new System.Windows.Forms.Button();
            this.buttonBlock = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxOrders = new System.Windows.Forms.GroupBox();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.groupBoxUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.groupBoxOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxUsers
            // 
            this.groupBoxUsers.Controls.Add(this.buttonUnblock);
            this.groupBoxUsers.Controls.Add(this.buttonBlock);
            this.groupBoxUsers.Controls.Add(this.dataGridViewUsers);
            this.groupBoxUsers.Controls.Add(this.buttonAdd);
            this.groupBoxUsers.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUsers.Name = "groupBoxUsers";
            this.groupBoxUsers.Size = new System.Drawing.Size(522, 417);
            this.groupBoxUsers.TabIndex = 4;
            this.groupBoxUsers.TabStop = false;
            this.groupBoxUsers.Text = "Список пользователей";
            // 
            // buttonUnblock
            // 
            this.buttonUnblock.Location = new System.Drawing.Point(306, 370);
            this.buttonUnblock.Name = "buttonUnblock";
            this.buttonUnblock.Size = new System.Drawing.Size(116, 30);
            this.buttonUnblock.TabIndex = 7;
            this.buttonUnblock.Text = "Разблокировать";
            this.buttonUnblock.UseVisualStyleBackColor = true;
            this.buttonUnblock.Click += new System.EventHandler(this.buttonUnblock_Click);
            // 
            // buttonBlock
            // 
            this.buttonBlock.Location = new System.Drawing.Point(180, 370);
            this.buttonBlock.Name = "buttonBlock";
            this.buttonBlock.Size = new System.Drawing.Size(107, 30);
            this.buttonBlock.TabIndex = 6;
            this.buttonBlock.Text = "Заблокировать";
            this.buttonBlock.UseVisualStyleBackColor = true;
            this.buttonBlock.Click += new System.EventHandler(this.buttonBlock_Click);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToResizeColumns = false;
            this.dataGridViewUsers.AllowUserToResizeRows = false;
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewUsers.Location = new System.Drawing.Point(6, 26);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(498, 338);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(68, 370);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(106, 30);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(983, 435);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(79, 30);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBoxOrders
            // 
            this.groupBoxOrders.Controls.Add(this.buttonDetail);
            this.groupBoxOrders.Controls.Add(this.dataGridViewOrders);
            this.groupBoxOrders.Location = new System.Drawing.Point(540, 17);
            this.groupBoxOrders.Name = "groupBoxOrders";
            this.groupBoxOrders.Size = new System.Drawing.Size(522, 412);
            this.groupBoxOrders.TabIndex = 8;
            this.groupBoxOrders.TabStop = false;
            this.groupBoxOrders.Text = "Заказы пользователя:";
            // 
            // buttonDetail
            // 
            this.buttonDetail.Location = new System.Drawing.Point(206, 370);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(116, 30);
            this.buttonDetail.TabIndex = 7;
            this.buttonDetail.Text = "Подробно";
            this.buttonDetail.UseVisualStyleBackColor = true;
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToResizeColumns = false;
            this.dataGridViewOrders.AllowUserToResizeRows = false;
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewOrders.Location = new System.Drawing.Point(6, 26);
            this.dataGridViewOrders.MultiSelect = false;
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowHeadersVisible = false;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(498, 338);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 476);
            this.Controls.Add(this.groupBoxOrders);
            this.Controls.Add(this.groupBoxUsers);
            this.Controls.Add(this.buttonClose);
            this.Name = "Users";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.groupBoxUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.groupBoxOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUsers;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUnblock;
        private System.Windows.Forms.Button buttonBlock;
        private System.Windows.Forms.GroupBox groupBoxOrders;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
    }
}