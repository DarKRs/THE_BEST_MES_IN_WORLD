using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES
{

    public class Object
    {
        
        public Dictionary<int, Questions> Questins = new Dictionary<int, Questions>();
        public string Name;
        public double pConst;
    }
}
