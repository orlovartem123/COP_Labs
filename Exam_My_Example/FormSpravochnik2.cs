using Exam_My_Example.Database.Storages;
using System;
using System.Windows.Forms;

namespace Exam_My_Example
{
    public partial class FormSpravochnik2 : Form
    {
        public FormSpravochnik2()
        {
            InitializeComponent();
            dataGridView.DataSource = Spravochnik2Storage.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                new FormCreateUpdateSpravochnik2().ShowDialog();
                dataGridView.DataSource = Spravochnik2Storage.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int spravochnikId = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;
                new FormCreateUpdateSpravochnik2(spravochnikId).ShowDialog();
                dataGridView.DataSource = Spravochnik2Storage.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int spravochnikId = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;
                Spravochnik2Storage.Delete(spravochnikId);
                dataGridView.DataSource = Spravochnik2Storage.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
