using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;

namespace ToyRobotSimulator.Simulation
{
    public class PlaceCommand : ICommand
    {
        private readonly int x;
        private readonly int y;
        private readonly Direction direction;


        public PlaceCommand(int X, int Y, Direction Direction ) 
        { 
            x = X;
            y = Y;
            direction = Direction;
        }

        public void Execute(IRobot Robot) 
        {
            Robot.Place(x, y, direction);
        }

        public bool Validate(IRobot Robot, ITableTop TableTop)
        {
            return true;
        }
    }
}
