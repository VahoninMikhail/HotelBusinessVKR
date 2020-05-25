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
    public partial class EditForm : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        List<ImageBindingModel> image = new List<ImageBindingModel>();

        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private async void Initialize()
        {
            if (id.HasValue)
            {
                try
                {
                    var form = await ApiClient.GetRequestData<FormViewModel>("api/Form/Get/" + id.Value);
                    textBoxFormName.Text = form.FormName;
                    textBoxPrice.Text = Convert.ToString(form.Price);
                    richTextBoxSpecification.Text = form.Specifications;
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFormName.Text))
            {
                MessageBox.Show("Заполните Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните Цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(richTextBoxSpecification.Text))
            {
                MessageBox.Show("Заполните Описание", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string name = textBoxFormName.Text;
                decimal price = Convert.ToDecimal(textBoxPrice.Text);
                string specification = richTextBoxSpecification.Text;
                if (id.HasValue)
                {
                    if (image.Count != 0)
                    {
                        await ApiClient.PostRequestData("api/Form/UpdElement", new FormBindingModel
                        {
                            Id = id.Value,
                            FormName = name,
                            Price = price,
                            Specifications = specification,
                            Images = image
                        });
                    }
                    else
                    {
                        await ApiClient.PostRequestData("api/Form/UpdElement", new FormBindingModel
                        {
                            Id = id.Value,
                            FormName = name,
                            Price = price,
                            Specifications = specification
                        });
                    }

                }
                else
                {
                    if (image.Count != 0)
                    {
                        await ApiClient.PostRequestData("api/Form/AddElement", new FormBindingModel
                        {
                            FormName = name,
                            Price = price,
                            Specifications = specification,
                            Images = image
                        });
                    }
                    else
                    {
                        await ApiClient.PostRequestData("api/Form/AddElement", new FormBindingModel
                        {
                            FormName = name,
                            Price = price,
                            Specifications = specification
                        });
                    }
                }
                MessageBox.Show("Сохранение прошло успешно. Обновите список", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] imageForm = File.ReadAllBytes(openFileDialog1.FileName);
                    if (imageForm != null)
                    {
                        image.Add(new ImageBindingModel
                        {
                            Image = imageForm
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

        private async void buttonWatch_Click(object sender, EventArgs e)
        {
            var form = await ApiClient.GetRequestData<FormViewModel>("api/Form/Get/" + id.Value);

            if (form.Images != null && form.Images.Count > 0)
            {
                try
                {
                    var buffer = form.Images[2].Image;
                    HttpPostedFileBase objFile = new MemoryPostedFile(buffer);
                    var image = ImageProcessing.ResizeImage(Image.FromStream(objFile.InputStream, true, true),
                        SystemInformation.VirtualScreen.Width / 2, (int)(SystemInformation.VirtualScreen.Height / 1.5));
                    pictureBox1.Image = image;
                }
                catch (Exception) { }
            }
        }
    }
}
