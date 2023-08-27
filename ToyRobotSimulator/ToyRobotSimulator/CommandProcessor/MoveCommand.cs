using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulator.Simulation
{
    public class MoveCommand : ICommand
    {
        public MoveCommand()
        {
        }

        public void Execute(IRobot Robot)
        {
            Robot.MoveOneStep();
        }

        public bool Validate(IRobot Robot, ITableTop TableTop)
        {
            if (!Robot.IsPlaced()) throw new ValidationException(RobotNotPlacedErrorMessage);
            return Robot.IsPlaced();
        }
    }
}
