using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;

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
            return Robot.IsPlaced();
        }
    }
}
