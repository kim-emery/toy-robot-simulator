using Moq;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.Simulation;
using ToyRobotSimulator.TableTop;

namespace ToyRobotSimulatorTests
{
    public class SimulationManagerUnitTest
    {
        private readonly Mock<IRobot> _robotMock = new();
        private readonly Mock<ITableTop> _tableTopMock = new();
        private readonly Mock<ICommandProcessor> _commandProcessorMock = new();
        private readonly Mock<ICommand> _mockCommand = new();
        private readonly string testString = "test";

        [Fact]
        public void HandleCommand_ValidCommandExecutes_Success()
        {
            _mockCommand.Setup(x => x.Validate(_robotMock.Object, _tableTopMock.Object)).Returns(true);
            _commandProcessorMock.Setup(x => x.CreateCommand(It.IsAny<string>())).Returns(_mockCommand.Object);

            // Arrange
            var simulationManager = new SimulationManager(_robotMock.Object, _tableTopMock.Object, _commandProcessorMock.Object);

            // Act
            var exception = Record.Exception(() => simulationManager.HandleCommand(testString));

            // Assert
            _mockCommand.Verify(x => x.Validate(It.IsAny<IRobot>(), It.IsAny<ITableTop>()), Times.Once);
            _mockCommand.Verify(x => x.Execute(It.IsAny<IRobot>()), Times.Once);
            Assert.Null(exception);
        }

        [Fact]
        public void HandleCommand_CommandDoesNotValidate_DoesNotExecute()
        {
            _mockCommand.Setup(x => x.Validate(_robotMock.Object, _tableTopMock.Object)).Throws<Exception>();
            _commandProcessorMock.Setup(x => x.CreateCommand(It.IsAny<string>())).Returns(_mockCommand.Object);

            // Arrange
            var simulationManager = new SimulationManager(_robotMock.Object, _tableTopMock.Object, _commandProcessorMock.Object);

            // Act
            var expectedException = Assert.Throws<Exception>(() => simulationManager.HandleCommand(testString));

            // Assert
            _mockCommand.Verify(x => x.Validate(It.IsAny<IRobot>(), It.IsAny<ITableTop>()), Times.Once);
            _mockCommand.Verify(x => x.Execute(It.IsAny<IRobot>()), Times.Never);
        }
    }
}
