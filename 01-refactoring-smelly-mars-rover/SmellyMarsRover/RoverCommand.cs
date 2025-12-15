namespace SmellyMarsRover;

public record RoverCommand(string value) {
    public void ExecuteOn(Rover rover) {
        if (value.Equals("l"))
        {
            rover.RotateLeft();
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
}