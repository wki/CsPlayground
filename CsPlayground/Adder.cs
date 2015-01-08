using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPlayground
{
    public class Adder : IAdder
    {
        public int Add1(int value)
        {
            return value + 1;
        }
    }
}
