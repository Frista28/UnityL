using System;
using L1_3.Scripts.Game.Utilities.Reactive;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;

namespace L4_5.Develop.Gameplay.Features.LifeCycle
{
    public class DeathProcessTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<bool> _isDead;
        private ReactiveVariable<bool> _inDeathProcess;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<float> _currentTime;
        
        private IDisposable _isDeadChangedDisposable;

        public void OnInit(Entity entity)
        {
            _isDead = entity.GetComponent<IsDead>().Value;
            _inDeathProcess = entity.GetComponent<InDeathProcess>().Value;
            _initialTime = entity.GetComponent<DeathProcessInitialTime>().Value;
            _currentTime = entity.GetComponent<DeathProcessCurrentTime>().Value;

            _isDeadChangedDisposable = _isDead.Subscribe(OnIsDeadChanged);
        }
        
        public void OnUpdate(float deltaTime)
        {
            if (_inDeathProcess.Value == false)
                return;
            
            _currentTime.Value -= deltaTime;
            
            if (CooldownIsOver())
                _inDeathProcess.Value = false;
        }

        public void OnDispose()
        {
            _isDeadChangedDisposable.Dispose();
        }

        private void OnIsDeadChanged(bool arg1, bool isDead)
        {
            if (isDead)
            {
                _currentTime.Value = _initialTime.Value;
                _inDeathProcess.Value = true;
            }
        }
        
        private bool CooldownIsOver() => _currentTime.Value <= 0;
    }
}