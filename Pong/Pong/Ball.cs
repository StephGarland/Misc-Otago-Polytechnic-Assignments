using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pong
{
    /// <summary>
    /// Provides states and behaviours for the ball
    /// </summary>
    public class Ball
    {
        private const int MENU_HEIGHT = 24;
        private const int VELOCITY_X = 5;
        private const int VELOCITY_Y = 5;

        private Size clientSize;
        private int ballSize;
        private Brush brush;

        private Point velocity;
        private Point ballPosition;

        private bool collisionLeft;
        private bool collisionRight;

        /// <summary>
        /// Initialises ball of given size and colour, at given start position
        /// </summary>
        /// <param name="ballSize">the dimensions of the ball</param>
        /// <param name="colour">the colour of the ball</param>
        /// <param name="clientSize">the bounds of the world the ball exists within</param>
        /// <param name="ballStartPosition">the starting position of the ball</param>
        public Ball(int ballSize, Color colour, Size clientSize, Point ballStartPosition)
        {
            this.ballSize = ballSize;
            this.clientSize = clientSize;
            velocity = new Point(VELOCITY_X, VELOCITY_Y);
            ballPosition = ballStartPosition;
            brush = new SolidBrush(colour);
        }

        /// <summary>
        /// Moves the ball horizontally
        /// </summary>
        public void MoveX()
        {
            ballPosition.X += velocity.X;
        }

        /// <summary>
        /// Moves the ball vertically
        /// </summary>
        public void MoveY()
        {
            ballPosition.Y += velocity.Y;
        }

        /// <summary>
        /// Draws the ball on the form
        /// </summary>
        /// <param name="graphics"></param>
        public void DrawSelf(Graphics graphics)
        {
            graphics.FillEllipse(brush, ballPosition.X, ballPosition.Y, ballSize, ballSize);
        }


        /// <summary>
        /// Reverses ball velocity on collision with the top or bottom bounds of the form
        /// </summary>
        public void EdgeCollision()
        {
            if ((ballPosition.Y >= clientSize.Height - ballSize) || (ballPosition.Y <= MENU_HEIGHT))
            {
                velocity.Y *= -1;
            }

            if (ballPosition.X <= 0)
            {
                collisionLeft = true;
            }
            if (ballPosition.X >= (clientSize.Width))
            {
                collisionRight = true;
            }
        }

        /// <summary>
        /// Reverses ball horizontal velocity on collision with a paddle
        /// </summary>
        /// <param name="paddle">paddle to check for a collision with</param>
        public void PaddleCollisionX(Paddle paddle)
        {            
            Rectangle ballBounds = new Rectangle(ballPosition.X, ballPosition.Y, ballSize, ballSize);
            Rectangle paddleBounds = new Rectangle(paddle.PaddlePosition, paddle.PaddleSize);

            if (ballBounds.IntersectsWith(paddleBounds))
            {
                if (velocity.X > 0)
                {
                    ballPosition.X -= (ballBounds.Right - paddleBounds.Left);
                }
                else
                {
                    ballPosition.X -= (ballBounds.Left - paddleBounds.Right);
                }
                velocity.X *= -1;
                paddle.CollisionSound.Play();
            }
        }

        /// <summary>
        /// Reverses ball vertical velocity on collision with a paddle
        /// </summary>
        /// <param name="paddle">paddle to check for a collision with</param>
        public void PaddleCollisionY(Paddle paddle)
        {
            Rectangle ballBounds = new Rectangle(ballPosition.X, ballPosition.Y, ballSize, ballSize);
            Rectangle paddleBounds = new Rectangle(paddle.PaddlePosition, paddle.PaddleSize);

            if (ballBounds.IntersectsWith(paddleBounds))
            {
                if (velocity.Y > 0)
                {
                    ballPosition.Y -= (ballBounds.Bottom - paddleBounds.Top);
                }
                else
                {
                    ballPosition.Y -= (ballBounds.Top - paddleBounds.Bottom);
                }

                velocity.Y *= -1;
                paddle.CollisionSound.Play();
            }
        }

        /// <summary>
        /// Allows the user to modify the colour of the ball
        /// </summary>
        /// <param name="colour">the colour the ball changes to</param>
        public void ChangeColor(string colour)
        {
            Color colourToChangeTo = Color.FromName(colour);
            brush = new SolidBrush(colourToChangeTo);
        }


        /// <summary>
        /// gets or sets toggle for whether a collision on the left has been made 
        /// </summary>
        public bool CollisionLeft
        {
            get { return collisionLeft; }
            set { collisionLeft = value; }
        }

        /// <summary>
        /// gets or sets toggle for whether a collision on the right has been made 
        /// </summary>
        public bool CollisionRight
        {
            get { return collisionRight; }
            set { collisionRight = value; }
        }

        /// <summary>
        /// gets or sets position of the ball 
        /// </summary>
        public Point BallPosition
        {
            get { return ballPosition; }
            set { ballPosition = value; }
        }
    }
}
