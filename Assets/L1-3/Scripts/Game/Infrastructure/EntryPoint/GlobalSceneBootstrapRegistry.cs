using System;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Infrastructure.Gameplay;
using L1_3.Scripts.Game.Infrastructure.MainMenu;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using Object = UnityEngine.Object;

namespace L1_3.Scripts.Game.Infrastructure.EntryPoint
{
    public static class GlobalSceneBootstrapRegistry
    {
        public static void Register(DIContainer container)
        {
            SceneBootstrapRegistry sceneBootstrapRegistry = container.Resolve<SceneBootstrapRegistry>();
            
            sceneBootstrapRegistry.Register(Scenes.Gameplay, CreateGameplaySceneBootstrap(container));
            sceneBootstrapRegistry.Register(Scenes.MainMenu, CreateMainMenuSceneBootstrap(container));
        }

        private static Func<ISceneBootstrap> CreateGameplaySceneBootstrap(DIContainer container)
        {
            return () =>
            {
                ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

                GameplayBootstrap gameplayBootstrap =
                    resourcesAssetsLoader.Load<GameplayBootstrap>("Gameplay/Bootstraps/GameplayBootstrap");

                return Object.Instantiate(gameplayBootstrap);
            };
        }
        
        private static Func<ISceneBootstrap> CreateMainMenuSceneBootstrap(DIContainer container)
        {
            return () =>
            {
                ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

                MainMenuBootstrap gameplayBootstrap =
                    resourcesAssetsLoader.Load<MainMenuBootstrap>("MainMenu/MainMenuBootstrap");

                return Object.Instantiate(gameplayBootstrap);
            };
        }
    }
}