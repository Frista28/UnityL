using L1_3.Scripts.Game.Gameplay.Subsequence.Config;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using UnityEngine;

namespace L1_3.Scripts.Game.Gameplay.Subsequence
{
    public class SubsequenceGameConditionProcessor
    {
        private readonly ScoreCounter _scoreCounter;
        private readonly WalletService _walletService;
        
        private readonly SubsequenceConfigs _subsequenceConfigs;

        public SubsequenceGameConditionProcessor(ScoreCounter scoreCounter, WalletService walletService, SubsequenceConfigs subsequenceConfigs)
        {
            _scoreCounter = scoreCounter;
            _walletService = walletService;
            _subsequenceConfigs = subsequenceConfigs;
        }

        public void ProcessWin()
        {
            _scoreCounter.Add(ScoreTypes.Win);
            _walletService.Add(CurrencyTypes.Gold, _subsequenceConfigs.WinGold);
            
            Debug.Log("Вы победили");
            Debug.Log($"Ваш счёт {_scoreCounter.Get(ScoreTypes.Win)}/{_scoreCounter.Get(ScoreTypes.Lose)}");
        }

        public void ProcessLose()
        {
            _scoreCounter.Add(ScoreTypes.Lose);
            
            Debug.Log("Вы проиграли");
            Debug.Log($"Ваш счёт {_scoreCounter.Get(ScoreTypes.Win)}/{_scoreCounter.Get(ScoreTypes.Lose)}");
        }
    }
}