using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace PacMan
{
    /// <summary>
    /// The maze that the game takes place in
    /// </summary>
    public class Grid: DataGridView
    {
        //constants
        private const int CELLSIZE = 30;
        private const int SPACESIZE = 4;
        private string[,] tileMap;
        private int nStartKibbles;
        private int kibblesRemaining;

        //constructor
        public Grid(String fileName): base()
        {
            initialiseTileMap(fileName);

            // set position of grid on the Form:
            Top = 0;
            Left = 0;

            // setup the columns to display images. We want to display images, so we set x columns worth of Image columns:
            for (int x = 0; x < tileMap.GetLength(0); x++)
            {
                DataGridViewImageColumn temp = new DataGridViewImageColumn();
                temp.ImageLayout = DataGridViewImageCellLayout.Zoom;
                Columns.Add(temp);
            }

            // then we can tell the grid the number of rows we want to display:
            RowCount = tileMap.GetLength(1);

            // set the properties of the grid(which is a DataGridView object):
            Height = RowCount * CELLSIZE + SPACESIZE;
            Width = Columns.Count * CELLSIZE + SPACESIZE;
            ScrollBars = ScrollBars.None;
            DoubleBuffered = true;
            CellBorderStyle = DataGridViewCellBorderStyle.None;
            ColumnHeadersVisible = false;
            RowHeadersVisible = false;

            foreach (DataGridViewRow r in Rows)
                r.Height = CELLSIZE;
            foreach (DataGridViewColumn c in Columns)
                c.Width = CELLSIZE;

            // rows and columns should never resize themselves to fit cell contents:
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // prevent user from resizing rows or columns:
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;

            DrawTiles();
            kibblesRemaining = nStartKibbles;
        } 

        /// <summary>
        /// Creates a tile map from a csv file
        /// </summary>
        /// <param name="fileName"></param>
        private void initialiseTileMap(String fileName)
        {
            List<string[]> tiles = new List<string[]>();
            StreamReader sr = new StreamReader(fileName);

            int line = 0;
            int longest = 0;
            //reads in file values
            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();

                string[] lineValues = temp.Split(',');
                tiles.Add(lineValues);

                //finds the longest row in the list
                if (tiles[line].Length > longest)
                {
                    longest = tiles[line].Length;
                }
                line++;
            } 
            sr.Close();

            //Creates an even tilemap by using longest row value as the overall row value
            tileMap = new string[longest,tiles.Count];
            for (int row = 0; row < tiles.Count; row++)
			{
			     for (int column = 0; column < tiles[row].Length; column++)
			    {
                    tileMap[column, row] = tiles[row][column];
			    }
			}
        }

        /// <summary>
        /// Draws images into gridcells. Counts how many kibbles it drew.
        /// </summary>
        public void DrawTiles()
        {
            nStartKibbles = 0;

            for (int column = 0; column < tileMap.GetLength(0); column++)
            {
                for (int row = 0; row < tileMap.GetLength(1); row++)
                {
                    switch (tileMap[column,row])
                    {
                        case "w":
                            Rows[row].Cells[column].Value = Properties.Resources.wall;
                            break;
                        case ".":
                            Rows[row].Cells[column].Value = Properties.Resources.mediumKibble;
                            nStartKibbles++;
                            break;
                        case "o":
                            Rows[row].Cells[column].Value = Properties.Resources.largeKibble;
                            break;
                        case "-":
                        default:
                            Rows[row].Cells[column].Value = Properties.Resources.blank;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the contents of the specified cell. 
        /// If a kibble is deleted, substracts one kibble from remaining kibble count.
        /// Returns a true flag if it was a big kibble that was deleted.
        /// </summary>
        /// <param name="CellToClear">The specific cell to delete the contents of</param>
        /// <returns>A boolean to indicate if a bigkibble was deleted</returns>
        public bool ClearCell(Point CellToClear)
        {
            bool bigKibbleDeleted = false;
            if (tileMap[CellToClear.X, CellToClear.Y] == ".")
            {
                kibblesRemaining--;
            }
            if (tileMap[CellToClear.X, CellToClear.Y] == "o")
            {
                bigKibbleDeleted = true;
            }
            tileMap[CellToClear.X, CellToClear.Y] = " ";
            Rows[CellToClear.Y].Cells[CellToClear.X].Value = Properties.Resources.blank;
            return bigKibbleDeleted;
        }

        /// <summary>
        /// Returns a true flag if a specified cell has a wall in it.
        /// </summary>
        /// <param name="CellToCheck">Cell in which to check for wall</param>
        /// <returns>A boolean to indicate if the cell has a wall in it</returns>
        public bool CheckForWall(Point CellToCheck)
        {
            bool thereIsAWall = false;
            if (tileMap[CellToCheck.X, CellToCheck.Y] == "w")
            {
                thereIsAWall = true;
            }
            return thereIsAWall;
        }

        /// <summary>
        /// Gets the number of Kibbles still in the Maze
        /// </summary>
        public int KibblesRemaining
        {
            get { return kibblesRemaining; }
        }

        /// <summary>
        /// Gets the number of Kibbles the maze started with
        /// </summary>
        public int NStartKibbles
        {
            get { return nStartKibbles; }
        }
    }
}
