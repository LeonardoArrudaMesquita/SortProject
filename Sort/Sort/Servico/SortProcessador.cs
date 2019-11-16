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
    public class SortProcessador
    {
        List<DadosExec> DadosExecList = new List<DadosExec>();        
        Vetor GerenciadorVetor = new Vetor();
        Stopwatch tempo = new Stopwatch();
        Sorties sort = new Sorties();
        Byte[] vetorCopia;

        public void ObterTempoSort(PropertyInfo atributo, Arrays ItemLista)
        {                        
            var vetor = (Byte[])atributo.GetValue(ItemLista, null);

            // BUBBLE SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.BubbleSort(vetorCopia);
            tempo.Stop();

            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Bubble,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));           

            tempo.Reset();

            // SELECTION SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.SelectionSort(vetorCopia);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Selection,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // INSERTION SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.InsertionSort(vetorCopia);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Insertion,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // MERGE SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.MergeSort(vetorCopia, 0, vetorCopia.Length - 1);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Merge,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // HEAP SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.HeapSort(vetorCopia);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Heap,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // QUICK SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.QuickSort(vetorCopia, 0, vetorCopia.Length - 1);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Quick,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // COUNT SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.CountSort(vetorCopia);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Count,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // BUCKET SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.BucketSort(vetorCopia);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Bucket,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();

            // RADIX SORT

            vetorCopia = GerenciadorVetor.CopiarVetor(vetor);
            tempo.Start();
            sort.RadixSort(vetorCopia);
            tempo.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Radix,
                            (vetor.Length <= 1000) ? tempo.Elapsed.TotalMilliseconds * 1e6 : tempo.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            tempo.Reset();
        }

        public DadosExec[] CalcularMediaTempoQuery()
        {
            List<DadosExec> tempoMediaLista = new List<DadosExec>();
            DadosExec[] tempoMediaVetor = new DadosExec[54];

            int cont = 0;
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

                    tempoMediaVetor[cont] = new DadosExec(nome, media, tamanho);

                    cont++;
                }
            }

            return tempoMediaVetor;
        }
    }
}
