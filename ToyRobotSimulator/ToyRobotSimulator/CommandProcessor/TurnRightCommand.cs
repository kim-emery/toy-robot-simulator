using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;

namespace ToyRobotSimulator.Simulation
{
    public class TurnRightCommand: ICommand
    {
        public TurnRightCommand()
        {
        }

        public void Execute(IRobot Robot)
        {
            Robot.TurnRight();
        }

        public bool Validate(IRobot Robot, ITableTop TableTop)
        {
            return !Robot.IsPlaced();
        }
    }
}
