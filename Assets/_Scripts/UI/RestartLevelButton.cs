using _Scripts.StateMachines.GameStateMachine;
using _Scripts.StateMachines.GameStateMachine.GameStates;
using Zenject;

namespace _Scripts.UI
{
    public class RestartLevelButton : BaseButton
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public override void OnButtonClicked()
        {
            _gameStateMachine.ChangeState<GameLoadState>();
        }
    }
}