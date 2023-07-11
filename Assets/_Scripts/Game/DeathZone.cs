using System;
using _Scripts.Game.Knife;
using _Scripts.StateMachines.LevelStateMachine;
using _Scripts.StateMachines.LevelStateMachine.LevelStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Game
{
    public class DeathZone : MonoBehaviour
    {
        private ILevelStateMachine _levelStateMachine;

        [Inject]
        private void Construct(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }
    }
}