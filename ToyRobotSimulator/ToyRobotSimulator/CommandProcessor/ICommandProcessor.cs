namespace ToyRobotSimulator.Simulation
{
    public interface ICommandProcessor
    {
        public ICommand CreateCommand(string commandInput);
    }
}
