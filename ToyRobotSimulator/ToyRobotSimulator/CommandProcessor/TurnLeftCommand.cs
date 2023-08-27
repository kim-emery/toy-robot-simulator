using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulator.Simulation
{
    public class TurnLeftCommand: ICommand
    {
        public TurnLeftCommand()
        {
        }

        public void Execute(IRobot Robot)
        {
            Robot.TurnLeft();
        }

        public bool Validate(IRobot Robot, ITableTop TableTop)
        {
            if (!Robot.IsPlaced()) throw new ValidationException(RobotNotPlacedErrorMessage);
            return !Robot.IsPlaced();
        }
    }
}
