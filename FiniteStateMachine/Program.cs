using System;

namespace FiniteStateMachine
{
    internal class Program
    {
        private static void Main()
        {
            var process = new ProcessStateMachine();
            Console.WriteLine("Current State = " + process.CurrentState);
            Console.WriteLine("Command.Begin: Current State = " + process.MoveNext(Command.Begin));
            Console.WriteLine("Command.Pause: Current State = " + process.MoveNext(Command.Pause));
            Console.WriteLine("Command.End: Current State = " + process.MoveNext(Command.End));
            Console.WriteLine("Command.Exit: Current State = " + process.MoveNext(Command.Exit));
            Console.ReadLine();
        }
    }
}