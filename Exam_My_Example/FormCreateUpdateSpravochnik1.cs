using Exam_My_Example.Database.Helpers;
using Exam_My_Example.Database.Models;
using Exam_My_Example.Database.Storages;
using System;
using System.Windows.Forms;

namespace Exam_My_Example
{
    public partial class FormCreateUpdateSpravochnik1 : Form
    {
        readonly int spravochnikId;

        public FormCreateUpdateSpravochnik1(int spravochnikId = -1)
        {
            InitializeComponent();
            this.spravochnikId = spravochnikId;
            comboBox1.DataSource = EnumsHelper.GetComboBoxModelForGender();
            comboBox1.DisplayMember = "DisplayName";
            comboBox1.ValueMember = "Value";

            if (spravochnikId != -1)
            {
                var obj = Spravochnik1Storage.Get(spravochnikId);

                textBox1.Text = obj.Fio;
                dateTimePicker1.Value = obj.BirthDate;
                comboBox1.SelectedValue = (int)obj.Gender;
                textBox2.Text = obj.Address;
                textBox3.Text = obj.Contacts;
                textBox4.Text = obj.Comment;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new Spravochnik1
                {
                    Id = spravochnikId == -1 ? 0 : spravochnikId,
                    Fio = textBox1.Text,
                    BirthDate = dateTimePicker1.Value.Date,
                    Gender = (Gender)comboBox1.SelectedValue,
                    Address = textBox2.Text,
                    Contacts = textBox3.Text,
                    Comment = textBox4.Text
                };

                if (!Validate(obj))
                {
                    throw new Exception("Одно или несколько полей заполнены некорректно");
                }

                if (spravochnikId == -1)
                    Spravochnik1Storage.Add(obj);
                else
                    Spravochnik1Storage.Update(obj);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод в котором будет проводиться валидация создаваемого/редактируемого объекта
        /// </summary>
        /// <param name="spravochnik"></param>
        /// <returns></returns>
        private bool Validate(Spravochnik1 spravochnik)
        {
            //пример проверки на длину строки
            //if (spravochnik.Address.Length < 3)
            //{
            //    return false;
            //}
            ////пример проверки не пустая ли строка
            //if (string.IsNullOrEmpty(spravochnik.Contacts))
            //{
            //    return false;
            //}

            //пример проверки на то, является ли строка числом или нет
            //(в данном примере не имеет смысла тк нету полей которые должны быть числом)
            //if (int.TryParse(spravochnik.Comment,out int result))
            //{
            //    return false;
            //}

            //если не попались ни в один if то значит проверка пройдена
            return true;
        }
    }
}
