using _Scripts.StateMachines.GameStateMachine;
using _Scripts.StateMachines.GameStateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Game
{
    public class GameStateMachineStarter : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;
        private GameStartState.Factory _gameStartStateFactory;
        private GameLoadState.Factory _gameLoadStateFactory;
        private GameRunState.Factory _gameRunStateFactory;

        [Inject]
        private void Construct(
            IGameStateMachine gameStateMachine,
            GameStartState.Factory gameStartStateFactory,
            GameLoadState.Factory gameLoadStateFactory,
            GameRunState.Factory gameRunStateFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameStartStateFactory = gameStartStateFactory;
            _gameLoadStateFactory = gameLoadStateFactory;
            _gameRunStateFactory = gameRunStateFactory;
        }

        private void Start()
        {
            _gameStateMachine.RegisterState(_gameStartStateFactory.Create(_gameStateMachine));
            _gameStateMachine.RegisterState(_gameLoadStateFactory.Create(_gameStateMachine));
            _gameStateMachine.RegisterState(_gameRunStateFactory.Create(_gameStateMachine));
            _gameStateMachine.ChangeState<GameStartState>();
        }
    }
}