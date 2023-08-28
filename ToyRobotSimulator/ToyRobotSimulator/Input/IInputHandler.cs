using ToyRobotSimulator.Robot;

namespace ToyRobotSimulator.Input
{
    public interface IInputHandler
    {
        // should change to something more generic <T>
        public string[] ParseRawInput(string rawInput);
        public Tuple<int, int, Direction> ValidatePlaceCommand(string[] commandInput);
        public RobotCommand ValidateDefaultCommand(string[] commandInput);
    }
}
