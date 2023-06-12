using System;
using Assignment;
using Assignment.InterfaceCommand; // Change to Assignment.InterfaceCommand when ready
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void RobotPropertiesTest()
        {
            // Create a new Robot instance with default number of commands
            Robot robot1 = new();
            Assert.AreEqual(robot1.NumCommands, 6);
            const int ExpectedCommands = 10;
            // Create a new Robot instance with a specified number of commands
            Robot robot2 = new(ExpectedCommands);
            Assert.AreEqual(robot2.NumCommands, ExpectedCommands);

            // Test the IsPowered property
            Assert.AreEqual(robot1.IsPowered, false);
            robot1.IsPowered = true;
            Assert.AreEqual(robot1.IsPowered, true);

            // Test the X property
            Assert.AreEqual(robot1.X, 0);
            // Moves the robot can move even though it is off!!
            // This is very bad! Not good encapsulation
            robot1.X = -5;
            Assert.AreEqual(robot1.X, -5);

            // Test the Y property
            Assert.AreEqual(robot1.Y, 0);
            robot1.Y = -5;
            Assert.AreEqual(robot1.Y, -5);

            // Test command assignments
            Console.WriteLine("Give 6 commands to the robot. Possible commands are:");
            Console.WriteLine("on");
            Console.WriteLine("off");
            Console.WriteLine("north");
            Console.WriteLine("south");
            Console.WriteLine("east");
            Console.WriteLine("west");

            RobotCommand[] commands = new RobotCommand[6];
            string[] commandNames = new string[6] { "west", "on", "north", "north", "west", "off" };

            for (int i = 0; i < 6; i++)
            {
                Console.Write($"Assign command #{i + 1}: ");
                string input = Console.ReadLine();
                bool validCommand = false;

                foreach (string command in commandNames)
                {
                    if (input == command)
                    {
                        validCommand = true;
                        break;
                    }
                }

                if (validCommand)
                {
                    switch (input)
                    {
                        case "on":
                            commands[i] = new OnCommand();
                            break;
                        case "off":
                            commands[i] = new OffCommand();
                            break;
                        case "north":
                            commands[i] = new NorthCommand();
                            break;
                        case "south":
                            commands[i] = new SouthCommand();
                            break;
                        case "east":
                            commands[i] = new EastCommand();
                            break;
                        case "west":
                            commands[i] = new WestCommand();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Command - try again");
                    i--;
                }
            }

            foreach (RobotCommand command in commands)
            {
                command.Run(robot1);
                const string ExpectedOutput = "Robot: X=<expected value>, Y=<expected value>, IsPowered=<expected value>";
                Assert.AreEqual(ExpectedOutput, robot1.ToString());
            }
        }

        public abstract class RobotCommand
        {
            public abstract void Run(Robot robot);
        }

        public class OffCommand : RobotCommand
        {
            public override void Run(Robot robot) => robot.IsPowered = false;
        }

        public class OnCommand : RobotCommand
        {
            public override void Run(Robot robot) => robot.IsPowered = true;
        }

        public class WestCommand : RobotCommand
        {
            public override void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
        }

        public class EastCommand : RobotCommand
        {
            public override void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
        }

        public class SouthCommand : RobotCommand
        {
            public override void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
        }

        public class NorthCommand : RobotCommand
        {
            public override void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
        }
    }
}
