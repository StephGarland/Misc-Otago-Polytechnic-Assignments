using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PacMan
{
    /// <summary>
    /// The template for a user controlled PacMan creature
    /// </summary>
    public class PacMan: Creature
    {
        private const int ANIMATION_FRAMES = 4;
        private const int START_LOCATION_X = 300;
        private const int START_LOCATION_Y = 450;

        private Bitmap[,] image;
        private Direction attemptedDirection;
        private int lives;

        public PacMan(): base(START_LOCATION_X, START_LOCATION_Y)
        {
            lives = 3;
            InitialiseImageArray();
        }

        /// <summary>
        /// Creates and resizes an image array of pacman sprites
        /// </summary>
        public void InitialiseImageArray()
        {
            int nPossibleDirections = Enum.GetNames(typeof(Direction)).Length;
            image = new Bitmap[nPossibleDirections, ANIMATION_FRAMES];

            //loads pacman images into image array
            for (int columns = 0; columns < nPossibleDirections; columns++)
            {
                string[] directionName = Enum.GetNames(typeof(Direction));
                image[columns, 0] = new Bitmap("PacManSprites/pacmanOrange.png");

                for (int rows = 1; rows < ANIMATION_FRAMES; rows++)
                {
                    string imageLocation = "PacManSprites/pacmanOrange" + directionName[columns] + rows + ".png";
                    image[columns, rows] = new Bitmap(imageLocation);
                }
            }

            //makes all the images in the ghost image array the same size.
            for (int columns = 0; columns < image.GetLength(0); columns++)
            {
                for (int rows = 0; rows < image.GetLength(1); rows++)
                {
                    Bitmap nicelySizedBitmap = new Bitmap(image[columns, rows], IMAGE_SIZE, IMAGE_SIZE);
                    image[columns, rows] = nicelySizedBitmap;

                    //makes the background of images transparent. Decides on the colour to make transparent based on top left pixel of image.
                    Color transparentColour = image[columns, rows].GetPixel(0, 0);
                    image[columns, rows].MakeTransparent(transparentColour);
                }
            }
        }

        /// <summary>
        /// Specifies the specific Pacman image to draw at his current location
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(image[(int)direction, imageToggle], location);
        }

        /// <summary>
        /// Changes PacMan's position to a new valid position
        /// </summary>
        /// <param name="dataGrid"></param>
        public void Move(Grid dataGrid)
        {
            //checks to see if pacman is aligned with a cell
            if ((location.X % IMAGE_SIZE == 0) && (location.Y % IMAGE_SIZE == 0))
            {
                Point location_cellIndex;
                location_cellIndex = new Point((location.X / IMAGE_SIZE), (location.Y / IMAGE_SIZE));

                Point attemptedLocation = location_cellIndex;
                //defines the location the user is attempting to move to
                switch (attemptedDirection)
                {
                    case Direction.Up:
                        attemptedLocation.Y--;
                        break;
                    case Direction.Left:
                        attemptedLocation.X--;
                        break;
                    case Direction.Right:
                        attemptedLocation.X++;
                        break;
                    case Direction.Down:
                        attemptedLocation.Y++;
                        break;
                    default:
                        break;
                }

                //checks to see if the next cell in the direction pacman wants to go in is valid
                if (dataGrid.CheckForWall(attemptedLocation) == false)
                {
                    direction = attemptedDirection;

                    imageToggle++;
                    imageToggle %= ANIMATION_FRAMES;
                }

                attemptedLocation = location_cellIndex;
                //attempted direction shift was unsuccessful, so instead pacman carries on the way he was going
                switch (direction)
                {
                    case Direction.Up:
                        attemptedLocation.Y--;
                        break;
                    case Direction.Left:
                        attemptedLocation.X--;
                        break;
                    case Direction.Right:
                        attemptedLocation.X++;
                        break;
                    case Direction.Down:
                        attemptedLocation.Y++;
                        break;
                    default:
                        break;
                }

                if (dataGrid.CheckForWall(attemptedLocation) == false)
                {
                    switch (direction)
                    {
                        case Direction.Up:
                            location.Y -= speed;
                            break;
                        case Direction.Left:
                            location.X -= speed;
                            break;
                        case Direction.Right:
                            location.X += speed;
                            break;
                        case Direction.Down:
                            location.Y += speed;
                            break;
                        default:
                            break;
                    }

                    imageToggle++;
                    imageToggle %= ANIMATION_FRAMES;
                }
            }

            else
            {
                switch (direction)
                {
                    case Direction.Up:
                        location.Y -= speed;
                        break;
                    case Direction.Left:
                        location.X -= speed;
                        break;
                    case Direction.Right:
                        location.X += speed;
                        break;
                    case Direction.Down:
                        location.Y += speed;
                        break;
                    default:
                        break;
                }

                imageToggle++;
                imageToggle %= ANIMATION_FRAMES;
            }
        }

        /// <summary>
        /// PacMan eats the contents of his location.
        /// </summary>
        /// <param name="dataGrid"></param>
        public bool Eat(Grid dataGrid)
        {
            bool bigKibbleEaten = false;
            if ((location.X % IMAGE_SIZE == 0) && (location.Y % IMAGE_SIZE == 0))
            {
                Point location_cellIndex;
                location_cellIndex = new Point((location.X / IMAGE_SIZE), (location.Y / IMAGE_SIZE));
                if (dataGrid.ClearCell(location_cellIndex) == true)
                {
                    bigKibbleEaten = true;
                }
            }

            return bigKibbleEaten;
        }

        /// <summary>
        /// Handles a pacman-ghost collision.
        /// </summary>
        /// <param name="ghost"></param>
        public void CheckGhostCollision(Ghost ghost)
        {

            if (location == ghost.Location)
            {
                if (ghost.BehaviourType == GhostMode.Frightened)
                {

                    ghost.BehaviourType = GhostMode.Eaten;
                }
                else if (ghost.BehaviourType == GhostMode.Aggressive)
                {
                    location = new Point(START_LOCATION_X, START_LOCATION_Y);
                    lives--;
                }
            }
        }

        //Sets the direction pacman will attempt to move to
        public Direction AttemptedDirection
        {
            set { attemptedDirection = value; }
        }

        //Returns whether or not pacman has lost all his lives
        public bool Alive
        {
            get 
            {
                if (lives <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        //Gets/Sets the number of lives pacman has remaining to him
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
    }
}
