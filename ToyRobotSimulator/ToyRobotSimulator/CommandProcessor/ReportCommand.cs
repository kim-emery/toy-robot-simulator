using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulator.Simulation
{
    public class ReportCommand: ICommand
    {
        public ReportCommand()
        {
        }

        public void Execute(IRobot Robot)
        {
            var (currentPositionX, currentPositionY, currentDirection) = Robot.GetCurrentPosition();
            Console.WriteLine( $"{currentPositionX},{currentPositionY},{currentDirection}");
        }

        public bool Validate(IRobot Robot, ITableTop TableTop)
        {
            if (!Robot.IsPlaced()) throw new ValidationException(RobotNotPlacedErrorMessage);
            return Robot.IsPlaced();
        }
    }
}
