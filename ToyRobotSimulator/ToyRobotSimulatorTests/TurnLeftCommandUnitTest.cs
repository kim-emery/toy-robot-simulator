using Moq;
using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.Simulation;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulatorTests
{
    public class TurnLeftCommandUnitTest
    {
        public readonly Mock<IRobot> _robotMock = new();  
        public readonly Mock<ITableTop> _tableTopMock = new();
        
        [Fact]
        public void Validate_RobotIsPlaced_Success()
        {
            //setup mock here
            _robotMock.Setup(x => x.IsPlaced()).Returns(true);
            
            // Arrange
            var turnLeftCommand = new TurnLeftCommand();

            // Act
            var isValidated = turnLeftCommand.Validate(_robotMock.Object, _tableTopMock.Object);

            // Assert
            Assert.True(isValidated);
            
        }

        [Fact]
        public void Validate_RobotIsNotPlaced_Failure()
        {
            //setup mock here
            _robotMock.Setup(x => x.IsPlaced()).Returns(false);

            // Arrange
            var turnLeftCommand = new TurnLeftCommand();


            var expectedException = Assert.Throws<ValidationException>(() => turnLeftCommand.Validate(_robotMock.Object, _tableTopMock.Object));

            // Assert
            Assert.Equal(RobotNotPlacedErrorMessage, expectedException.Message);
            
        }
    }
}
