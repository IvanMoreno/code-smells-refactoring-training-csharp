using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SmellyMarsRover;

public record CommandsSequence(IEnumerable<RoverCommand> Commands) : IEnumerable<RoverCommand> {
    public static implicit operator CommandsSequence(string encodedCommands) => Create(encodedCommands);

    public static CommandsSequence Create(string encodedCommands) => new(ParseCommands(encodedCommands));

    public static IEnumerable<RoverCommand> ParseCommands(string encodedCommands)
    {
        return encodedCommands.Select(i => RoverCommandMapper.CreateInstance(i.ToString()));
    }

    public IEnumerator<RoverCommand> GetEnumerator() {
        return Commands.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}