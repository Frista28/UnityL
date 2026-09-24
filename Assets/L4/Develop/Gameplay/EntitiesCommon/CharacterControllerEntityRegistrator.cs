using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace L4.Develop.Gameplay.EntitiesCommon
{
    public class CharacterControllerEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddComponent(new CharacterControllerComponent() { Value = GetComponent<CharacterController>() });
        }
    }
}