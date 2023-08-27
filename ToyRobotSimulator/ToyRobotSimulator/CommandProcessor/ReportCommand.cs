using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;

namespace ToyRobotSimulator.Simulation
{
    public class ReportCommand: ICommand
    {
        public ReportCommand()
        {
        }

        public void Execute(IRobot Robot)
        {
           Console.WriteLine( Robot.GetCurrentPosition().ToString());
        }

        public bool Validate(IRobot Robot, ITableTop TableTop)
        {
            return Robot.IsPlaced();
        }
    }
}
