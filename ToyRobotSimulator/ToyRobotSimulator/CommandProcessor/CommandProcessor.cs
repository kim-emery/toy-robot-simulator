using ToyRobotSimulator.Input;
using ToyRobotSimulator.Robot;

namespace ToyRobotSimulator.Simulation
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IInputHandler _inputHandler;
        public CommandProcessor(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public ICommand CreateCommand(string commandInput)
        {
            // maybe change to boolean with out like tryparse?
            var commandArguments = _inputHandler.ParseRawInput(commandInput);
            RobotCommand command;

            var validCommand = Enum.TryParse(commandArguments[0].ToString(), true, out command);
            if (validCommand)
            {
                switch (command)
                {
                    case RobotCommand.PLACE:
                        var positionData = _inputHandler.ValidatePlaceCommand(commandArguments);
                        return new PlaceCommand(positionData.Item1, positionData.Item2, positionData.Item3);

                    case RobotCommand.MOVE:
                        var moveData = _inputHandler.ValidateDefaultCommand(commandArguments);
                        return new MoveCommand();

                    case RobotCommand.RIGHT:
                        var rightData = _inputHandler.ValidateDefaultCommand(commandArguments);
                        return new TurnRightCommand();

                    case RobotCommand.LEFT:
                        var leftData = _inputHandler.ValidateDefaultCommand(commandArguments);
                        return new TurnLeftCommand();

                    case RobotCommand.REPORT:
                        var reportData = _inputHandler.ValidateDefaultCommand(commandArguments);
                        return new ReportCommand();

                    default:
                        throw new ArgumentException("Invalid Argument");
                }
            }
            else
            {
                throw new ArgumentException("Invalid Command");
            }
        }
    }
}
