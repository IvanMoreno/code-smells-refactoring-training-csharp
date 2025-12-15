namespace SmellyMarsRover;

public abstract record RoverCommand {
    public abstract void ExecuteOn(Rover rover);

    internal record RotateLeft : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.RotateLeft();
    }
    
    internal record RotateRight : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.RotateRight();
    }
    
    internal record Move(int Displacement) : RoverCommand {
        public override void ExecuteOn(Rover rover) {
            rover.Move(Displacement);
        }
    }
    
    internal record MoveForward() : Move(1) {
    }
    
    internal record MoveBackward() : Move(-1) {
    }
}