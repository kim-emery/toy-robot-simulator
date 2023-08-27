using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;

namespace ToyRobotSimulator.Simulation
{
    public class SimulationManager : ISimulationManager
    {
        private readonly IRobot _toyRobot;
        private readonly ITableTop _tableTop;
        private readonly ICommandProcessor _commandProcessor;

        public SimulationManager(IRobot toyRobot, ITableTop tableTop, ICommandProcessor commandProcessor)
        {
            _toyRobot = toyRobot;
            _tableTop = tableTop;
            _commandProcessor = commandProcessor;
        }

        public void HandleCommand(string commandInput)
        {
            try
            {
                ICommand command = _commandProcessor.CreateCommand(commandInput);
                if (command.Validate(_toyRobot, _tableTop)) command.Execute(_toyRobot);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
 