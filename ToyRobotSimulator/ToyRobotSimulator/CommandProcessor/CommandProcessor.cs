using ToyRobotSimulator.Input;
using ToyRobotSimulator.Robot;
using static ToyRobotSimulator.ApplicationStrings;

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

            string[] commandArguments = _inputHandler.ParseRawInput(commandInput);
            RobotCommand command;

            var validCommand = Enum.TryParse(commandArguments[0].ToString(), true, out command);
            if (validCommand)
            {
                switch (command)
                {
                    case RobotCommand.PLACE:
                        var (positionX, positionY, direction) = _inputHandler.ValidatePlaceCommand(commandArguments);
                        return new PlaceCommand(positionX, positionY, direction);

                    case RobotCommand.MOVE:
                        _ = _inputHandler.ValidateDefaultCommand(commandArguments);
                        return new MoveCommand();

                    case RobotCommand.RIGHT:
                        _ = _inputHandler.ValidateDefaultCommand(commandArguments);
                        return new TurnRightCommand();

                    case RobotCommand.LEFT:
                        _ = _inputHandler.ValidateDefaultCommand(commandArguments);
                        return new TurnLeftCommand();

                    case RobotCommand.REPORT:
                        _ = _inputHandler.ValidateDefaultCommand(commandArguments);
                        return new ReportCommand();

                    default:
                        throw new ArgumentException(InvalidInputErrorMessage);
                }
            }
            else
            {
                throw new ArgumentException(InvalidInputErrorMessage);
            }
        }
    }
}
