// This is the Robot class that represents a robot with properties and methods for controlling its behavior.
// It provides functionality for loading commands, running the commands, and maintaining the robot's position and power state.
// The class implements the ICommand interface for command execution.
// Note: The implementation of RobotCommand and ICommand interfaces is not provided in this code snippet.
// Make sure to define them correctly and include their respective code in your implementation.

// Change to 'using Assignment.InterfaceCommand' when you are ready to test your interface implementation
using Assignment.InterfaceCommand;

namespace Assignment;

public class Robot
{
    // These are properties, you can replace these with traditional getters/setters if you prefer.
    public int NumCommands { get; }

    // These properties are not good! The setter allows
    // us to move the robot even if it off
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }

    private const int DefaultCommands = 6;
    // An array is not the preferred data structure here.
    // You will get bonus marks if you replace the array with the preferred data structure
    // Hint: It is NOT a list either,
    private readonly RobotCommand[] _commands;
    private int _commandsLoaded = 0;

    public override string ToString()
    {
        return $"[{X} {Y} {IsPowered}]";
    }

    // You should not have to use any of the methods below here but you should
    // provide XML documentation for the argumented constructor, the Run method and one
    // of the LoadCommand methods.
    public Robot() : this(DefaultCommands) { }

    /// <summary>
    /// Constructor that initializes the robot with the capacity to store a user specified
    /// number of commands
    /// </summary>
    /// <param name="numCommands">The maximum number of commands the robot can store</param>
    public Robot(int numCommands)
    {
        _commands = new RobotCommand[numCommands];
        NumCommands = numCommands;
    }

    /// <summary>
    /// Runs the loaded commands sequentially, executing them on the robot.
    /// </summary>
    public void Run()
    {
        for (var i = 0; i < _commandsLoaded; ++i)
        {
            _commands[i].Run(this);
            Console.WriteLine(this);
        }
    }

    /// <summary>
    /// Loads a command into the robot's command storage.
    /// </summary>
    /// <param name="command">The command to be loaded</param>
    /// <returns>True if the command was successfully loaded, false otherwise</returns>
    public bool LoadCommand(RobotCommand command)
    {
        if (_commandsLoaded >= NumCommands)
            return false;
        _commands[_commandsLoaded++] = command;
        return true;
    }
}
