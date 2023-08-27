using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToyRobotSimulator.Input;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.Simulation;
using ToyRobotSimulator.TableTop;

namespace ToyRobotSimulator
{
    internal class Program
    {
        private const String TableTopConfigName = "TableTop";

        static void Main(string[] args)
        {
            IHost host = CreateHost(args);
            ISimulationManager manager = host.Services.GetRequiredService<ISimulationManager>();

            Console.WriteLine(ApplicationStrings.AppDescription);
            bool exitApplication = false;
            do
            {
                var command = Console.ReadLine();

                if (command == null) continue;

                if (command.ToUpper() == "EXIT")
                {
                    exitApplication = true;
                }
                else
                {
                    manager.HandleCommand(command);
                }
            } while (!exitApplication);
        }

        public static IHost CreateHost(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.Configure<TableTopConfig>(context.Configuration.GetSection(TableTopConfigName));
                services.AddScoped<ITableTop, SquareTableTop>();
                services.AddScoped<IRobot, ToyRobot>();
                services.AddScoped<IInputHandler, ConsoleInputHandler>();
                services.AddScoped<ICommandProcessor, CommandProcessor>();
                services.AddSingleton<ISimulationManager, SimulationManager>();
            })
            .Build();
    }
}