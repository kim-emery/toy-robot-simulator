using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;

namespace ToyRobotSimulator.Simulation
{
    public interface ICommand
    {
        public void Execute(IRobot robot);
        public bool Validate(IRobot robot, ITableTop tableTop);
    }
}
