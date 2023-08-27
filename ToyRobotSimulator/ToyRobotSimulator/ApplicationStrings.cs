namespace ToyRobotSimulator
{
    public static class ApplicationStrings
    {   
        // move this to appsettings.json
        public static readonly string AppDescription = 
@"Toy Robot Simulator
----------------------------------------------------------------
Simulates a toy robot moving on a {0} x {1} table top.

Commands:
    PLACE X,Y,F
    MOVE
    LEFT
    RIGHT
    REPORT

The first valid command to the robot is a PLACE command.
After that, any sequence of commands may be issued, in any order.
-------------------------------------------------------------------
";
        
        public static readonly string AppExitMessage = @"Toy robot simulator is closing.";
        public static readonly string RobotNotPlacedErrorMessage = "Robot needs to be placed first!";
        public static readonly string PositionOutOfBoundsErrorMessage = "Robot needs to be placed within table top bounds.";
        public static readonly string InvalidPlaceInputErrorMessage = "Invalid Command. PLACE command should be in the format: PLACE X,Y,F ";
        public static readonly string InvalidPositionInputErrorMessage = "Invalid position input";
        public static readonly string InvalidDirectionInputErrorMessage = "Invalid direction input. Must be either NORTH, SOUTH, EAST, WEST";
        public static readonly string InvalidInputErrorMessage = "Invalid command.";
    }
}
