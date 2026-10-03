using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Features.ApplyDamage;
using L4_5.Develop.Gameplay.Features.LifeCycle;
using L4_5.Develop.Gameplay.Features.MovementFeature;
using L4_5.Develop.Gameplay.Features.MovementFeature.Teleport;
using L4_5.Develop.Gameplay.Utilities.Conditions;
using L4.Develop.Gameplay.EntitiesCore.Mono;
using L4.Develop.Gameplay.Features.MovementFeature;
using UnityEngine;

namespace L4.Develop.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        
        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = container.Resolve<MonoEntitiesFactory>();
        }
        
        public Entity CreateRigidbodyEntity(Vector3 position)
        {
            Entity entity = new Entity();
            
            _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/EntityRigidbody");

            entity
                .AddComponent(new MoveDirection() { Value = new ReactiveVariable<Vector3>(Vector3.forward) })
                .AddComponent(new MoveSpeed() { Value = new ReactiveVariable<float>(10) })
                .AddComponent(new RotateDirection() { Value = new ReactiveVariable<Vector3>(Vector3.forward) })
                .AddComponent(new RotateSpeed() { Value = new ReactiveVariable<float>(300) })
                .AddComponent(new MaxHealth() { Value = new ReactiveVariable<float>(100) })
                .AddComponent(new CurrentHealth() { Value = new ReactiveVariable<float>(100) })
                .AddComponent(new IsDead() { Value =  new ReactiveVariable<bool>(false) })
                .AddComponent(new InDeathProcess() { Value =  new ReactiveVariable<bool>(false) })
                .AddComponent(new DeathProcessInitialTime() { Value = new ReactiveVariable<float>(2) })
                .AddComponent(new DeathProcessCurrentTime() { Value = new ReactiveVariable<float>() })
                .AddTakeDamageRequest()
                .AddTakeDamageEvent();
            
            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));
            
            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));
            
            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddCanApplyDamage(canApplyDamage);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotatorSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));
            
            _entitiesLifeContext.Add(entity);

            return entity;
        }
        
        public Entity CreateCharacterEntity(Vector3 position)
        {
            Entity entity = new Entity();
            
            _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/EntityCharacter");

            entity
                .AddComponent(new MoveDirection() { Value = new ReactiveVariable<Vector3>(Vector3.forward) })
                .AddComponent(new MoveSpeed() { Value = new ReactiveVariable<float>(2) })
                .AddComponent(new RotateDirection() { Value = new ReactiveVariable<Vector3>(Vector3.forward) })
                .AddComponent(new RotateSpeed() { Value = new ReactiveVariable<float>(300) });

            entity
                .AddSystem(new TransformRotatorSystem())
                .AddSystem(new CharacterControllerMovementSystem());
            
            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateTeleportEntity(Vector3 position)
        {
            Entity entity = new Entity();
            
            _monoEntitiesFactory.Create(entity, position, "Gameplay/Entities/EntityCharacter");

            entity
                .AddTeleportRequest()
                .AddTeleportEvent()
                .AddMoveEnergyMax(new ReactiveVariable<float>() { Value = 100f })
                .AddMoveEnergyCurrent(new ReactiveVariable<float>() { Value = 100f })
                .AddTeleportCost(new ReactiveVariable<float>() { Value = 20f })
                .AddTeleportRadius(new ReactiveVariable<float>() { Value = 5f })
                .AddMoveEnergyRecovery(new ReactiveVariable<float>() { Value = 5f });
            
            ICompositeCondition canTeleport = new CompositeCondition()
                .Add(new FuncCondition(() => entity.MoveEnergyCurrent.Value >= entity.TeleportCost.Value));

            entity
                .AddCanTeleport(canTeleport);

            entity
                .AddSystem(new MoveEnergyTimeRecoverSystem())
                .AddSystem(new TeleportSystem())
                .AddSystem(new TeleportSpendMoveEnergySystem());
            
            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}