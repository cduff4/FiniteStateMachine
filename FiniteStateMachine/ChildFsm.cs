using System.Collections.Generic;

namespace FiniteStateMachine
{
    public enum PlayerState
    {
        Idle,
        Run,
        Jump
    }

    public class ChildFsm : BaseFsm<PlayerState>
    {
        public ChildFsm() : base()
        {
            CurrentState = PlayerState.Idle;

            transitions = new Dictionary<StateTransition, PlayerState>
            {
                { new StateTransition(PlayerState.Idle, PlayerState.Run), PlayerState.Run },
                { new StateTransition(PlayerState.Run, PlayerState.Jump), PlayerState.Jump },
            };
        }
    }
}