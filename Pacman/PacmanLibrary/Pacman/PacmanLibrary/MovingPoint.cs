using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanLibrary
{
    public class MovingPoint : GraphicPoint
    {
        public int MovementSpeed { get; protected set; }
        public int DirectionX { get; protected set; }
        public int DirectionY { get; protected set; }

        public MovingPoint(int x, int y, int movementSpeed) : base(x, y)
        {
            MovementSpeed = movementSpeed;
        }

        public void Move()
        {
            if (X == 448)
            {
                X = -10;
            }
            else if (X == -16)
            {
                X = 446;
            }
            else
            {
                X += MovementSpeed * DirectionX;
                Y += MovementSpeed * DirectionY;
            }
        }

        public void ChangeDirection(int directionX, int directionY)
        {
            DirectionX = directionX;
            DirectionY = directionY;
        }

        public bool CheckCollision(int targetX1, int targetY1, int deltaX, int deltaY)
        {
            int targetX2 = targetX1 + 16;
            int targetY2 = targetY1 + 16;

            int futureX2 = X + 16 + MovementSpeed * deltaX;
            int futureY2 = Y + 16 + MovementSpeed * deltaY;

            int futureX1 = X + MovementSpeed * deltaX;
            int futureY1 = Y + MovementSpeed * deltaY;

            if (((futureX2 > targetX1) && (futureY2 > targetY1)) && ((futureX2 < targetX2) && (futureY2 <= targetY2)) ||
                ((futureX2 > targetX1) && (futureY1 > targetY1)) && ((futureX2 <= targetX2) && (futureY1 < targetY2)) ||
                ((futureX1 > targetX1) && (futureY1 >= targetY1)) && ((futureX1 < targetX2) && (futureY1 < targetY2)) ||
                ((futureX1 >= targetX1) && (futureY2 > targetY1)) && ((futureX1 < targetX2) && (futureY2 < targetY2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckCollision(int targetX1, int targetY1, int size)
        {
            int targetX2 = targetX1 + size;
            int targetY2 = targetY1 + size;

            int futureX2 = X + size + MovementSpeed * DirectionX;
            int futureY2 = Y + size + MovementSpeed * DirectionY;

            int futureX1 = X + MovementSpeed * DirectionX;
            int futureY1 = Y + MovementSpeed * DirectionY;

            if (((futureX2 > targetX1) && (futureY2 > targetY1)) && ((futureX2 < targetX2) && (futureY2 <= targetY2)) ||
                ((futureX2 > targetX1) && (futureY1 > targetY1)) && ((futureX2 <= targetX2) && (futureY1 < targetY2)) ||
                ((futureX1 > targetX1) && (futureY1 >= targetY1)) && ((futureX1 < targetX2) && (futureY1 < targetY2)) ||
                ((futureX1 >= targetX1) && (futureY2 > targetY1)) && ((futureX1 < targetX2) && (futureY2 < targetY2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
