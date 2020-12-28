using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Boar : Monster
    {
        public Boar(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string description) : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, description)
        {

        }


        public Boar()
        {
            MaxLife = 15;
            MaxDamage = 6;
            Name = "Skeleton Warrior";
            Life = 15;
            HitChance = 15;
            Block = 30;
            MinDamage = 1;
            Description = "An angry looking boar seems to be charging at you. It seems there is no rest for you this time.";
        }
    }
}
