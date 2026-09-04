using UnityEngine;

namespace L1_3.Scripts.Game.Utilities.AssetsManagement
{
    public class ResourcesAssetsLoader
    {
        public T Load<T>(string resourcePath) where T : Object
            => Resources.Load<T>(resourcePath);
    }
}