using Sort.Modelo;
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

        public void GerarExcel(DadosExec[] tempoMediaVetor)
        {
            // Pega a pasta Raiz e concatena com o arquivo .xlsx
            String excelPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Excel\\APS.xlsx");

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

                // Estilizando a borda
                Ex.Borders borda = planilha.Borders;
                borda.LineStyle = Ex.XlLineStyle.xlContinuous;

                //// Popula a planilha com as médias
                this.PopularPlanilha(tempoMediaVetor);

                // Auto preenchendo o width das colunas e das linhas
                planilha.EntireColumn.AutoFit();
                planilha.EntireRow.AutoFit();

                // Cria uma nova planilha
                oSheetChart = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.Add();
                oSheetChart.Name = "Gráfico";

                GerarGraficoExcel("B2", "J2", 5, 10, 30, 300, 300); // Tam. 5
                GerarGraficoExcel("B3", "J3", 10, 320, 30, 300, 300); // Tam. 10
                GerarGraficoExcel("B4", "J4", 50, 630, 30, 300, 300); // Tam. 50
                GerarGraficoExcel("B5", "J5", 100, 10, 340, 300, 300); // Tam. 100
                GerarGraficoExcel("B6", "J6", 1000, 320, 340, 300, 300); // Tam. 1000
                GerarGraficoExcel("B7", "J7", 10000, 630, 340, 300, 300); // Tam. 10000

                // Fechando e salvando o arquivo
                oBook.Close(true, excelPath, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);                
            }
        }

        private void PopularPlanilha(DadosExec[] tempoMediaLista)
        {
            int cont = 0;

            for (int i = 2; i <= 7; i++)
            {
                for (int j = 2; j <= 10 ; j++)
                {
                    oApp.Cells[i, j] = tempoMediaLista[cont].TempoExec;
                    cont++;
                }
            }                             
        }

        private void GerarGraficoExcel(String c1, String c2, int tamanho, double left, double top, double width, double height)
        {
                       
            // Cria um Chart(Gráfico)
            Ex.ChartObjects cb = (Ex.ChartObjects)oSheetChart.ChartObjects(Type.Missing);
            Ex.ChartObject cbc = (Ex.ChartObject)cb.Add(left, top, width, height);
            Ex.Chart cp = cbc.Chart;

            Ex.Range bubbleValores = oSheet.get_Range(c1, c2);
            Ex.Range selectionValores = oSheet.get_Range("B3", "B3");
            Ex.Range insertionValores = oSheet.get_Range("C3", "C3");
            Ex.Range heapValores = oSheet.get_Range("C3", "C3");
            Ex.Range mergeValores = oSheet.get_Range("C3", "C3");
            Ex.Range quickValores = oSheet.get_Range("C3", "C3");
            Ex.Range countValores = oSheet.get_Range("C3", "C3");
            Ex.Range bucketValores = oSheet.get_Range("C3", "C3");
            Ex.Range radixValores = oSheet.get_Range("C3", "C3");

            // Seta o título do gráfico e o formata
            cp.HasTitle = true;
            cp.ChartTitle.Text = "MÉDIA DE TEMPO EM VETORES DE TAMANHO " + tamanho + " EM " + (tamanho <= 1000 ? "NANO" : "MILLI");
            cp.ChartTitle.Font.Name = "Arial";

            // Seta os nomes das colunas
            Ex.SeriesCollection seriesCollectionBubble = cp.SeriesCollection();
            Ex.Series bubbleSeries = seriesCollectionBubble.NewSeries();

            Ex.SeriesCollection seriesCollectionSelection = cp.SeriesCollection();
            Ex.Series selectionSeries = seriesCollectionSelection.NewSeries();

            Ex.SeriesCollection seriesCollectionInsertion = cp.SeriesCollection();
            Ex.Series insertionSeries = seriesCollectionInsertion.NewSeries();

            Ex.SeriesCollection seriesCollectionHeap = cp.SeriesCollection();
            Ex.Series heapSeries = seriesCollectionHeap.NewSeries();

            Ex.SeriesCollection seriesCollectionMerge = cp.SeriesCollection();
            Ex.Series mergeSeries = seriesCollectionMerge.NewSeries();

            Ex.SeriesCollection seriesCollectionQuick = cp.SeriesCollection();
            Ex.Series quickSeries = seriesCollectionQuick.NewSeries();

            Ex.SeriesCollection seriesCollectionCount = cp.SeriesCollection();
            Ex.Series countSeries = seriesCollectionCount.NewSeries();

            Ex.SeriesCollection seriesCollectionBucket = cp.SeriesCollection();
            Ex.Series bucketSeries = seriesCollectionBucket.NewSeries();

            Ex.SeriesCollection seriesCollectionRadix = cp.SeriesCollection();
            Ex.Series radixSeries = seriesCollectionRadix.NewSeries();            

            //series.Values = valores;
            bubbleSeries.Name = "Bubble";
            selectionSeries.Name = "Selection";
            insertionSeries.Name = "Insertion";
            heapSeries.Name = "Heap";
            mergeSeries.Name = "Merge";
            quickSeries.Name = "Quick";
            countSeries.Name = "Count";
            bucketSeries.Name = "Bucket";
            radixSeries.Name = "Radix";

            //series2.Values = valores2;
            bubbleSeries.Values = bubbleValores;
            selectionSeries.Values = selectionValores;
            insertionSeries.Values = insertionValores;
            heapSeries.Values = heapValores;
            mergeSeries.Values = mergeValores;
            quickSeries.Values = quickValores;
            countSeries.Values = countValores;
            bucketSeries.Values = bucketValores;
            radixSeries.Values = radixValores;

            bubbleSeries.XValues = oSheet.get_Range("B1", "B1");
            selectionSeries.XValues = oSheet.get_Range("B2", "B2");
            insertionSeries.XValues = oSheet.get_Range("B3", "B3");
            heapSeries.XValues = oSheet.get_Range("B4", "B4");
            mergeSeries.XValues = oSheet.get_Range("B5", "B5");
            quickSeries.XValues = oSheet.get_Range("B6", "B6");
            countSeries.XValues = oSheet.get_Range("B8", "B8");
            bucketSeries.XValues = oSheet.get_Range("B9", "B9");
            radixSeries.XValues = oSheet.get_Range("B10", "B10");
        }
    }
}
