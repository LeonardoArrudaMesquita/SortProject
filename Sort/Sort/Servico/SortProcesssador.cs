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

        public void ObterTempoSort(PropertyInfo atributo, Arrays ItemLista)
        {
            Stopwatch stw = new Stopwatch();
            var sort = new Sorties();
            
            var vetor = (Byte[])atributo.GetValue(ItemLista, null);

            // BUBBLE SORT

            stw.Start();
            sort.BubbleSort(GerenciadorVetor.CopiarVetor(vetor));
            stw.Stop();

            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Bubble,
                            (vetor.Length < 10000) ? stw.Elapsed.TotalMilliseconds * 1000000 : stw.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));           

            stw.Reset();

            // SELECTION SORT

            stw.Start();
            sort.SelectionSort(GerenciadorVetor.CopiarVetor(vetor));
            stw.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Selection,
                            (vetor.Length < 10000) ? stw.Elapsed.TotalMilliseconds * 1000000 : stw.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            stw.Reset();

            // INSERTION SORT

            stw.Start();
            sort.InsertionSort(GerenciadorVetor.CopiarVetor(vetor));
            stw.Stop();
            DadosExecList.Add(
                    new DadosExec(
                            SortEnum.Insertion,
                            (vetor.Length < 10000) ? stw.Elapsed.TotalMilliseconds * 1000000 : stw.Elapsed.TotalMilliseconds,
                            vetor.Length
                        ));
            stw.Reset();

            // HEAP SORT



            // MERGE SORT

            // QUICK SORT

            // COUNT SORT

            // BUCKET SORT

            // RADIX SORT

        }

        public void CalcularMediaTempoQuery()
        {
            //var media = DadosExecList.Select(x => x.TempoExec)
            //    .Where(y => y.);

            //var teste = from values in DadosExecList
            //             Where values.Tamanho == 0 && values.NomeSort == SortEnum.Bubble
            //            select values.Tamanho;





        }
    }
}
