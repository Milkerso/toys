using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toys
{
    interface IRise
    {
        int wysokosc { get; set; }
        void Rise(int change);
    }
}
