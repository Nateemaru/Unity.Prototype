using Zenject;

namespace _Scripts.StateMachines.LevelStateMachine.LevelStates
{
    public class LevelRunState : IState
    {
        private readonly ILevelStateMachine _levelStateMachine;

        public LevelRunState(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public class Factory : PlaceholderFactory<IStateMachine, LevelRunState>
        {
        }
    }
}