using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class KoboldLord : Monster
    {
        public KoboldLord(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string description) : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, description)
        {

        }


        public KoboldLord()
        {
            MaxLife = 25;
            MaxDamage = 4;
            Name = "Ilfang The Kobold Lord";
            Life = 25;
            HitChance = 25;
            Block = 25;
            MinDamage = 1;
            Description = "This Monstrocity is Ilfang The Kobold Lord, Being 20ft tall and very tanky he will be a difficult enemy.";
        }
    }
}
