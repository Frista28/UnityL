using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;

namespace L1_3.Scripts.Game.Utilities.Timer
{
    public class TimerServiceFactory
    {
        private readonly DIContainer _container;

        public TimerServiceFactory(DIContainer container)
        {
            _container = container;
        }

        public TimerService Create(float cooldown)
            => new TimerService(cooldown, _container.Resolve<ICoroutinesPerformer>());
    }
}