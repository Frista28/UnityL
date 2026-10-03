using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Mono;
using L4.Develop.Gameplay.Features.MovementFeature;
using UnityEngine;

namespace L4.Develop.Gameplay.EntitiesCommon
{
    public class RigidbodyEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddComponent(new RigidbodyComponent() { Value = GetComponent<Rigidbody>() });
        }
    }
}