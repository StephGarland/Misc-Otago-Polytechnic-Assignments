using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PacMan
{
    /// <summary>
    /// The parent class of all creatures in the game
    /// </summary>
    /// 
    public abstract class Creature
    {
        protected const int BASE_SPEED = 6;
        protected const int IMAGE_SIZE = 30;

        protected Point location;
        protected Direction direction;

        //an integer used to toggle through a creature's image-frames
        protected int imageToggle;
        protected int speed;

        public Creature(int startLocationX, int startLocationY)
        {
            speed = BASE_SPEED;
            imageToggle = 0;
            location = new Point(startLocationX, startLocationY);
            direction = Direction.Up;
        }

        public abstract void Draw(Graphics graphics);
        //public abstract void Move(Graphics graphics);

    }
}
