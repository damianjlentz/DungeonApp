using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //new classes in a DLL default internal. Internal is not a keyword you have to type in. THat is the defualt if you do not supply another access modifier

        //sealed ends the inheritance line so this one can't be a base

        public Weapon EquippedWeapon { get; set; }

        //ctors
        //only going to make a fqctor because we do not want to allow anyone to make a player that does not have values for all of the properties

        public Player(string name, int hitChance, int block, int life, int maxLife, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            EquippedWeapon = equippedWeapon;
        }

        public override string ToString()
        {
            string description = "";


            return string.Format("***** {0} *****\nLife: {1} of {2}\nHit Chance: {3}%\n{4}\nBlock: {5}\nDescription: {6}", Name, Life, MaxLife, CalcHitChance(), EquippedWeapon, Block, description);

        }
        //overiding the CalcDamage in player to use their weapons property of mindamgae and maxdamage
        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage;

            //return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }


    }
}

