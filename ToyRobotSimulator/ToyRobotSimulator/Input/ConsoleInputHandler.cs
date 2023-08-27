using ToyRobotSimulator.Robot;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulator.Input
{
    public class ConsoleInputHandler : IInputHandler
    {
        private readonly string positionSplitCharacter;
        private readonly string commandSplitCharacter;

        public ConsoleInputHandler()
        {
            commandSplitCharacter = " ";
            positionSplitCharacter = ","; // put in config
        }

        public string[] ParseRawInput(string rawUserInput)
        {
            return rawUserInput.Split(commandSplitCharacter);
        }

        // should probably extract these to separate validation objects to make them more testable
        public Tuple<int, int, Direction> ValidatePlaceCommand(string[] commandInput)
        {
            const int rawInputCount = 2; //expectedRawArguments
            const int positionalParamCount = 3;

            int xPlacement;
            int yPlacement;
            Direction direction;


            if (commandInput.Length != rawInputCount) throw new ArgumentException(InvalidPlaceInputErrorMessage);

            var positionalParams = commandInput[1].Split(positionSplitCharacter);

            if (positionalParams.Length != positionalParamCount) throw new ArgumentException(InvalidPlaceInputErrorMessage);

            // check if correct numeric input for positions x and y, can refactor these
            if (!int.TryParse(positionalParams[0], out xPlacement)) throw new ArgumentException(InvalidPositionInputErrorMessage);

            if (!int.TryParse(positionalParams[1], out yPlacement)) throw new ArgumentException(InvalidPositionInputErrorMessage);


            // check if correct direction (NORTH, SOUTH, EAST, WEST)
            if (!Enum.TryParse(positionalParams[2], true, out direction)) throw new ArgumentException(InvalidDirectionInputErrorMessage);

            return Tuple.Create(xPlacement, yPlacement, direction);
        }

        public RobotCommand ValidateDefaultCommand(string[] commandInput)
        {
            RobotCommand command;
            const int expectedParamCount = 1;
            if (commandInput.Length != expectedParamCount)
            {
                throw new ArgumentException(InvalidInputErrorMessage);
            }
            var validCommand = Enum.TryParse(commandInput[0], true, out command);
            return command;

        }
    }
}
