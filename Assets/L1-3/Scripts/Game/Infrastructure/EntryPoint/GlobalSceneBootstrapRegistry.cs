using System;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Infrastructure.Gameplay;
using L1_3.Scripts.Game.Infrastructure.MainMenu;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using L4.Develop.Gameplay.Infrastructure;
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
            sceneBootstrapRegistry.Register(Scenes.L4Gameplay, CreateL4GameplaySceneBootstrap(container));
        }
        
        private static Func<ISceneBootstrap> CreateL4GameplaySceneBootstrap(DIContainer container)
        {
            return () =>
            {
                ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

                L4GameplayBootstrap gameplayBootstrap =
                    resourcesAssetsLoader.Load<L4GameplayBootstrap>("Gameplay/Bootstraps/L4GameplayBootstrap");

                return Object.Instantiate(gameplayBootstrap);
            };
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