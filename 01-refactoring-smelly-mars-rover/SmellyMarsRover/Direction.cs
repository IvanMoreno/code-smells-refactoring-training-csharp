namespace SmellyMarsRover;

internal abstract record Direction
{
    private const string NORTH = "N";
    private const string WEST = "W";
    private const string SOUTH = "S";

    public static Direction CreateInstance(string Value) {
        if (Value.Equals(NORTH))
        {
            return North.Create();
        }
        
        if (Value.Equals(SOUTH))
        {
            return South.Create();
        }
        
        if (Value.Equals(WEST))
        {
            return West.Create();
        }
        
        return East.Create();
    }

    public abstract Direction RotateLeft();
    public abstract Direction RotateRight();
    public abstract Coordinates Move(int displacement, Coordinates from);

    internal record North : Direction
    {
        public override Direction RotateLeft() {
            return West.Create();
        }

        public override Direction RotateRight() {
            return East.Create();
        }

        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x, from.y + displacement);
        }

        public static North Create() {
            return new North();
        }
    }
    
    internal record South : Direction
    {
        public override Direction RotateLeft() {
            return East.Create();
        }

        public override Direction RotateRight() {
            return West.Create();
        }

        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x, from.y - displacement);
        }

        public static South Create() {
            return new South();
        }
    }
    
    internal record West : Direction
    {
        public override Direction RotateLeft() {
            return South.Create();
        }

        public override Direction RotateRight() {
            return North.Create();
        }

        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x - displacement, from.y);
        }

        public static West Create() {
            return new West();
        }
    }
    
    internal record East : Direction
    {
        public override Direction RotateLeft() {
            return North.Create();
        }

        public override Direction RotateRight() {
            return South.Create();
        }

        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x + displacement, from.y);
        }

        public static East Create() {
            return new East();
        }
    }
}