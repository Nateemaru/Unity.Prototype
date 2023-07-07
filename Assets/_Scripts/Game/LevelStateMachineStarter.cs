using _Scripts.StateMachines.LevelStateMachine;
using _Scripts.StateMachines.LevelStateMachine.LevelStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Game
{
    public class LevelStateMachineStarter : MonoBehaviour
    {
        private ILevelStateMachine _levelStateMachine;
        private LevelInitState.Factory _levelInitStateFactory;
        private LevelStartState.Factory _levelStartStateFactory;
        private LevelRunState.Factory _levelRunStateFactory;
        private LevelPauseState.Factory _levelPauseStateFactory;
        private LevelLoseState.Factory _levelLoseStateFactory;
        private LevelWinState.Factory _levelWinStateFactory;

        [Inject]
        private void Construct(
            ILevelStateMachine levelStateMachine,
            LevelInitState.Factory levelInitStateFactory,
            LevelStartState.Factory levelStartStateFactory,
            LevelRunState.Factory levelRunStateFactory,
            LevelPauseState.Factory levelPauseStateFactory,
            LevelLoseState.Factory levelLoseStateFactory,
            LevelWinState.Factory levelWinStateFactory)
        {
            _levelStateMachine = levelStateMachine;
            _levelInitStateFactory = levelInitStateFactory;
            _levelStartStateFactory = levelStartStateFactory;
            _levelRunStateFactory = levelRunStateFactory;
            _levelPauseStateFactory = levelPauseStateFactory;
            _levelLoseStateFactory = levelLoseStateFactory;
            _levelWinStateFactory = levelWinStateFactory;
        }

        public void Start()
        {
            _levelStateMachine.RegisterState(_levelInitStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelStartStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelRunStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelPauseStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelLoseStateFactory.Create(_levelStateMachine));
            _levelStateMachine.RegisterState(_levelWinStateFactory.Create(_levelStateMachine));
            _levelStateMachine.ChangeState<LevelInitState>();
        }
    }
}