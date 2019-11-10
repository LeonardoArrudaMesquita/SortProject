using Sort.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Servico
{
    public class SortProcesssador
    {
        List<DadosExec> DadosExecList = new List<DadosExec>();        
        Vetor GerenciadorVetor = new Vetor();
        Stopwatch tempo = new Stopwatch();
        Sorties sort = new Sorties();

        public void ObterTempoSort(PropertyInfo atributo, Arrays ItemLista)
        {                        
            var vetor = (Byte[])atributo.GetValue(ItemLista, null);

            // BUBBLE SORT

            tempo.Start();
            sort.BubbleSort(GerenciadorVetor.CopiarVetor(vetor));
            tempo.Stop();

            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Bubble,
                            (vetor.Length < 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));           

            tempo.Reset();

            // SELECTION SORT

            tempo.Start();
            sort.SelectionSort(GerenciadorVetor.CopiarVetor(vetor));
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Selection,
                            (vetor.Length < 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // INSERTION SORT

            tempo.Start();
            sort.InsertionSort(GerenciadorVetor.CopiarVetor(vetor));
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Insertion,
                            (vetor.Length < 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // MERGE SORT

            tempo.Start();
            sort.MergeSort(GerenciadorVetor.CopiarVetor(vetor), 0, vetor.Length - 1);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Merge,
                            (vetor.Length < 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // HEAP SORT

            tempo.Start();
            sort.HeapSort(GerenciadorVetor.CopiarVetor(vetor));
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Heap,
                            (vetor.Length < 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // QUICK SORT

            tempo.Start();
            sort.QuickSort(GerenciadorVetor.CopiarVetor(vetor), 0, vetor.Length - 1);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Quick,
                            (vetor.Length < 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // COUNT SORT

            // BUCKET SORT

            // RADIX SORT

        }

        public void CalcularMediaTempoQuery()
        {
            int[] TamanhosVetoresAux = { 5, 10, 50, 100, 1000, 10000 };
            SortEnum[] NomesVetoresAux = {
                                SortEnum.Bubble,
                                SortEnum.Selection,
                                SortEnum.Insertion,
                                SortEnum.Heap,
                                SortEnum.Merge,
                                SortEnum.Quick,
                                SortEnum.Count,
                                SortEnum.Bucket,
                                SortEnum.Radix };

            foreach (var tamanho in TamanhosVetoresAux)                        
            {
                foreach (var nome in NomesVetoresAux)
                {
                    var media = (from values in DadosExecList
                                 where values.Tamanho == tamanho && values.NomeSort == nome
                                 select values.TempoExec).Sum() / 50;
                }
            }            
        }
    }
}
