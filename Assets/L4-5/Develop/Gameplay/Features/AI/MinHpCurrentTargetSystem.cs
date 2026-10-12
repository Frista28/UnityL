using System;
using System.Collections.Generic;
using System.Linq;
using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Features.ApplyDamage;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.AI
{
    public class MinHpCurrentTargetSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private readonly EntitiesLifeContext _entitiesContext;

        private Entity _self;
        private Transform _selfTransform;
        private ReactiveVariable<Entity> _currentTarget;

        private IDisposable _disposable;

        public MinHpCurrentTargetSystem(EntitiesLifeContext entitiesContext)
        {
            _entitiesContext = entitiesContext;
            _entitiesContext.Released += OnReleasedEntity;
        }

        public void OnInit(Entity entity)
        {
            _self = entity;
            _selfTransform = entity.Transform;
            _currentTarget = entity.CurrentTarget;
            
            
        }

        public void OnUpdate(float deltaTime)
        {
            SetCurrentTarget();
        }
        
        public void OnDispose()
        {
            _entitiesContext.Released -= OnReleasedEntity;
        }

        private void OnReleasedEntity(Entity entity)
        {
            if (entity == _currentTarget.Value)
            {
                SetCurrentTarget();
            }
        }

        private void SetCurrentTarget()
        {
            IEnumerable<Entity> selectedTargets = _entitiesContext.Entities.Where(target =>
            {
                bool result = target.HasComponent<TakeDamageRequest>();

                result = result && (target != _self);

                return result;
            });

            if (selectedTargets.Count() == 0)
            {
                if (_currentTarget.Value != null)
                    _currentTarget.Value = null;
                
                return;
            }
            
            Entity minHpTarget = selectedTargets.First();
            float minHp = minHpTarget.CurrentHealth.Value;

            foreach (Entity target in selectedTargets)
            {
                float hp = target.CurrentHealth.Value;

                if(hp < minHp)
                {
                    minHp = hp;
                    minHpTarget = target;
                }
            }
            
            _currentTarget.Value = minHpTarget;
        }
    }
}