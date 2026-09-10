using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.DataManagement.DataProvider;
using L1_3.Scripts.Game.Utilities.DataManagement.DataRepository;
using L1_3.Scripts.Game.Utilities.DataManagement.KeyStorage;
using L1_3.Scripts.Game.Utilities.DataManagement.SaveLoadService;
using L1_3.Scripts.Game.Utilities.DataManagement.Serializer;
using L1_3.Scripts.Game.Utilities.LoadingScreen;
using L1_3.Scripts.Game.Utilities.Reactive;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;
using Object = UnityEngine.Object;

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
            
            container.RegisterAsSingle(CreateSaveLoadService);
            
            container.RegisterAsSingle(CreatePlayerDataProvider);
            
            container.RegisterAsSingle(CreateWalletService).NonLazy();
        }
        
        private static ISaveLoadService CreateSaveLoadService(DIContainer container)
        {
            IDataSerializer dataSerializer = new JsonSerializer();
            IDataKeysStorage dataKeysStorage = new MapDataKeysStorage();

            string saveFolderPath = Application.isEditor ? Application.dataPath : Application.persistentDataPath;

            IDataRepository dataRepository = new LocalFileDataRepository(saveFolderPath, "json");

            return new SaveLoadService(dataSerializer, dataKeysStorage, dataRepository);
        }
        
        private static PlayerDataProvider CreatePlayerDataProvider(DIContainer container)
            => new PlayerDataProvider(container.Resolve<ISaveLoadService>(), container.Resolve<ConfigsProviderService>());
        
        private static WalletService CreateWalletService(DIContainer container)
        {
            Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies = new();

            foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
                currencies[currencyType] = new ReactiveVariable<int>();

            return new WalletService(currencies, container.Resolve<PlayerDataProvider>());
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