using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Reflection;

namespace PISBusinessLogic.BusinessLogic
{
    internal class SaveToPdf
    {
        public static void CreateGist(string filename, string docName, string gistName,
            LocationLegend legend, GistInfo gistInfo)
        {

            var document = new ceTe.DynamicPDF.Document();
            var page = new Page();
            document.Pages.Add(page);

            var chart = new Chart(0, 30, 500, 300);
            var plotArea = chart.PrimaryPlotArea;

            var label = new ceTe.DynamicPDF.PageElements.Label(docName, 0, 0, 500, 30, ceTe.DynamicPDF.Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label);

            var histogramTitle = new Title(gistName);
            chart.HeaderTitles.Add(histogramTitle);

            IndexedBarSeries barSeries = null;

            var rnd = new Random();
            foreach (var item in gistInfo.Data)
            {
                if (item.Value.Length < 1)
                {
                    throw new Exception("Input data is empty!");
                }
                barSeries = new IndexedBarSeries(item.Key);
                barSeries.Values.Add(item.Value);
                barSeries.Color = new RgbColor((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble());
                plotArea.Series.Add(barSeries);
            }

            for (int i = 0; i < gistInfo.Data.Count; i++)
            {
                barSeries.YAxis.Labels.Add(new IndexedYAxisLabel((i + 1).ToString(), i));
            }

            chart.Legends.Placement = (LegendPlacement)legend;

            page.Elements.Add(chart);
            document.Draw(filename);
        }

        public static void SaveTable(string nameOfFile, string nameOfDocument, List<TableReport> workers)
        {
            if (workers == null || workers.Count == 0)
                throw new Exception("list is null or empty");

            var columns = new List<TableColumn>
            {
                new TableColumn{ Name="Book",PropertyName="Book",Width=80 },
                new TableColumn{ Name="01",PropertyName="January"},
                new TableColumn{ Name="02",PropertyName="February"},
                new TableColumn{ Name="03",PropertyName="March"},
                new TableColumn{ Name="04",PropertyName="April"},
                new TableColumn{ Name="05",PropertyName="May"},
                new TableColumn{ Name="06",PropertyName="June"},
                new TableColumn{ Name="07",PropertyName="July"},
                new TableColumn{ Name="08",PropertyName="August"},
                new TableColumn{ Name="09",PropertyName="September"},
                new TableColumn{ Name="10",PropertyName="October"},
                new TableColumn{ Name="11",PropertyName="November"},
                new TableColumn{ Name="12",PropertyName="December"},
                new TableColumn{ Name="Total",PropertyName="Total",Width=40}
            };
            var rows = new TableRowV2[] { new TableRowV2 { Height = 40 }, new TableRowV2 { Height = 40 } };

            PdfPTable table = CreateTable(columns, rows, workers);
            FileStream fs = new FileStream(nameOfFile, FileMode.Create);
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.Add(new Paragraph(nameOfDocument));
            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }

        private static PdfPTable CreateTable(List<TableColumn> columns,
            TableRowV2[] rows, List<TableReport> workers)
        {
            float[] widths = new float[columns.Count];

            bool widthsExist = columns.FirstOrDefault(rec => rec.Width == 0) == null;

            if (widthsExist)
            {
                int index = 0;
                int sum = 0;
                foreach (var column in columns)
                {
                    widths[index] = column.Width;
                    sum += column.Width;
                    index++;
                }
            }

            //Здесь мы проверяем наличие данных о высоте колонок
            bool heightsExist = rows.FirstOrDefault(rec => rec.Height == 0) == null;
            //if (row != null /*|| rows.Length == 2*/)
            //    heightsExist = false;

            //Если есть ширина, то добавляем параметры
            PdfPTable table = new PdfPTable(columns.Count);
            if (widthsExist)
            {
                table.LockedWidth = true;
                table.SetTotalWidth(widths);
            }

            //столбцы
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bfTimes, 16, iTextSharp.text.Font.BOLD);
            foreach (TableColumn column in columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.Name, font));
                if (heightsExist) cell.MinimumHeight = rows[0].Height;
                table.AddCell(cell);
            }

            //ячейки
            foreach (var worker in workers)
            {
                foreach (var column in columns)
                {
                    PropertyInfo propertyInfo = worker.GetType().GetProperty(column.PropertyName);
                    string value = propertyInfo.GetValue(worker).ToString();
                    PdfPCell cell = new PdfPCell(new Phrase(value));
                    if (heightsExist) cell.MinimumHeight = rows[1].Height;
                    table.AddCell(cell);
                }
            }

            foreach (var row in table.Rows)
            {
                PdfPCell cell = row.GetCells()[0];
                string text = cell.Phrase.Content;
                PdfPCell newcell = new PdfPCell(new Phrase(text, font));
                row.GetCells()[0] = newcell;
            }

            return table;
        }
    }

    public class GistInfo
    {
        public Dictionary<string, float[]> Data { get; set; }
    }

    public enum LocationLegend
    {
        TopCenter = 0,
        TopRight = 1,
        TopLeft = 2,
        LeftCenter = 3,
        RightCenter = 4,
        BottomCenter = 5,
        BottomLeft = 6,
        BottomRight = 7
    }

    public class TableRowV2
    {
        public int Height { get; set; }
    }

    public class TableColumn
    {
        public int Width { set; get; }
        public string PropertyName { set; get; }
        public string Name { set; get; }
    }

    public class TableReport
    {
        private string book;

        public string Book { get => book; set => book = Tr(value.ToUpper()); }

        public int January { get; set; }

        public int February { get; set; }

        public int March { get; set; }

        public int April { get; set; }

        public int May { get; set; }

        public int June { get; set; }

        public int July { get; set; }

        public int August { get; set; }

        public int September { get; set; }

        public int October { get; set; }

        public int November { get; set; }

        public int December { get; set; }

        public int Total { get => January + February + March + April + May + June + July + August + September + October + November + December; }

        private string Tr(string s)
        {
            string ret = "";
            string[] rus = {"1","2","3","4","5","6","7","8","9","0"," ","А","Б","В","Г","Д","Е","Ё","Ж", "З","И","Й","К","Л","М", "Н",
          "О","П","Р","С","Т","У","Ф","Х", "Ц", "Ч", "Ш", "Щ",   "Ъ", "Ы","Ь",
          "Э","Ю", "Я" };
            string[] eng = {"1","2","3","4","5","6","7","8","9","0"," ","A","B","V","G","D","E","E","ZH","Z","I","Y","K","L","M","N",
          "O","P","R","S","T","U","F","KH","TS","CH","SH","SHCH",null,"Y",null,
          "E","YU","YA"};

            for (int j = 0; j < s.Length; j++)
                for (int i = 0; i < rus.Length; i++)
                    if (s.Substring(j, 1) == rus[i]) ret += eng[i];

            return ret;
        }
    }
}

