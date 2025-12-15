namespace SmellyMarsRover;

internal static class RoverCommandMapper {
    public static RoverCommand CreateInstance(string encodedCommand) =>
            encodedCommand switch {
                    "l" => new RoverCommand.RotateLeft(),
                    "r" => new RoverCommand.RotateRight(),
                    "f" => new RoverCommand.MoveForward(),
                    _ => new RoverCommand.MoveBackward()
            };
}