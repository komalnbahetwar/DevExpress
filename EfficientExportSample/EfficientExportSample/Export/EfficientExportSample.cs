using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace EfficientExportSample.Export
{
    public class TestItem
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }
    public partial class EfficientExportSample : DevExpress.XtraReports.UI.XtraReport
    {
        private XRTable xrTable = new XRTable();
        private List<TestItem> Source = new List<TestItem>();

        private float UsableWidth { get { return PageWidth - Margins.Left - Margins.Right; } }
        public EfficientExportSample()
        {
            InitializeComponent();
            for (int i = 0; i < 5000; i++)
            {
                Source.Add(new TestItem() { Column1 = "ABC", Column2 = "PQR" });
            }

            DataSource = Source;
            AddTableHeader();
            ProcessData(Source);
            Detail.Controls.Add(xrTable);
            Detail.HeightF = 23;
        }

        private void AddTableHeader()
        {
            PageHeaderBand band = new PageHeaderBand() { HeightF = 23 };
            Bands.Add(band);

            XRTable headerTable = new XRTable() { WidthF = UsableWidth };
            headerTable.BeginInit();
            XRTableRow row = new XRTableRow();
            headerTable.Rows.Add(row);

            for (int i = 1; i < 3; i++)
            {
                XRTableCell cell = new XRTableCell()
                {
                    TextAlignment = TextAlignment.MiddleCenter,
                    CanGrow = true,
                    Width = 100,
                    Font = new Font("Times New Roman", 9, FontStyle.Bold),
                    Text = "Column" + i.ToString()
                };
                row.Cells.Add(cell);
            }

            headerTable.AdjustSize();
            headerTable.EndInit();

            band.Controls.Add(headerTable);

        }

        private void ProcessData(List<TestItem> Source)
        {
            //Here in sample we are not using Source
            xrTable.BeginInit();

            xrTable.WidthF = UsableWidth;

            XRTableRow row = new XRTableRow();
            xrTable.Rows.Add(row);

            for (int i = 1; i < 3; i++)
            {
                XRTableCell cell = new XRTableCell()
                {
                    TextAlignment = TextAlignment.MiddleCenter,
                    CanGrow = true,
                    Width = 100,
                    Font = new Font("Times New Roman", 9, FontStyle.Bold)
                };

                row.Cells.Add(cell);
                cell.DataBindings.Add("Text", null, "Column" + i.ToString());
            }
            xrTable.AdjustSize();

            xrTable.EndInit();
        }
    }
}
