using Sort.Sort;
using System;
using System.Diagnostics;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Vetor vt = new Vetor();
            var sort = new Sorties();
            Stopwatch sw = new Stopwatch();

            var vetores = vt.GerarVetores();

            vetores.ForEach(x =>                
                sort.BubbleSort(x.IndiceCinco)
            );

            foreach (var item in vetores)
            {                
                sw.Start();

                sort.BubbleSort(item.IndiceCinco);


                sw.Stop();

                item.TempoMiliSeg = sw.Elapsed.TotalMilliseconds;
                item.TempoNanoSeg = sw.Elapsed.TotalMilliseconds * 1000000;
            }

            Console.ReadKey();
        }
    }
}
