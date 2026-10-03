namespace L4.Develop.Gameplay.EntitiesCore.Systems
{
    public interface IInitializableSystem : IEntitySystem
    {
        void OnInit(Entity entity);
    }
}