namespace SmellyMarsRover;

internal static class DirectionMapper {
    private const string NORTH = "N";
    private const string WEST = "W";
    private const string SOUTH = "S";

    public static Direction CreateInstance(string encodedDirection) {
        if (encodedDirection.Equals(NORTH))
        {
            return Direction.North.Create();
        }
        
        if (encodedDirection.Equals(SOUTH))
        {
            return Direction.South.Create();
        }
        
        if (encodedDirection.Equals(WEST))
        {
            return Direction.West.Create();
        }
        
        return Direction.East.Create();
    }
}