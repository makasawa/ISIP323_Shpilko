using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP323_Shpilko.Model
{
    internal class SkeletBossKova : Skelet
    {
        public SkeletBossKova()
        {
            Name = "Скелет-Ковальский";
            MaxHP = (int)(40 * 2.5);
            CurrentHP = MaxHP;
            Attack = (int)(6 * 1.3);
            Defense = (int)(3 * 1.4);
        }
    }
}
