using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ex = Microsoft.Office.Interop.Excel;

namespace Sort.Servico
{
    public class Excel
    {
        public void GerarExcel()
        {
            try
            {
                String excelPath = @"C:\SI\Excel\APS.xlsx";

                if (File.Exists(excelPath))
                {
                    File.Delete(excelPath);
                }

                Ex.Application oApp;
                Ex._Workbook oBook;
                Ex._Worksheet oSheet;

                // Inicializando Excel App Object           
                oApp = new Ex.Application();
                oApp.Visible = true;

                //workbook = xlApp.Workbooks.Open(excelPath);
                oBook = (Ex._Workbook)oApp.Workbooks.Add(Missing.Value);
                oSheet = (Ex._Worksheet)oBook.ActiveSheet;

                oApp.Cells[1, 1] = "Teste";
                oApp.Cells[1, 2] = "Teste";
                oApp.Cells[1, 3] = "Teste";

                oBook.SaveAs(excelPath);
                oBook.Close(true, excelPath, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
