/*  
    Program name:           PacMan
    Project file name:      PacMan
    Author:                 Steph Garland
    Date:                   14 November, 2014
    Language:               C#
    Platform:               Microsoft Visual Studio
 
    Purpose:                The aim of this program is to recreate the arcade game Pac-Man, wherein Pac-Man navigates through a maze 
                            trying to eat all kibbles present. NPC ghosts chase Pac-Man, killing him on contact.
 
    Description:            The player controls Pac-Man’s movement through a maze, trying to eat all of the kibble. The player is 
                            awarded 10 points per kibble eaten. When all kibble is eaten, the game has been won. Four ghosts roam the 
                            maze, trying to catch Pac-Man. If a ghost touches Pac-Man, a life is lost and the ghosts and Pac-Man 
                            revert to their starting areas to continue the game. When all lives have been lost, the game ends.
 
    Known Bugs:              - My custom menu strip stopped showing up one day, and I'm not sure why
                             - The functionality of PacMan eating the large kibbles is incomplete:
                                            - Eaten ghosts become scared again if a nother large kibble is eaten quickly enough
 
    Additional Features:     - The Grid is set up to handle different tilemaps being loaded in. Even if a tilemap is loaded that has 
                               rows/columns of varying lengths, it rounds out the difference with blank tiles.
                             - Creatures are drawn between tiles (as well as in tiles), allowing for smoother looking movements
                             - Eating big kibbles makes the ghosts scared and edible
                             - Sound
                             - Ghost have multiple images that describe their state, direction, and frames
                             - Ghost behaviour is more refined than random: 
                                            - In aggressive mode they cannot go backwards
                                            - They can only change direction at an intersection
                                            - They reverse direction when frightened
                             - PacMan moves in the intended direction at next available opportunity instead of stopping if direction is not valid
 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PacMan
{
    /// <summary>
    /// The form provides the user interface handles user-triggered events. It also handles the timer and creates the gameEngine object.
    /// </summary>
    public partial class Form1 : Form
    {
        private const int SCORE_SIZE_AREA = 50;
        private Random rand;
        private Grid dataGrid;
        private GameEngine gameEngine;
        private PictureBox[] lifeCounter;
        private System.Windows.Media.MediaPlayer sound;

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            dataGrid = new Grid("TileMap.csv");
            Controls.Add(dataGrid);
            sound = new System.Windows.Media.MediaPlayer();
            sound.Open(new Uri("pacmanDubHeavy.mp3", UriKind.Relative));
            sound.Play();

            gameEngine = new GameEngine(dataGrid, rand, timer1.Interval);

            //pacman font
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("crackman.ttf");

            FontFamily ff = fontCollection.Families[0];
            int fontsize = 12;
            Font pacmanFont = new Font(ff, fontsize, FontStyle.Bold);

            label2.Font = pacmanFont;
            label3.Font = pacmanFont;
            label4.Font = pacmanFont;

            lifeCounter = new PictureBox[3];
            lifeCounter[0] = pictureBox1;
            lifeCounter[1] = pictureBox2;
            lifeCounter[2] = pictureBox3;
        }

        /// <summary>
        /// If the user clicks this menustrip item the application closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// If the user clicks this menustrip item the game can toggle between paused/unpaused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                pauseToolStripMenuItem.Image = Properties.Resources.play;
            }
            else
            {
                timer1.Enabled = true;
                pauseToolStripMenuItem.Image = Properties.Resources.pause;
            } 
        }

        /// <summary>
        /// INCOMPLETE
        /// If the user clicks this menustrip item the game can toggle sound on/off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soundONOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                soundONOFFToolStripMenuItem.Image = Properties.Resources.soundON;
            }
            else
            {
                timer1.Enabled = true;
                soundONOFFToolStripMenuItem.Image = Properties.Resources.soundOFF;
            } 
        }

        /// <summary>
        /// Listens for user keystrokes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gameEngine.GetUserDirection(e.KeyCode);
        }

        /// <summary>
        /// Prompts the game to progress at each timer-tick. Also prompts Score, Lives left, and Game Over visuals to display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {                        
            label3.Text = gameEngine.CalculateScore().ToString();
            gameEngine.RunGame();

            for (int i = gameEngine.N_Lives; i < lifeCounter.Length; i++)
            {
                lifeCounter[i].Visible = false;
            }

            if (gameEngine.GameOver == true)
            {
                label4.Text = ("GAME OVER \n\nFINAL SCORE: " + gameEngine.CalculateScore().ToString());
                label4.Visible = true;
                timer1.Enabled = false;
            }
        }

    }
}
