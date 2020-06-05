namespace HotelBusinessViewAdmin.Admins
{
    partial class Admins
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
            this.groupBoxAdmins = new System.Windows.Forms.GroupBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.dataGridViewAdmins = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUnblock = new System.Windows.Forms.Button();
            this.buttonBlock = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxAdmins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmins)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAdmins
            // 
            this.groupBoxAdmins.Controls.Add(this.buttonDel);
            this.groupBoxAdmins.Controls.Add(this.dataGridViewAdmins);
            this.groupBoxAdmins.Controls.Add(this.buttonAdd);
            this.groupBoxAdmins.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAdmins.Name = "groupBoxAdmins";
            this.groupBoxAdmins.Size = new System.Drawing.Size(325, 373);
            this.groupBoxAdmins.TabIndex = 5;
            this.groupBoxAdmins.TabStop = false;
            this.groupBoxAdmins.Text = "Список администраторов";
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(190, 332);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(80, 30);
            this.buttonDel.TabIndex = 8;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAdmins
            // 
            this.dataGridViewAdmins.AllowUserToAddRows = false;
            this.dataGridViewAdmins.AllowUserToResizeColumns = false;
            this.dataGridViewAdmins.AllowUserToResizeRows = false;
            this.dataGridViewAdmins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdmins.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAdmins.Location = new System.Drawing.Point(9, 19);
            this.dataGridViewAdmins.MultiSelect = false;
            this.dataGridViewAdmins.Name = "dataGridViewAdmins";
            this.dataGridViewAdmins.RowHeadersVisible = false;
            this.dataGridViewAdmins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAdmins.Size = new System.Drawing.Size(310, 300);
            this.dataGridViewAdmins.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(46, 332);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(80, 30);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUnblock
            // 
            this.buttonUnblock.Location = new System.Drawing.Point(230, 417);
            this.buttonUnblock.Name = "buttonUnblock";
            this.buttonUnblock.Size = new System.Drawing.Size(107, 30);
            this.buttonUnblock.TabIndex = 7;
            this.buttonUnblock.Text = "Разблокировать";
            this.buttonUnblock.UseVisualStyleBackColor = true;
            // 
            // buttonBlock
            // 
            this.buttonBlock.Location = new System.Drawing.Point(18, 417);
            this.buttonBlock.Name = "buttonBlock";
            this.buttonBlock.Size = new System.Drawing.Size(105, 30);
            this.buttonBlock.TabIndex = 6;
            this.buttonBlock.Text = "Заблокировать";
            this.buttonBlock.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(130, 391);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(79, 30);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Admins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 459);
            this.Controls.Add(this.groupBoxAdmins);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonUnblock);
            this.Controls.Add(this.buttonBlock);
            this.Name = "Admins";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администраторы";
            this.Load += new System.EventHandler(this.Admins_Load);
            this.groupBoxAdmins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAdmins;
        private System.Windows.Forms.Button buttonUnblock;
        private System.Windows.Forms.Button buttonBlock;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewAdmins;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
    }
}