using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.Charts;
 
namespace TimeSheet2017.AppCode
{
   

    public class Report
    {
       
        public void genExcel()
        {
            SpreadsheetInfo.SetLicense("FREE-LMITED-KEY");

            ExcelFile workbook = new ExcelFile();
            ExcelWorksheet worksheet = workbook.Worksheets.Add("Sheet1");

            worksheet.Cells[0, 0].Value = "Hello World!";

            try
            {
                workbook.Save("testWorkbook.xlsx");
            }
            catch (Exception ex)
            {
                string typeName = ex.GetType().Name;
            }



     
            // Create a new workbook and add a new worksheet to it.
            //var workbook = new ExcelFile();
           // var worksheet = workbook.Worksheets.Add("Chart");

            // Add a new Column chart to the worksheet.
            //var chart = worksheet.Charts.Add(ChartType.Column, "K17", "R33");
            // Select data for the chart.
           // chart.SelectData("A1:E5");

            // TODO: populate cell range A1:E5 with data.

            // Save workbook to XLSX and PDF formats.
            //workbook.Save("Chart.xlsx");
            //workbook.Save("Chart.pdf");

            //Additional information: License not set.Call SpreadsheetInfo.SetLicense() 
            //method before using any other class from GemBox.Spreadsheet library.Free 
            //version serial key is: FREE-LIMITED-KEY


        }










    }
}