using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.Gameplay.Subsequence;
using L1_3.Scripts.Game.UI.CommonView;
using L1_3.Scripts.Game.UI.Core;
using UnityEngine;

namespace L1_3.Scripts.Game.UI.Gameplay.Subsequence
{
    public class SubsequencePresenter : IPresenter
    {
        private readonly SubsequenceHandler _handler;
        
        private readonly TextView _subsequenceView;
        private readonly TextView _currentSubsequenceView;

        private readonly List<IDisposable> _disposables = new();

        public SubsequencePresenter(
            TextView subsequenceView,
            TextView currentSubsequenceView,
            SubsequenceHandler handler)
        {
            _subsequenceView = subsequenceView;
            _currentSubsequenceView = currentSubsequenceView;
            _handler = handler;
        }

        public void Initialize()
        {
            UpdateSubsequence(_handler.Subsequence.Value);
            UpdateCurrentSubsequence(_handler.CurrentSubsequence.Value);
            
            _disposables.Add(_handler.Subsequence.Subscribe(OnSubsequenceChanged));
            _disposables.Add(_handler.CurrentSubsequence.Subscribe(OnCurrentSubsequenceChanged));
            
            // Можно вынести в конфиги
            _handler.Win += OnWin;
            _handler.Lose += OnLose;
        }

        public void Dispose()
        {
            foreach (IDisposable scoresDisposable in _disposables)
                scoresDisposable.Dispose();
            
            _handler.Win -= OnWin;
            _handler.Lose -= OnLose;
        }
        
        private void OnSubsequenceChanged(string oldValue, string newValue) => UpdateSubsequence(newValue);
        
        private void OnCurrentSubsequenceChanged(string oldValue, string newValue) => UpdateCurrentSubsequence(newValue);
        
        private void UpdateSubsequence(string value) => _subsequenceView.SetText(value);
        
        private void UpdateCurrentSubsequence(string value) => _currentSubsequenceView.SetText(value);

        private void OnWin() => _currentSubsequenceView.SetColor(Color.green);
        
        private void OnLose() => _currentSubsequenceView.SetColor(Color.red);
    }
}