using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Subsequence;
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
            
            return new SubsequenceGameLoop(subsequenceHandler, sceneSwitcherService, coroutinesPerformer, _gameplaySceneContext);
        }
    }
}