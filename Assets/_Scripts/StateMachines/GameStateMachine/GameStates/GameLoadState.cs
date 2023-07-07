using _Scripts.Services.Database;
using _Scripts.Services.SceneLoadService;
using Zenject;

namespace _Scripts.StateMachines.GameStateMachine.GameStates
{
    public class GameLoadState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoadService _sceneLoadService;

        public GameLoadState(IGameStateMachine gameStateMachine, ISceneLoadService sceneLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoadService = sceneLoadService;
        }

        public void Enter()
        {
            _sceneLoadService.Load(GlobalConstants.GAME_SCENE_KEY, () =>
            {
                _gameStateMachine.ChangeState<GameRunState>();
            });
        }

        public class Factory : PlaceholderFactory<IStateMachine, GameLoadState>
        {
        }
    }
}