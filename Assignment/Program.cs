namespace Assignment
{
    static class Program
    {
        static void Main()
        {
            System.Console.WriteLine("hello world");
            RobotTester.TestRobot();
            // Run your RobotTester class here -> RobotTester.TestRobot()
        }

        private static class RobotTester
        {
            public static void TestRobot()
            {
                // Create an instance of the Robot class
                Robot robot = new();

                // Call methods or perform actions on the robot object
                robot.TurnOn();
                robot.MoveForward(10);
                robot.TurnOn();
            }
        }
    }
}
