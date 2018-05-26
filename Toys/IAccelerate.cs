using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    interface IAccelerate
    {
        int przyspieszenie { get; set; }
        void Accelerate(int change);
    }
}
