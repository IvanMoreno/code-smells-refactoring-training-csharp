namespace SmellyMarsRover;

internal static class DirectionMapper {
    public static Direction CreateInstance(string encodedDirection) {
        if (encodedDirection.Equals("N"))
        {
            return Direction.North.Create();
        }
        
        if (encodedDirection.Equals("S"))
        {
            return Direction.South.Create();
        }
        
        if (encodedDirection.Equals("W"))
        {
            return Direction.West.Create();
        }
        
        return Direction.East.Create();
    }
}