using L1_3.Scripts.Game.Utilities.Reactive;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.LifeCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _isDead;

        private ReactiveVariable<float> _currentHealth;

        public void OnInit(Entity entity)
        {
            _isDead = entity.GetComponent<IsDead>().Value;
            _currentHealth = entity.GetComponent<CurrentHealth>().Value;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value)
            {
                return;
            }
            
            if(_currentHealth.Value <= 0)
            {
                _isDead.Value = true;
                Debug.Log("Я умер!");
            }
        }
    }
}