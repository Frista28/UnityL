using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.LoadingScreen;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Infrastructure.EntryPoint
{
    public static class GlobalContainerRegistration
    {
        public static void Register(DIContainer container)
        {
            container.RegisterAsSingle(CreateCoroutinesPerformer);

            container.RegisterAsSingle(CreateResourcesAssetsLoader);

            container.RegisterAsSingle(CreateSceneLoaderService);

            container.RegisterAsSingle(CreateSceneSwitcherService);

            container.RegisterAsSingle(CreateLoadingScreen);
            
            container.RegisterAsSingle(CreateSceneBootstrapRegistry);
            
            container.RegisterAsSingle(CreateConfigsProviderService);
        }

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer container)
            => new SceneSwitcherService(
                container.Resolve<SceneLoaderService>(),
                container.Resolve<ILoadingScreen>(),
                container);

        private static SceneLoaderService CreateSceneLoaderService(DIContainer container)
            => new SceneLoaderService();

        private static ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer container)
            => new ResourcesAssetsLoader();

        private static ICoroutinesPerformer CreateCoroutinesPerformer(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            CoroutinesPerformer coroutinesPerformerPrefab = resourcesAssetsLoader
                .Load<CoroutinesPerformer>("Utilities/CoroutinesPerformer");

            return Object.Instantiate(coroutinesPerformerPrefab);
        }

        private static ILoadingScreen CreateLoadingScreen(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            StandardLoadingScreen standardLoadingScreenPrefab = resourcesAssetsLoader
                .Load<StandardLoadingScreen>("Utilities/LoadingScreen");

            return Object.Instantiate(standardLoadingScreenPrefab);
        }

        private static ConfigsProviderService CreateConfigsProviderService(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();
            
            IConfigsLoader configsLoader = new ResourcesConfigsLoader(resourcesAssetsLoader);
            
            return new ConfigsProviderService(configsLoader);
        }

        private static SceneBootstrapRegistry CreateSceneBootstrapRegistry(DIContainer container)
        => new SceneBootstrapRegistry();
    }
}