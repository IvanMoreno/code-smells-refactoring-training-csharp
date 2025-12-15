using System;
using System.Collections.Generic;
using System.Linq;

namespace SmellyMarsRover
{
    public record RoverCommand(string value);
    
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
            ParseCommands2(commandsSequence).ForEach(ExecuteCommand2);
        }

        static List<RoverCommand> ParseCommands2(string commandsSequence)
        {
            return commandsSequence.Select((_, i) => new RoverCommand(commandsSequence.Substring(i, 1))).ToList();
        }

        void ExecuteCommand2(RoverCommand command)
        {
            if (command.value.Equals("l"))
            {
                RotateLeft();
            }
            else if (command.value.Equals("r")) // Magic literal
            {
                RotateRight();
            }
            else if (command.value.Equals("f"))
            {
                MoveForward();
            }
            else
            {
                MoveBackwards();
            }
        }

        private void MoveBackwards() {
            coordinates = direction.Move(-1, coordinates);
        }

        private void MoveForward() {
            coordinates = direction.Move(1, coordinates);
        }

        private void RotateRight() {
            direction = direction.RotateRight();
        }

        private void RotateLeft() {
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