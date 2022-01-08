using System;
using System.Windows.Forms;

namespace Exam_My_Example
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void spravochnik1_Click(object sender, EventArgs e)
        {
            new FormSpravochnik1().ShowDialog();
        }

        private void spravochnik2_Click(object sender, EventArgs e)
        {
            new FormSpravochnik2().ShowDialog();
        }

        private void document1_Click(object sender, EventArgs e)
        {
            new FormDocument1().ShowDialog();
        }
    }
}
