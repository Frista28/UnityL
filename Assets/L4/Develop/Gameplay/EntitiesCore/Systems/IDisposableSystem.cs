namespace L4.Develop.Gameplay.EntitiesCore.Systems
{
    public interface IDisposableSystem : IEntitySystem
    {
        void OnDispose();
    }
}