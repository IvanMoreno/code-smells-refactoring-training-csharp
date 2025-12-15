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
    public abstract Direction RotateRight();
    public abstract Coordinates Move(int displacement, Coordinates from);

    private record North : Direction
    {
        public North() : base("N")
        {
        }

        public override Direction RotateLeft() {
            return CreateInstance(WEST);
        }
        
        public override Direction RotateRight() {
            return CreateInstance(EAST);
        }
        
        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x, from.y + displacement);
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
        
        public override Direction RotateRight() {
            return CreateInstance(WEST);
        }
        
        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x, from.y - displacement);
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
        
        public override Direction RotateRight() {
            return CreateInstance(NORTH);
        }
        
        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x - displacement, from.y);
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
        
        public override Direction RotateRight() {
            return CreateInstance(SOUTH);
        }
        
        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x + displacement, from.y);
        }
    }
}