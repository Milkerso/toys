using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    class Car : Zabawki, IAccelerate
    {
        public int przyspieszenie { get; set; } = 0;

        public void Accelerate(int change)
        {
            this.przyspieszenie = change;
        }
    }
}
