using L1_3.Scripts.Game.Utilities.Reactive;
using L4.Develop.Gameplay.EntitiesCore;

namespace L4_5.Develop.Gameplay.Features.ApplyDamage.TeleportDamage
{
    public class TeleportContactDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}