using System;
using System.Collections;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Subsequence;
using L1_3.Scripts.Game.Infrastructure.Gameplay;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Infrastructure.MainMenu
{
    public class MainMenuBootstrap : MonoBehaviour, ISceneBootstrap
    {
        private DIContainer _container;
        
        public void ProcessRegistrations(DIContainer container, SceneContext sceneContext)
        {
            Debug.Log("Регистрация меню");
            _container = container;
        }

        public IEnumerator Initialize()
        {
            Debug.Log("Инициализация меню");
            yield break;
        }

        public void Run()
        {
            Debug.Log("Запуск меню");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplaySceneContext(SubsequenceType.Number)));
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplaySceneContext(SubsequenceType.Chars)));
            }
        }
    }
}