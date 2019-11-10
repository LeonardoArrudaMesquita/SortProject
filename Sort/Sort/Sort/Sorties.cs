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
            int maior = EncontrarMaior(vetor);

            List<int>[] auxiliar = new List<int>[vetor.Length];

            // Cria o bucket em cada índice para armazenar os números
            for (int i = 0; i < auxiliar.Length; i++)
            {
                auxiliar[i] = new List<int>(vetor.Length);
            }

            int indice;

            for (int i = 0; i < auxiliar.Length; i++)
            {
                indice = (vetor[i] * vetor.Length) / (maior + 1);

                List<int> temporario = auxiliar[indice];
                int contador = 0;

                while (contador < temporario.Count && temporario.ElementAt(contador) < vetor[i])
                {
                    contador++;
                }

                temporario.Insert(contador, vetor[i]);
            }

            indice = 0;

            for (int i = 0; i < auxiliar.Length; i++)
            {
                // Any() verifica se tem algum registro na lista (isEmpty)
                while (auxiliar[i].Any())
                {
                    vetor[indice++] = (Byte)auxiliar[i].ElementAt(0);
                    auxiliar[i].RemoveAt(0);
                }
            }
        }

        public void RadixSort(Byte[] vetor)
        {
            int i, j;
            int[] temporario = new int[vetor.Length];

            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < vetor.Length; ++i)
                {
                    bool move = (vetor[i] << shift) >= 0;
                    if (shift == 0 ? !move : move) // shift the 0's to old's head
                    {
                        vetor[i - j] = vetor[i];
                    }
                    else // move the 1's to tmp
                    {
                        temporario[j++] = vetor[i];
                    }                    
                }
                
                //temporario.CopyTo(vetor, vetor.Length - j);
            }
        }
    }
}
