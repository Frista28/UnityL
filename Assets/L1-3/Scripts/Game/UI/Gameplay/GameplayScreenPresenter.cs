using System.Collections.Generic;
using L1_3.Scripts.Game.UI.Core;
using L1_3.Scripts.Game.UI.Gameplay.Subsequence;
using L1_3.Scripts.Game.UI.Score;
using L1_3.Scripts.Game.UI.Wallet;

namespace L1_3.Scripts.Game.UI.Gameplay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly GameplayScreenView _screen;

        private readonly GlobalPresentersFactory _globalPresentersFactory;
        private readonly GameplayPresenterFactory _gameplayPresenterFactory;
        
        private readonly List<IPresenter> _childPresenters = new();
        
        public GameplayScreenPresenter(
            GameplayScreenView screen,
            GlobalPresentersFactory globalPresentersFactory,
            GameplayPresenterFactory gameplayPresenterFactory
        )
        {
            _screen = screen;
            _globalPresentersFactory = globalPresentersFactory;
            _gameplayPresenterFactory = gameplayPresenterFactory;
        }

        public void Initialize()
        {
            CreateWallet();
            CreateScore();
            CreateSubsequences();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }
        
        public void Dispose()
        {
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _globalPresentersFactory.CreateWalletPresenter(_screen.Wallet);

            _childPresenters.Add(walletPresenter);
        }
        
        private void CreateScore()
        {
            ScorePresenter scorePresenter = _globalPresentersFactory.CreateScorePresenter(_screen.ScoreView);

            _childPresenters.Add(scorePresenter);
        }

        private void CreateSubsequences()
        {
            SubsequencePresenter subsequencePresenter = _gameplayPresenterFactory.CreateSubsequencePresenter(
                _screen.Subsequence,
                _screen.CurrentSubsequence);
            
            _childPresenters.Add(subsequencePresenter);
        }
    }
}