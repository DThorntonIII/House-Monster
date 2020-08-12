﻿using System;

namespace MonsterHouse
{
    class Monster
    {
        public static int X { get; set; }
        public static int Y { get; set; }
        public static string Location;
        private static Random random = new Random();

        public Monster(int x, int y)
        {
            X = x;
            Y = y;
            Location = "Foyer";
        }

        //rolls random. on 1-201 monster moves towards players coords. --- on 202-400 moves in a random direction. 
        public static void Move(Room[] rooms, Player player)
        {
            int rand = random.Next(1, 400);
            if (rand < 201)
            {
                if (player.X < X && player.Y < Y)
                {
                    if (player.X - X > player.Y - Y)
                    {
                        X--;
                    }
                    else
                    {
                        Y--;
                    }
                }
                if (player.X > X && player.Y < Y)
                {
                    if (player.X - X > player.Y - Y)
                    {
                        X++;
                    }
                    else
                    {
                        Y--;
                    }
                }
                else if (player.X > X && player.Y > Y)
                {
                    if (player.X - X > player.Y - Y)
                    {
                        X++;
                    }
                    else
                    {
                        Y++;
                    }
                }
                else if (player.X < X && player.Y > Y)
                {
                    if (player.X - X > player.Y - Y)
                    {
                        X--;
                    }
                    else
                    {
                        Y++;
                    }
                }
                else if (player.X == X && player.Y > Y)
                {
                    Y++;
                }
                else if (player.X == X && player.Y < Y)
                {
                    Y--;
                }
                else if (player.Y == Y && player.X > X)
                {
                    X++;
                }
                else if (player.Y == Y && player.X < X)
                {
                    X--;
                }
            }
            else
            {
                if (rand > 201 && rand < 250)
                {
                    if (X >= 0 && X < 3)
                    {
                        X++;
                    }
                    else
                    {
                        X--;
                    }
                }
                else if (rand > 251 && rand < 300)
                {
                    if (Y >= 0 && Y < 3)
                    {
                        Y++;
                    }
                    else
                    {
                        Y--;
                    }
                }
                else if (rand > 301 && rand < 350)
                {
                    if (X <= 3 && X > 0)
                    {
                        X--;
                    }
                    else
                    {
                        X++;
                    }
                }
                else if (rand > 351 && rand < 400)
                {
                    if (Y <= 3 && Y > 0)
                    {
                        Y--;
                    }
                    else
                    {
                        Y++;
                    }
                }
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