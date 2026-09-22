using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.Utilities.AssetsManagement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace L1_3.Scripts.Game.UI.Core
{
    public class ViewsFactory
    {
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader;

        private readonly Dictionary<ViewTypes, string> _viewIDToResourcesPath = new Dictionary<ViewTypes, string>()
        {
            {ViewTypes.CurrencyView, "UI/Wallet/CurrencyView" },
            {ViewTypes.ScoreView, "UI/Score/ScoreView" },
            {ViewTypes.MainMenuScreenView, "UI/MainMenu/MainMenuScreenView" },
            {ViewTypes.GameplayScreenView, "UI/Gameplay/GameplayScreenView" },
        };

        public ViewsFactory(ResourcesAssetsLoader resourcesAssetsLoader)
        {
            _resourcesAssetsLoader = resourcesAssetsLoader;
        }

        public TView Create<TView>(ViewTypes viewType, Transform parent = null) where TView : MonoBehaviour, IView
        {
            if (_viewIDToResourcesPath.TryGetValue(viewType, out string resourcePath) == false)
                throw new ArgumentException($"You didn't set resource path for {typeof(TView)}, searched id: {viewType}");

            GameObject prefab = _resourcesAssetsLoader.Load<GameObject>(resourcePath);
            GameObject instance = Object.Instantiate(prefab, parent);
            TView view = instance.GetComponent<TView>();

            if (view == null)
                throw new InvalidOperationException($"Not found {typeof(TView)} component on view instance");

            return view;
        }

        public void Release<TView>(TView view) where TView : MonoBehaviour, IView
        {
            Object.Destroy(view.gameObject);
        }
    }
}