using System.ComponentModel.DataAnnotations;
using ToyRobotSimulator.Robot;
using ToyRobotSimulator.TableTop;
using static ToyRobotSimulator.ApplicationStrings;

namespace ToyRobotSimulator.Simulation
{
    public class MoveCommand : ICommand
    {
        public MoveCommand()
        {
        }

        public void Execute(IRobot Robot)
        {
            //swap to place
            var (nextPositionX, nextPositionY) = Robot.GetNextPositionAfterStep();
            //simplify this!
            var (currentPositionX, currentPositionY, currentDirection) = Robot.GetCurrentPosition();
            Robot.Place(nextPositionX,nextPositionY, currentDirection);
        } 

        public bool Validate(IRobot Robot, ITableTop TableTop)
        {
            if (!Robot.IsPlaced()) throw new ValidationException(RobotNotPlacedErrorMessage);

            var (nextPositionX, nextPositionY) = Robot.GetNextPositionAfterStep();
            if (!TableTop.IsValidPlacement(nextPositionX, nextPositionY)) throw new ValidationException(PositionOutOfBoundsErrorMessage);
            
            return true;
        }
    }
}
