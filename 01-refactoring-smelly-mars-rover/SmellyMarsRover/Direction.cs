using System;

namespace SmellyMarsRover;

internal abstract record Direction(string Value)
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
        
        if (Value.Equals(SOUTH))
        {
            return new South();
        }
        
        if (Value.Equals(WEST))
        {
            return new West();
        }
        
        return new East();
    }

    public abstract Direction RotateLeft();

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
    
    private record South : Direction
    {
        public South() : base("S")
        {
        }
        
        public override Direction RotateLeft() {
            return CreateInstance(EAST);
        }
    }
    
    private record West : Direction
    {
        public West() : base("W")
        {
        }
        
        public override Direction RotateLeft() {
            return CreateInstance(SOUTH);
        }
    }
    
    private record East : Direction
    {
        public East() : base("E")
        {
        }
        
        public override Direction RotateLeft() {
            return CreateInstance(NORTH);
        }
    }
}