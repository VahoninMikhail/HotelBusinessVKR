using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if (dataGridViewForms.SelectedRows.Count == 1)
            {
                var form = new AddFreeService();
                form.Id = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Initialize();
                }
            }
        }

        private async void buttonDelService_Click(object sender, EventArgs e)
        {
            if (dataGridViewForms.SelectedRows.Count == 1 && dataGridViewService.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idForm = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);
                    int idService = Convert.ToInt32(dataGridViewService.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequestData("api/Form/DelFreeServiceElement", new FormFreeServiceBindingModel
                        {
                            ServiceId = idService,
                            FormId = idForm
                        });
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

        private async void buttonAddImages_Click(object sender, EventArgs e)
        {
            if (dataGridViewForms.SelectedRows.Count == 1)
            {
                int idForm = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] imageForm = File.ReadAllBytes(openFileDialog1.FileName);
                        if (imageForm != null)
                        {
                            await ApiClient.PostRequestData("api/Form/AddImageElement", new ImageBindingModel
                            {
                                Image = imageForm,
                                FormId = idForm
                            });
                        }
                        MessageBox.Show("Изображение добавлено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //buttonShow.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        private async void buttonDelImages_Click(object sender, EventArgs e)
        {
            if (dataGridViewForms.SelectedRows.Count == 1 && dataGridViewImages.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idForm = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);
                    int idImages = Convert.ToInt32(dataGridViewImages.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        await ApiClient.PostRequestData("api/Form/DelImageElement", new ImageBindingModel
                        {
                            Id = idImages,
                            FormId = idForm
                        });
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

        private async void dataGridViewImages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idForm = Convert.ToInt32(dataGridViewForms.SelectedRows[0].Cells[0].Value);
            FormViewModel form1 = await ApiClient.GetRequestData<FormViewModel>("api/Form/Get/" + idForm);
            int id = Convert.ToInt32(dataGridViewImages.SelectedRows[0].Cells[0].Value);

            var imag = form1.Images.Find(r => r.Id == id);
            HttpPostedFileBase objFile = new MemoryPostedFile(imag.Image);
            var image = ImageProcessing.ResizeImage(System.Drawing.Image.FromStream(objFile.InputStream, true, true),
                    SystemInformation.VirtualScreen.Width / 4, (int)(SystemInformation.VirtualScreen.Height / 2.5));

            pictureBox1.Image = image;
        }

        private async void dataGridViewForms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

            for (int i = 0; i < form.Images.Count; i++)
            {
                // создадим объект ListViewItem (строку) для listView1
                ListViewItem listViewItem = new ListViewItem(new string[] { "", Convert.ToString(form.Images[i].Id) });

                // индекс изображения из imageList для данной строки listViewItem
                listViewItem.ImageIndex = i;

                // добавляем созданный элемент listViewItem (строку) в listView1
            }


            if (form != null)
            {
                dataGridViewService.DataSource = form.FormFreeServices;
                dataGridViewImages.DataSource = form.Images;

                //  listBox1.ValueMember = "Id";

                // dataGridViewImages.Columns[1].ValueType = Image;
                // dataGridViewService.Columns[0].Visible = false;
            }
        }
    }
}
