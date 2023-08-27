using ToyRobotSimulator.Input;
using ToyRobotSimulator.Robot;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulatorTests
{
    public class InputHandlerUnitTest
    {

        [Fact]
        public void ValidatePlaceCommand_ValidCommandInput_Success()
        {
            // Arrange
            var commandInput = new[] { "place", "1,2,north" };
            var inputHandler = new ConsoleInputHandler();

            //Act
            var (xPlacement, yPlacement, direction) = inputHandler.ValidatePlaceCommand(commandInput);

            // Assert
            Assert.Equal(1, xPlacement);
            Assert.Equal(2, yPlacement);
            Assert.Equal(Direction.NORTH, direction);
        }

        [Fact]
        public void ValidatePlaceCommand_MissingPositionalInputs_Failure()
        {
            // Arrange
            var commandInput = new[] { "place" };
            var inputHandler = new ConsoleInputHandler();

            //Act
            var expectedException = Assert.Throws<ArgumentException>(() => inputHandler.ValidatePlaceCommand(commandInput));

            // Assert
            Assert.Equal(InvalidPlaceInputErrorMessage, expectedException.Message);
        }

        [Fact]
        public void ValidatePlaceCommand_InCorrectDirection_Failure()
        {
            // Arrange
            var commandInput = new[] { "place", "1,2,nowhere" };
            var inputHandler = new ConsoleInputHandler();

            //Act
            var expectedException = Assert.Throws<ArgumentException>(() => inputHandler.ValidatePlaceCommand(commandInput));

            // Assert
            Assert.Equal(InvalidDirectionInputErrorMessage, expectedException.Message);
        }

        [Fact]
        public void ValidatePlaceCommand_InvalidXPositionInput_Failure()
        {
            // Arrange
            var commandInput = new[] { "place", "a,2,north" };
            var inputHandler = new ConsoleInputHandler();

            //Act
            var expectedException = Assert.Throws<ArgumentException>(() => inputHandler.ValidatePlaceCommand(commandInput));

            // Assert
            Assert.Equal(InvalidPositionInputErrorMessage, expectedException.Message);
        }

        [Fact]
        public void ValidatePlaceCommand_InvalidYPositionInput_Failure()
        {
            // Arrange
            var commandInput = new[] { "place", "1,b,north" };
            var inputHandler = new ConsoleInputHandler();

            //Act
            var expectedException = Assert.Throws<ArgumentException>(() => inputHandler.ValidatePlaceCommand(commandInput));

            // Assert
            Assert.Equal(InvalidPositionInputErrorMessage, expectedException.Message);
        }


        [Fact]
        public void ValidateDefaultCommand_ValidCommandInput_Failure()
        {
            // Arrange
            var commandInput = new[] { "move" };
            var inputHandler = new ConsoleInputHandler();

            //Act
            RobotCommand command = inputHandler.ValidateDefaultCommand(commandInput);

            // Assert
            Assert.Equal(RobotCommand.MOVE, command);
        }

        [Fact]
        public void ValidateDefaultCommand_InvalidCommandInput_Failure()
        {
            // Arrange
            var commandInput = new[] { "move", "2" };
            var inputHandler = new ConsoleInputHandler();

            //Act
            var expectedException = Assert.Throws<ArgumentException>(() => inputHandler.ValidateDefaultCommand(commandInput));

            // Assert
            Assert.Equal(InvalidInputErrorMessage, expectedException.Message);
        }
    }
}
