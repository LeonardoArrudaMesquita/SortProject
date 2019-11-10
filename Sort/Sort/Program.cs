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
            Excel excel = new Excel();
            Vetor GerenciadorVetor = new Vetor();                                    
            var vetores = GerenciadorVetor.PopularVetor();

            SortProcessador sortControle = new SortProcessador();

            // Percorre cada item da List
            foreach (var ItemLista in vetores)
            {                
                // Percorre as propriedades dos objetos Arrays da List
                foreach (PropertyInfo atributo in ItemLista.GetType().GetProperties())
                {
                    sortControle.ObterTempoSort(atributo, ItemLista);                                        
                }
            }

            // Calcula a média de tempo dos sorties, adiciona em um Vetor e retorna
            var tempoMediaVetor = sortControle.CalcularMediaTempoQuery();

            // Criar o excel, popula com as médias e gera os gráficos
            excel.GerarExcel(tempoMediaVetor);

            Console.WriteLine("Programa Executado com Sucesso !");
            Console.ReadKey();
        }
    }
}