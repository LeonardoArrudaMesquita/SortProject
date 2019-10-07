using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Modelo
{
    public class Arrays
    {
        public Arrays()
        {                       
            ArrCinco = new byte[5];
            ArrDez = new byte[10];
            ArrCinquenta = new byte[50];
            ArrCem = new byte[100];
            ArrMil = new byte[1000];
            ArrDezMil = new byte[1000];
        }       

        public byte[] ArrCinco { get; set; }

        public byte[] ArrDez { get; set; }

        public byte[] ArrCinquenta { get; set; }

        public byte[] ArrCem { get; set; }

        public byte[] ArrMil { get; set; }

        public byte[] ArrDezMil { get; set; }
    }
}
