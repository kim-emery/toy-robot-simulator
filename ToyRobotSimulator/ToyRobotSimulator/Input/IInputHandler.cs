using ToyRobotSimulator.Robot;

namespace ToyRobotSimulator.Input
{
    public interface IInputHandler
    {
        // should change to something more generic <T>
        string[] ParseRawInput(string rawInput);
        Tuple<int, int, Direction> ValidatePlaceCommand(string[] commandInput);
        RobotCommand ValidateDefaultCommand(string[] commandInput);
    }
}
