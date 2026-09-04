using System;
using System.Collections;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Infrastructure;
using L1_3.Scripts.Game.Utilities.LoadingScreen;

namespace L1_3.Scripts.Game.Utilities.SceneManagement
{
    public class SceneSwitcherService
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private readonly ILoadingScreen _loadingScreen;
        private readonly DIContainer _globalContainer;

        public SceneSwitcherService(
            SceneLoaderService sceneLoaderService, 
            ILoadingScreen loadingScreen,
            DIContainer globalContainer)
        {
            _sceneLoaderService = sceneLoaderService;
            _loadingScreen = loadingScreen;
            _globalContainer = globalContainer;
        }

        public IEnumerator ProcessSwitchTo(Scenes sceneName, SceneContext sceneContext)
        {
            _loadingScreen.Show();

            yield return _sceneLoaderService.LoadAsync(sceneName);

            SceneBootstrapRegistry sceneBootstrapRegistry = _globalContainer.Resolve<SceneBootstrapRegistry>();
            
            ISceneBootstrap sceneBootstrap = sceneBootstrapRegistry.Create(sceneName);
            
            if (sceneBootstrap == null)
                throw new InvalidOperationException(nameof(sceneBootstrap) + " not found");

            DIContainer sceneContainer = new DIContainer(_globalContainer);

            sceneBootstrap.ProcessRegistrations(sceneContainer, sceneContext);

            yield return sceneBootstrap.Initialize();

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}