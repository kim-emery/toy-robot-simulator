using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;

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
            return !Robot.IsPlaced();
        }
    }
}
