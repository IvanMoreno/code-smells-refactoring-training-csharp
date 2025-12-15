namespace SmellyMarsRover;

internal abstract record Direction
{
    public abstract Direction RotateLeft();
    public abstract Direction RotateRight();
    public abstract Coordinates Move(int displacement, Coordinates from);

    internal record North : Direction
    {
        public override Direction RotateLeft() {
            return Direction.West.Create();
        }

        public override Direction RotateRight() {
            return Direction.East.Create();
        }

        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x, from.y + displacement);
        }

        public static Direction.North Create() {
            return new Direction.North();
        }
    }
    
    internal record South : Direction
    {
        public override Direction RotateLeft() {
            return Direction.East.Create();
        }

        public override Direction RotateRight() {
            return Direction.West.Create();
        }

        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x, from.y - displacement);
        }

        public static Direction.South Create() {
            return new Direction.South();
        }
    }
    
    internal record West : Direction
    {
        public override Direction RotateLeft() {
            return Direction.South.Create();
        }

        public override Direction RotateRight() {
            return Direction.North.Create();
        }

        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x - displacement, from.y);
        }

        public static Direction.West Create() {
            return new Direction.West();
        }
    }
    
    internal record East : Direction
    {
        public override Direction RotateLeft() {
            return Direction.North.Create();
        }

        public override Direction RotateRight() {
            return Direction.South.Create();
        }

        public override Coordinates Move(int displacement, Coordinates from)
        {
            return new(from.x + displacement, from.y);
        }

        public static Direction.East Create() {
            return new Direction.East();
        }
    }
}