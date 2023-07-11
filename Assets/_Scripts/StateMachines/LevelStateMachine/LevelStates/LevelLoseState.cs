using Zenject;

namespace _Scripts.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelLoseState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;

        public LevelLoseState(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public void Enter()
        {
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelLoseState>
        {
        }
    }
}