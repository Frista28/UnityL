using L1_3.Scripts.Game.Gameplay.Menu.Configs;
using L1_3.Scripts.Game.Gameplay.Subsequence;
using L1_3.Scripts.Game.Infrastructure.Gameplay;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.DataManagement.DataProvider;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Gameplay.Menu
{
    public class MenuSystem
    {
        private readonly ScoreCounter _scoreCounter;
        private readonly WalletService _walletService;
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private readonly MenuSystemConfig _menuSystemConfig;


        public MenuSystem(
            ScoreCounter scoreCounter, 
            WalletService walletService, 
            SceneSwitcherService sceneSwitcherService,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            MenuSystemConfig menuSystemConfig)
        {
            _scoreCounter = scoreCounter;
            _walletService = walletService;
            _sceneSwitcherService = sceneSwitcherService;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _menuSystemConfig = menuSystemConfig;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplaySceneContext(SubsequenceType.Number)));
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplaySceneContext(SubsequenceType.Chars)));
                return;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log($"Ваш счёт {_scoreCounter.Get(ScoreTypes.Win)}/{_scoreCounter.Get(ScoreTypes.Lose)}");
                Debug.Log($"Золото {_walletService.GetCurrency(CurrencyTypes.Gold).Value}");
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                bool enoughGold = _walletService.Enough(CurrencyTypes.Gold, _menuSystemConfig.ResetCost);

                if (enoughGold)
                    Reset();
                else
                    Debug.Log($"У вас недостаточно средвтсв, ваше золото - {_walletService.GetCurrency(CurrencyTypes.Gold).Value} из {_menuSystemConfig.ResetCost}");
            }
        }
        
        private void Reset()
        {
            _walletService.Spend(CurrencyTypes.Gold, _menuSystemConfig.ResetCost);
            _scoreCounter.Reset();
            _coroutinesPerformer.StartPerform(_playerDataProvider.Save());
            
            Debug.Log("Сброс прогресса");
            Debug.Log($"Теперь ваш счёт {_scoreCounter.Get(ScoreTypes.Win)}/{_scoreCounter.Get(ScoreTypes.Lose)} и золото {_walletService.GetCurrency(CurrencyTypes.Gold).Value}");
        }
    }
}