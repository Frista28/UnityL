using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace L4.Develop.Gameplay.EntitiesCommon
{
    public class TransformEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddComponent(new TransformComponent() { Value = GetComponent<Transform>() });
        }
    }
}