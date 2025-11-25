using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP323_Shpilko.Model
{
    internal class SkeletBossPest : Skelet
    {
        public SkeletBossPest()
        {
            Name = "Скелет-Пестов";
            MaxHP = (int)(40 * 1.3);
            CurrentHP = MaxHP;
            Attack = (int)(6 * 1.8);
            Defense = (int)(3 * 0.6);
        }
    }
}
