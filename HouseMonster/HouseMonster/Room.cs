﻿using System;

namespace MonsterHouse
{
    class Room
    {
        public int X;
        public int Y;
        public string RoomName1;
        public string RoomName2;

        // gives names to room coords.
        public Room(int x, int y)
        {
            X = x;
            Y = y;
            if (X == 0 && Y == 0)
            {
                RoomName1 = "Master";
                RoomName2 = "Bedroom";
            }
            else if (X == 1 && Y == 0)
            {
                RoomName1 = "Guest";
                RoomName2 = "Bedroom";
            }
            else if (X == 2 && Y == 0)
            {
                RoomName1 = "Closet";
                RoomName2 = " ";
            }
            if (X == 3 && Y == 0)
            {
                RoomName1 = "Laundry";
                RoomName2 = "Room";
            }
            else if (X == 0 && Y == 1)
            {
                RoomName1 = "Hallway";
                RoomName2 = " ";
            }
            else if (X == 1 && Y == 1)
            {
                RoomName1 = "Hallway";
                RoomName2 = " ";
            }
            else if (X == 2 && Y == 1)
            {
                RoomName1 = "Hallway";
                RoomName2 = " ";
            }
            else if (X == 3 && Y == 1)
            {
                RoomName1 = "Kitchen";
                RoomName2 = " ";
            }
            else if (X == 0 && Y == 2)
            {
                RoomName1 = "Office";
                RoomName2 = " ";
            }
            else if (X == 1 && Y == 2)
            {
                RoomName1 = "Bath";
                RoomName2 = " ";
            }
            else if (X == 2 && Y == 2)
            {
                RoomName1 = "Hallway";
                RoomName2 = " ";
            }
            else if (X == 3 && Y == 2)
            {
                RoomName1 = "Dining";
                RoomName2 = "Room";
            }
            else if (X == 0 && Y == 3)
            {
                RoomName1 = "Den";
                RoomName2 = " ";
            }
            else if (X == 1 && Y == 3)
            {
                RoomName1 = "Living";
                RoomName2 = "Room";
            }
            else if (X == 2 && Y == 3)
            {
                RoomName1 = "Hallway";
                RoomName2 = " ";
            }
            else if (X == 3 && Y == 3)
            {
                RoomName1 = "Foyer";
                RoomName2 = " ";
            }
        }

        // turns the room name green if player is at the coords, red if monster is at the coords, white otherwise
        public void Draw(Player player, Monster monster, int i)
        {
            if (player.X == X && player.Y == Y)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (i == 1)
                {
                    Console.Write(RoomName1);
                }
                else if (i == 2)
                {
                    Console.Write(RoomName2);
                }
                Console.ForegroundColor = ConsoleColor.White;


            }
            else if (Monster.X == X && Monster.Y == Y)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (i == 1)
                {
                    Console.Write(RoomName1);
                }
                else if (i == 2)
                {
                    Console.Write(RoomName2);
                }
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i == 1)
                {
                    Console.Write(RoomName1);
                }
                else if (i == 2)
                {
                    Console.Write(RoomName2);
                }
            }
        }
    }
}