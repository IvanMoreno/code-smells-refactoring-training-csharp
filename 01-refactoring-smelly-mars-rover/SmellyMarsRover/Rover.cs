using System;
using System.Collections.Generic;
using System.Linq;

namespace SmellyMarsRover
{
    public record RoverCommand(string value) {
        public void Execute2(Rover rover) {
            if (this.value.Equals("l"))
            {
                rover.RotateLeft();
            }
            else if (this.value.Equals("r")) // Magic literal
            {
                rover.RotateRight();
            }
            else if (this.value.Equals("f"))
            {
                rover.MoveForward();
            }
            else
            {
                rover.MoveBackwards();
            }
        }
    }

    public class Rover
    {
        Coordinates coordinates;
        Direction direction;

        public Rover(int x, int y, string direction)
        {
            this.direction = DirectionMapper.CreateInstance(direction);
            coordinates = new(x, y);
        }

        public void Receive(string commandsSequence) // Primitive obsession
        {
            ParseCommands(commandsSequence).ForEach(ExecuteCommand);
        }

        static List<RoverCommand> ParseCommands(string commandsSequence)
        {
            return commandsSequence.Select((_, i) => new RoverCommand(commandsSequence.Substring(i, 1))).ToList();
        }

        void ExecuteCommand(RoverCommand command) {
            Rover rover = this;
            command.Execute2(rover);
        }

        public void MoveBackwards() {
            coordinates = direction.Move(-1, coordinates);
        }

        public void MoveForward() {
            coordinates = direction.Move(1, coordinates);
        }

        public void RotateRight() {
            direction = direction.RotateRight();
        }

        public void RotateLeft() {
            direction = direction.RotateLeft();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rover)obj);
        }

        protected bool Equals(Rover other)
        {
            return Equals(coordinates, other.coordinates) && Equals(direction, other.direction);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(coordinates, direction);
        }

        public override string ToString()
        {
            return $"{nameof(coordinates)}: {coordinates}, {nameof(direction)}: {direction}";
        }
    }
}