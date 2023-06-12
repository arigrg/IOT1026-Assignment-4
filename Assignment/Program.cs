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
            internal static void TestRobot() => throw new NotImplementedException();
        }
    }
}
