using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP323_Shpilko.Model
{
    internal class Skelet : Enemy
    {
        public Skelet() : base(40, 6, 3)
        {
            Name = "Скелет";
            IgnoreDefense = true;
        }
    }
}
