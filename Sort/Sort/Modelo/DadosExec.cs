using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Modelo
{
    public class DadosExec
    {
        public DadosExec(SortEnum nomeSort, Double tempoExec, int tamanho)
        {
            NomeSort = nomeSort;
            TempoExec = tempoExec;
            Tamanho = tamanho;
        }

        public SortEnum NomeSort { get; set; }
        public Double TempoExec { get; set; }
        public int Tamanho { get; set; }
    }
}
