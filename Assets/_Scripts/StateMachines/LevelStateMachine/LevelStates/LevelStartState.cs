using UnityEngine;
using Zenject;

namespace _Scripts.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelStartState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;

        public LevelStartState(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelStartState>
        {
        }
    }
}