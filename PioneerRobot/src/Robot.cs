using System;

namespace PioneerRobot
{
    public class Robot
    {
        private readonly Tabletop _tabletop;

        public Robot(Tabletop tabletop)
        {
            _tabletop = tabletop;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Direction { get; set; } = "";

        /**
         * Move - Move the robot by one unit, if possible.
         * TODO: Store (and display) a trail.
        **/
        public bool Move()
        {
            var movement = Tabletop.Movement[Tabletop.GetDirectionIndex(Direction)];
            var newX = X + movement.Item1;
            var newY = Y + movement.Item2;
            if (!_tabletop.IsOnTable(newX, newY)) return false;
            X = newX;
            Y = newY;
            return true;
        }

        /**
         * Left - Change direction one step to the left
         */
        public void Left()
        {
            Direction = Tabletop.Directions[(Tabletop.GetDirectionIndex(Direction) + Tabletop.Directions.Count - 1) % Tabletop.Directions.Count];
        }

        /**
         * Right - Change direction one step to the right
         */
        public void Right()
        {
            Direction = Tabletop.Directions[(Tabletop.GetDirectionIndex(Direction) + Tabletop.Directions.Count + 1) % Tabletop.Directions.Count];
        }

        /**
         * Report - Simply return the coord and direction of the robot.
         */
        public (string?, int?, int?) Report()
        {
            return (Direction, X, Y);
        }
    }
}