using L1_3.Scripts.Game.Utilities.Reactive;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.MovementFeature
{
    public class MoveEnergyTimeRecoverSystem : IUpdatableSystem, IInitializableSystem
    {
        private ReactiveVariable<float> _moveEnergyCurrent;
        private ReactiveVariable<float> _moveEnergyMax;
        
        private ReactiveVariable<float> _energyRecoveryTime;

        private float _timer;

        public void OnInit(Entity entity)
        {
            _moveEnergyCurrent = entity.MoveEnergyCurrent;
            _moveEnergyMax = entity.MoveEnergyMax;
            
            _energyRecoveryTime = entity.MoveEnergyRecovery;
        }
        
        public void OnUpdate(float deltaTime)
        {
            Debug.Log(_moveEnergyCurrent.Value);
            if (_moveEnergyCurrent.Value >= _moveEnergyMax.Value)
            {
                _timer = 0;
                return;
            }

            if (_timer < _energyRecoveryTime.Value)
            {
                _timer += deltaTime;
                return;
            }
            
            if (_moveEnergyCurrent.Value + _moveEnergyMax.Value * 0.1f > _moveEnergyMax.Value)
            {
                _moveEnergyCurrent.Value = _moveEnergyMax.Value;
                _timer = 0;
                return;
            }

            _moveEnergyCurrent.Value += _moveEnergyMax.Value * 0.1f;
            _timer = 0;
        }
    }
}