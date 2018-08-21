using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Pong
{
    /// <summary>
    /// Creates the score, paddles and ball, and holds a Run method that details in what order different parts of the game run.
    /// </summary>
    public class GameEngine
    {
        private const int PADDLE_WIDTH = 10;
        private const int PADDLE_HEIGHT = 50;
        private const int PADDLE_X = 10;
        private const int PADDLE_Y = 30;
        private const int BALL_SIZE = 20;
        private const int PENWIDTH = 3;
        private const int FONT_SIZE = 60;
        private const int POSITION_Y_DIVISOR = 8;
        private const int VICTORY_TEXT_OFFSET = 330;
        private const double POSITION_1ST_QUARTER = 0.25;
        private const double POSITION_3RD_QUARTER = 0.75;
        
        private Score scoreLeft;
        private Score scoreRight;
        private Paddle leftPaddle;
        private Paddle rightPaddle;
        private Ball ball;
        private Point ballStartPosition;
        private bool winConditions;
        private Size clientSize;
        private Pen dashedLinePen;
        private Point topCentre;
        private Point bottomCentre;

        /// <summary>
        /// Initialises Game Engine with given dimensions of game-world
        /// </summary>
        /// <param name="clientSize">dimensions of game-world</param>
        public GameEngine(Size clientSize)
        {
            this.clientSize = clientSize;
            ballStartPosition = new Point(clientSize.Width / 2, clientSize.Height / 2);
            ball = new Ball(BALL_SIZE, Color.Orange, clientSize, ballStartPosition);
            
            Size paddleSize = new Size(PADDLE_WIDTH, PADDLE_HEIGHT);

            Point paddlePosition = new Point(PADDLE_X, PADDLE_Y);
            leftPaddle = new Paddle(paddleSize, paddlePosition, Color.Red, clientSize, "femaleGrunt.wav");

            paddlePosition = new Point((clientSize.Width - PADDLE_WIDTH) - PADDLE_X, PADDLE_Y);
            rightPaddle = new Paddle(paddleSize, paddlePosition, Color.Red, clientSize, "maleGrunt.wav");

            topCentre = new Point((clientSize.Width / 2), 0);
            bottomCentre = new Point((clientSize.Width / 2), clientSize.Height);
            dashedLinePen = new Pen(Color.White, PENWIDTH);
            dashedLinePen.DashStyle = DashStyle.Dash;
            
            winConditions = false;

            int x = Convert.ToInt32((clientSize.Width * POSITION_1ST_QUARTER) - FONT_SIZE);
            Point position = new Point(x, (clientSize.Height / POSITION_Y_DIVISOR)); 
            scoreLeft = new Score(position);

            x = Convert.ToInt32((clientSize.Width * POSITION_3RD_QUARTER) - FONT_SIZE);
            position = new Point (x, (clientSize.Height / POSITION_Y_DIVISOR));
            scoreRight = new Score(position);
        }

        /// <summary>
        /// Details in what order different parts of the game run
        /// </summary>
        public void Run()
        {
            CheckScoreConditions();
            ball.MoveX();
            ball.PaddleCollisionX(leftPaddle);
            ball.PaddleCollisionX(rightPaddle);
            ball.MoveY();
            ball.PaddleCollisionY(leftPaddle);
            ball.PaddleCollisionY(rightPaddle);
            ball.EdgeCollision();
            leftPaddle.MoveTowardsPosition(ball.BallPosition);
        }

        /// <summary>
        /// Draws game objects
        /// </summary>
        /// <param name="graphics">The canvas to draw to</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(dashedLinePen, topCentre, bottomCentre);
            scoreRight.DrawScore(graphics);
            scoreLeft.DrawScore(graphics);
            rightPaddle.Draw(graphics);
            leftPaddle.Draw(graphics);
            ball.DrawSelf(graphics);

            if (winConditions == true)
            {
                DisplayVictory(graphics);
            }            
        }

        /// <summary>
        /// method for accepting user input
        /// </summary>
        /// <param name="mousePosition">position of mouse pointer on form</param>
        public void userInput(Point mousePosition)
        {
            rightPaddle.CentreOnPosition(mousePosition);
        }

        /// <summary>
        /// Draws gameover feedback
        /// </summary>
        /// <param name="graphics">The canvas to draw to</param>
        public void DisplayVictory(Graphics graphics)
        {
            int x = Convert.ToInt32((clientSize.Width / 2) - VICTORY_TEXT_OFFSET);
            Point winDeclarationPosition = new Point(x,(clientSize.Height / 2));
            if (scoreLeft.WinConditions == true)
            {
                graphics.DrawString("Player1 Loses!", scoreLeft.ScoreFont, Brushes.White, winDeclarationPosition);
            }
            if (scoreRight.WinConditions == true)
            {
                graphics.DrawString("Player1 Wins!", scoreRight.ScoreFont, Brushes.White, winDeclarationPosition);
            }
        }

        /// <summary>
        /// checks if a player has scored, if so, resets ball's position
        /// </summary>
        public void CheckScoreConditions()
        {
            if (ball.CollisionLeft == true)
            {
                scoreRight.UpdateScore();
                ball.BallPosition = ballStartPosition;
                ball.CollisionLeft = false;
                winConditions = scoreRight.WinConditions;
            }
            else if (ball.CollisionRight == true)
            {
                scoreLeft.UpdateScore();
                ball.BallPosition = ballStartPosition;
                ball.CollisionRight = false;
                winConditions = scoreLeft.WinConditions;
            }
        }

        /// <summary>
        /// Prompts the ball to change colour
        /// </summary>
        /// <param name="colour">the new colour</param>
        public void ChangeColourBall(string colour)
        {
            ball.ChangeColor(colour);
        }


        /// <summary>
        /// gets and sets toggle for whether game has been won or not
        /// </summary>
        public bool WinConditions
        {
            get { return winConditions; }
            set { winConditions = value; }
        }
    }
}
