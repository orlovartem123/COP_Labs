using CustomNoVisualComponents.Components;
using CustomWinFormsComponents.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COPLab1
{
    public partial class FormMain : Form
    {
        private readonly List<string> items = new List<string> { "Фонарь налобный", "Воздушный фильтр", "Элетрообогреватель", "Кирпич" };

        private readonly string[,] table = { { "item00", "item01", "item02" }, { "item10", "item11", "item12" }, { "item20", "item21", "item22" } };

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

        [Obsolete]
        private void btnCreatePdf_Click(object sender, EventArgs e)
        {
            customPdfTableV21.CreateFile("D:\\PdfTest1.pdf", "Super header", table);
        }

        private readonly string Test2Path = "D:\\PdfTest2.pdf";
        private readonly string Test2Title = "Title_super";
        private readonly List<CustomNoVisualComponents.Models.WorkerModel> dataTest2 = new List<CustomNoVisualComponents.Models.WorkerModel>
        {
            new CustomNoVisualComponents.Models.WorkerModel
            {
                Id=1,
                FirstName="Ivan",
                LastName="Petrov",
                Age=4,
                Position="Director",
                Exp=3
            },
            new CustomNoVisualComponents.Models.WorkerModel
            {
                Id=2,
                FirstName="Ivan",
                LastName="Sidorov",
                Age=5,
                Position="Dispatcher",
                Exp=2
            },
            new CustomNoVisualComponents.Models.WorkerModel
            {
                Id=3,
                FirstName="Grisha",
                LastName="Ivanov",
                Age=6,
                Position="Manages",
                Exp=30
            }
        };
        private void buttonTestPdf2_Click(object sender, EventArgs e)
        {
            var columns = new List<TableColumn>
            {
                new TableColumn { Name="Id",PropertyName="Id" },
                new TableColumn{ Name="Name",PropertyName="FirstName"},
                new TableColumn{ Name="LastName",PropertyName="LastName"},
                new TableColumn{ Name="Age",PropertyName="Age"},
                new TableColumn{ Name="Position",PropertyName="Position"},
                new TableColumn{ Name="Exp",PropertyName="Exp"}
            };
            var rows = new TableRow[] { new TableRow { Height = 40 }, new TableRow { Height = 40 } };
            CustomPdfSecondTable secondTableComponent = new CustomPdfSecondTable();
            secondTableComponent.SaveTable(Test2Path, Test2Title, columns, rows, dataTest2);
        }

        private readonly string Test3Path = "D:\\PdfTest3.pdf";
        private readonly string Test3Title = "Title_super";
        private readonly string Test3GistName = "Gist";
        private void buttonTestPdf3_Click(object sender, EventArgs e)
        {
            var gistogramDocument = new CustomPdfGisto();
            var legend = LocationLegend.BottomCenter;

            var gistogramInfo = new GistInfo();
            Dictionary<string, float[]> data = new Dictionary<string, float[]>();
            data.Add("d1", new float[] { 10 });
            data.Add("d2", new float[] { 16 });
            data.Add("d3", new float[] { 19 });
            data.Add("d4", new float[] { 27 });
            data.Add("d5", new float[] { 30 });
            gistogramInfo.Data = data;

            gistogramDocument.CreateGist(Test3Path, Test3Title, Test3GistName, legend, gistogramInfo);
        }
    }
}
