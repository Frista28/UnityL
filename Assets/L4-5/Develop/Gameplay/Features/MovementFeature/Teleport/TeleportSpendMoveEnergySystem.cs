using System;
using L1_3.Scripts.Game.Utilities.Reactive;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.MovementFeature.Teleport
{
    public class TeleportSpendMoveEnergySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<Vector3> _teleportEvent;
        
        private ReactiveVariable<float> _energyCurrent;
        private ReactiveVariable<float> _teleportCost;
        
        private IDisposable _eventDisposable;
        
        public void OnInit(Entity entity)
        {
            _teleportEvent = entity.TeleportEvent;

            _energyCurrent = entity.MoveEnergyCurrent;
            _teleportCost = entity.TeleportCost;

            _eventDisposable = _teleportEvent.Subscribe(OnTeleportEvent);
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
        }
        
        private void OnTeleportEvent(Vector3 position) => _energyCurrent.Value -= _teleportCost.Value;
    }
}