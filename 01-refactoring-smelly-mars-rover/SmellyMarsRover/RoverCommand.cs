namespace SmellyMarsRover;

public abstract record RoverCommand {
    public abstract void ExecuteOn(Rover rover);

    internal record RotateLeft : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.RotateLeft();
    }
    
    internal record RotateRight : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.RotateRight();
    }
    
    internal record MoveForward : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.MoveForward();
    }
    
    internal record MoveBackward : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.MoveBackwards();
    }
}