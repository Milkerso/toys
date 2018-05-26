using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    class Submarine : Zabawki, IDive, IAccelerate
    {
        public int glebokosc { get; set; } = 0;
        public int przyspieszenie { get; set; } = 0;

        public void Accelerate(int change)
        {
            this.przyspieszenie = change;
        }

        public void Dive(int change)
        {
            this.glebokosc = change;
        }
    }
}
