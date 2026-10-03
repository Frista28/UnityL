using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Utilities.Conditions;
using L4.Develop.Gameplay.EntitiesCore;
using UnityEngine;

namespace L4.Develop.Gameplay.Features.MovementFeature
{
    public class MoveDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MoveSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanMove : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class RotateDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class RotateSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class CanRotate : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class MoveEnergyMax : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MoveEnergyCurrent : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MoveEnergyRecovery : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}