using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SAO DnD Project";
            Console.WriteLine("Welcome to the castle floating in the sky... Aincrad");

            int levelsBeat = 0;
            bool usedSwordSkill = false;
            bool usedHealing = false;

            Console.WriteLine("Please enter the name you wish to go by in the game");
            string playerName = Console.ReadLine();

            // 1. Create the player - need to learn custom classes
            // 2. Create a weapon
            Weapon LongSword = new Weapon(1, 8, "Long Sword", 10, false);
            Weapon GreatSword = new Weapon(6, 15, "Greatsword", 5, true);
            Weapon Dagger = new Weapon(1, 4, "Dagger", 25, false);
            Weapon MaceandShield = new Weapon(3, 10, "Mace and Shield", 15, true);

            Console.WriteLine("Choose a weapon type you would like to use on your quest to clear the game\nLongsword 1\nGreatsword 2\nDagger 3\nMace and Shield 4");
            string weaponChoice = Console.ReadLine().ToUpper();
            bool agile = false;
            Weapon chosenWeapon = null;
            bool hasChosenWeapon = false;
            do
            {
                {
                    switch (weaponChoice)
                    {
                        case "1":
                        case "LONGSWORD":
                        case "L":
                            chosenWeapon = LongSword;
                            hasChosenWeapon = true;
                            break;
                        case "2":
                        case "GREATSWORD":
                        case "G":                            
                            chosenWeapon = GreatSword;
                            hasChosenWeapon = true;
                            break;
                        case "3":
                        case "DAGGER":
                        case "D":
                            chosenWeapon = Dagger;
                            agile = true;
                            hasChosenWeapon = true;
                            break;
                        case "4":
                        case "MACEANDSHIELD":
                        case "M":                           
                            chosenWeapon = MaceandShield;
                            hasChosenWeapon = true;
                            break;
                        default:
                            Console.WriteLine("Input not recognized. Please enter a correct response");
                            hasChosenWeapon = false;
                            break;
                    }
                }
            } while (hasChosenWeapon == false);

            Player player = new Player(playerName, 10, 15, 20, 20, chosenWeapon);
            int playerLevel = 1;

            if (chosenWeapon == LongSword)
            {
                player.HitChance = 50;
                player.Block = 15;
                player.Life = 15;
                player.MaxLife = 15;
            }
            if (chosenWeapon == GreatSword)
            {
                player.HitChance = 40;
                player.Block = 10;
                player.Life = 20;
                player.MaxLife = 20;
            }
            if (chosenWeapon == Dagger)
            {
                player.HitChance = 60;
                player.Block = 20;
                player.Life = 12;
                player.MaxLife = 12;
            }
            if (chosenWeapon == MaceandShield)
            {
                player.HitChance = 35;
                player.Block = 30;
                player.Life = 30;
                player.MaxLife = 30;
            }
            //3. Create a loop for the room and monster

            bool exit = false;

                        do
                       {
                // 4. Create a room
                Console.WriteLine(GetRoom());
                // 5. Create a monster
                Skeleton r1 = new Skeleton(); //uses the default ctor which sets some default values
                Skeleton r2 = new Skeleton("Skeleton Hero", 30, 35, 18, 18, 3, 7, "A hero from a forgotten realm, risen from his grave.");
                Boar r3 = new Boar();
                Boar r4 = new Boar("Dire Boar", 20, 35, 20, 20, 2, 8, "A boar transformed by it's incredible rage, truly a dangerous foe");
                KoboldLord r5 = new KoboldLord();
                //all of our child monsters are of type mosnster so we can store them in an array
                Monster[] monsters = { r1, r1, r2, r3, r3, r4, r5 };

                //randomly select a monster
                Random rand = new Random();
                int randNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randNbr];

                Console.WriteLine("\nIn this room you find " + monster.Name);

                #region Menu Loop
                //TODO 6 Create a loop for menu of options
                bool reload = false;

                do
                {
                    #region Menu Switch
                    //7. Create a menu of options
                    Console.WriteLine("\nPlease choose an action:\nA) Attack\nS) Sword Skill \nR) Run Away\nP) Player Info\nM) Monster Info\nH) Heal\nX) Exit\n");

                    //8. cathc the the choice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    //9. Clear the console
                    Console.Clear();

                    //10. Build switch for user choice
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //11 handlle attack sequence
                            if (agile == true)
                            {
                                Combat.DoAttack(player, monster);
                            }
                            Combat.DoBattle(player, monster);
                            //12 handle player win
                            if (monster.Life <= 0)
                            {
                                //monster is dead
                                //could put in item drop, xp, or life gain
                                playerLevel += 1;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nWith the {0} Slain, you make your way 1 floor closer to the end.\n", monster.Name);
                                Console.ResetColor();
                                player.Life = player.MaxLife;
                                usedSwordSkill = false;
                                usedHealing = false;
                                reload = true; //breaks us out of the inner loop but no the outer, will allow the player to continue on their journey
                                levelsBeat++;
                                if (levelsBeat >= 1)
                                {
                                    player.Life += 1;
                                    player.MaxLife += 1;
                                    player.Block += 1;
                                    player.HitChance += 1;
                                }
                            }
                            
                            break;
                        case ConsoleKey.S:
                            if (usedSwordSkill == true)
                            {
                                Console.WriteLine("You cannot use another sword skill during this combat.");
                            } else
                            {
                                Console.WriteLine("You unleash a sword skill to do more damage");
                                player.EquippedWeapon.MinDamage += 10;
                                player.EquippedWeapon.MaxDamage += 10;
                                player.EquippedWeapon.BonusHitChance += 15;
                                Combat.DoAttack(player, monster);
                                player.EquippedWeapon.MinDamage -= 10;
                                player.EquippedWeapon.MaxDamage -= 10;
                                player.EquippedWeapon.BonusHitChance -= 15;
                                usedSwordSkill = true;
                            }
                            if (monster.Life <= 0)
                            {
                                //monster is dead
                                //could put in item drop, xp, or life gain
                                playerLevel += 1;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nWith the {0} Slain, you make your way 1 floor closer to the end.\n", monster.Name);
                                Console.ResetColor();
                                player.Life = player.MaxLife;
                                usedSwordSkill = false;
                                usedHealing = false;
                                reload = true; //breaks us out of the inner loop but no the outer, will allow the player to continue on their journey
                                levelsBeat++;
                                if (levelsBeat >= 1)
                                {
                                    player.Life += 1;
                                    player.MaxLife += 1;
                                    player.Block += 1;
                                    player.HitChance += 1;
                                }
                            }
                            
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("So it seems your cowardly instincts have prevailed, how unfortunate.");
                            //todo handle the free attack
                            Console.WriteLine($"{monster.Name} attempts to attack as you run");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            usedSwordSkill = false;
                            usedHealing = false;
                            //14 exit inner loop and get a new room
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            // 15. print out player info
                            Console.WriteLine("Player info");
                            Console.WriteLine(playerName);
                            Console.WriteLine(player);
                            Console.WriteLine("You are level " + playerLevel);
                            Console.WriteLine("Floors Cleared: " + levelsBeat);
                            break;
                        case ConsoleKey.M:
                            //todo print out monster info
                            Console.WriteLine("monster info");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.H:
                            if (usedHealing == true)
                            {
                                Console.WriteLine("You cannot use another Healing Crystal during this combat.");
                            }
                            else
                            {
                                player.Life = player.MaxLife;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("You take out a Healing Crystal and use it");
                                Console.ResetColor();
                                usedHealing = true;
                            }
                            
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("After unequipping your weapon, you slowly end up rotting away in the Town of Beginnings");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("learn to type bruh");
                            break;
                    }
                    #endregion

                    //todo 17 check life before continuing
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("As your Health Bar is Depleted your body disappears and your vision goes black\a");
                        exit = true; //break out of both loops
                    }
                    if (levelsBeat == 100)
                    {
                        Console.WriteLine("As you defeat the final enemy a giant Game Cleared sign appears before you and you open your eyes to see the real world\a");
                        exit = true; //break out of both loops
                    }
                    if (levelsBeat == 20 && levelsBeat == 40 && levelsBeat == 60 && levelsBeat == 80)
                    {
                        r1.Life += 5;
                        r1.MaxLife += 5;
                        r1.Block += 5;
                        r1.HitChance += 5;
                        r1.MinDamage += 2;
                        r1.MaxDamage += 4;
                        r2.Life += 5;
                        r2.MaxLife += 5;
                        r2.Block += 5;
                        r2.HitChance += 5;
                        r2.MinDamage += 2;
                        r2.MaxDamage += 4;
                        r3.Life += 3;
                        r3.MaxLife += 3;
                        r3.Block += 7;
                        r3.HitChance += 3;
                        r3.MinDamage += 3;
                        r3.MaxDamage += 5;
                        r4.Life += 4;
                        r4.MaxLife += 4;
                        r4.Block += 8;
                        r4.HitChance += 4;
                        r4.MinDamage += 3;
                        r4.MaxDamage += 5;
                        r5.Life += 5;
                        r5.MaxLife += 5;
                        r5.Block += 10;
                        r5.HitChance += 5;
                        r5.MinDamage += 1;
                        r5.MaxDamage += 3;

                    }
                    if (levelsBeat == 25 && chosenWeapon == LongSword)
                    {
                        Console.WriteLine("On the 25th floor you find a Dark Steel Longsword and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 3;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 50 && chosenWeapon == LongSword)
                    {
                        Console.WriteLine("On the 50th floor you find a Holy Steel Longsword and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 4;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 75 && chosenWeapon == LongSword)
                    {
                        Console.WriteLine("On the 75th floor you find the Elucidator and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 4;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 25 && chosenWeapon == GreatSword)
                    {
                        Console.WriteLine("On the 25th floor you find a Dark Steel Greatsword and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 3;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 50 && chosenWeapon == GreatSword)
                    {
                        Console.WriteLine("On the 50th floor you find a Holy Steel Greatsword and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 4;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 75 && chosenWeapon == GreatSword)
                    {
                        Console.WriteLine("On the 75th floor you find the Doomblade and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 4;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 25 && chosenWeapon == Dagger)
                    {
                        Console.WriteLine("On the 25th floor you find a Dark Steel Dagger and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 3;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 50 && chosenWeapon == LongSword)
                    {
                        Console.WriteLine("On the 50th floor you find a Holy Steel Dagger and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 4;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 75 && chosenWeapon == LongSword)
                    {
                        Console.WriteLine("On the 75th floor you find the Assassin's Dirk and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 4;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 25 && chosenWeapon == MaceandShield)
                    {
                        Console.WriteLine("On the 25th floor you find a Dark Steel Mace and Shield and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 3;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 50 && chosenWeapon == MaceandShield)
                    {
                        Console.WriteLine("On the 50th floor you find a Holy Steel Mace and Shield and Equip it.\n");
                        player.EquippedWeapon.MinDamage += 4;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                    if (levelsBeat == 75 && chosenWeapon == MaceandShield)
                    {
                        Console.WriteLine("On the 75th floor you find the Demon's Cudgel and Shield and Equip them.\n");
                        player.EquippedWeapon.MinDamage += 4;
                        player.EquippedWeapon.MaxDamage += 4;
                        player.EquippedWeapon.BonusHitChance += 5;
                    }
                } while (!exit && !reload);
                #endregion
            } while (!exit); //while exit is false it will loop

            Console.WriteLine("You cleared " + levelsBeat + " floor" + (levelsBeat == 1 ? "." : "s."));
        }

        private static string GetRoom()
        {
            //collection intialization syntax
            string[] rooms =
            {
                "When you enter this floor's boss room you see that it is almost like the inside of a crystal palace, as soon as you take your first step to what looks like the throne the room lights up and the boss spawns.",
                "This floor's room seems to be overgrown with harsh vines and several smaller trees. As you make it towards the center, out of the ground, the boss appears."
            };

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;
            //return rooms[new Random().Next(rooms.Length)];
        }



    }
}



    