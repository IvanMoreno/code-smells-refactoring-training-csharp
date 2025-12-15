using System;

namespace SmellyMarsRover;

internal record Direction(string Value)
{
    private const string NORTH = "N";
    private const string WEST = "W";
    private const string SOUTH = "S";
    private const string EAST = "E";

    public static Direction CreateInstance(string Value) {
        if (Value.Equals(NORTH))
        {
            return new North();
        }
        
        return new Direction(Value);
    }

    public virtual Direction RotateLeft()
    {
        if (Value.Equals(NORTH)) {
            throw new NotImplementedException("Should be unreachable");
        }

        if (Value.Equals(SOUTH))
        {
            return CreateInstance(EAST);
        }
        
        if (Value.Equals(WEST))
        {
            return CreateInstance(SOUTH);
        }
        
        return CreateInstance(NORTH);
    }

    public Direction RotateRight()
    {
        if (Value.Equals(NORTH))
        {
            return CreateInstance(EAST);
        }

        if (Value.Equals(SOUTH))
        {
            return CreateInstance(WEST);
        }
        
        if (Value.Equals(WEST))
        {
            return CreateInstance(NORTH);
        }
        
        return CreateInstance(SOUTH);
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
    
    private record North : Direction
    {
        public North() : base("N")
        {
        }

        public override Direction RotateLeft() {
            return CreateInstance(WEST);
        }
    }
}