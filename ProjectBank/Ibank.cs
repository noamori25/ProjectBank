using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBank
{
    interface Ibank
    {
       string Name { get; }
       string Address { get; }
       int CustomerCount { get; }
    }
}
