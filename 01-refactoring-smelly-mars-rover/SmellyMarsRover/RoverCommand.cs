namespace SmellyMarsRover;

internal abstract record RoverCommand {
    public abstract void ExecuteOn(Rover rover);

    internal record RotateLeftCommand : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.RotateLeft();
    }
    
    internal record RotateRightCommand : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.RotateRight();
    }
    
    internal record MoveForwardCommand : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.MoveForward();
    }
    
    internal record MoveBackwardCommand : RoverCommand {
        public override void ExecuteOn(Rover rover) => rover.MoveBackwards();
    }
}