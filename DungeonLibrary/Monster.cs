using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //field
        private int _minDamage;
        //properties

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than max
                //can't be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    //tried to set a value outside the range
                    _minDamage = 1;
                }
            }
        }

        //min lab
        //create the default and fqctor for monster. rembember - the assignment order isnide of teh FQ Ctor matters

        public Monster()
        {
            //default
        }
        public Monster(string name, int hitChance, int block, int life, int maxLife, int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            MinDamage = minDamage;
            Description = description;
        }

        //methods
        public override string ToString()
        {
            return string.Format("\n***** Monster *****\n{0}\nLife: {1} of {2}\nDamage: {3} to {4}\nBlock:{5}\nDescritpion:\n{6}", Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }

        //we are overriding the ClacDamage() to use teh properties of min and max damage
        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
            //if we had a monster with min of 2 and max of 8, if we passed min and max dmg we would never be able to get back 8 because the max value in the Nex() method is exclusive
        }
    }//end class
}
