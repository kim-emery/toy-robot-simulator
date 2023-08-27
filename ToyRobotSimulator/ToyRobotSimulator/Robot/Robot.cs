namespace ToyRobotSimulator.Robot
{
    public class ToyRobot : IRobot
    {
        private const int _step = 1;
        private bool _isPlaced = false;
        public int XAxisPlacement { get; private set; }
        public int YAxisPlacement { get; private set; }
        public Direction FaceDirection { get; set; }

        // initialise the toy robot
        public ToyRobot()
        {
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

        public (int, int) GetNextPositionAfterStep()
        {
            int yIndex = YAxisPlacement;
            int xIndex = XAxisPlacement;

            switch (FaceDirection)
            {
                case Direction.NORTH:
                    yIndex = YAxisPlacement + _step;
                    break;
                case Direction.SOUTH:
                    yIndex = YAxisPlacement - _step;
                    break;
                case Direction.WEST:
                    xIndex = XAxisPlacement - _step;
                    break;
                case Direction.EAST:
                    xIndex = XAxisPlacement + _step;
                    break;
            }

            return (xIndex, yIndex);
        }

        private void Rotate(int rightAngleTurn)
        {
            int newDirectionToFace = (int)FaceDirection + (rightAngleTurn);

            if (newDirectionToFace > (int)Direction.WEST)
            {
                FaceDirection = Direction.NORTH;
            }
            else if (newDirectionToFace < (int)Direction.NORTH)
            {
                FaceDirection = Direction.WEST;
            }
            else
            {
                FaceDirection = (Direction)newDirectionToFace;
            }
        }

        public (int, int, Direction) GetCurrentPosition()
        {
            return (XAxisPlacement, YAxisPlacement, FaceDirection);
        }
    }
}
