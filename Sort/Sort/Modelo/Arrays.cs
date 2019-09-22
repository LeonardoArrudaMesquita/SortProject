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
            MediaMiliSeg = 0;
            MediaNanoSeg = 0;
            ArrCinco = new byte[5];
            ArrDez = new byte[10];
            ArrCinquenta = new byte[50];
            ArrCem = new byte[100];
            ArrMil = new byte[1000];
            ArrDezMil = new byte[1000];
        }

        public double MediaMiliSeg { get; set; }

        public double MediaNanoSeg { get; set; }

        public byte[] ArrCinco { get; set; }

        public byte[] ArrDez { get; set; }

        public byte[] ArrCinquenta { get; set; }

        public byte[] ArrCem { get; set; }

        public byte[] ArrMil { get; set; }

        public byte[] ArrDezMil { get; set; }
    }
}
