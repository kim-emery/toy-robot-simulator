using Moq;
using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.Simulation;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulatorTests
{
    public class TurnRightCommandUnitTest
    {
        public readonly Mock<IRobot> _robotMock = new();
        public readonly Mock<ITableTop> _tableTopMock = new();

        [Fact]
        public void Validate_RobotIsPlaced_Success()
        {
            _robotMock.Setup(x => x.IsPlaced()).Returns(true);

            // Arrange
            var turnRightCommand = new TurnRightCommand();

            // Act
            var isValidated = turnRightCommand.Validate(_robotMock.Object, _tableTopMock.Object);

            // Assert
            Assert.True(isValidated);
        }

        [Fact]
        public void Validate_RobotIsNotPlaced_Failure()
        {
            _robotMock.Setup(x => x.IsPlaced()).Returns(false);

            // Arrange
            var turnRightCommand = new TurnRightCommand();

            var expectedException = Assert.Throws<ValidationException>(() => turnRightCommand.Validate(_robotMock.Object, _tableTopMock.Object));

            // Assert
            Assert.Equal(RobotNotPlacedErrorMessage, expectedException.Message);
        }
    }
}
