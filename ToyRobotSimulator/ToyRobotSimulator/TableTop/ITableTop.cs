namespace ToyRobotSimulator.TableTop
{
    public interface ITableTop
    {
        public (int, int) GetDimensions();
        public bool IsValidPlacement(int rowIndex, int columnIndex);
    }
}
