using System;
using System.Collections.Generic;
using System.Drawing;
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
                
                oBook = (Ex._Workbook)oApp.Workbooks.Add(Missing.Value);
                oSheet = (Ex._Worksheet)oBook.ActiveSheet;

                // Dividindo os ranges da planilha
                Ex.Range planilha = oSheet.get_Range("A1", "J7");
                Ex.Range headSort = oSheet.get_Range("A1", "J1");
                Ex.Range headArray = oSheet.get_Range("A1", "A7");

                // Cabeçalho da planilha
                oApp.Cells[1, 2] = "Bubble";
                oApp.Cells[1, 3] = "Selection";
                oApp.Cells[1, 4] = "Inserction";
                oApp.Cells[1, 5] = "Merge";
                oApp.Cells[1, 6] = "Heap";
                oApp.Cells[1, 7] = "Quick";
                oApp.Cells[1, 8] = "Count";
                oApp.Cells[1, 9] = "Bucket";
                oApp.Cells[1, 10] = "Radix";

                oApp.Cells[2, 1] = "Índice 5";
                oApp.Cells[3, 1] = "Índice 10";
                oApp.Cells[4, 1] = "Índice 50";
                oApp.Cells[5, 1] = "Índice 100";
                oApp.Cells[6, 1] = "Índice 1000";
                oApp.Cells[7, 1] = "Índice 10000";
                
                // Estilizando a fonte
                planilha.Font.Name = "Arial";
                headSort.Font.Bold = true;
                headArray.Font.Bold = true;

                // Auto preenchendo o width das colunas e das linhas
                planilha.EntireColumn.AutoFit();
                planilha.EntireRow.AutoFit();

                // Estilizando a borda
                Ex.Borders borda = planilha.Borders;
                borda.LineStyle = Ex.XlLineStyle.xlContinuous;                   

                // Fechando e salvando o arquivo
                oBook.Close(true, excelPath, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);                
            }
        }
    }
}
