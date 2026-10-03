using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Utilities.Conditions;
using L4.Develop.Gameplay.EntitiesCore;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.MovementFeature.Teleport
{
    public class TeleportRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }
    
    public class TeleportEvent : IEntityComponent
    {
        public ReactiveEvent<Vector3> Value;
    }
    
    public class TeleportCost : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class TeleportRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class CanTeleport : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}