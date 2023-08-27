using ToyRobotSimulator.Robot;

namespace ToyRobotSimulator.Input
{
    public class ConsoleInputHandler : IInputHandler
    {
        // should be in it's own class with interface and splitting options
        public string[] ParseRawInput(string rawUserInput)
        {
            return rawUserInput.Split(" "); // put in config
        }


        public static void ValidateInputCommands(string[] commandInput)
        {


        }

        //separate valid input types, parsing format validating format
        public Tuple<int, int, Direction> ValidatePlaceCommand(string[] commandInput)
        {
            const int positionalParamCount = 3;
            const int rawInputCount = 2; //expectedRawArguments

            int xPlacement;
            int yPlacement;
            Direction direction;


            if (commandInput.Length != rawInputCount)
            {
                throw new ArgumentException("Invalid Command. PLACE command should be in the format: PLACE X,Y,F ");
            }

            var positionalParams = commandInput[1].Split(",");

            if (positionalParams.Length != positionalParamCount)
            {
                throw new ArgumentException("Invalid Command. PLACE command should be in the format: PLACE X,Y,F ");
            }


            // check if correct numeric input for positions x and y
            if (!int.TryParse(positionalParams[0], out xPlacement))
            {
                throw new ArgumentException("Invalid position input.");
            }

            if (!int.TryParse(positionalParams[1], out yPlacement))
            {
                throw new ArgumentException("Invalid position input.");
            }

            // check if correct direction (NORTH, SOUTH, EAST, WEST)
            if (!Enum.TryParse(positionalParams[2], true, out direction))
            {
                throw new ArgumentException("Invalid direction input. Must be either NORTH, SOUTH, EAST, WEST");
            }

            return Tuple.Create(xPlacement, yPlacement, direction);

        }

        public RobotCommand ValidateDefaultCommand(string[] commandInput)
        {
            RobotCommand command;
            const int expectedParamCount = 1;
            if (commandInput.Length != expectedParamCount)
            {
                throw new ArgumentException("Invalid Command.");
            }
            var validCommand = Enum.TryParse(commandInput[0], true, out command);
            return command;

        }
    }
}
