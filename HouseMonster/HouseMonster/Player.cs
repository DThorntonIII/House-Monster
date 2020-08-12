﻿using System;

namespace MonsterHouse
{
    class Player
    {
        public int X;
        public int Y;
        public string Location;

        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Location = "Master Bedroom";
        }

        //takes UI to know which direction to move. Checks for valid entry and valid possible location. 
        public void move(Room[] rooms)
        {
            bool Answered = false;
            while (Answered == false)
            {
                string input = Console.ReadLine();
                if (string.Compare(input, "up", true) == 0)
                {
                    if (Y > 0)
                    {
                        Y--;
                        Answered = true;
                    }
                    else
                    {
                        Console.WriteLine("There is a wall there and you cannot go that direction");
                    }
                }
                else if (string.Compare(input, "down", true) == 0)
                {
                    if (Y < 3)
                    {
                        Y++;
                        Answered = true;
                    }
                    else
                    {
                        Console.WriteLine("There is a wall there and you cannot go that direction");
                    }
                }
                else if (string.Compare(input, "left", true) == 0)
                {
                    if (X > 0)
                    {
                        X--;
                        Answered = true;
                    }
                    else
                    {
                        Console.WriteLine("There is a wall there and you cannot go that direction");
                    }
                }
                else if (string.Compare(input, "right", true) == 0)
                {
                    if (X < 3)
                    {
                        X++;
                        Answered = true;
                    }
                    else
                    {
                        Console.WriteLine("There is a wall there and you cannot go that direction");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid entry. \"left\" \"up\" \"right\" \"down\"");
                }

                //sets location field to match what room it currently is in.
                foreach (Room room in rooms)
                {
                    if (room.X == X && room.Y == Y)
                    {
                        Location = room.RoomName1;
                        Location.Insert(room.RoomName1.Length, room.RoomName2);
                    }
                }
            }
        }
    }
}