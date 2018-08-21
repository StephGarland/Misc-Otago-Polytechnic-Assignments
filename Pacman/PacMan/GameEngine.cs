using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PacMan
{
    /// <summary>
    /// Manages the game: Creates grid, pacman and ghost objects, sets order of game mechanics.
    /// </summary>
    public class GameEngine
    {
        //In the classic game, a kibble is worth 10 points. Multiplies the score by 10.
        private const int SCORE_MODIFIER = 10;

        private Grid dataGrid;
        private PacMan pacman;
        private Ghost[] ghost;
        private Random rand;
        private int score;
        private bool gameOver;

        public GameEngine(Grid dataGrid, Random rand, int tickInterval)
        {            
            this.dataGrid = dataGrid;
            this.rand = rand;

            dataGrid.Paint += new PaintEventHandler(dataGrid_Paint);
            pacman = new PacMan();
            ghost = new Ghost[4];
            ghost[0] = new Ghost("Purple");
            ghost[1] = new Ghost("Red");
            ghost[2] = new Ghost("Blue");
            ghost[3] = new Ghost("Green");
            gameOver = false;
        }

        /// <summary>
        /// Prompts creatures to be painted on grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGrid_Paint(object sender, PaintEventArgs e)
        {
            pacman.Draw(e.Graphics);
            for (int i = 0; i < ghost.Length; i++)
            {
                ghost[i].Draw(e.Graphics);
            }
        }

        /// <summary>
        /// Checks to see if the game is over
        /// </summary>
        public void checkGameOverConditions()
        {
            if ((pacman.Alive == false) || (dataGrid.KibblesRemaining == 0))
            {               
                gameOver = true;
            }
        }

        /// <summary>
        /// Sets the main order of the game.
        /// </summary>
        public void RunGame()
        {
            MoveCreatures();
            Draw();
            checkGameOverConditions();
        }

        /// <summary>
        /// Prompts Creatures to move.
        /// </summary>
        public void MoveCreatures()
        {
            pacman.Move(dataGrid);
            if (pacman.Eat(dataGrid))
            {
                foreach (Ghost individualGhost in ghost)
                {
                    individualGhost.BehaviourType = GhostMode.Frightened;
                }  
            }      

            for (int i = 0; i < ghost.Length; i++)
            {
                pacman.CheckGhostCollision(ghost[i]);
                ghost[i].Move(rand, dataGrid);
                ghost[i].UpdateMode();
                pacman.CheckGhostCollision(ghost[i]);
            }
        }

        /// <summary>
        /// Prompts everything on the grid to be redrawn
        /// </summary>
        public void Draw()
        {
            dataGrid.Invalidate();
        }

        /// <summary>
        /// Decides what direction the user is attempting to turn to
        /// </summary>
        /// <param name="userKeyStroke"></param>
        public void GetUserDirection(Keys userKeyStroke)
        {
            switch (userKeyStroke)
            {
                case Keys.Up:
                    pacman.AttemptedDirection = Direction.Up;
                    break;
                case Keys.Left:
                    pacman.AttemptedDirection = Direction.Left;
                    break;
                case Keys.Down:
                    pacman.AttemptedDirection = Direction.Down;
                    break;
                case Keys.Right:
                    pacman.AttemptedDirection = Direction.Right;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Calculates the player's score
        /// </summary>
        /// <returns></returns>
        public int CalculateScore()
        {
            return score = ((dataGrid.NStartKibbles - dataGrid.KibblesRemaining) * SCORE_MODIFIER);
        }

        /// <summary>
        /// Gets/Sets whether or not the game is over
        /// </summary>
        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

        /// <summary>
        /// Gets/Sets the Score
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        /// <summary>
        /// Gets/Sets the current number of lives the user has.
        /// </summary>
        public int N_Lives
        {
            get { return pacman.Lives; }
        }
    }
}
