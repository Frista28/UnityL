using System.Collections;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Menu;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Infrastructure.MainMenu
{
    public class MainMenuBootstrap : MonoBehaviour, ISceneBootstrap
    {
        private DIContainer _container;
        private MenuSystem _menuSystem;
        
        private bool _running;
        
        public void ProcessRegistrations(DIContainer container, SceneContext sceneContext)
        {
            Debug.Log("Регистрация меню");
            _container = container;
            MainMenuContainerRegistration.Registration(container);
            
            _menuSystem = _container.Resolve<MenuSystem>();
        }

        public IEnumerator Initialize()
        {
            Debug.Log("Инициализация меню");
            yield break;
        }

        public void Run()
        {
            Debug.Log("Запуск меню");
            _running = true;
        }

        private void Update()
        {
            if (!_running)
                return;
            
            _menuSystem.Update();
        }
    }
}