using System;
using System.Collections.Generic;
using System.Text;

namespace Sort.Modelo
{
    public class Arrays
    {
        public Arrays()
        {
            Comparacoes = 0;
            IndiceCinco = new byte[5];
            IndiceDez = new byte[10];
            IndiceCinquenta = new byte[50];
            IndiceCem = new byte[100];
            IndiceMil = new byte[1000];
            IndiceDezMil = new byte[1000];
        }

        public int Comparacoes { get; set; }

        public double TempoMiliSeg { get; set; }

        public double TempoNanoSeg { get; set; }

        public byte[] IndiceCinco { get; set; }

        public byte[] IndiceDez { get; set; }

        public byte[] IndiceCinquenta { get; set; }

        public byte[] IndiceCem { get; set; }

        public byte[] IndiceMil { get; set; }

        public byte[] IndiceDezMil { get; set; }
    }
}
