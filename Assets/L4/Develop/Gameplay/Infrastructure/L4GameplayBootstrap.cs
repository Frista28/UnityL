using System.Collections;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Infrastructure;
using L1_3.Scripts.Game.Utilities.SceneManagement;
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
        
        private Entity _entity;
        private Entity _entity2;
        
        private bool _running;
        
        public void ProcessRegistrations(DIContainer container, SceneContext sceneContext)
        {
            _container = container;
            L4GameplayContainerRegistration.Registration(container);
            
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public IEnumerator Initialize()
        {
            yield break;
        }

        public void Run()
        {
            _entity = _entitiesFactory.CreateRigidbodyEntity(Vector3.zero);
            _entity2 = _entitiesFactory.CreateCharacterEntity(Vector3.right);
            
            _running = true;
        }

        private void Update()
        {
            if (!_running)
                return;
            
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            _entity.GetComponent<MoveDirection>().Value.Value = input;
            _entity.GetComponent<RotateDirection>().Value.Value = input;
            
            _entity2.GetComponent<MoveDirection>().Value.Value = input;
            _entity2.GetComponent<RotateDirection>().Value.Value = input;
            
            _entitiesLifeContext.Update(Time.fixedDeltaTime);
        }
    }
}