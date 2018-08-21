using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;

namespace Pong
{
    /// <summary>
    /// Provides states and behaviours for the paddle objects
    /// </summary>
    public class Paddle
    {
        private const int MENU_HEIGHT = 24;
        private const int MAXSPEED = 4;
        private Brush brush;
        private Size clientSize;
        private Point paddlePosition;
        private Size paddleSize;
        private SoundPlayer collisionSound;

        /// <summary>
        /// Initialises paddle of a given size, position and colour. 
        /// </summary>
        /// <param name="paddleSize">the dimensions of the paddle</param>
        /// <param name="paddlePosition">the position of the paddle in the game</param>
        /// <param name="colour">the colour of the paddle</param>
        /// <param name="clientSize">the bounds of the world the paddle exists within</param>
        /// <param name="soundFileName">associates a sound with the paddle</param>
        public Paddle(Size paddleSize, Point paddlePosition, Color colour, Size clientSize, string soundFileName)
        {
            this.clientSize = clientSize;
            brush = new SolidBrush(colour);
            this.paddleSize = paddleSize;
            this.paddlePosition = paddlePosition;
            collisionSound = new SoundPlayer(soundFileName);
            collisionSound.Load();
        }

        /// <summary>
        /// Draws the paddle on the form
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, paddlePosition.X, paddlePosition.Y, paddleSize.Width, paddleSize.Height);
        }

        /// <summary>
        /// Increments paddles position in the direction of a given position
        /// </summary>
        /// <param name="ballPosition">position to move towards</param>
        public void MoveTowardsPosition(Point ballPosition)
        {
            Point temp = (paddlePosition);

            if (paddlePosition.Y < ballPosition.Y)
            {
                temp.Y += MAXSPEED;
            }
            if (paddlePosition.Y > ballPosition.Y)
            {
                temp.Y -= MAXSPEED;
            }

            if ((temp.Y >= (clientSize.Height - paddleSize.Height)) || (temp.Y <= (0 + MENU_HEIGHT)))
            {
                if (temp.Y >= (clientSize.Height - paddleSize.Height))
                {
                    paddlePosition.Y = (clientSize.Height - paddleSize.Height);
                }
                else
                {
                    paddlePosition.Y = (0 + MENU_HEIGHT);
                }
            }
            else
            {
                paddlePosition = temp;
            }

        }

        /// <summary>
        /// Centres the paddle on the given position
        /// </summary>
        /// <param name="mousePosition">position to centre on</param>
        public void CentreOnPosition(Point mousePosition)
        {
            Point temp = new Point(paddlePosition.X, mousePosition.Y - (paddleSize.Height / 2));


            if ((temp.Y >= (clientSize.Height - paddleSize.Height)) || (temp.Y <= (0 + MENU_HEIGHT)))
            {
                if (temp.Y >= (clientSize.Height - paddleSize.Height))
                {
                    paddlePosition.Y = (clientSize.Height - paddleSize.Height);
                }
                else
                {
                    paddlePosition.Y = (0 + MENU_HEIGHT);
                }
            }
            else
            {
                paddlePosition = temp;
            }

        }

        /// <summary>
        /// gets or sets the size of the paddle
        /// </summary>
        public Size PaddleSize
        {
            get { return paddleSize; }
            set { paddleSize = value; }
        }

        /// <summary>
        /// gets or sets the position of the paddle
        /// </summary>
        public Point PaddlePosition
        {
            get { return paddlePosition; }
            set { paddlePosition = value; }
        }

        /// <summary>
        /// gets or sets the sound file associated with the paddle
        /// </summary>
        public SoundPlayer CollisionSound
        {
            get { return collisionSound; }
            set { collisionSound = value; }
        }
    }
}
