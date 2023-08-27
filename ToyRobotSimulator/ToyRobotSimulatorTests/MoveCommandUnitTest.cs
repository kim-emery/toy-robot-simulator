﻿using Moq;
using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.Simulation;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulatorTests
{
    public class MoveCommandUnitTest
    {
        public readonly Mock<IRobot> _robotMock = new();  
        public readonly Mock<ITableTop> _tableTopMock = new();
        
        [Fact]
        public void Validate_RobotIsPlaced_Success()
        {
            _robotMock.Setup(x => x.IsPlaced()).Returns(true);
            _tableTopMock.Setup(x => x.IsValidPlacement(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            
            // Arrange
            var moveCommand = new MoveCommand();

            // Act
            var isValidated = moveCommand.Validate(_robotMock.Object, _tableTopMock.Object);

            // Assert
            Assert.True(isValidated);
        }

        [Fact]
        public void Validate_RobotIsNotPlaced_Failure()
        {
            _robotMock.Setup(x => x.IsPlaced()).Returns(false);
            _tableTopMock.Setup(x => x.IsValidPlacement(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            // Arrange
            var moveCommand = new MoveCommand();
            var expectedException = Assert.Throws<ValidationException>(() => moveCommand.Validate(_robotMock.Object, _tableTopMock.Object));

            // Assert
            Assert.Equal(RobotNotPlacedErrorMessage, expectedException.Message);
        }
    }
}
