namespace SmellyMarsRover;

internal static class RoverCommandMapper {
    public static RoverCommand CreateInstance(string encodedCommand) {
        if (encodedCommand.Equals("l"))
        {
            return new RoverCommand.RotateLeft();
        }
        
        if (encodedCommand.Equals("r"))
        {
            return new RoverCommand.RotateRight();
        }
        
        if (encodedCommand.Equals("f"))
        {
            return new RoverCommand.MoveForward();
        }
        
        return new RoverCommand.MoveBackward();
    }
}