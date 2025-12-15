namespace SmellyMarsRover;

internal static class RoverCommandMapper {
    public static RoverCommand CreateInstance(string encodedCommand) {
        if (encodedCommand.Equals("l"))
        {
            return new RoverCommand.RotateLeftCommand();
        }
        
        if (encodedCommand.Equals("r"))
        {
            return new RoverCommand.RotateRightCommand();
        }
        
        if (encodedCommand.Equals("f"))
        {
            return new RoverCommand.MoveForwardCommand();
        }
        
        return new RoverCommand.MoveBackwardCommand();
    }
}