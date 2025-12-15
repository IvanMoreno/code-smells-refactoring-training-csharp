namespace SmellyMarsRover;

internal static class DirectionMapper {
    private const string NORTH = "N";
    private const string WEST = "W";
    private const string SOUTH = "S";

    public static Direction CreateInstance(string value) {
        if (value.Equals(NORTH))
        {
            return Direction.North.Create();
        }
        
        if (value.Equals(SOUTH))
        {
            return Direction.South.Create();
        }
        
        if (value.Equals(WEST))
        {
            return Direction.West.Create();
        }
        
        return Direction.East.Create();
    }
}