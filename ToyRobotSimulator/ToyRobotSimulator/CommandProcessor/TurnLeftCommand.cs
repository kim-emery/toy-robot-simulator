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

        public void Execute(IRobot robot)
        {
            robot.TurnLeft();
        }

        public bool Validate(IRobot robot, ITableTop tableTop)
        {
            if (!robot.IsPlaced()) throw new ValidationException(RobotNotPlacedErrorMessage);
            return robot.IsPlaced();
        }
    }
}
