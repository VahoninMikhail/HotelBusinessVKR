namespace HotelBusinessViewAdmin.Forms
{
    partial class Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms));
            this.dataGridViewForms = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxFroms = new System.Windows.Forms.GroupBox();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.buttonDelService = new System.Windows.Forms.Button();
            this.groupBoxService = new System.Windows.Forms.GroupBox();
            this.groupBoxImages = new System.Windows.Forms.GroupBox();
            this.dataGridViewImages = new System.Windows.Forms.DataGridView();
            this.buttonDelImages = new System.Windows.Forms.Button();
            this.buttonAddImages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxFroms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            this.groupBoxService.SuspendLayout();
            this.groupBoxImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridViewForms.Size = new System.Drawing.Size(349, 321);
            this.dataGridViewForms.TabIndex = 1;
            this.dataGridViewForms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewForms_CellClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(6, 351);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(85, 33);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(143, 351);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(80, 33);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(258, 351);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(97, 33);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(725, 380);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(89, 40);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Выход";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Безымянный1.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(401, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 267);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxFroms
            // 
            this.groupBoxFroms.Controls.Add(this.dataGridViewForms);
            this.groupBoxFroms.Controls.Add(this.buttonAdd);
            this.groupBoxFroms.Controls.Add(this.buttonEdit);
            this.groupBoxFroms.Controls.Add(this.buttonDel);
            this.groupBoxFroms.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFroms.Name = "groupBoxFroms";
            this.groupBoxFroms.Size = new System.Drawing.Size(361, 408);
            this.groupBoxFroms.TabIndex = 9;
            this.groupBoxFroms.TabStop = false;
            this.groupBoxFroms.Text = "Виды номеров:";
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
            this.dataGridViewService.Size = new System.Drawing.Size(318, 321);
            this.dataGridViewService.TabIndex = 5;
            // 
            // buttonAddService
            // 
            this.buttonAddService.Location = new System.Drawing.Point(50, 350);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(85, 33);
            this.buttonAddService.TabIndex = 5;
            this.buttonAddService.Text = "Добавить";
            this.buttonAddService.UseVisualStyleBackColor = true;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);
            // 
            // buttonDelService
            // 
            this.buttonDelService.Location = new System.Drawing.Point(176, 350);
            this.buttonDelService.Name = "buttonDelService";
            this.buttonDelService.Size = new System.Drawing.Size(97, 33);
            this.buttonDelService.TabIndex = 5;
            this.buttonDelService.Text = "Удалить";
            this.buttonDelService.UseVisualStyleBackColor = true;
            this.buttonDelService.Click += new System.EventHandler(this.buttonDelService_Click);
            // 
            // groupBoxService
            // 
            this.groupBoxService.Controls.Add(this.dataGridViewService);
            this.groupBoxService.Controls.Add(this.buttonDelService);
            this.groupBoxService.Controls.Add(this.buttonAddService);
            this.groupBoxService.Location = new System.Drawing.Point(389, 13);
            this.groupBoxService.Name = "groupBoxService";
            this.groupBoxService.Size = new System.Drawing.Size(330, 407);
            this.groupBoxService.TabIndex = 10;
            this.groupBoxService.TabStop = false;
            this.groupBoxService.Text = "Бесплатные услуги данного вида номера:";
            // 
            // groupBoxImages
            // 
            this.groupBoxImages.Controls.Add(this.dataGridViewImages);
            this.groupBoxImages.Controls.Add(this.buttonDelImages);
            this.groupBoxImages.Controls.Add(this.buttonAddImages);
            this.groupBoxImages.Controls.Add(this.pictureBox1);
            this.groupBoxImages.Location = new System.Drawing.Point(12, 426);
            this.groupBoxImages.Name = "groupBoxImages";
            this.groupBoxImages.Size = new System.Drawing.Size(802, 300);
            this.groupBoxImages.TabIndex = 11;
            this.groupBoxImages.TabStop = false;
            this.groupBoxImages.Text = "Фотографии данного вида номера:";
            // 
            // dataGridViewImages
            // 
            this.dataGridViewImages.AllowUserToAddRows = false;
            this.dataGridViewImages.AllowUserToResizeColumns = false;
            this.dataGridViewImages.AllowUserToResizeRows = false;
            this.dataGridViewImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImages.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewImages.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewImages.MultiSelect = false;
            this.dataGridViewImages.Name = "dataGridViewImages";
            this.dataGridViewImages.RowHeadersVisible = false;
            this.dataGridViewImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewImages.Size = new System.Drawing.Size(295, 267);
            this.dataGridViewImages.TabIndex = 12;
            this.dataGridViewImages.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewImages_CellClick);
            // 
            // buttonDelImages
            // 
            this.buttonDelImages.Location = new System.Drawing.Point(307, 223);
            this.buttonDelImages.Name = "buttonDelImages";
            this.buttonDelImages.Size = new System.Drawing.Size(88, 63);
            this.buttonDelImages.TabIndex = 6;
            this.buttonDelImages.Text = "Удалить";
            this.buttonDelImages.UseVisualStyleBackColor = true;
            this.buttonDelImages.Click += new System.EventHandler(this.buttonDelImages_Click);
            // 
            // buttonAddImages
            // 
            this.buttonAddImages.Location = new System.Drawing.Point(307, 154);
            this.buttonAddImages.Name = "buttonAddImages";
            this.buttonAddImages.Size = new System.Drawing.Size(88, 63);
            this.buttonAddImages.TabIndex = 9;
            this.buttonAddImages.Text = "Добавить";
            this.buttonAddImages.UseVisualStyleBackColor = true;
            this.buttonAddImages.Click += new System.EventHandler(this.buttonAddImages_Click);
            // 
            // Forms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 739);
            this.Controls.Add(this.groupBoxImages);
            this.Controls.Add(this.groupBoxService);
            this.Controls.Add(this.groupBoxFroms);
            this.Controls.Add(this.buttonClose);
            this.Name = "Forms";
            this.Text = "Forms";
            this.Load += new System.EventHandler(this.Forms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxFroms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            this.groupBoxService.ResumeLayout(false);
            this.groupBoxImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewForms;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxFroms;
        private System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonDelService;
        private System.Windows.Forms.GroupBox groupBoxService;
        private System.Windows.Forms.GroupBox groupBoxImages;
        private System.Windows.Forms.Button buttonDelImages;
        private System.Windows.Forms.Button buttonAddImages;
        private System.Windows.Forms.DataGridView dataGridViewImages;
    }
}