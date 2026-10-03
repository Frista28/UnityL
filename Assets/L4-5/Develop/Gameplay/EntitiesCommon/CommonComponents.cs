using L4.Develop.Gameplay.EntitiesCore;
using UnityEngine;

namespace L4.Develop.Gameplay.EntitiesCommon
{
    public class RigidbodyComponent : IEntityComponent
    {
        public Rigidbody Value;
    }

    public class CharacterControllerComponent : IEntityComponent
    {
        public CharacterController Value;
    }

    public class TransformComponent : IEntityComponent
    {
        public Transform Value;
    }
}