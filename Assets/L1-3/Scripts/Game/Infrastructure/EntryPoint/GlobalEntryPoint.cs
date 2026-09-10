using System.Collections;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.DataManagement.DataProvider;
using L1_3.Scripts.Game.Utilities.LoadingScreen;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Infrastructure.EntryPoint
{
    public class GlobalEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("GameEntryPoint Awake");
            
            DIContainer globalContainer = new DIContainer();
            GlobalContainerRegistration.Register(globalContainer);
            globalContainer.Initialize();
            GlobalSceneBootstrapRegistry.Register(globalContainer);
            globalContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(globalContainer));
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();

            loadingScreen.Show();
            
            Debug.Log("Начинается инициализация сервисов");

            yield return container.Resolve<ConfigsProviderService>().LoadAsync();
            
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();
            
            bool isPlayerDataSaveExists = false;
            
            yield return playerDataProvider.Exists(result => isPlayerDataSaveExists = result);

            if (isPlayerDataSaveExists)
                yield return playerDataProvider.Load();
            else
                playerDataProvider.Reset();

            yield return new WaitForSeconds(1f);

            Debug.Log("Завершается инициализация сервисов");

            // loadingScreen.Hide();
            
            yield return container.Resolve<SceneSwitcherService>().ProcessSwitchTo(Scenes.MainMenu, new SceneContext());
        }
    }
}
