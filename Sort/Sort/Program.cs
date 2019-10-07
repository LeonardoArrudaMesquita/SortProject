using Sort.Servico;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

            //var ge = new Excel();
            //ge.GerarExcel();

            var vetores = vt.PopulaVetor();

            foreach (var vetor in vetores)
            {
                using (var temporizardor = new Cronometro())
                {
                    foreach (PropertyInfo atributo in vetor.GetType().GetProperties())
                    {
                        var valorProp = atributo.GetValue(vetor, null);

                        sort.SelectionSort((Byte[])valorProp);
                        sort.InsertionSort((Byte[])valorProp);
                        sort.BubbleSort((Byte[])valorProp);
                    }                    
                }
            }

            Console.WriteLine("Programa Executado com Sucesso !");
            Console.ReadKey();
        }
    }
}