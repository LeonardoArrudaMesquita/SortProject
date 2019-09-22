﻿using Sort.Servico;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Vetor vt = new Vetor();
            var sort = new Sorties();
            Stopwatch sw = new Stopwatch();

            var ge = new Excel();
            ge.GerarExcel();

            var vetores = vt.GerarVetores();

            foreach (var item in vetores)
            {
                sw.Start();

                sort.BubbleSort(item.ArrCinco);


                sw.Stop();

                item.MediaMiliSeg = sw.Elapsed.TotalMilliseconds;
                item.MediaNanoSeg = sw.Elapsed.TotalMilliseconds * 1000000;
            }

            Console.ReadKey();
        }
    }
}