using System;
using System.Collections.Generic;

namespace FiniteStateMachine
{
    /// <summary>
    /// Manages the transitions of a state machine that inherits this class. 
    /// </summary>
    /// <remarks>
    /// <para>The derived class should have an enum of States.</para>
    /// <para>The derived class should have an enum of Events.</para>
    /// <para>The derived class should intialize the list 
    /// of <see cref="StateTransition"/>s in its constructor.</para>
    /// </remarks>
    /// <typeparam name="T1">States enum</typeparam>
    /// <typeparam name="T2">Events enum</typeparam>
    public class StateMachine<T1, T2>
        where T1 : struct, IConvertible
        where T2 : struct, IConvertible
    {
        protected Dictionary<StateTransition, ProcessState> transitions;

        protected StateMachine(ProcessState initialState)
        {
            if (!typeof(T1).IsEnum)
            {
                throw new Exception($"{typeof(T1).FullName} is not an enum type.");
            }

            if (!typeof(T2).IsEnum)
            {
                throw new Exception($"{typeof(T2).FullName} is not an enum type.");
            }

            CurrentState = initialState;
        }

        public ProcessState CurrentState { get; private set; }

        public ProcessState GetNext(Command command)
        {
            var transition = new StateTransition(CurrentState, command);
            if (!transitions.TryGetValue(transition, out ProcessState nextState))
            {
                throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
            }

            return nextState;
        }

        public ProcessState MoveNext(Command command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }

        protected class StateTransition
        {
            private readonly ProcessState CurrentState;
            private readonly Command Command;

            public StateTransition(ProcessState currentState, Command command)
            {
                CurrentState = currentState;
                Command = command;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return obj is StateTransition other && CurrentState == other.CurrentState && Command == other.Command;
            }
        }
    }
}