using Zenject;

namespace _Scripts.StateMachines.GameStateMachine.GameStates
{
    public class GameStartState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameStartState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _gameStateMachine.ChangeState<GameLoadState>();
        }

        public class Factory : PlaceholderFactory<IStateMachine, GameStartState>
        {
        }
    }
}