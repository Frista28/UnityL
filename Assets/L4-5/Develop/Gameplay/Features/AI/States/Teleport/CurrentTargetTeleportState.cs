using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Utilities.StateMachineCore;
using L4.Develop.Gameplay.EntitiesCore;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.AI.States.Teleport
{
    public class CurrentTargetTeleportState : State, IUpdatableState
    {
        private readonly ReactiveEvent<Vector3> _teleportRequest;
        private readonly ReactiveVariable<Entity> _currentTarget;
        
        private readonly ReactiveVariable<float> _teleportRadius;
        private readonly ReactiveVariable<float> _moveEnergyMax;
        private readonly ReactiveVariable<float> _moveEnergyCurrent;
        
        private readonly Transform _transform;
        
        private readonly float _cooldownBetweenTeleportRequest;

        private float _time;

        public CurrentTargetTeleportState(
            Entity entity,
            float cooldown)
        {
            _teleportRequest = entity.TeleportRequest;
            _currentTarget = entity.CurrentTarget;
            
            _teleportRadius = entity.TeleportRadius;
            _moveEnergyMax = entity.MoveEnergyMax;
            _moveEnergyCurrent = entity.MoveEnergyCurrent;
            
            _transform = entity.Transform;
            
            _cooldownBetweenTeleportRequest = cooldown;
        }
        
        public void Update(float deltaTime)
        {
            if (_currentTarget.Value == null)
            {
                _time = 0;
                return;
            }

            _time += deltaTime;
            
            if (!EnoughEnergy())
                return;

            if(_time >= _cooldownBetweenTeleportRequest)
            {
                _teleportRequest.Invoke(GetTeleportPosition());
                _time = 0;
            }
        }

        private bool EnoughEnergy() => _moveEnergyCurrent.Value >= _moveEnergyMax.Value * 0.4f;

        private Vector3 GetTeleportPosition()
        {
            Transform targetTransform = _currentTarget.Value.Transform;
            
            // if(targetTransform == null)
            //     return Vector3.zero;
            
            Vector3 newPosition = Vector3.MoveTowards(_transform.position, targetTransform.position, _teleportRadius.Value);
            
            return newPosition;
        }
    }
}