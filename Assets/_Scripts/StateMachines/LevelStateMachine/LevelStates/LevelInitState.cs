using UnityEngine;
using Zenject;

namespace _Scripts.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelInitState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;

        public LevelInitState(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public void Enter()
        {
            _levelStateMachine.ChangeState<LevelStartState>();
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelInitState>
        {
        }
    }
}