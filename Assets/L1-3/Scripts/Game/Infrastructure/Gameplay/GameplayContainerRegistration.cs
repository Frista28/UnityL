using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Subsequence;
using L1_3.Scripts.Game.Gameplay.Subsequence.Config;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.SceneManagement;

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