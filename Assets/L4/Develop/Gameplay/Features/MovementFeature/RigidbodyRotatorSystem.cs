using L1_3.Scripts.Game.Utilities.Reactive;
using L4.Develop.Gameplay.EntitiesCommon;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4.Develop.Gameplay.Features.MovementFeature
{
    public class RigidbodyRotatorSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _rotateDirection;
        private ReactiveVariable<float> _rotateSpeed;
        private Rigidbody _rigidbody;

        public void OnInit(Entity entity)
        {
            _rotateDirection = entity.GetComponent<RotateDirection>().Value;
            _rotateSpeed = entity.GetComponent<RotateSpeed>().Value;
            _rigidbody = entity.GetComponent<RigidbodyComponent>().Value;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 direction = _rotateDirection.Value.normalized;
            float speed = _rotateSpeed.Value;
            
            // if (direction.magnitude < 0.05f)
            //     return;
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            
            float angle = speed * deltaTime;
            
            Quaternion newRotation = Quaternion.RotateTowards(_rigidbody.rotation, targetRotation, angle);
            
            _rigidbody.MoveRotation(newRotation);
            
            Debug.Log(direction);
        }
    }
}