using System.Collections.Generic;
using L1_3.Scripts.Game.Gameplay.Menu;
using L1_3.Scripts.Game.UI.Core;
using L1_3.Scripts.Game.UI.Score;
using L1_3.Scripts.Game.UI.Wallet;
using UnityEngine;

namespace L1_3.Scripts.Game.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screen;

        private readonly GlobalPresentersFactory _globalPresentersFactory;
        
        private readonly MenuSystem _menuSystem;
        
        private readonly List<IPresenter> _childPresenters = new();
        
        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            GlobalPresentersFactory globalPresentersFactory,
            MenuSystem menySystem
            )
        {
            _screen = screen;
            _globalPresentersFactory = globalPresentersFactory;
            _menuSystem = menySystem;
        }

        public void Initialize()
        {
            _screen.ResetButtonClicked += OnResetButtonClicked;
            
            CreateWallet();
            CreateScore();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }
        
        public void Dispose()
        {
            _screen.ResetButtonClicked -= OnResetButtonClicked;
            
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

        private void OnResetButtonClicked()
        {
            Debug.Log("OnResetButtonClicked");
            _menuSystem.TryReset();
        }
    }
}