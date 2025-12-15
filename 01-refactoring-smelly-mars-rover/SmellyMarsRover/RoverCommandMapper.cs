namespace SmellyMarsRover;

internal static class RoverCommandMapper {
    private const int DISPLACEMENT_LENGTH = 1;
    
    public static RoverCommand CreateInstance(string encodedCommand) =>
            encodedCommand switch {
                    "l" => new RoverCommand.RotateLeft(),
                    "r" => new RoverCommand.RotateRight(),
                    "f" => new RoverCommand.Move(DISPLACEMENT_LENGTH),
                    _ => new RoverCommand.Move(-DISPLACEMENT_LENGTH)
            };
}