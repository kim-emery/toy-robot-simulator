using Microsoft.Extensions.Options;

namespace ToyRobotSimulator.TableTop
{
    public class SquareTableTop : ITableTop
    {
        private readonly TableTopConfig _tableTopConfig;
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public SquareTableTop(IOptions<TableTopConfig> options)
        {
            _tableTopConfig = options.Value;
            Rows = options.Value.Size;
            Columns = options.Value.Size;
        }

        // check valid position
        public (int, int) GetDimensions()
        {
            return (Rows, Columns);
        }
    }
}
