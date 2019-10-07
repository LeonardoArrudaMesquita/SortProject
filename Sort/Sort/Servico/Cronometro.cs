using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.Servico
{
    public class Cronometro : IDisposable
    {
        public static Stopwatch CronometroTempo = new Stopwatch();

        static Cronometro()
        {
            CronometroTempo.Start();
        }

        public void Dispose()
        {
            CronometroTempo.Stop();


        }
    }
}
