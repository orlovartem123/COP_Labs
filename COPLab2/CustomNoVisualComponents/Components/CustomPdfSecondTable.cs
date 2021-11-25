using CustomNoVisualComponents.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustomNoVisualComponents.Components
{
    public partial class CustomPdfSecondTable : Component
    {
        public CustomPdfSecondTable()
        {
            InitializeComponent();
        }

        public void SaveTable(string nameOfFile, string nameOfDocument, List<TableColumn> columns,
            TableRow[] rows, List<WorkerModel> workers)
        {
            if (workers == null || workers.Count == 0)
                throw new Exception("list is null or empty");

            if (columns.FirstOrDefault(column => column.Name == null || column.PropertyName == null) != null)
                throw new Exception("Fill data");

            PdfPTable table = CreateTable(columns, rows, workers);
            FileStream fs = new FileStream(nameOfFile, FileMode.Create);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.Add(new Paragraph(nameOfDocument));
            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }

        private PdfPTable CreateTable(List<TableColumn> columns,
            TableRow[] rows, List<WorkerModel> workers)
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

    public class TableRow
    {
        public int Height { get; set; }
    }

    public class TableColumn
    {
        public int Width { set; get; }
        public string PropertyName { set; get; }
        public string Name { set; get; }
    }
}
