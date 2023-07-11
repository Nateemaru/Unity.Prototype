using System;
using System.Collections.Generic;
using _Scripts.CodeSugar;
using _Scripts.StateMachines;
using _Scripts.StateMachines.LevelStateMachine;
using _Scripts.StateMachines.LevelStateMachine.LevelStates;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class SetActiveViewsOnState : MonoBehaviour
    {
        [SerializeField] private bool _toggleToActive = true;
        [SerializeField] private GameObject[] _onRunning;
        [SerializeField] private GameObject[] _onWin;
        [SerializeField] private GameObject[] _onLose;
        [SerializeField] private GameObject[] _onGamePause;
        
        private ILevelStateMachine _levelStateMachine;
        private Dictionary<Type, Action> _cachedSwitch = new Dictionary<Type, Action>();

        [Inject]
        private void Construct(ILevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        private void Start()
        {
            _levelStateMachine.OnStateChanged += SwitchScreen;
            
            _cachedSwitch.Add(typeof(LevelPauseState), () => UpdateActivity(_onGamePause));
            _cachedSwitch.Add(typeof(LevelRunState), () => UpdateActivity(_onRunning));
            _cachedSwitch.Add(typeof(LevelWinState), () => UpdateActivity(_onWin));
            _cachedSwitch.Add(typeof(LevelLoseState), () => UpdateActivity(_onLose));
        }

        private void SwitchScreen(IState state)
        {
            if(_cachedSwitch.TryGetValue(state.GetType(), out Action value))
                value.Invoke();
        }

        private void UpdateActivity(GameObject[] views)
        {
            if (views.IsNullOrEmpty()) 
                return;
            
            foreach (GameObject o in views)
            {
                if (o == null)
                    continue;
                
                o.SetActive(_toggleToActive);
            }
        }
    }
}