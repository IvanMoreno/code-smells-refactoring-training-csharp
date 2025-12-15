namespace SmellyMarsRover;

internal record Direction(string Value)
{
    public Direction RotateLeft()
    {
        if (Value.Equals("N"))
        {
            return new("W");
        }

        if (Value.Equals("S"))
        {
            return new("E");
        }
        
        if (Value.Equals("W"))
        {
            return new("S");
        }
        
        return new("N");
    }

    public Direction RotateRight()
    {
        if (Value.Equals("N"))
        {
            return new("E");
        }

        if (Value.Equals("S"))
        {
            return new("W");
        }
        
        if (Value.Equals("W"))
        {
            return new("N");
        }
        
        return new("S");
    }

    public Coordinates Move(int displacement, Coordinates from)
    {
        if (Value.Equals("N"))
        {
            return new(from.x, from.y + displacement);
        }

        if (Value.Equals("S"))
        {
            return new(from.x, from.y - displacement);
        }
        
        if (Value.Equals("W"))
        {
            return new(from.x - displacement, from.y);
        }
        
        return new(from.x + displacement, from.y);
    }
}