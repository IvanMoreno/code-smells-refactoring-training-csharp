using System;

namespace SmellyMarsRover;

internal abstract record RoverCommand(string value) {
    public static RoverCommand CreateInstance(string value) {
        if (value.Equals("l"))
        {
            return new RotateLeftCommand();
        }
        
        if (value.Equals("r"))
        {
            return new RotateRightCommand();
        }
        
        if (value.Equals("f"))
        {
            return new MoveForwardCommand();
        }
        
        return new MoveBackwardCommand();
    }

    public abstract void ExecuteOn(Rover rover);

    internal record RotateLeftCommand : RoverCommand {
        public RotateLeftCommand() : base("l") { }
        
        public override void ExecuteOn(Rover rover) {
            rover.RotateLeft();
        }
    }
    
    internal record RotateRightCommand : RoverCommand {
        public RotateRightCommand() : base("r") { }
        
        public override void ExecuteOn(Rover rover) {
            rover.RotateRight();
        }
    }
    
    internal record MoveForwardCommand : RoverCommand {
        public MoveForwardCommand() : base("f") { }
        
        public override void ExecuteOn(Rover rover) {
            rover.MoveForward();
        }
    }
    
    internal record MoveBackwardCommand : RoverCommand {
        public MoveBackwardCommand() : base("b") { }
        
        public override void ExecuteOn(Rover rover) {
            rover.MoveBackwards();
        }
    }
}