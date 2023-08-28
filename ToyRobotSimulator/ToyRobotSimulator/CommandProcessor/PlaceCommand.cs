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
        public PlaceCommand(int xPlacement, int yPlacement, Direction direction)
        {
            _xPlacement = xPlacement;
            _yPlacement = yPlacement;
            _direction = direction;
        }

        public void Execute(IRobot robot)
        {
            robot.Place(_xPlacement, _yPlacement, _direction);
        }

        public bool Validate(IRobot robot, ITableTop tableTop)
        {
            if (!tableTop.IsValidPlacement(_xPlacement, _yPlacement)) throw new ValidationException(PositionOutOfBoundsErrorMessage);
            return true;
        }
    }
}
