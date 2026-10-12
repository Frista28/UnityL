using System;
using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Utilities.Conditions;
using L4.Develop.Gameplay.EntitiesCommon;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.MovementFeature.Teleport
{
    public class TeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<Vector3> _teleportRequest;
        private ReactiveEvent<Vector3> _teleportEvent;
        
        private ReactiveVariable<float> _teleportRadius;
        
        private ICompositeCondition _canTeleport;
        private Transform _transform;
        
        private IDisposable _requestDisposable;
        
        public void OnInit(Entity entity)
        {
            _teleportRequest = entity.TeleportRequest;
            _teleportEvent = entity.TeleportEvent;
            
            _teleportRadius = entity.TeleportRadius;
            _transform = entity.GetComponent<TransformComponent>().Value;
            
            _canTeleport = entity.CanTeleport;

            _requestDisposable = _teleportRequest.Subscribe(OnTeleportRequest);
        }
        
        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        private void OnTeleportRequest(Vector3 position)
        {
            if (_canTeleport.Evaluate() == false)
                return;
            
            Teleport(position);
        }

        private void Teleport(Vector3 position)
        {
            _transform.position = position;
            _teleportEvent.Invoke(position);
        }
    }
}