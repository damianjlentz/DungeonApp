using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //this class will not have fields, properties or any ctors. It is just a warehouse for methods

        public static void DoAttack(Character attacker, Character defender)
        {
            //get random number from 1 - 100 as our dice roll (To hit)
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30); //number is time in milliseconds

            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock())) //this is the place to decide how the success of an attack works
            {
                //the attacker hit
                int damageDealt = attacker.CalcDamage();

                //assign the dmg
                defender.Life -= damageDealt;

                //write the result out
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} missed like a chump", attacker.Name);
            }
        }

        public static void DoBattle(Player player, Monster monster)
        {
            //player attacks first
            DoAttack(player, monster);

            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
