using ToyRobotSimulator.Input;
using Moq;
using ToyRobotSimulator.Simulation;
using ToyRobotSimulator.Robot;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulatorTests
{
    public class CommandProcessorUnitTest
    {
        private readonly Mock<IInputHandler> _inputHandlerMock = new();
        private readonly string genericCommandString = "doesNotMatterWhatIsInHere";
        
        [Fact]
        public void CreateCommand_Move_Success()
        {
            //setup mock here, isolate behaviour of inputhandler
            _inputHandlerMock.Setup(x => x.ParseRawInput(It.IsAny<string>())).Returns(new string[]{"move"});
            _inputHandlerMock.Setup(x => x.ValidateDefaultCommand(It.IsAny<string[]>())).Returns(RobotCommand.MOVE);

            // Arrange
            var commandProcessor = new CommandProcessor(_inputHandlerMock.Object);

            // Act
            var commandCreated = commandProcessor.CreateCommand(genericCommandString);

            // Assert
            Assert.True(commandCreated.GetType() == typeof(MoveCommand));
            _inputHandlerMock.Verify(x => x.ParseRawInput(It.IsAny<string>()), Times.Once);
            _inputHandlerMock.Verify(x => x.ValidateDefaultCommand(It.IsAny<string[]>()), Times.Once);
        }

        [Fact]
        public void CreateCommand_Right_Success()
        {
            //setup mock here, isolate behaviour of inputhandler
            _inputHandlerMock.Setup(x => x.ParseRawInput(It.IsAny<string>())).Returns(new string[] { "right" });
            _inputHandlerMock.Setup(x => x.ValidateDefaultCommand(It.IsAny<string[]>())).Returns(RobotCommand.RIGHT);

            // Arrange
            var commandProcessor = new CommandProcessor(_inputHandlerMock.Object);

            // Act
            var commandCreated = commandProcessor.CreateCommand(genericCommandString);

            // Assert
            Assert.True(commandCreated.GetType() == typeof(TurnRightCommand));
            _inputHandlerMock.Verify(x => x.ParseRawInput(It.IsAny<string>()), Times.Once);
            _inputHandlerMock.Verify(x => x.ValidateDefaultCommand(It.IsAny<string[]>()), Times.Once);
        }

        [Fact]
        public void CreateCommand_Left_Success()
        {
            //setup mock here, isolate behaviour of inputhandler
            _inputHandlerMock.Setup(x => x.ParseRawInput(It.IsAny<string>())).Returns(new string[] { "left" });
            _inputHandlerMock.Setup(x => x.ValidateDefaultCommand(It.IsAny<string[]>())).Returns(RobotCommand.LEFT);

            // Arrange
            var commandProcessor = new CommandProcessor(_inputHandlerMock.Object);

            // Act
            var commandCreated = commandProcessor.CreateCommand(genericCommandString);

            // Assert
            Assert.True(commandCreated.GetType() == typeof(TurnLeftCommand));
            _inputHandlerMock.Verify(x => x.ParseRawInput(It.IsAny<string>()), Times.Once);
            _inputHandlerMock.Verify(x => x.ValidateDefaultCommand(It.IsAny<string[]>()), Times.Once);
        }

        [Fact]
        public void CreateCommand_Report_Success()
        {
            //setup mock here, isolate behaviour of inputhandler
            _inputHandlerMock.Setup(x => x.ParseRawInput(It.IsAny<string>())).Returns(new string[] { "report" });
            _inputHandlerMock.Setup(x => x.ValidateDefaultCommand(It.IsAny<string[]>())).Returns(RobotCommand.LEFT);

            // Arrange
            var commandProcessor = new CommandProcessor(_inputHandlerMock.Object);

            // Act
            var commandCreated = commandProcessor.CreateCommand(genericCommandString);

            // Assert
            Assert.True(commandCreated.GetType() == typeof(ReportCommand));
            _inputHandlerMock.Verify(x => x.ParseRawInput(It.IsAny<string>()), Times.Once);
            _inputHandlerMock.Verify(x => x.ValidateDefaultCommand(It.IsAny<string[]>()), Times.Once);
        }

        [Fact]
        public void CreateCommand_Place_Success()
        {
            //setup mock here, isolate behaviour of inputhandler
            _inputHandlerMock.Setup(x => x.ParseRawInput(It.IsAny<string>())).Returns(new string[] { "place" });
            _inputHandlerMock.Setup(x => x.ValidatePlaceCommand(It.IsAny<string[]>())).Returns(Tuple.Create(0, 0, Direction.NORTH));

            // Arrange
            var commandProcessor = new CommandProcessor(_inputHandlerMock.Object);

            // Act
            var commandCreated = commandProcessor.CreateCommand(genericCommandString);

            // Assert
            Assert.True(commandCreated.GetType() == typeof(PlaceCommand));
            _inputHandlerMock.Verify(x => x.ParseRawInput(It.IsAny<string>()), Times.Once);
            _inputHandlerMock.Verify(x => x.ValidatePlaceCommand(It.IsAny<string[]>()), Times.Once);
        }

        [Fact]
        public void CreateCommand_Failure_InvalidCommand()
        {
            //setup mock here, isolate behaviour of inputhandler
            _inputHandlerMock.Setup(x => x.ParseRawInput(It.IsAny<string>())).Returns(new string[] { "badinput" });
            //_inputHandlerMock.Setup(x => x.ValidateDefaultCommand(It.IsAny<string[]>())).Returns(RobotCommand.MOVE);

            // Arrange
            var exceptionType = typeof(ArgumentException);
            var commandProcessor = new CommandProcessor(_inputHandlerMock.Object);

            // Act
            var expectedException = Assert.Throws<ArgumentException>(() => commandProcessor.CreateCommand(genericCommandString));

            // Assert
            Assert.Equal(InvalidInputErrorMessage, expectedException.Message);
            _inputHandlerMock.Verify(x => x.ParseRawInput(It.IsAny<string>()), Times.Once);
            _inputHandlerMock.Verify(x => x.ValidateDefaultCommand(It.IsAny<string[]>()), Times.Never);
        }
    }
}