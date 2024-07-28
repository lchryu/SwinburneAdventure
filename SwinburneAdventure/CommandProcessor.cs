namespace SwinburneAdventure;

using System.Collections.Generic;

public class CommandProcessor
{
    private Dictionary<string, Command> _commands;

    public CommandProcessor()
    {
        _commands = new Dictionary<string, Command>();
    }

    public void RegisterCommand(Command command)
    {
        foreach (var id in command.Identifiers)
        {
            _commands[id.ToLower()] = command;
        }
    }

    public string ExecuteCommand(Player player, string[] commandParts)
    {
        if (commandParts.Length == 0)
        {
            return "I don't understand that command.";
        }

        string commandName = commandParts[0].ToLower();
        if (_commands.ContainsKey(commandName))
        {
            return _commands[commandName].Execute(player, commandParts);
        }

        return "I don't understand that command.";
    }
}