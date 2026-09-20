using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Menu;
using L1_3.Scripts.Game.Gameplay.Menu.Configs;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.UI.Core;
using L1_3.Scripts.Game.UI.MainMenu;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.DataManagement.DataProvider;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Infrastructure.MainMenu
{
    public class MainMenuContainerRegistration
    {
        public static void Registration(DIContainer container)
        {
            container.RegisterAsSingle(CreateMenuSystem);
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
        }
        
        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer container)
        {
            MainMenuUIRoot uiRoot = container.Resolve<MainMenuUIRoot>();

            MainMenuScreenView view = container
                .Resolve<ViewsFactory>()
                .Create<MainMenuScreenView>(ViewTypes.MainMenuScreenView, uiRoot.HUDLayer);

            MainMenuScreenPresenter presenter = container
                .Resolve<MainMenuPresentersFactory>()
                .CreateMainMenuScreen(view);

            return presenter;
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer container)
            => new MainMenuPresentersFactory(container);
        
        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            MainMenuUIRoot mainMenuUIRootPrefab = resourcesAssetsLoader
                .Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRootPrefab);
        }

        private static MenuSystem CreateMenuSystem(DIContainer container)
        {
            ScoreCounter scoreCounter = container.Resolve<ScoreCounter>();
            WalletService walletService = container.Resolve<WalletService>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();
            ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();

            return new MenuSystem(
                scoreCounter, 
                walletService, 
                sceneSwitcherService, 
                playerDataProvider, 
                coroutinesPerformer, 
                configsProviderService.GetConfig<MenuSystemConfig>());
        }
    }
}