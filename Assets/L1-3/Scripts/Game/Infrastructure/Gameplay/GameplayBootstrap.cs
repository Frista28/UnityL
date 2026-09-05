using System;
using System.Collections;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Subsequence;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Infrastructure.Gameplay
{
    public class GameplayBootstrap : MonoBehaviour, ISceneBootstrap
    {
        private DIContainer _container;
        private GameplaySceneContext _gameplaySceneContext;
        
        private SubsequenceGameLoop _subsequenceGameLoop;
        
        public void ProcessRegistrations(DIContainer container, SceneContext sceneContext)
        {
            Debug.Log("Регистрация геймплея");
            _container = container;
            
            if (sceneContext is not GameplaySceneContext subsequenceSceneContext)
                throw new ArgumentException($"{nameof(sceneContext)} is not match with {typeof(GameplaySceneContext)} type");
            
            _gameplaySceneContext = subsequenceSceneContext;
            
            GameplayContainerRegistration.Registration(_container, subsequenceSceneContext);
        }

        public IEnumerator Initialize()
        {
            Debug.Log("Инициализация геймплея");
            
            yield return _subsequenceGameLoop = _container.Resolve<SubsequenceGameLoop>();
        }

        public void Run()
        {
            Debug.Log("Запуск геймплея");
            
            _subsequenceGameLoop.Start(_gameplaySceneContext.SubsequenceType);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu, new SceneContext()));
            }
            
            _subsequenceGameLoop.Update();
        }

        private void OnDestroy()
        {
            _subsequenceGameLoop.Dispose();
        }
    }
}