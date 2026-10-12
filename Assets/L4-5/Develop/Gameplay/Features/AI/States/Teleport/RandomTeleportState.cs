using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Utilities.StateMachineCore;
using L4.Develop.Gameplay.EntitiesCore;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.AI.States.Teleport
{
    public class RandomTeleportState : State, IUpdatableState
    {
        private readonly ReactiveEvent<Vector3> _teleportRequestEvent;

        private readonly ReactiveVariable<float> _teleportRadius;
        
        private readonly float _cooldownBetweenTeleportRequest;
        
        private float _time;

        public RandomTeleportState(
            Entity entity,
            float cooldownBetweenTeleportRequest)
        {
            _teleportRequestEvent = entity.TeleportRequest;
            _teleportRadius = entity.TeleportRadius;
            _cooldownBetweenTeleportRequest = cooldownBetweenTeleportRequest;
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            if(_time >= _cooldownBetweenTeleportRequest)
            {
                _teleportRequestEvent.Invoke(GetRandomPosition());
                _time = 0;
            }
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 random = Random.insideUnitSphere * _teleportRadius.Value;
            random.y = 0;
            
            return random;
        }
    }
}