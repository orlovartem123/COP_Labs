using CustomWinFormsComponents.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COPLab1
{
    public partial class FormMain : Form
    {
        private readonly List<string> items = new List<string> { "Фонарь налобный", "Воздушный фильтр", "Элетрообогреватель", "Кирпич" };

        private readonly List<CreateColumnModel> columns = new List<CreateColumnModel>
        {
            new CreateColumnModel
            {
                Header = "Id",
                Width = 50,
                Visible = true,
                DataColumnName = "Id"
            },
            new CreateColumnModel
            {
                Header = "FirstName",
                Width = 100,
                Visible = true,
                DataColumnName = "FirstName"
            },
            new CreateColumnModel
            {
                Header = "LastName",
                Width = 70,
                Visible = true,
                DataColumnName = "LastName"
            },
            new CreateColumnModel
            {
                Header = "Age",
                Width = 130,
                Visible = false,
                DataColumnName = "Age"
            },
            new CreateColumnModel
            {
                Header = "Position",
                Width = 124,
                Visible = true,
                DataColumnName = "Position"
            },
            new CreateColumnModel
            {
                Header = "Exp",
                Width = 200,
                Visible = false,
                DataColumnName = "Exp"
            }
        };

        private readonly List<WorkerModel> workers = new List<WorkerModel>
        {
            new WorkerModel
            {
                Id=1,
                FirstName="Peter",
                LastName="Jones",
                Age=23,
                Position="Pos1",
                Exp=23
            },
            new WorkerModel
            {
                Id=2,
                FirstName="Jack",
                LastName="Black",
                Age=12,
                Position="Pos2",
                Exp=90
            },
            new WorkerModel
            {
                Id=3,
                FirstName="Alex",
                LastName="Davidson",
                Age=23,
                Position="Pos3",
                Exp=45
            }
        };

        public FormMain()
        {
            InitializeComponent();
            customListBox.ChangeSelectedEvent += new EventHandler(ShowMessage);
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            MessageBox.Show("Work!", "Message");
        }

        private void buttonAddItems_Click(object sender, EventArgs e)
        {
            customListBox.AddItems(items);
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            int? value = 0;
            try
            {
                value = customInput.Number;
                if (value.HasValue)
                    customListBox.AddItems(new List<string> { value.ToString() });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var value = textBox.Text;
            try
            {
                var num = Convert.ToInt32(value);
                customInput.Number = num;
            }
            catch
            {
                customInput.Number = null;
            }
        }

        private void buttonAddColumns_Click(object sender, EventArgs e)
        {
            customGrid1.ConfigureColumns(columns);
        }

        private void buttonAddWorkers_Click(object sender, EventArgs e)
        {
            customGrid1.AddData(workers);
        }

        private void buttonGetWorker_Click(object sender, EventArgs e)
        {
            var worker = customGrid1.GetSelectedItem<WorkerModel>();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            customGrid1.ClearRows();
        }

        private void buttonSetValue_Click(object sender, EventArgs e)
        {
            customListBox.SelectedItem = "132";
        }
    }
}
