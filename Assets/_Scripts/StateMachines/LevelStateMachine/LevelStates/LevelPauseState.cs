using Zenject;

namespace _Scripts.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelPauseState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;

        public LevelPauseState(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelPauseState>
        {
        }
    }
}