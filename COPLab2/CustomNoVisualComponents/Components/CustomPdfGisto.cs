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
using System.Windows.Forms;
using System.Collections.Generic;

namespace CustomNoVisualComponents.Components
{
    public partial class CustomPdfGisto : Component
    {
        public CustomPdfGisto()
        {
            InitializeComponent();
        }

        public void CreateGist(string filename, string docName, string gistName,
            LocationLegend legend, GistInfo gistInfo)
        {

            var document = new Document();
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
}
