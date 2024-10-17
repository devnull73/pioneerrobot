using System;
using System.Collections.Generic;

namespace PioneerRobot
{
    public class Tabletop
    {
        public static readonly List<string> Directions = new(){ "NORTH", "EAST", "SOUTH", "WEST" };
        
        // X/Y movement amount for Directions.
        public static readonly Tuple<int,int>[] Movement = {
            new(0, 1),
            new(1, 0),
            new(0, -1),
            new(-1, 0)
        };

        private readonly int _xSize = 0, _ySize = 0;
        
        private static readonly char[] Sprites =
        {
            '^','>','v','<'
        };
        
        // Constructor
        public Tabletop(int xSize, int ySize)
        {
            _xSize = xSize;
            _ySize = ySize;
        }

        public Tabletop() : this(5, 5)
        {
        }

        /**
         * GetDirectionIndex - return the index of the provided string in the Directions array
         */
        public static int GetDirectionIndex(string direction)
        {
            return Directions.IndexOf(direction);
        }

        /**
         * IsOnTable - is the provided coord on the table?
         */
        public bool IsOnTable(int x, int y)
        {
            return x >= 0 & y >= 0 & x < _xSize & y < _ySize;
        }

        
        /**
         * Display - just a cheap way to show location in text
         */
        public void Display(Robot robot)
        {
            Console.WriteLine("+{0}+", new string('-', _xSize));
            for (var y = 0; y < _ySize; y++)
            {
                if (robot.Y == y)
                {
                    Console.WriteLine("|{0}{1}{2}|", new string('-', robot.X), Sprites[GetDirectionIndex(robot.Direction)], new string('-', _xSize - robot.X - 1)); 
                }
                else
                {
                    Console.WriteLine("|{0}|", new string('-', _xSize));    
                }
            }
            Console.WriteLine("+{0}+", new string('-', _xSize));
        }
    }
}