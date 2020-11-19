using System;

namespace FiniteStateMachine
{
    internal class Program
    {
        private static void Main()
        {
            var fsm = new ChildFsm();
            Console.WriteLine($"Current State = {fsm.CurrentState}");
            Console.WriteLine($"Command.Begin: Current State = {fsm.MoveNext(PlayerState.Run)}");
            Console.WriteLine($"Invalid transition: {fsm.CanReachNext(PlayerState.Idle)}");
            Console.WriteLine($"Previous State = {fsm.PreviousState}");
        }
    }
}