using ToyRobotSimulator.Robot;

namespace ToyRobotSimulatorTests
{
    public class RobotUnitTest
    {
        [Fact]
        public void Place_UpdatesProperties_Success()
        {
            // Arrange
            int xPlacement = 1;
            int yPlacement = 2;
            Direction direction = Direction.NORTH;
            var robot = new ToyRobot();

            // Act
            robot.Place(xPlacement, yPlacement, direction);

            // Assert
            var (currentPositionX, currentPositionY, currentDirection) = robot.GetCurrentPosition();
            Assert.Equal(currentPositionX, xPlacement);
            Assert.Equal(currentPositionY, yPlacement);
            Assert.Equal(currentDirection, direction);
            Assert.True(robot.IsPlaced());
        }

        [Theory]
        [InlineData(Direction.NORTH, Direction.EAST)]
        [InlineData(Direction.EAST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.NORTH)]

        public void TurnRight_Success(Direction initialDirection, Direction resultDirection)
        {
            // Arrange
            int xPlacement = 1;
            int yPlacement = 2;
            Direction direction = initialDirection;
            var robot = new ToyRobot();
            robot.Place(xPlacement, yPlacement, direction);

            // Act
            robot.TurnRight();
            var currentDirection = robot.FaceDirection;
            
            // Assert
            Assert.Equal(resultDirection, currentDirection);
        }

        [Theory]
        [InlineData(Direction.NORTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.EAST)]
        [InlineData(Direction.EAST, Direction.NORTH)]
        public void TurnLeft_Success(Direction initialDirection, Direction resultDirection)
        {
            // Arrange
            int xPlacement = 1;
            int yPlacement = 2;
            Direction direction = initialDirection;
            var robot = new ToyRobot();
            robot.Place(xPlacement, yPlacement, direction);

            // Act
            robot.TurnLeft();
            var currentDirection = robot.FaceDirection;

            // Assert
            Assert.Equal(resultDirection, currentDirection);
        }


        [Theory]
        [InlineData(Direction.NORTH, 2, 3)]
        [InlineData(Direction.SOUTH, 2, 1)]
        [InlineData(Direction.WEST, 1, 2)]
        [InlineData(Direction.EAST, 3, 2)]
        public void GetNextPositionAfterStep_Success(Direction direction, int expectedXPlacment, int expectedYPlacement)
        {
            // Arrange
            int xPlacement = 2;
            int yPlacement = 2;
            var robot = new ToyRobot();
            robot.Place(xPlacement, yPlacement, direction);

            // Act
            var (resultXPlacement, resultYPlacement) = robot.GetNextPositionAfterStep();

            // Assert
            var currentDirection = robot.FaceDirection;

            Assert.Equal(direction, currentDirection);
            Assert.Equal(resultXPlacement, expectedXPlacment);
            Assert.Equal(resultYPlacement, expectedYPlacement);
        }
    }
}
