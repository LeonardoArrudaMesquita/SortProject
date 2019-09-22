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
        public List<Arrays> GerarVetores()
        {
            var lstByte = new List<Arrays>();
            Random rd = new Random();

            for (int i = 0; i < 50; i++)
            {
                var valor = new Arrays();

                Byte[] arrCinco = new Byte[5];
                Byte[] arrDez = new Byte[10];
                Byte[] arrCinquenta = new Byte[50];
                Byte[] arrCem = new Byte[100];
                Byte[] arrMil = new Byte[1000];
                Byte[] arrDezMil = new Byte[10000];

                rd.NextBytes(arrCinco);
                rd.NextBytes(arrDez);
                rd.NextBytes(arrCinquenta);
                rd.NextBytes(arrCem);
                rd.NextBytes(arrMil);
                rd.NextBytes(arrDezMil);

                valor.ArrCinco = arrCinco;
                valor.ArrDez = arrDez;
                valor.ArrCinquenta = arrCinquenta;
                valor.ArrCem = arrCem;
                valor.ArrMil = arrMil;
                valor.ArrDezMil = arrDezMil;

                lstByte.Add(valor);
            }
            return lstByte;
        }
    }
}
