using System;
using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Utilities;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.ApplyDamage.TeleportDamage
{
    public class DealDamageOnTeleportContactSystem: IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<Vector3> _teleportEvent;
        
        private ReactiveVariable<float> _damage;
        
        private Buffer<Entity> _targetBuffer;
        
        private IDisposable _eventDisposable;
        
        public void OnInit(Entity entity)
        {
            _teleportEvent = entity.TeleportEvent;

            _damage = entity.TeleportContactDamage;

            _targetBuffer = entity.ContactEntitiesBuffer;

            _eventDisposable = _teleportEvent.Subscribe(OnTeleportEvent);
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
        }

        private void OnTeleportEvent(Vector3 position)
        {
            for (int i = 0; i < _targetBuffer.Count; i++)
            {
                if (_targetBuffer.Items[i].HasComponent<TakeDamageRequest>())
                    _targetBuffer.Items[i].TakeDamageRequest.Invoke(_damage.Value);
            }
        }
    }
}