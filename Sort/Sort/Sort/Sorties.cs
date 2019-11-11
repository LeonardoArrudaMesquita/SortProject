using System;
using System.Collections;
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
            if (inicio < fim)
            {
                // Retorna o meio do vetor e "divide" o vetor em dois
                int meio = Particionar(vetor, inicio, fim);

                // Particiona ordenando do inicio até meio - 1
                QuickSort(vetor, inicio, meio - 1);

                // Particiona ordenando do meio + 1 até o fim
                QuickSort(vetor, meio + 1, fim);
            }
        }

        private int Particionar(Byte[] vetor, int pivo, int fim)
        {
            int i, j;

            // Joga tudo que é maior que o pivô á direito e tudo que é menor a esquerda
            for (i = pivo + 1, j = fim; i <= j;)
            {
                if (vetor[i] < vetor[pivo])
                {
                    i++;
                }
                else if (vetor[j] > vetor[pivo])
                {
                    j--;
                }
                else
                {
                    Swap(vetor, i, j);
                    i++;
                    j--;
                }
            }

            // Joga o pivô para o meio
            Swap(vetor, pivo, j);
            return j;
        }

        public void CountSort(Byte[] vetor)
        {
            int maior = EncontrarMaior(vetor);

            Byte[] vetorContador = new Byte[maior + 1];

            // Soma +1 para a quantidade de elementos encontrados naquele index
            for (int i = 0; i < vetor.Length; i++)
            {
                vetorContador[vetor[i]] += 1;
            }

            // Pecorre o Vetor Contador
            for (int i = 0, indiceAux = 0; i < vetorContador.Length; i++)
            {
                // Laço para inserção de elemento em vetor de saida de acordo com quantidade de vezes que o elemento aparece
                while (vetorContador[i] > 0)
                {
                    // Adiciona o elemento de forma ordenada no vetor
                    vetor[indiceAux] = (Byte)i;
                    indiceAux++;
                    vetorContador[i]--;
                }
            }
        }

        private int EncontrarMaior(Byte[] vetor)
        {
            int maior = vetor[0];

            for (int i = 1; i < vetor.Length; i++)
            {
                if (maior < vetor[i])
                {
                    maior = vetor[i];
                }
            }

            return maior;
        }

        public void BucketSort(Byte[] vetor)
        {
            
            //Verify input
            if (vetor == null || vetor.Length == 0)
                return;

            //Find the maximum and minimum values in the array
            int maxValue = vetor[0]; //start with first element
            int minValue = vetor[0];

            //Note: start from index 1
            for (int i = 1; i < vetor.Length; i++)
            {
                if (vetor[i] > maxValue)
                    maxValue = vetor[i];

                if (vetor[i] < minValue)
                    minValue = vetor[i];
            }

            //Create a temporary "bucket" to store the values in order
            //each value will be stored in its corresponding index
            //scooting everything over to the left as much as possible (minValue)
            //e.g. 34 => index at 34 - minValue
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            //Initialize the bucket
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            //Move items to bucket
            for (int i = 0; i < vetor.Length; i++)
            {
                bucket[vetor[i] - minValue].Add(vetor[i]);
            }

            //Move items in the bucket back to the original array in order
            int k = 0; //index for original array
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        vetor[k] = (Byte)bucket[i][j];
                        k++;
                    }
                }
            }
        }

        public void RadixSort(Byte[] vetor)
        {
            int max = EncontrarMaior(vetor);
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(vetor, vetor.Length, exp);
            }
        }

        //This is a modified version of Counting Sort from an earlier post
        //We need to do Counting Sort against each group of integers,
        //where the groups are made based on the position of significant digits.
        //So, we use Counting Sort on the least-significant digit, then the next-least, etc.
        //After that, we concatenate the groups together to form the final array.
        private static void CountingSort(Byte[] array, int length, int exponent)
        {
            //Create a new "output" array
            int[] output = new int[length]; // output array  
            int i;

            //Create a new "counting" array which stores the count of each unique number
            int[] count = new int[10];
            for (i = 0; i < 10; i++)
            {
                count[i] = 0;
            }
            for (i = 0; i < length; i++)
            {
                count[(array[i] / exponent) % 10]++;
            }

            //Change count[i] so that count[i] now contains actual position of  
            //this character in the output array.
            for (i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            //Build the output array.
            //This is the tricky part.
            for (i = length - 1; i >= 0; i--)
            {
                output[count[(array[i] / exponent) % 10] - 1] = array[i];
                count[(array[i] / exponent) % 10]--;
            }

            //Copy the output array to the final array.
            for (i = 0; i < length; i++)
            {
                array[i] = (Byte)output[i];
            }
        }
    }
}
