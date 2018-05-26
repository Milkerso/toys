using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    class Plane : Zabawki, IRise, IAccelerate
    {
        public int wysokosc { get; set; } = 0;
        public int przyspieszenie { get; set; } = 0;

        public void Accelerate(int change)
        {
            this.przyspieszenie = change;
        }

        public void Rise(int change)
        {
            this.wysokosc = change;
        }
    }
}
