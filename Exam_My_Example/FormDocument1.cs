using Exam_My_Example.Database.Storages;
using System;
using System.Windows.Forms;

namespace Exam_My_Example
{
    public partial class FormDocument1 : Form
    {
        public FormDocument1()
        {
            InitializeComponent();
            dataGridView.DataSource = Document1Storage.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                new FormCreateUpdateDocument1().ShowDialog();
                dataGridView.DataSource = Document1Storage.GetAll();
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
                new FormCreateUpdateDocument1(spravochnikId).ShowDialog();
                dataGridView.DataSource = Document1Storage.GetAll();
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
                Document1Storage.Delete(spravochnikId);
                dataGridView.DataSource = Document1Storage.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
