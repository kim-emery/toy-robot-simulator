using Microsoft.Extensions.Options;
using Moq;
using ToyRobotSimulator;
using ToyRobotSimulator.TableTop;

namespace ToyRobotSimulatorTests
{
    public class TableTopUnitTest
    {
        [Theory]
        [InlineData(5, 0, 0)]
        [InlineData(5, 1, 0)]
        [InlineData(5, 2, 0)]
        [InlineData(5, 3, 0)]
        [InlineData(5, 4, 0)]
        [InlineData(5, 1, 1)]
        [InlineData(5, 2, 2)]
        [InlineData(5, 3, 3)]
        [InlineData(5, 4, 4)]
        public void IsValidPlacement_WhenRowIndexValid_Success(int tableSize, int xPlacement, int yPlacement)
        {
            TableTopConfig tableTopConfig = new TableTopConfig() { Size = tableSize };
            var _tableTopOptionsMock = new Mock<IOptions<TableTopConfig>>();
            _tableTopOptionsMock.Setup(x => x.Value).Returns(tableTopConfig);

            // Arrange
            ITableTop tableTop = new SquareTableTop(_tableTopOptionsMock.Object);

            // Act
            bool isValidPlacement = tableTop.IsValidPlacement(xPlacement, yPlacement);

            // Assert
            Assert.True(isValidPlacement);
        }

        [Theory]
        [InlineData(5, 5, 0)]
        [InlineData(5, 0, 5)]
        [InlineData(5, 6, 0)]
        [InlineData(5, 0, 6)]
        [InlineData(5, -1, 0)]
        [InlineData(5, 0, -1)]
        public void IsInvalidPlacement_WhenRowIndexOutOfBounds_Fail(int tableSize, int xPlacement, int yPlacement)
        {
            TableTopConfig tableTopConfig = new TableTopConfig() { Size = tableSize };
            var _tableTopOptionsMock = new Mock<IOptions<TableTopConfig>>();
            _tableTopOptionsMock.Setup(x => x.Value).Returns(tableTopConfig);

            // Arrange
            ITableTop tableTop = new SquareTableTop(_tableTopOptionsMock.Object);

            // Act
            bool isValidPlacement = tableTop.IsValidPlacement(xPlacement, yPlacement);

            // Assert
            Assert.False(isValidPlacement);
        }
    }
}
