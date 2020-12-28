using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Skeleton : Monster
    {

        

        public Skeleton(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string description) : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, description)
        {

        }
        

        public Skeleton()
        {
            MaxLife = 12;
            MaxDamage = 5;
            Name = "Skeleton Warrior";
            Life = 12;
            HitChance = 25;
            Block = 20;
            MinDamage = 1;
            Description = "It seems even the dead will attempt your thwart your progress to salvation in this wretched game, even now a undead skelton shambles toward you, sword in hand.";
        }
    }
}
