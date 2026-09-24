using L1_3.Scripts.Game.Utilities.Reactive;
using L4.Develop.Gameplay.EntitiesCommon;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4.Develop.Gameplay.Features.MovementFeature
{
    public class CharacterControllerMovementSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<float> _moveSpeed;
        private CharacterController _characterController;

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.GetComponent<MoveDirection>().Value;
            _moveSpeed = entity.GetComponent<MoveSpeed>().Value;
            _characterController = entity.GetComponent<CharacterControllerComponent>().Value;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 velocity = _moveDirection.Value.normalized * _moveSpeed.Value;

            _characterController.Move(velocity * deltaTime);
        }
    }
}