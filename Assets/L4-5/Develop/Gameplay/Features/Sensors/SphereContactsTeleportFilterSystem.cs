using System;
using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.EntitiesCore;
using L4_5.Develop.Gameplay.Utilities;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.Sensors
{
    public class SphereContactsTeleportFilterSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<Vector3> _teleportEvent;
        
        private Buffer<Collider> _contacts;
        private Buffer<Entity> _contactsEntities;
        
        private readonly CollidersRegistryService _collidersRegistryService;
        
        private IDisposable _eventDisposable;

        public SphereContactsTeleportFilterSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _teleportEvent = entity.TeleportEvent;
            _contacts = entity.ContactCollidersBuffer;
            _contactsEntities = entity.ContactEntitiesBuffer;
            
            _eventDisposable = _teleportEvent.Subscribe(OnTeleportEvent);
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
        }

        private void OnTeleportEvent(Vector3 position)
        {
            Debug.Log("Filter");
            _contactsEntities.Count = 0;

            for (int i = 0; i < _contacts.Count; i++)
            {
                Collider collider = _contacts.Items[i];
                
                Entity contactEntity = _collidersRegistryService.GetBy(collider);

                if(contactEntity != null)
                {
                    _contactsEntities.Items[_contactsEntities.Count] = contactEntity;
                    _contactsEntities.Count++;
                }
            }
        }
    }
}