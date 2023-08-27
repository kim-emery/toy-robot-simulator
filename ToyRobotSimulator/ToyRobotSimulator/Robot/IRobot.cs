namespace ToyRobotSimulator.Robot
{
    public interface IRobot
    {
        public bool IsPlaced();
        public void Place (int x, int y, Direction direction);
        public void TurnLeft();
        public void TurnRight();
        public (int, int, Direction) GetCurrentPosition();
        public void MoveOneStep();
    }
}
