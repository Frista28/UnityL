using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Utilities.Conditions;
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
        
        private ICompositeCondition _canRotate;

        public void OnInit(Entity entity)
        {
            _rotateDirection = entity.GetComponent<RotateDirection>().Value;
            _rotateSpeed = entity.GetComponent<RotateSpeed>().Value;
            _rigidbody = entity.GetComponent<RigidbodyComponent>().Value;

            _canRotate = entity.CanRotate;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;
            
            Vector3 direction = _rotateDirection.Value.normalized;
            float speed = _rotateSpeed.Value;
            
            if (direction == Vector3.zero)
                return;
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            
            float angle = speed * deltaTime;
            
            Quaternion newRotation = Quaternion.RotateTowards(_rigidbody.rotation, targetRotation, angle);
            
            _rigidbody.MoveRotation(newRotation);
        }
    }
}