using _Scripts.Services;
using _Scripts.Services.CoroutineRunner;
using _Scripts.Services.Database;
using _Scripts.Services.InputService;
using _Scripts.Services.PauseHandlerService;
using _Scripts.Services.SceneLoadService;
using _Scripts.StateMachines;
using _Scripts.StateMachines.GameStateMachine;
using _Scripts.StateMachines.GameStateMachine.GameStates;
using Zenject;

namespace _Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFPSUnlocker();
            BindFactories();
            BindGameStateMachine();
            BindCoroutineRunner();
            BindStorage();
            BindDataReader();
            BindSceneLoadService();
            BindPauseHandler();
            BindInputService();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }

        private void BindPauseHandler()
        {
            Container
                .Bind<IPauseHandler>()
                .To<PauseHandler>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindSceneLoadService()
        {
            Container
                .Bind<ISceneLoadService>()
                .To<SceneLoader>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
        
        private void BindStorage()
        {
            Container
                .Bind<IStorageService>()
                .To<JsonToFileStorage>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindDataReader()
        {
            Container
                .BindInterfacesAndSelfTo<DataReader>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }

        private void BindFactories()
        {
            Container.BindFactory<IStateMachine, GameStartState, GameStartState.Factory>();
            Container.BindFactory<IStateMachine, GameLoadState, GameLoadState.Factory>();
            Container.BindFactory<IStateMachine, GameRunState, GameRunState.Factory>();
        }

        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindFPSUnlocker()
        {
            Container
                .Bind<FPSUnlocker>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}
