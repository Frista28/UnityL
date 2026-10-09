using L1_3.Scripts.Game.Utilities.Reactive;

namespace L4_5.Develop.Gameplay.Utilities.StateMachineCore
{
    public interface IState
    {
        IReadOnlyEvent Entered { get; }
        IReadOnlyEvent Exited { get; }

        void Enter();
        void Exit();
    }
}