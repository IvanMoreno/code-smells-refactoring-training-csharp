using System;

namespace SmellyMarsRover;

internal record RoverCommand(string value) {
    public static RoverCommand CreateInstance(string value) {
        if (value.Equals("l"))
        {
            return new RotateLeftCommand();
        }
        
        return new RoverCommand(value);
    }

    public virtual void ExecuteOn(Rover rover) {
        if (value.Equals("l"))
        {
            throw new InvalidOperationException("Use RotateLeftCommand for 'l' command");
        }
        else if (value.Equals("r")) // Magic literal
        {
            rover.RotateRight();
        }
        else if (value.Equals("f"))
        {
            rover.MoveForward();
        }
        else
        {
            rover.MoveBackwards();
        }
    }

    internal record RotateLeftCommand : RoverCommand {
        public RotateLeftCommand() : base("l") { }
        
        public override void ExecuteOn(Rover rover) {
            rover.RotateLeft();
        }
    }
}