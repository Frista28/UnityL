using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Menu;
using L1_3.Scripts.Game.Gameplay.Menu.Configs;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.DataManagement.DataProvider;
using L1_3.Scripts.Game.Utilities.SceneManagement;

namespace L1_3.Scripts.Game.Infrastructure.MainMenu
{
    public class MainMenuContainerRegistration
    {
        public static void Registration(DIContainer container)
        {
            container.RegisterAsSingle(CreateMenuSystem);
        }

        private static MenuSystem CreateMenuSystem(DIContainer container)
        {
            ScoreCounter scoreCounter = container.Resolve<ScoreCounter>();
            WalletService walletService = container.Resolve<WalletService>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();
            ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
            ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();

            return new MenuSystem(scoreCounter, walletService, sceneSwitcherService, playerDataProvider, coroutinesPerformer, configsProviderService.GetConfig<MenuSystemConfig>());
        }
    }
}