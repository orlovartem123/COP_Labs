using Exam_My_Example.Database.Models;
using Exam_My_Example.Database.Storages;
using System;
using System.Windows.Forms;

namespace Exam_My_Example
{
    public partial class FormCreateUpdateSpravochnik2 : Form
    {
        readonly int spravochnikId;

        public FormCreateUpdateSpravochnik2(int spravochnikId = -1)
        {
            InitializeComponent();
            this.spravochnikId = spravochnikId;

            if (spravochnikId != -1)
            {
                var obj = Spravochnik2Storage.Get(spravochnikId);

                textBox1.Text = obj.Fio;
                textBox2.Text = obj.Otdelenie;
                textBox3.Text = obj.Doljnost;
                textBox4.Text = obj.Category;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new Spravochnik2
                {
                    Id = spravochnikId == -1 ? 0 : spravochnikId,
                    Fio = textBox1.Text,
                    Otdelenie = textBox2.Text,
                    Doljnost = textBox3.Text,
                    Category = textBox4.Text
                };

                if (!Validate(obj))
                {
                    throw new Exception("Одно или несколько полей заполнены некорректно");
                }

                if (spravochnikId == -1)
                    Spravochnik2Storage.Add(obj);
                else
                    Spravochnik2Storage.Update(obj);

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
        private bool Validate(Spravochnik2 spravochnik)
        {
            //добавить сюда код проверки по аналогии из формы FormCreateUpdateSpravochnik2, если будет необходимо 

            //если не попались ни в один if то значит проверка пройдена
            return true;
        }
    }
}
