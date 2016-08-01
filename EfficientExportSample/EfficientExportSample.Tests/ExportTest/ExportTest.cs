using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevExpress.XtraPrinting;

namespace EfficientExportSample.Tests.ExportTest
{
    [TestClass]
    public class ExportTest
    {
        [TestMethod]
        public void TestExport()
        {
            var startTime = DateTime.Now;
            string path = "E://Workspace/temp/temp.xls";

            var report = new Export.EfficientExportSample();
            report.ExportToXls(path, new XlsExportOptions(TextExportMode.Value, true));

            var time = (DateTime.Now - startTime).TotalMilliseconds;
            Console.WriteLine("Total time taken for export :" + time);
        }
    }
}
