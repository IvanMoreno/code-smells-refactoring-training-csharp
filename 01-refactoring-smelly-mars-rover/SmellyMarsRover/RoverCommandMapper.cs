namespace SmellyMarsRover;

internal static class RoverCommandMapper {
    public static RoverCommand CreateInstance(string encodedCommand) =>
            encodedCommand switch {
                    "l" => new RoverCommand.RotateLeft(),
                    "r" => new RoverCommand.RotateRight(),
                    "f" => new RoverCommand.Move(1),
                    _ => new RoverCommand.Move(-1)
            };
}