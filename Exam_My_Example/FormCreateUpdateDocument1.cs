using Exam_My_Example.Database.Helpers;
using Exam_My_Example.Database.Models;
using Exam_My_Example.Database.Storages;
using System;
using System.Windows.Forms;

namespace Exam_My_Example
{
    public partial class FormCreateUpdateDocument1 : Form
    {
        readonly int documentId;

        public FormCreateUpdateDocument1(int documentId = -1)
        {
            InitializeComponent();
            this.documentId = documentId;

            comboBox1.DataSource = EnumsHelper.GetComboBoxModelForTypePriema();
            comboBox1.DisplayMember = "DisplayName";
            comboBox1.ValueMember = "Value";

            comboBox2.DataSource = Spravochnik1Storage.GetAll();
            comboBox2.DisplayMember = "Fio";
            comboBox2.ValueMember = "Id";

            comboBox3.DataSource = Spravochnik2Storage.GetAll();
            comboBox3.DisplayMember = "Fio";
            comboBox3.ValueMember = "Id";

            if (documentId != -1)
            {
                var obj = Document1Storage.Get(documentId);

                dateTimePicker1.Value = obj.Date;
                comboBox1.SelectedValue = (int)obj.TypePriema;
                comboBox2.SelectedValue = obj.Spravochnik1Id;
                comboBox3.SelectedValue = obj.Spravochnik2Id;
                textBox1.Text = obj.Jalobi;
                textBox2.Text = obj.Diagnoz;
                textBox3.Text = obj.Naznachenia;
                dateTimePicker2.Value = obj.DateVizdorovlenia;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new Document1
                {
                    Id = documentId == -1 ? 0 : documentId,
                    Date = dateTimePicker1.Value,
                    TypePriema = (TypePriema)comboBox1.SelectedValue,
                    Spravochnik1Id = (int)comboBox2.SelectedValue,
                    Spravochnik2Id = (int)comboBox3.SelectedValue,
                    Jalobi = textBox1.Text,
                    Diagnoz = textBox2.Text,
                    Naznachenia = textBox3.Text,
                    DateVizdorovlenia = dateTimePicker2.Value
                };

                if (!Validate(obj))
                {
                    throw new Exception("Одно или несколько полей заполнены некорректно");
                }

                if (documentId == -1)
                    Document1Storage.Add(obj);
                else
                    Document1Storage.Update(obj);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Метод в котором будет проводиться валидация создаваемого/редактируемого объекта
        /// </summary>
        /// <param name="spravochnik"></param>
        /// <returns></returns>
        private bool Validate(Document1 document)
        {
            //пример проверки корректности дат (дата обследования не может быть больше даты выздоровления)
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                return false;
            }

            //если не попались ни в один if то значит проверка пройдена
            return true;
        }
    }
}
