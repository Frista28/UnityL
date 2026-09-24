namespace L4.Develop.Gameplay.EntitiesCore.Systems
{
    public interface IUpdatableSystem : IEntitySystem
    {
        void OnUpdate(float deltaTime);
    }
}