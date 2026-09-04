using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Infrastructure;

namespace L1_3.Scripts.Game.Utilities.SceneManagement
{
    public class SceneBootstrapRegistry
    {
        private readonly Dictionary<Scenes, Func<ISceneBootstrap>> _factories = new();

        public void Register(Scenes sceneName, Func<ISceneBootstrap> factory)
        {
            _factories[sceneName] = factory;
        }

        public ISceneBootstrap Create(Scenes sceneName)
        {
            if (!_factories.TryGetValue(sceneName, out Func<ISceneBootstrap> factory))
                throw new KeyNotFoundException($"No bootstrap registered for scene '{sceneName}'");

            return factory();
        }
    }
}