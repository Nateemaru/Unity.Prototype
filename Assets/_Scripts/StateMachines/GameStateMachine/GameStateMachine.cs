using System;
using System.Collections.Generic;

namespace _Scripts.StateMachines.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IState> _registeredStates;
        private IState _currentGameState;

        public IStateMachine.StateChanged OnStateChanged { get; set; }


        public IState CurrentState => _currentGameState;
        public IState LastState { get; private set; }

        public GameStateMachine()
        {
            _registeredStates = new Dictionary<Type, IState>();
        }

        public void RegisterState<TState>(TState state) where TState : IState =>
            _registeredStates.Add(typeof(TState), state);

        public void ChangeState<TState>() where TState : class, IState
        {
            TState state = GetState<TState>();

            if (state != _currentGameState)
            {
                _currentGameState?.Exit();
                LastState = _currentGameState;
                _currentGameState = state;
                _currentGameState.Enter();
                OnStateChanged?.Invoke(_currentGameState);
            }
        }
    
        private TState GetState<TState>() where TState : class, IState => 
            _registeredStates[typeof(TState)] as TState;
    }
}