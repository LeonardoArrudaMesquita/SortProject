using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class Sorties
    {
        public void BubbleSort(Byte[] vetor)
        {
            for (int i = 0; i < vetor.Length; i++)
            {
                for (int j = 0; j < vetor.Length - (1 + i); j++)
                {
                    if (vetor[j] > vetor[j + 1])
                    {
                        Byte aux = vetor[j + 1];
                        vetor[j + 1] = vetor[j];
                        vetor[j] = aux;
                    }
                }
            }
        }
    }
}
