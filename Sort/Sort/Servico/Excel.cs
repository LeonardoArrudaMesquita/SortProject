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
        Ex.Application oApp;
        Ex._Workbook oBook;
        Ex._Worksheet oSheet;
        Ex._Worksheet oSheetChart;

        public void GerarExcel()
        {
            String excelPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "//Excel//");

            // Inicializando Excel App Object           
            oApp = new Ex.Application();
            oApp.Visible = true;

            oBook = (Ex._Workbook)oApp.Workbooks.Add(Missing.Value);
            oSheet = (Ex._Worksheet)oBook.ActiveSheet;
            oSheet.Name = "Tempo";

            try
            {                
                if (File.Exists(excelPath))
                {
                    File.Delete(excelPath);
                }              

                // Dividindo os ranges da planilha
                Ex.Range planilha = oSheet.get_Range("A1", "J7");
                Ex.Range headSort = oSheet.get_Range("A1", "J1");
                Ex.Range headArray = oSheet.get_Range("A1", "A7");

                // Cabeçalho da planilha
                oApp.Cells[1, 2] = "Bubble";
                oApp.Cells[1, 3] = "Selection";
                oApp.Cells[1, 4] = "Insertion";
                oApp.Cells[1, 5] = "Heap";
                oApp.Cells[1, 6] = "Merge";
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

                // Cria uma nova planilha
                oSheetChart = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.Add();
                oSheetChart.Name = "Gráfico";

                GerarGraficoExcel("B2", "J2", "5", 10, 30, 300, 300); // Tam. 5
                GerarGraficoExcel("B3", "J3", "10", 320, 30, 300, 300); // Tam. 10
                GerarGraficoExcel("B4", "J4", "50", 630, 30, 300, 300); // Tam. 50
                GerarGraficoExcel("B5", "J5", "100", 10, 340, 300, 300); // Tam. 100
                GerarGraficoExcel("B6", "J6", "1000", 320, 340, 300, 300); // Tam. 1000
                GerarGraficoExcel("B7", "J7", "10000", 630, 340, 300, 300); // Tam. 10000

                // Fechando e salvando o arquivo
                oBook.Close(true, excelPath, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                oBook.Close(true, excelPath, null);
            }
        }

        public void PopulaPlanilha()
        {

        }

        public void GerarGraficoExcel(String c1, String c2, String tam, double left, double top, double width, double height)
        {
                       
            // Cria um Chart(Gráfico)
            Ex.ChartObjects cb = (Ex.ChartObjects)oSheetChart.ChartObjects(Type.Missing);
            Ex.ChartObject cbc = (Ex.ChartObject)cb.Add(left, top, width, height);
            Ex.Chart cp = cbc.Chart;

            Ex.Range valores = oSheet.get_Range(c1, c2);
            
            // Seta o título do gráfico
            cp.HasTitle = true;
            cp.ChartTitle.Text = "MÉDIA DE TEMPO EM VETORES DE TAMANHO " + tam;            

            // Seta os nomes das colunas
            Ex.SeriesCollection seriesCollection = cp.SeriesCollection();
            Ex.Series series = seriesCollection.NewSeries();

            series.Values = valores;
            series.XValues = oSheet.get_Range("B1", "J1");

            // Popula o Gráfico
            cp.SetSourceData(valores, Ex.XlRowCol.xlRows);
        }
    }
}
