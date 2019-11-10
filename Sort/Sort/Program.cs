using Sort.Servico;
using System;
using System.Collections.Generic;
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
            Vetor GerenciadorVetor = new Vetor();                                    
            var vetores = GerenciadorVetor.PopularVetor();

            SortProcessador sp = new SortProcessador();

            // Percorre cada item da List
            foreach (var ItemLista in vetores)
            {                
                // Percorre as propriedades dos objetos Arrays da List
                foreach (PropertyInfo atributo in ItemLista.GetType().GetProperties())
                {
                    sp.ObterTempoSort(atributo, ItemLista);                                        
                }
            }

            sp.CalcularMediaTempoQuery();

            Console.WriteLine("Programa Executado com Sucesso !");
            Console.ReadKey();
        }
    }
}