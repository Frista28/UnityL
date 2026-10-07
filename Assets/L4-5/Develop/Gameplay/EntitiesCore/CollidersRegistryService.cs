using System.Collections.Generic;
using L4.Develop.Gameplay.EntitiesCore;
using UnityEngine;

namespace L4_5.Develop.Gameplay.EntitiesCore
{
    public class CollidersRegistryService
    {
        private readonly Dictionary<Collider, Entity> _colliderToEntity = new();

        public void Register(Collider collider, Entity entity)
        {
            _colliderToEntity.Add(collider, entity);
        }

        public void Unregister(Collider collider)
        {
            _colliderToEntity.Remove(collider);
        }

        public Entity GetBy(Collider collider) => _colliderToEntity.GetValueOrDefault(collider);
    }
}