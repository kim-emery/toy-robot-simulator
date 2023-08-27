using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulator.Simulation
{
    public class PlaceCommand : ICommand
    {
        private readonly int _xPlacement;
        private readonly int _yPlacement;
        private readonly Direction _direction;

        // rename these to be more descriptive
        public PlaceCommand(int X, int Y, Direction Direction ) 
        { 
            _xPlacement = X;
            _yPlacement = Y;
            _direction = Direction;
        }

        public void Execute(IRobot Robot) 
        {
            Robot.Place(_xPlacement, _yPlacement, _direction);
        }

        public bool Validate(IRobot Robot, ITableTop TableTop)
        {
            if (!TableTop.IsValidPlacement(_xPlacement, _yPlacement)) throw new ValidationException(PositionOutOfBoundsErrorMessage);
            return true;
        }
    }
}
