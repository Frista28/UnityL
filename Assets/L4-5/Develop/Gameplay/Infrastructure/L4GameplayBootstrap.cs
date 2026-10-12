using System.Collections;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Infrastructure;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using L4_5.Develop.Gameplay.Features.AI;
using L4_5.Develop.Gameplay.Features.LifeCycle;
using L4.Develop.Gameplay.EntitiesCore;
using L4.Develop.Gameplay.Features.MovementFeature;
using UnityEngine;

namespace L4.Develop.Gameplay.Infrastructure
{
    public class L4GameplayBootstrap : MonoBehaviour, ISceneBootstrap
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;
        
        private EntitiesLifeContext _entitiesLifeContext;
        private AIBrainsContext _aiBrainsContext;
        private BrainsFactory _brainsFactory;
        
        private Entity _entity;
        private Entity _entity2;
        private Entity _teleportEntity;
        
        private bool _running;
        
        public void ProcessRegistrations(DIContainer container, SceneContext sceneContext)
        {
            _container = container;
            L4GameplayContainerRegistration.Registration(container);
            
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _aiBrainsContext = _container.Resolve<AIBrainsContext>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
        }

        public IEnumerator Initialize()
        {
            yield break;
        }

        public void Run()
        {
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(3,0,0));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(-3,0,0));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(0,0,3));
            _entitiesFactory.CreateRigidbodyEntity(new Vector3(0,0,-3));
            // _entity2 = _entitiesFactory.CreateCharacterEntity(Vector3.right);
            
            /*_entity2 = _entitiesFactory.CreateCharacterEntity(Vector3.zero);
            _brainsFactory.CreateGhostBrain(_entity2);*/

            _teleportEntity = _entitiesFactory.CreateTeleportEntity(Vector3.zero);
            _brainsFactory.CreateTeleportGhostBrain(_teleportEntity);
            
            _running = true;
        }

        private void Update()
        {
            if (!_running)
                return;
            
            _aiBrainsContext.Update(Time.deltaTime);
            
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     _entity.TakeDamageRequest.Invoke(50);
            //     Debug.Log("Текущий уровень здоровья: " + _entity.GetComponent<CurrentHealth>().Value.Value);
            // }
            //
            // Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            //
            // _entity.GetComponent<MoveDirection>().Value.Value = input;
            // _entity.GetComponent<RotateDirection>().Value.Value = input;
            
            // _entity2.GetComponent<MoveDirection>().Value.Value = input;
            // _entity2.GetComponent<RotateDirection>().Value.Value = input;
            
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     _teleportEntity.TeleportRequest.Invoke();
            // }
            
            _entitiesLifeContext.Update(Time.deltaTime);
        }
    }
}