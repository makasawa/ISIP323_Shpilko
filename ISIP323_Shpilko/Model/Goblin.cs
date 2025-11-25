using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP323_Shpilko.Model
{
    internal class Goblin : Enemy
    {
        public Goblin() : base(30, 5, 2)
        {
            Name = "Гоблин";
            HasCrit = true;
            CritChance = 20;
        }
    }
}
