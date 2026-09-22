using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Subsequence;
using L1_3.Scripts.Game.Gameplay.Subsequence.Config;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.UI.Core;
using L1_3.Scripts.Game.UI.Gameplay;
using L1_3.Scripts.Game.UI.MainMenu;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Infrastructure.Gameplay
{
    public static class GameplayContainerRegistration
    {
        private static GameplaySceneContext _gameplaySceneContext;
        
        public static void Registration(DIContainer container, GameplaySceneContext gameplaySceneContext)
        {
            _gameplaySceneContext = gameplaySceneContext;
            
            container.RegisterAsSingle(CreateSubsequenceGenerator);
            container.RegisterAsSingle(CreateSubsequenceHandler);
            container.RegisterAsSingle(CreateSubsequenceGameLoop);
            container.RegisterAsSingle(CreateSubsequenceGameConditionProcessor);
            container.RegisterAsSingle(CreateGameplayUIRoot);
            container.RegisterAsSingle(CreateGameplayPresenterFactory);
            container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();
        }
        
        private static GameplayScreenPresenter CreateGameplayScreenPresenter(DIContainer container)
        {
            GameplayUIRoot uiRoot = container.Resolve<GameplayUIRoot>();

            GameplayScreenView view = container
                .Resolve<ViewsFactory>()
                .Create<GameplayScreenView>(ViewTypes.GameplayScreenView, uiRoot.HUDLayer);

            GameplayScreenPresenter presenter = container
                .Resolve<GameplayPresenterFactory>()
                .CreateMainMenuScreen(view);

            return presenter;
        }

        private static GameplayPresenterFactory CreateGameplayPresenterFactory(DIContainer container)
            => new GameplayPresenterFactory(container);
        
        private static GameplayUIRoot CreateGameplayUIRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            GameplayUIRoot mainMenuUIRootPrefab = resourcesAssetsLoader
                .Load<GameplayUIRoot>("UI/Gameplay/GameplayUIRoot");

            return Object.Instantiate(mainMenuUIRootPrefab);
        }

        private static SubsequenceGameConditionProcessor CreateSubsequenceGameConditionProcessor(DIContainer container)
        {
            ScoreCounter scoreCounter = container.Resolve<ScoreCounter>();
            WalletService walletService = container.Resolve<WalletService>();
            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
            
            return new SubsequenceGameConditionProcessor(scoreCounter, walletService, configsProviderService.GetConfig<SubsequenceConfigs>());
        }

        private static SubsequenceGenerator CreateSubsequenceGenerator(DIContainer container) => new SubsequenceGenerator(container);

        private static SubsequenceHandler CreateSubsequenceHandler(DIContainer container)
        {
            SubsequenceGenerator subsequenceGenerator = container.Resolve<SubsequenceGenerator>();
            
            return new SubsequenceHandler(subsequenceGenerator);
        }

        private static SubsequenceGameLoop CreateSubsequenceGameLoop(DIContainer container)
        {
            SubsequenceHandler subsequenceHandler = container.Resolve<SubsequenceHandler>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
            SubsequenceGameConditionProcessor conditionProcessor = container.Resolve<SubsequenceGameConditionProcessor>();
            
            return new SubsequenceGameLoop(subsequenceHandler, sceneSwitcherService, coroutinesPerformer, conditionProcessor, _gameplaySceneContext);
        }
    }
}