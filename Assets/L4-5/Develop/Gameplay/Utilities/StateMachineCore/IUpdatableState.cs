namespace L4_5.Develop.Gameplay.Utilities.StateMachineCore
{
    public interface IUpdatableState : IState
    {
        void Update(float deltaTime);
    }
}