﻿using System;
using System.Threading;

namespace MonsterHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the room and its X Y coords, the player and the monster
            Room[] rooms = new Room[] {
                new Room(0,0), new Room(1,0), new Room(2,0), new Room(3,0),
                new Room(0,1), new Room(1,1), new Room(2,1), new Room(3,1),
                new Room(0,2), new Room(1,2), new Room(2,2), new Room(3,2),
                new Room(0,3), new Room(1,3), new Room(2,3), new Room(3,3)
            };
            Player player = new Player(0, 0);
            Monster monster = new Monster(3, 3);

            //play intro and draw starting map
            Intro();
            DrawMap(rooms, player, monster);

            //gameloop
            bool end = false;
            bool newGame = false;
            while (newGame == false)
            {
                while (end == false)
                {
                    player.move(rooms);
                    DrawMap(rooms, player, monster);
                    Thread.Sleep(750);
                    Monster.Move(rooms, player);
                    DrawMap(rooms, player, monster);

                    if (player.X == 3 && player.Y == 3)
                    {
                        end = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You escaped the home into the cold, damp night. You live to see another morning!");
                    }
                    else if (Monster.X == player.X && Monster.Y == player.Y)
                    {
                        end = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You were eaten!");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nWould you like to try another night? Y/N");
                string input = Console.ReadLine();
                if (string.Compare(input, "y", true) == 0)
                {
                    end = false;
                    player.X = 0;
                    player.Y = 0;
                    Monster.X = 3;
                    Monster.Y = 3;
                    DrawMap(rooms, player, monster);
                }
                else if (string.Compare(input, "n", true) == 0)
                {
                    newGame = true;
                }
                else
                {
                    Console.WriteLine("please enter a valid entry. \"y\" or \"n\"");
                }
            }
        }

        public static void DrawMap(Room[] rooms, Player player, Monster monster) //draws the map on the console - shows location of monster and player. 
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         |         |         |         |");
            Console.Write("|  "); rooms[0].Draw(player, monster, 1); Console.Write(" |  "); rooms[1].Draw(player, monster, 1); Console.Write("  | "); rooms[2].Draw(player, monster, 1); Console.Write("  | "); rooms[3].Draw(player, monster, 1); Console.Write(" |\n");
            Console.Write("| "); rooms[0].Draw(player, monster, 2); Console.Write(" | "); rooms[1].Draw(player, monster, 2); Console.Write(" |         "); Console.Write("|   "); rooms[3].Draw(player, monster, 2); Console.Write("  |\n");
            Console.WriteLine("|         |         |         |         |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         |         |         |         |");
            Console.Write("| "); rooms[4].Draw(player, monster, 1); Console.Write(" | "); rooms[5].Draw(player, monster, 1); Console.Write(" | "); rooms[6].Draw(player, monster, 1); Console.Write(" | "); rooms[7].Draw(player, monster, 1); Console.Write(" |\n");
            Console.WriteLine("|         |         |         |         |");
            Console.WriteLine("|         |         |         |         |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         |         |         |         |");
            Console.Write("|  "); rooms[8].Draw(player, monster, 1); Console.Write(" |  "); rooms[9].Draw(player, monster, 1); Console.Write("   | "); rooms[10].Draw(player, monster, 1); Console.Write(" |  "); rooms[11].Draw(player, monster, 1); Console.Write(" |\n");
            Console.Write("|         |         |         |   "); rooms[11].Draw(player, monster, 2); Console.Write("  |\n");
            Console.WriteLine("|         |         |         |         |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         |         |         |         |");
            Console.Write("|   "); rooms[12].Draw(player, monster, 1); Console.Write("   |  "); rooms[13].Draw(player, monster, 1); Console.Write(" | "); rooms[14].Draw(player, monster, 1); Console.Write(" |  "); rooms[15].Draw(player, monster, 1); Console.Write("  |\n");
            Console.Write("|         |   "); rooms[13].Draw(player, monster, 2); Console.Write("  |         |         |\n");
            Console.WriteLine("|         |         |         |         |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("\n\nYou are in the {0}.", player.Location);
            Console.WriteLine("The monster is in the {0}.", Monster.Location);
            Console.WriteLine("Which direction do you run?");



        }

        public static void Intro() // displays introduction as well as instructions on how to play.
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You're sound asleep in your bed.");
            Thread.Sleep(2000);
            Console.Write("You hear a"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(" blood-curdling scream "); Console.ForegroundColor = ConsoleColor.White; Console.Write("outside of your home.\n");
            Thread.Sleep(3000);
            Console.Write("You quickly check your security cameras and see "); Console.ForegroundColor = ConsoleColor.Red; Console.Write("A terrifying, bone-chilling monster "); Console.ForegroundColor = ConsoleColor.White;
            Console.Write("approaching your home.\n");
            Thread.Sleep(3000);
            Console.WriteLine("CRASH!"); Thread.Sleep(2000); Console.WriteLine("You hear the sound of your front door break.");
            Thread.Sleep(3000); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("IT IS IN YOUR HOUSE."); Console.ForegroundColor = ConsoleColor.White; Thread.Sleep(2000); Console.WriteLine("Get to the Foyer, NOW!");
            Thread.Sleep(3000);
            Console.WriteLine("\n\nHOW TO PLAY:");
            Console.WriteLine("Type \"up\", \"down\", \"left\", or \"right\" to move in that direction.\nEvery time you move one room the monster also moves one room.");
            Console.WriteLine("Get to the Foyer to escape the house and win the game!\nDon't let the monster enter into the same room as you or you'll be eaten and lose!");
            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
            Console.ReadKey();

        }
    }
}
