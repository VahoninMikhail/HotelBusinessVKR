using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Windows.Forms;

namespace HotelBusinessViewAdmin.Forms
{
    public partial class Forms : Form
    {
        public Forms()
        {
            InitializeComponent();
        }

        private async void Initialize()
        {
            try
            {
                List<FormViewModel> list = await ApiClient.GetRequestData<List<FormViewModel>>("api/Form/GetList");
                if (list != null)
                {
                    dataGridViewForms.DataSource = list;
                    dataGridViewForms.Columns[0].Visible = false;
                    dataGridViewForms.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                   
                }

            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Initialize();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewForms.SelectedRows.Count == 1)
            {
                var form = new EditForm();
                form.Id = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Initialize();
                }
            }
        }

        private async void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewForms.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequest("api/Form/DelElement/" + id);
                        MessageBox.Show("Запись удалена. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Initialize();
                    }
                    catch (Exception ex)
                    {
                        while (ex.InnerException != null)
                        {
                            ex = ex.InnerException;
                        }
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Forms_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void dataGridViewForms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            listViewImages.Items.Clear();

            int id = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);
            var form = await ApiClient.GetRequestData<FormViewModel>("api/Form/Get/" + id);

            // создаем список изображений для строк listViewImages
            ImageList imageList = new ImageList();
            // устанавливаем размер изображений
           // imageList.ImageSize = new Size(50, 50);

            foreach (var im in form.Images)
            {
                HttpPostedFileBase objFile = new MemoryPostedFile(im.Image);
               // var image = System.Drawing.Image.FromStream(objFile.InputStream, true, true);
                var image = ImageProcessing.ResizeImage(System.Drawing.Image.FromStream(objFile.InputStream, true, true),
                        SystemInformation.VirtualScreen.Width / 4, (int)(SystemInformation.VirtualScreen.Height / 2.5));

             
                pictureBox1.Image = image;

                imageList.Images.Add(pictureBox1.Image);
            }

            // устанавливаем в listView1 список изображений imageList
            listViewImages.SmallImageList = imageList;

            for (int i = 0; i < form.Images.Count; i++)
            {
                // создадим объект ListViewItem (строку) для listView1
                ListViewItem listViewItem = new ListViewItem(new string[] { "" });

                // индекс изображения из imageList для данной строки listViewItem
                listViewItem.ImageIndex = i;

                // добавляем созданный элемент listViewItem (строку) в listView1
                listViewImages.Items.Add(listViewItem);
            }
        }

        private async void listViewImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idrow = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);
            var form = await ApiClient.GetRequestData<FormViewModel>("api/Form/Get/" + idrow);

            int id = Convert.ToInt32(listViewImages.SelectedIndices);

        }
    }
}
