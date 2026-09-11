using System;
using System.Collections;
using System.Collections.Generic;
using L1_3.Scripts.Game.Gameplay.Menu.Configs;
using L1_3.Scripts.Game.Gameplay.Subsequence.Config;
using L1_3.Scripts.Game.Systems.Wallet.Configs;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Utilities.ConfigsManagement
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLoader _resources;

        private Dictionary<Type, string> _configsResourcesPaths = new()
        {
            [typeof(SubsequenceConfigs)] = "Gameplay/Configs/Subsequence/SubsequenceConfigs",
            [typeof(StartWalletConfig)] = "Configs/Systems/Wallet/StartWalletConfig",
            [typeof(MenuSystemConfig)] = "Configs/Menu/MenuSystemConfig",
        };

        public ResourcesConfigsLoader(ResourcesAssetsLoader resources)
        {
            _resources = resources;
        }

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new();

            foreach (KeyValuePair<Type, string> configResourcesPath in _configsResourcesPaths)
            {
                ScriptableObject config = _resources.Load<ScriptableObject>(configResourcesPath.Value);
                loadedConfigs.Add(configResourcesPath.Key, config);
                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }
    }
}