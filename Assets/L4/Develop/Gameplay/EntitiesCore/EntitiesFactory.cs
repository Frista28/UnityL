using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Utilities.Reactive;
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
                .AddComponent(new RotateSpeed() { Value = new ReactiveVariable<float>(300) });

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotatorSystem());
            
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
    }
}