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
using ProductPlugin;
using ProductType.Database.Interfaces;
using ProductType.Database.Types;
using ProductTypesUserInterface.Forms;

namespace ProductTypesUserInterface
{
    public partial class MainForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IPlugin _ProductsLogic;
        private readonly IMemento memento;
        public MainForm(IMemento memento)
        {
            _ProductsLogic = Program.ProductPlugin;
            this.memento = memento;
            InitializeComponent();
            LoadData();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddProduct>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAddProduct>();
                form.Id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void LoadData()
        {
            try
            {
                var users = _ProductsLogic.Read(null);
                if (users != null)
                {
                    dataGridViewProducts.DataSource = users;
                    dataGridViewProducts.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            memento.Undo();
            LoadData();
        }

        private void buttonSaveState_Click(object sender, EventArgs e)
        {
            memento.Save(_ProductsLogic.Read(null).Select(x => new ProductType.Database.Models.Product
            {
                Id = x.Id,
                Name = x.Name,
                typeProd = (TypeProd)x.ProductType
            }).ToList());
        }

        private void buttonPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        componentPdf1.CreateDoc(new ComponentsView.PdfInfo
                        {
                            FileName = dialog.FileName,
                            Items = _ProductsLogic.Read(null).Select(x => x.Name).ToList(),
                            Title = "Report"
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
