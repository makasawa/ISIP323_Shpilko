using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP323_Shpilko.Model
{
    internal class MagBoss : Mag
    {
        public MagBoss()
        {
            Name = "Архимаг C++";
            MaxHP = (int)(25 * 1.8);
            CurrentHP = MaxHP;
            Attack = (int)(4 * 1.6);
            Defense = (int)(2 * 1.1);
            FreezeChance += 10;
        }
    }
}
