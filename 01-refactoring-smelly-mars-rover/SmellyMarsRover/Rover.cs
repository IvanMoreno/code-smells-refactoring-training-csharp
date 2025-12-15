using System;
using System.Collections.Generic;
using System.Linq;

namespace SmellyMarsRover
{
    public class Rover
    {
        Coordinates coordinates;
        Direction direction;

        public Rover(int x, int y, string direction)
        {
            this.direction = Direction.CreateInstance(direction);
            coordinates = new(x, y);
        }

        public void Receive(string commandsSequence) // Primitive obsession
        {
            ParseCommands(commandsSequence).ForEach(ExecuteCommand);
        }

        static List<string> ParseCommands(string commandsSequence)
        {
            return commandsSequence.Select((_, i) => commandsSequence.Substring(i, 1)).ToList();
        }

        void ExecuteCommand(string command) // Primitive obsession
        {
            if (command.Equals("l"))
            {
                direction = direction.RotateLeft();
            }
            else if (command.Equals("r")) // Magic literal
            {
                direction = direction.RotateRight();
            }
            else if (command.Equals("f"))
            {
                coordinates = direction.Move(1, coordinates);
            }
            else
            {
                coordinates = direction.Move(-1, coordinates);
            }
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