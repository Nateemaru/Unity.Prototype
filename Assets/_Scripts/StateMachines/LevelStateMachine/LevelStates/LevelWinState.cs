using Zenject;

namespace _Scripts.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelWinState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;

        public LevelWinState(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelWinState>
        {
        }
    }
}