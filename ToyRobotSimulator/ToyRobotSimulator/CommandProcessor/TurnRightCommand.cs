using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulator.Simulation
{
    public class TurnRightCommand: ICommand
    {
        public TurnRightCommand()
        {
        }

        public void Execute(IRobot robot)
        {
            robot.TurnRight();
        }

        public bool Validate(IRobot robot, ITableTop tableTop)
        {
            if (!robot.IsPlaced()) throw new ValidationException(RobotNotPlacedErrorMessage);
            return robot.IsPlaced();
        }
    }
}
