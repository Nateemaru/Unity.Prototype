using System;
using _Scripts.StateMachines.LevelStateMachine;
using _Scripts.StateMachines.LevelStateMachine.LevelStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Game
{
    public class FinishZone : MonoBehaviour
    {
        private ILevelStateMachine _levelStateMachine;

        [Inject]
        private void Construct(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 10)
                _levelStateMachine.ChangeState<LevelWinState>();
        }
    }
}