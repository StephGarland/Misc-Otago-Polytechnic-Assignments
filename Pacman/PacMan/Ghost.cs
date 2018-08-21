using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PacMan
{
    /// <summary>
    /// The template for an AI controlled ghost
    /// </summary>
    public class Ghost : Creature
    {
        private const int EATEN_SPEED = 6;
        private const int EATEN_DURATION = 121;
        private const int FRIGHTENED_SPEED = 3;
        private const int FRIGHTENED_DURATION = 121;
        //private const int SCATTER_PHASE_LENGTH = 6000;
        //private const int CHASE_PHASE_LENGTH = 20000;
        private const int ANIMATION_FRAMES = 2;
        private const int START_LOCATION_X = 300;
        private const int START_LOCATION_Y = 270;

        private Bitmap[][][] image;
        private GhostMode behaviourType;
        private Point location_cellIndex;

        private int frightenedDurationCountdown;
        private int eatenDurationCountdown;

        public Ghost(string colour)
            : base(START_LOCATION_X, START_LOCATION_Y)
        {
            initialiseImageArray(colour);
            behaviourType = GhostMode.Aggressive;
            speed = BASE_SPEED;
            imageToggle = 0;
            location = new Point(START_LOCATION_X, START_LOCATION_Y);
        }

        /// <summary>
        /// Fills up the ghosts image array
        /// </summary>
        /// <param name="colour"></param>
        private void initialiseImageArray(string colour)
        {
            int nPossibleDirections = Enum.GetNames(typeof(Direction)).Length;
            int nPossibleStates = Enum.GetNames(typeof(GhostMode)).Length;
            //jagged array of brain bleeding
            //------------------------------
            //This declares that the image jagged-array begins with an outer layer/array of a size equal to the number of different states a ghost can be in.
            image = new Bitmap[nPossibleStates][][];

            //AGGRESSIVE MODE
            //This declares the size of the middle layer/array for the aggressive state.
            image[(int)GhostMode.Aggressive] = new Bitmap[nPossibleDirections][];

            //for each slot in the middle array (which represents directions)
            for (int directionSlot = 0; directionSlot < nPossibleDirections; directionSlot++)
            {
                //Declares the size of the innermost array (which represents number of animation frames)
                image[(int)GhostMode.Aggressive][directionSlot] = new Bitmap[ANIMATION_FRAMES];

                string[] directionName = Enum.GetNames(typeof(Direction));
                //Puts the image in!
                for (int frameSlot = 0; frameSlot < image[(int)GhostMode.Aggressive][directionSlot].Length; frameSlot++)
                {
                    string imageLocation = "PacManSprites/ghost" + colour + directionName[directionSlot] + (frameSlot + 1) + ".png";
                    image[(int)GhostMode.Aggressive][directionSlot][frameSlot] = new Bitmap(imageLocation);
                }
            }

            //RANDOM MODE
            //This declares the size of the middle layer/array for the aggressive state.
            image[(int)GhostMode.Random] = new Bitmap[nPossibleDirections][];

            //for each slot in the middle array (which represents directions)
            for (int directionSlot = 0; directionSlot < nPossibleDirections; directionSlot++)
            {
                //Declares the size of the innermost array (which represents number of animation frames)
                image[(int)GhostMode.Random][directionSlot] = new Bitmap[ANIMATION_FRAMES];

                string[] directionName = Enum.GetNames(typeof(Direction));
                //Puts the image in!
                for (int frameSlot = 0; frameSlot < image[(int)GhostMode.Random][directionSlot].Length; frameSlot++)
                {
                    string imageLocation = "PacManSprites/ghost" + colour + directionName[directionSlot] + (frameSlot + 1) + ".png";
                    image[(int)GhostMode.Random][directionSlot][frameSlot] = new Bitmap(imageLocation);
                }
            }

            //FRIGHTENED MODE
            //This declares the size of the middle layer/array for the frightened state.
            image[(int)GhostMode.Frightened] = new Bitmap[1][];

            //Declares the size of the innermost array (which represents number of animation frames)
            image[(int)GhostMode.Frightened][0] = new Bitmap[ANIMATION_FRAMES];

            //Puts the image in!
            for (int frameSlot = 0; frameSlot < image[(int)GhostMode.Frightened][0].Length; frameSlot++)
            {
                string imageLocation = "PacManSprites/ghostEdible" + (frameSlot + 1) + ".png";
                image[(int)GhostMode.Frightened][0][frameSlot] = new Bitmap(imageLocation);
            }


            //EATEN MODE
            //This declares the size of the middle layer/array for the Eaten state.
            image[(int)GhostMode.Eaten] = new Bitmap[1][];

            //Declares the size of the innermost array (which represents number of animation frames)
            image[(int)GhostMode.Eaten][0] = new Bitmap[ANIMATION_FRAMES];

            //Puts the image in!
            for (int frameSlot = 0; frameSlot < image[(int)GhostMode.Eaten][0].Length; frameSlot++)
            {
                string imageLocation = "PacManSprites/ghostDeadEyes" + (frameSlot + 1) + ".png";
                image[(int)GhostMode.Eaten][0][frameSlot] = new Bitmap(imageLocation);
            }

            adjustImageSizeAndTransparency();
        }
        /// <summary>
        /// Adjusts the size and transparency of the ghost's image array
        /// </summary>
        private void adjustImageSizeAndTransparency()
        {
            for (int behaviourSlot = 0; behaviourSlot < image.Length; behaviourSlot++)
            {
                for (int directionSlot = 0; directionSlot < image[behaviourSlot].Length; directionSlot++)
                {
                    for (int frameSlot = 0; frameSlot < image[behaviourSlot][directionSlot].Length; frameSlot++)
                    {
                        //makes all the images in the ghost image array the same size.
                        Bitmap nicelySizedBitmap = new Bitmap(image[behaviourSlot][directionSlot][frameSlot], IMAGE_SIZE, IMAGE_SIZE);
                        image[behaviourSlot][directionSlot][frameSlot] = nicelySizedBitmap;

                        //makes the background of images transparent. Decides on the colour to make transparent based on top left pixel of image.
                        Color transparentColour = image[behaviourSlot][directionSlot][frameSlot].GetPixel(0, 0);
                        image[behaviourSlot][directionSlot][frameSlot].MakeTransparent(transparentColour);
                    }
                }
            }
        }

        /// <summary>
        /// Specifies the specific ghost image to draw at its current location
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            //current direction gets modded by the length of the direction array. 
            //this prevents an index out of range exception on arrays that have a direction array length of size 1
            int directionSlot = (int)direction % image[(int)behaviourType].Length;
            graphics.DrawImage(image[(int)behaviourType][directionSlot][imageToggle], location);
        }

        /// <summary>
        /// Randomises the direction the ghost moves in. 
        /// Specifies that a ghost should not move in the opposite direction of the one he's currently moving in.
        /// </summary>
        /// <param name="rand"></param>
        /// <param name="dataGrid"></param>
        public void RandomiseDirection(Random rand, Grid dataGrid)
        {
            int nPossibleDirections = Enum.GetNames(typeof(Direction)).Length;
            Direction tempDirection = (Direction)rand.Next(nPossibleDirections);

            Point attemptedLocation = GetNextLocation(tempDirection);

            //while the direction randomised is the opposite direction of the one he's currently moving in, randomise again.
            while (((int)tempDirection == (((int)direction + 2) % nPossibleDirections)) || (dataGrid.CheckForWall(attemptedLocation) == true))
            {
                tempDirection = (Direction)rand.Next(nPossibleDirections);
                attemptedLocation = GetNextLocation(tempDirection);
            }

            direction = tempDirection;
        }

        /// <summary>
        /// Determines the location the user is trying to move to
        /// </summary>
        /// <param name="directionToMove"></param>
        /// <returns></returns>
        public Point GetNextLocation(Direction directionToMove)
        {
            Point attemptedLocation = location_cellIndex;
            switch (directionToMove)
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
            return attemptedLocation;
        }

        /// <summary>
        /// Changes the ghost's position to a new valid position
        /// </summary>
        /// <param name="rand"></param>
        /// <param name="dataGrid"></param>
        public void Move(Random rand, Grid dataGrid)
        {
            //checks to see if the ghost is perfectly aligned with a cell
            if ((location.X % IMAGE_SIZE == 0) && (location.Y % IMAGE_SIZE == 0))
            {
                location_cellIndex = new Point((location.X / IMAGE_SIZE), (location.Y / IMAGE_SIZE));

                RandomiseDirection(rand, dataGrid);
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
        /// Updates the ghost's mode
        /// </summary>
        public void UpdateMode()
        {
            switch (behaviourType)
            {
                case GhostMode.Aggressive:
                    break;
                case GhostMode.Frightened:
                    if (frightenedDurationCountdown > 0)
                    {
                        frightenedDurationCountdown--;
                    }
                    else
                    {
                        BehaviourType = GhostMode.Aggressive;
                    }
                    break;
                case GhostMode.Eaten:
                    if (eatenDurationCountdown > 0)
                    {
                        eatenDurationCountdown--;
                    }
                    else
                    {
                        BehaviourType = GhostMode.Aggressive;
                    }
                    break;
                case GhostMode.Random:
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Gets the ghosts current location
        /// </summary>
        public Point Location
        {
            get { return location; }
        }

        /// <summary>
        /// Gets/Sets the ghost's behaviour type
        /// </summary>
        public GhostMode BehaviourType
        {
            get { return behaviourType; }
            set
            {
                behaviourType = value;
                switch (behaviourType)
                {
                    case GhostMode.Aggressive:
                        speed = BASE_SPEED;
                        break;
                    case GhostMode.Frightened:
                        speed = FRIGHTENED_SPEED;
                        int nPossibleDirections = Enum.GetNames(typeof(Direction)).Length;
                        direction = (Direction)(((int)direction + 2) % nPossibleDirections);
                        frightenedDurationCountdown = FRIGHTENED_DURATION;
                        break;
                    case GhostMode.Eaten:
                        speed = EATEN_SPEED;
                        eatenDurationCountdown = EATEN_DURATION;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
