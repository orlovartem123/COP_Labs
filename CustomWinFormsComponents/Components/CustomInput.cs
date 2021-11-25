using System;
using System.Windows.Forms;

namespace CustomWinFormsComponents.Components
{
    public partial class CustomInput : UserControl
    {
        /// <summary>
        /// Получает введенный элемент
        /// </summary>
        /// при сете записывать в текст бокс и делать нерабочим при нуле
        public int? Number
        {
            get
            {
                if (checkBox.Checked)
                    return null;

                if (string.IsNullOrEmpty(textBox.Text))
                    return 0;

                int result = 0;
                if (!int.TryParse(textBox.Text, out result))
                    throw new Exception("Текст не является числом");

                return Convert.ToInt32(textBox.Text);
            }
            set
            {
                if (value != null)
                {
                    textBox.Text = value.Value.ToString();
                    checkBox.Checked = false;
                }
                else
                {
                    textBox.Text = string.Empty;
                    checkBox.Checked = true;
                }
            }
        }


        public CustomInput()
        {
            InitializeComponent();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            textBox.Enabled = !checkBox.Checked;
        }
    }
}
