using System;
using System.Collections.Generic;

namespace FiniteStateMachine
{
    public class BaseFsm<T> where T : struct, IConvertible
    {
        #region State Transition

        public class StateTransition
        {
            private readonly T currentState;
            private readonly T nextState;

            public StateTransition(T currentState, T nextState)
            {
                this.currentState = currentState;
                this.nextState = nextState;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * currentState.GetHashCode() + 31 * nextState.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return obj is StateTransition other && currentState.Equals(other.currentState) && nextState.Equals(other.nextState);
            }
        }

        #endregion State Transition

        #region BaseFsm Implementation

        public T CurrentState;
        public T PreviousState;
        protected Dictionary<StateTransition, T> transitions;

        protected BaseFsm()
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception($"{typeof(T).FullName} is not an enum type.");
            }
        }

        public bool CanReachNext(T next)
        {
            var transition = new StateTransition(CurrentState, next);

            if (!transitions.TryGetValue(transition, out T _))
            {
                Console.WriteLine($"Invalid transition: {CurrentState} -> {next}");
                return false;
            }

            return true;
        }

        public T MoveNext(T next)
        {
            PreviousState = CurrentState;
            CurrentState = GetNext(next);
            Console.WriteLine($"Change state from {PreviousState} to {CurrentState}");
            return CurrentState;
        }

        private T GetNext(T next)
        {
            var transition = new StateTransition(CurrentState, next);

            if (!transitions.TryGetValue(transition, out T nextState))
            {
                throw new Exception($"Invalid transition: {CurrentState} -> {next}");
            }

            Console.WriteLine($"Next state {nextState}");
            return nextState;
        }

        #endregion BaseFsm Implementation
    }
}