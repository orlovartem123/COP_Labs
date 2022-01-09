using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using ProductType.Database.Interfaces;
using ProductType.Database.Types;
using ProductPlugin;

namespace ProductTypesUserInterface.Forms
{
    public partial class FormAddProduct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }

        private readonly IPlugin ProductLogic;

        private int? id;
        public FormAddProduct()
        {
            this.ProductLogic = Program.ProductPlugin;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                ProductLogic.CreateOrUpdate(new Product
                {
                    Id = id.HasValue ? id.Value : -1,
                    Name = textBox1.Text,
                    ProductType = selectComponent1.SelectedIndex
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {

            foreach (var role in Enum.GetNames(typeof(TypeProd)))
            {
                selectComponent1.AddElement(role);
            }

            if (id.HasValue)
            {
                try
                {
                    var view = ProductLogic.Read(id)?[0];
                    if (view != null)
                    {
                        textBox1.Text = view.Name;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
