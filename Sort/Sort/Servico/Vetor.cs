using Sort.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Servico
{
    public class Vetor
    {
        public List<Arrays> PopularVetor()
        {
            var lstByte = new List<Arrays>();
            Random rd = new Random();

            for (int i = 0; i < 50; i++)
            {
                var valor = new Arrays();
                
                rd.NextBytes(valor.ArrCinco);
                rd.NextBytes(valor.ArrDez);
                rd.NextBytes(valor.ArrCinquenta);
                rd.NextBytes(valor.ArrCem);
                rd.NextBytes(valor.ArrMil);
                rd.NextBytes(valor.ArrDezMil);           

                lstByte.Add(valor);
            }
            return lstByte;
        }

        public Byte[] CopiarVetor(Byte[] vetor)
        {
            Byte[] aux = new Byte[vetor.Length];

            vetor.CopyTo(aux, 0);

            return aux;
        }
    }
}