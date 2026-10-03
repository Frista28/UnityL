using L1_3.Scripts.Game.Utilities.Reactive;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.LifeCycle
{
    public class SelfReleaseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private Entity _entity;

        private ReactiveVariable<bool> _isDead;

        private ReactiveVariable<bool> _inDeathProcess;

        public SelfReleaseSystem(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _isDead = entity.GetComponent<IsDead>().Value;
            _inDeathProcess = entity.GetComponent<InDeathProcess>().Value;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_isDead.Value && !_inDeathProcess.Value)
                _entitiesLifeContext.Release(_entity);
        }
    }
}