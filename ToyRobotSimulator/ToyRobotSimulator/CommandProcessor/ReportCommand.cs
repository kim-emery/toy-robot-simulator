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

        public void Execute(IRobot robot)
        {
            var (currentPositionX, currentPositionY, currentDirection) = robot.GetCurrentPosition();
            Console.WriteLine( $"{currentPositionX},{currentPositionY},{currentDirection}"); // better to have this injected as outputhandler
        }

        public bool Validate(IRobot robot, ITableTop tableTop)
        {
            if (!robot.IsPlaced()) throw new ValidationException(RobotNotPlacedErrorMessage);
            return robot.IsPlaced();
        }
    }
}
