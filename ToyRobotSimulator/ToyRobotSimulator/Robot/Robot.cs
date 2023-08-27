namespace ToyRobotSimulator.Robot
{
    public class ToyRobot : IRobot
    {
        private const int _step = 1;
        public bool _isPlaced { get; private set; }
        public int XAxisPlacement { get; private set; }
        public int YAxisPlacement { get; private set; }
        public Direction FaceDirection { get; set; } //maybe change this to singular instead of plural
        
        // initialise the toy robot
        public ToyRobot()
        {
            _isPlaced = false;
        }

        public bool IsPlaced()
        {
            return _isPlaced;
        }

        public void Place(int xPlacement, int yPlacement, Direction direction)
        {
            _isPlaced = true;       
            XAxisPlacement = xPlacement;
            YAxisPlacement = yPlacement;
            FaceDirection = direction;
        }

        public void TurnLeft()
        {
            Rotate(-1);
        }

        public void TurnRight()
        {
            Rotate(1);
        }

        public void MoveOneStep() // check to see if robot can be moved
        {
            switch (FaceDirection)
            {
                case Direction.NORTH:
                    XAxisPlacement += _step;
                    break;
                case Direction.SOUTH:
                    XAxisPlacement -= _step;
                    break;
                case Direction.WEST:
                    YAxisPlacement -= _step;
                    break;
                case Direction.EAST:
                    YAxisPlacement += _step;
                    break;
                default:
                    break;
            }
        }

        private void Rotate(int rightAngleTurn)
        {
            int newDirectionToFace = (int) FaceDirection + (rightAngleTurn);

            if ((int) newDirectionToFace > (int) Direction.WEST)
            {
                FaceDirection = Direction.NORTH;
            }else if ((int) newDirectionToFace < (int)Direction.NORTH)
            {
                FaceDirection = Direction.WEST;
            }
            else
            {
                FaceDirection = (Direction) newDirectionToFace;
            }
        }

        public (int, int, Direction) GetCurrentPosition()
        {
            return (XAxisPlacement, YAxisPlacement, FaceDirection);
        }
    }
}
