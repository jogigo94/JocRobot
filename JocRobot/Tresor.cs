using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JocRobot
{
    public class Tresor : Posicio
    {
        public Tresor(int fila, int columna) : base(fila, columna) { }
        public override bool EsRobot { get => false; }
        public override bool EsTresor { get => true; }

    }
}
