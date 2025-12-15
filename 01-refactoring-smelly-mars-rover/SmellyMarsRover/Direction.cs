namespace SmellyMarsRover;

internal record Direction(string Value)
{
    private const string NORTH = "N";
    private const string WEST = "W";
    private const string SOUTH = "S";
    private const string EAST = "E";

    public Direction RotateLeft()
    {
        if (Value.Equals(NORTH))
        {
            return new(WEST);
        }

        if (Value.Equals(SOUTH))
        {
            return new(EAST);
        }
        
        if (Value.Equals(WEST))
        {
            return new(SOUTH);
        }
        
        return new(NORTH);
    }

    public Direction RotateRight()
    {
        if (Value.Equals(NORTH))
        {
            return new(EAST);
        }

        if (Value.Equals(SOUTH))
        {
            return new(WEST);
        }
        
        if (Value.Equals(WEST))
        {
            return new(NORTH);
        }
        
        return new(SOUTH);
    }

    public Coordinates Move(int displacement, Coordinates from)
    {
        if (Value.Equals(NORTH))
        {
            return new(from.x, from.y + displacement);
        }

        if (Value.Equals(SOUTH))
        {
            return new(from.x, from.y - displacement);
        }
        
        if (Value.Equals(WEST))
        {
            return new(from.x - displacement, from.y);
        }
        
        return new(from.x + displacement, from.y);
    }
}