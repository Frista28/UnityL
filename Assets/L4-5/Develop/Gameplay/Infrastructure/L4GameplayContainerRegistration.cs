using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using L4_5.Develop.Gameplay.EntitiesCore;
using L4_5.Develop.Gameplay.Features.AI;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Mono;

namespace L4.Develop.Gameplay.Infrastructure
{
    public static class L4GameplayContainerRegistration
    {
        public static void Registration(DIContainer container)
        {
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreateCollidersRegistryService);
            container.RegisterAsSingle(CreateBrainsFactory);
            container.RegisterAsSingle(CreateAIBrainsContext);
            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();
        }
        
        private static AIBrainsContext CreateAIBrainsContext(DIContainer container)
        {
            return new AIBrainsContext();
        }

        private static BrainsFactory CreateBrainsFactory(DIContainer container)
        {
            return new BrainsFactory(container);
        }

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer container)
        {
            return new MonoEntitiesFactory(
                container.Resolve<ResourcesAssetsLoader>(),
                container.Resolve<EntitiesLifeContext>(),
                container.Resolve<CollidersRegistryService>());
        }

        private static CollidersRegistryService CreateCollidersRegistryService(DIContainer container)
        {
            return new CollidersRegistryService();
        }

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer container)
            => new EntitiesLifeContext();
        
        private static EntitiesFactory CreateEntitiesFactory(DIContainer container)
            => new EntitiesFactory(container);
    }
}