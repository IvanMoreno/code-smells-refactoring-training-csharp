namespace SmellyMarsRover;

internal static class DirectionMapper {
    public static Direction CreateInstance(string encodedDirection) =>
            encodedDirection switch {
                    "N" => Direction.North.Create(),
                    "S" => Direction.South.Create(),
                    "W" => Direction.West.Create(),
                    _ => Direction.East.Create()
            };
}