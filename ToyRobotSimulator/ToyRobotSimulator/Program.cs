using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Input;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.Simulation;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulator
{
    public class Program
    {
        private const string TableTopConfigName = "TableTop";
   
        static void Main(string[] args)
        {
            IHost host = CreateHost(args);
            ISimulationManager manager = host.Services.GetRequiredService<ISimulationManager>();
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
            int tableTopSize = config.GetValue<int>($"{TableTopConfigName}:Size");

            Console.WriteLine(AppDescription, tableTopSize, tableTopSize);

            bool exitApplication = false;
            do
            {
                var command = Console.ReadLine();

                if (string.IsNullOrEmpty(command)) continue;

                if (command.ToUpper() == "EXIT") exitApplication = true;

                else
                {
                    try
                    {
                        manager.HandleCommand(command);
                    }catch (Exception ex)
                    {
                        if (ex is ArgumentException) Console.WriteLine(ex.Message);
                        if (ex is ValidationException) Console.WriteLine(ex.Message);
                    }
                    
                }
            } while (!exitApplication);
       

            Console.WriteLine(AppExitMessage);
            Environment.Exit(0);
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