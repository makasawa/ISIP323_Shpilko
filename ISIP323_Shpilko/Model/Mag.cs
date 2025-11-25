using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP323_Shpilko.Model
{
    internal class Mag : Enemy
    {
        public Mag() : base(25, 4, 2)
        {
            Name = "Маг";
            CanFreeze = true;
            FreezeChance = 20;
        }
    }
}
