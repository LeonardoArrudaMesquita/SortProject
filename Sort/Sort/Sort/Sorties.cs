using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class Sorties
    {
        private Stopwatch sw;

        public Sorties()
        {
            sw = new Stopwatch();
        }

        public void Swap(Byte[] vetor, int a, int b)
        {
            byte aux = vetor[a];
            vetor[a] = vetor[b];
            vetor[b] = aux;
        }

        public void BubbleSort(Byte[] vetor)
        {            
            for (int i = 0; i < vetor.Length - 1; i++)
            {
                for (int j = 0; j < vetor.Length - (1 + i); j++)
                {
                    if (vetor[j] > vetor[j + 1])
                    {
                        Swap(vetor, j, j + 1);                        
                    }
                }
            }            
        }        

        public void InsertionSort(Byte[] vetor)
        {            
            for (int i = 1; i < vetor.Length; i++)
            {
                for (int j = i; j > 0 && vetor[j] < vetor[j - 1]; j--)
                {
                    Swap(vetor, j, j - 1);                                                   
                }
            }
        }

        public void SelectionSort(Byte[] vetor)
        {


            for (int i = 0, menor = 0; i < vetor.Length - 1; i++, menor = i)
            {                
                for (int j = i + 1; j < vetor.Length; j++)
                {
                    if (vetor[j] < vetor[menor])
                    {
                        menor = j;
                    }
                }
                Swap(vetor, i, menor);
            }
        }

        public void MergeSort(Byte[] vetor)
        {
            if (vetor[0] < vetor[vetor.Length - 1])
            {

            }
        }

        public void Intercala()
        {

        }
    }
}
