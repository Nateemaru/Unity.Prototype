using _Scripts.Factories;
using _Scripts.StateMachines;
using _Scripts.StateMachines.LevelStateMachine;
using _Scripts.StateMachines.LevelStateMachine.LevelStates;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
            BindLevelStateMachine();
        }

        private void BindFactories()
        {
            Container.BindFactory<IStateMachine, LevelInitState, LevelInitState.Factory>();
            Container.BindFactory<IStateMachine, LevelStartState, LevelStartState.Factory>();
            Container.BindFactory<IStateMachine, LevelRunState, LevelRunState.Factory>();
            Container.BindFactory<IStateMachine, LevelPauseState, LevelPauseState.Factory>();
            Container.BindFactory<IStateMachine, LevelLoseState, LevelLoseState.Factory>();
            Container.BindFactory<IStateMachine, LevelWinState, LevelWinState.Factory>();
            
            Container.BindFactory<GameObject, GameObjectFactory>().FromFactory<GameObjectFactory>();
        }

        private void BindLevelStateMachine()
        {
            Container
                .Bind<ILevelStateMachine>()
                .To<LevelStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}