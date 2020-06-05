namespace HotelBusinessViewAdmin.Reviews
{
    partial class Reviews
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
            this.dataGridViewReviews = new System.Windows.Forms.DataGridView();
            this.richTextBoxReview = new System.Windows.Forms.RichTextBox();
            this.groupBoxReplyReview = new System.Windows.Forms.GroupBox();
            this.richTextBoxReplyReview = new System.Windows.Forms.RichTextBox();
            this.buttonSendReplyReview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReviews)).BeginInit();
            this.groupBoxReplyReview.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewReviews
            // 
            this.dataGridViewReviews.AllowUserToAddRows = false;
            this.dataGridViewReviews.AllowUserToResizeColumns = false;
            this.dataGridViewReviews.AllowUserToResizeRows = false;
            this.dataGridViewReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReviews.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewReviews.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewReviews.MultiSelect = false;
            this.dataGridViewReviews.Name = "dataGridViewReviews";
            this.dataGridViewReviews.RowHeadersVisible = false;
            this.dataGridViewReviews.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReviews.Size = new System.Drawing.Size(365, 300);
            this.dataGridViewReviews.TabIndex = 1;
            this.dataGridViewReviews.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReviews_CellClick);
            // 
            // richTextBoxReview
            // 
            this.richTextBoxReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxReview.Enabled = false;
            this.richTextBoxReview.Location = new System.Drawing.Point(383, 12);
            this.richTextBoxReview.Name = "richTextBoxReview";
            this.richTextBoxReview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxReview.Size = new System.Drawing.Size(416, 175);
            this.richTextBoxReview.TabIndex = 2;
            this.richTextBoxReview.Text = "";
            // 
            // groupBoxReplyReview
            // 
            this.groupBoxReplyReview.Controls.Add(this.buttonSendReplyReview);
            this.groupBoxReplyReview.Controls.Add(this.richTextBoxReplyReview);
            this.groupBoxReplyReview.Location = new System.Drawing.Point(383, 193);
            this.groupBoxReplyReview.Name = "groupBoxReplyReview";
            this.groupBoxReplyReview.Size = new System.Drawing.Size(416, 119);
            this.groupBoxReplyReview.TabIndex = 3;
            this.groupBoxReplyReview.TabStop = false;
            this.groupBoxReplyReview.Text = "Ответ на отзыв";
            // 
            // richTextBoxReplyReview
            // 
            this.richTextBoxReplyReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxReplyReview.Location = new System.Drawing.Point(7, 20);
            this.richTextBoxReplyReview.Name = "richTextBoxReplyReview";
            this.richTextBoxReplyReview.Size = new System.Drawing.Size(321, 93);
            this.richTextBoxReplyReview.TabIndex = 0;
            this.richTextBoxReplyReview.Text = "";
            // 
            // buttonSendReplyReview
            // 
            this.buttonSendReplyReview.Location = new System.Drawing.Point(334, 20);
            this.buttonSendReplyReview.Name = "buttonSendReplyReview";
            this.buttonSendReplyReview.Size = new System.Drawing.Size(75, 23);
            this.buttonSendReplyReview.TabIndex = 1;
            this.buttonSendReplyReview.Text = "Отправить";
            this.buttonSendReplyReview.UseVisualStyleBackColor = true;
            this.buttonSendReplyReview.Click += new System.EventHandler(this.buttonSendReplyReview_Click);
            // 
            // Reviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(824, 323);
            this.Controls.Add(this.groupBoxReplyReview);
            this.Controls.Add(this.richTextBoxReview);
            this.Controls.Add(this.dataGridViewReviews);
            this.Name = "Reviews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отзывы";
            this.Load += new System.EventHandler(this.Reviews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReviews)).EndInit();
            this.groupBoxReplyReview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReviews;
        private System.Windows.Forms.RichTextBox richTextBoxReview;
        private System.Windows.Forms.GroupBox groupBoxReplyReview;
        private System.Windows.Forms.Button buttonSendReplyReview;
        private System.Windows.Forms.RichTextBox richTextBoxReplyReview;
    }
}