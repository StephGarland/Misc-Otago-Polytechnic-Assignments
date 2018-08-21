using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pong
{
    /// <summary>
    /// Contains score information for a player, and information for drawing that score to a canvas
    /// </summary>
    public class Score
    {
        private const int POINTS_TO_WIN = 10;
        private const int FONTSIZE = 60;
        private int score;
        private Font scoreFont;
        private Point position;
        private bool winConditions;

        /// <summary>
        /// Initialises a score at given position
        /// </summary>
        /// <param name="position">the position of the score in the game</param>
        public Score(Point position)
        {
            score = 0;
            winConditions = false;
            this.position = position;
            FontFamily fontFamily = new FontFamily("OCR-A");
            scoreFont = new Font(fontFamily, FONTSIZE);
        }

        /// <summary>
        /// Draws the score on the form
        /// </summary>
        /// <param name="graphics"></param>
        public void DrawScore(Graphics graphics)
        {
            graphics.DrawString(score.ToString("00"), scoreFont, Brushes.White, position);
        }

        /// <summary>
        /// Increments the score, checks to see if score is at max
        /// </summary>
        public void UpdateScore()
        {
            score++;
            if (score == POINTS_TO_WIN)
            {
                winConditions = true;
            }           
        }

        /// <summary>
        /// gets and sets a toggle for whether a player's score has met the win conditions
        /// </summary>
        public bool WinConditions
        {
            get { return winConditions; }
            set { winConditions = value; }
        }

        /// <summary>
        /// gets and sets the font associated with the score
        /// </summary>
        public Font ScoreFont
        {
            get { return scoreFont; }
            set { scoreFont = value; }
        }

        /// <summary>
        /// gets and sets the position of the score
        /// </summary>
        public Point Position
        {
            get { return position; }
            set { position = value; }
        } 
    }
}
