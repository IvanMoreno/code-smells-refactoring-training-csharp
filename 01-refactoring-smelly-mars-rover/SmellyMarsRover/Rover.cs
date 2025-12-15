using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SmellyMarsRover
{
    public record CommandsSequence(string encodedCommands, List<RoverCommand> commands) : IEnumerable<RoverCommand> {
        public static implicit operator CommandsSequence(string encodedCommands) => Create(encodedCommands);

        public static CommandsSequence Create(string encodedCommands) => new(encodedCommands, ParseCommands(encodedCommands));

        public static List<RoverCommand> ParseCommands(string encodedCommands)
        {
            return encodedCommands.Select((_, i) => RoverCommandMapper.CreateInstance(encodedCommands.Substring(i, 1))).ToList();
        }

        public IEnumerator<RoverCommand> GetEnumerator() {
            return commands.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
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
        
        public void Receive(CommandsSequence commandsSequence)
        {
            commandsSequence.ToList().ForEach(command => command.ExecuteOn(this));
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
            if (obj.GetType() != GetType()) return false;
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