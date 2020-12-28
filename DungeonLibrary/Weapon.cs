using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //what are the members of a data type class

        //fields
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        //properties
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than max or less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        //constructors
        //create a fully qualified contructor (FQCTOR)
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            //If you have any properties with business rules that relys on other properties you must set the other properties value first
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = IsTwoHanded;
        }

        //no default ctor here. We don't want them to make an empty weapon
        //methods

        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\nBonus Hit: {3}%\t{4}", Name, MinDamage, MaxDamage, BonusHitChance, IsTwoHanded ? "Two-Handed" : "One-Handed");
        }
    }
}
