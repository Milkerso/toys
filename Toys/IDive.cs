using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    interface IDive
    {
        int glebokosc { get; set; }
        void Dive(int change);
    }
}
