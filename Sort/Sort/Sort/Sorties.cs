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
        private void Swap(Byte[] vetor, int a, int b)
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

        public void MergeSort(Byte[] vetor, int inicio, int fim)
        {
            if (inicio < fim)
            {
                int meio = (inicio + fim) / 2;

                // Divide o vetor em uma posição cada dividindo ao meio
                MergeSort(vetor, inicio, meio);
                MergeSort(vetor, meio + 1, fim);

                // Junta os vetores ordenando novamente
                Intercala(vetor, inicio, meio, fim);
            }
        }

        private void Intercala(Byte[] vetor, int inicio, int meio, int fim)
        {
            Byte[] vetorAux = new Byte[fim + 1];

            int i, j;

            for (i = inicio; i <= meio; i++)
            {
                vetorAux[i] = vetor[i];
            }

            for (j = meio + 1; j <= fim; j++)
            {
                vetorAux[fim + meio + 1 - j] = vetor[j];
            }

            i = inicio;
            j = fim;

            for (int k = inicio; k <= fim; k++)
            {
                if (vetorAux[i] <= vetorAux[j])
                {
                    vetor[k] = vetorAux[i];
                    i = i + 1;
                }
                else
                {
                    vetor[k] = vetorAux[j];
                    j = j - 1;
                }
            }
        }

        public void HeapSort(Byte[] vetor)
        {
            // Transforma o array numa arvore binária Max Heap (Maior elemento á esquerda do vetor)
            CriaHeap(vetor);

            // Joga o maior elemento para o final do vetor e arruma os heaps de novo
            for (int fim = vetor.Length - 1; fim > 0;)
            {                
                Swap(vetor, 0, fim);
                ArrumaHeap(vetor, 0, --fim);
            }
        }

        private void CriaHeap(Byte[] vetor)
        {
            int inicio = (vetor.Length - 2) / 2;

            for (int i = inicio; i >= 0; i--)
            {
                ArrumaHeap(vetor, i, vetor.Length - 1);                
            }
        }

        private void ArrumaHeap(Byte[] vetor, int inicio, int fim)
        {
            for (int raiz = inicio; raiz * 2 + 1 <= fim; raiz++)
            {
                int filho = raiz * 2 + 1;
                int pai = raiz;

                // Verifica se o pai é menor que o filho
                if (vetor[pai] < vetor[filho])
                {
                    pai = filho;
                }

                // Verifica se o pai é menor que o segundo filho
                if (filho + 1 <= fim && vetor[pai] < vetor[filho + 1])
                {
                    pai = filho + 1;
                }

                // Se os elementos forem iguais não haverá troca e caso as duas condições acima forem falsas
                if (pai == raiz)
                {
                    break;
                }
                else
                {
                    Swap(vetor, pai, raiz);
                }
            }            
        }

        public void QuickSort(Byte[] vetor, int inicio, int fim)
        {

        }
    }
}
