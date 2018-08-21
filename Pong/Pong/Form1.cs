/*  
    Program name:           Pong
    Project file name:      Pong
    Author:                 Steph Garland
    Date:                   26 September 2014
    Language:               C#
    Platform:               Microsoft Visual Studio.
    Purpose:                Simulates a game of ping-pong.
    Description:            The user controls a paddle by moving it vertically across the left side of the screen, 
                            competing against an AI opponent controlling a second paddle on the opposing side. Players use the paddles to hit a ball back and forth. 
                            Whoever gets the ball past the other, gets a point. First to 10 points wins.
    Known Bugs:             Menu provides options for things that have not yet been implemented (ran out of time).
    Additional Features:    Improved movement of computer paddle. Pause button, sound, user can change ball colour.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pong
{
    /// <summary>
    /// GUI for pong game: Handles user input.
    /// </summary>
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;

        /// <summary>
        /// Instantiates game engine and form controls
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            gameEngine = new GameEngine(ClientSize);
        }

        /// <summary>
        /// On every timer tick, gameEngine updates and form refreshes.
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameEngine.WinConditions)
            {
                timer1.Enabled = false;
            }
            gameEngine.Run();
            Refresh();
        }

        /// <summary>
        /// Tells game engine to draw game objects
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            gameEngine.Draw(graphics);
        }

        /// <summary>
        /// Invoked when the mouse-pointer moves within form
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            gameEngine.userInput(e.Location);
        }


        /// <summary>
        /// Invoked when pause button is clicked
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameEngine.WinConditions == false)
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

        }

        /// <summary>
        /// Invoked when Exit button is clicked
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Invoked when the Restart button is clicked
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameEngine = new GameEngine(ClientSize);
            Refresh();
        }

        /// <summary>
        /// Invoked when change ball to red option is clicked
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameEngine.ChangeColourBall(redToolStripMenuItem.Text);
        }

        /// <summary>
        /// Invoked when change ball to yellow option is clicked
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameEngine.ChangeColourBall(yellowToolStripMenuItem.Text);
        }

        /// <summary>
        /// Invoked when change ball to green option is clicked
        /// </summary>
        /// <param name="sender">object that invoked this event</param>
        /// <param name="e">event data</param>
        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameEngine.ChangeColourBall(greenToolStripMenuItem.Text);
        }






    }
}
