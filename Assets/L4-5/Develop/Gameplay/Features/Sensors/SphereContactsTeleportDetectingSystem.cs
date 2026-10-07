using System;
using L1_3.Scripts.Game.Utilities.Reactive;
using L4_5.Develop.Gameplay.Utilities;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace L4_5.Develop.Gameplay.Features.Sensors
{
    public class SphereContactsTeleportDetectingSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<Vector3> _teleportEvent;
        
        private ReactiveVariable<float> _colliderRadius;
        
        private Buffer<Collider> _contacts;
        private LayerMask _mask;
        
        private CapsuleCollider _body;
        
        private IDisposable _eventDisposable;
        
        public void OnInit(Entity entity)
        {
            _teleportEvent = entity.TeleportEvent;

            _colliderRadius = entity.SphereColliderRadius;
            
            _contacts = entity.ContactCollidersBuffer;
            _mask = entity.ContactsDetectingMask;

            _body = entity.BodyCollider;

            _eventDisposable = _teleportEvent.Subscribe(OnTeleportEvent);
        }

        public void OnDispose()
        {
            _eventDisposable.Dispose();
        }

        private void OnTeleportEvent(Vector3 position)
        {
            Debug.Log(position);
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                position, 
                _colliderRadius.Value, 
                _contacts.Items, 
                _mask,
                QueryTriggerInteraction.Ignore);
        
            RemoveSelfFromContacts();

            Debug.Log("Контакты: " + _contacts.Count);
            for (int i = 0; i < _contacts.Count; i++)
            {
                Debug.Log($"{_contacts.Items[i].name}: {_contacts.Items[i].transform.position}");
            }
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; i++)
                {
                    _contacts.Items[i] = _contacts.Items[i + 1];
                }

                _contacts.Count--;
            }
        }
    }
}