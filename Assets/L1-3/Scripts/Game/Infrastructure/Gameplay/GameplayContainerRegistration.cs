using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Subsequence;

namespace L1_3.Scripts.Game.Infrastructure.Gameplay
{
    public static class GameplayContainerRegistration
    {
        public static void Registration(DIContainer container, GameplaySceneContext gameplaySceneContext)
        {
            container.RegisterAsSingle(CreateSubsequenceGenerator);
        }

        private static SubsequenceGenerator CreateSubsequenceGenerator(DIContainer container) => new SubsequenceGenerator(container);
    }
}