using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.UI.CommonView;
using L1_3.Scripts.Game.UI.Core;

namespace L1_3.Scripts.Game.UI.Score
{
    public class ScorePresenter : IPresenter
    {
        private readonly ScoreCounter _scoreCounter;
        
        private readonly TextView _view;

        private List<IDisposable> _scoresDisposables = new();

        public ScorePresenter(
            ScoreCounter scoreCounter,
            TextView view)
        {
            _scoreCounter = scoreCounter;
            _view = view;
        }

        public TextView View => _view;

        public void Initialize()
        {
            UpdateScore(_scoreCounter.GetScoreValue(ScoreTypes.Win), _scoreCounter.GetScoreValue(ScoreTypes.Lose));

            _scoresDisposables.Add(_scoreCounter.GetScore(ScoreTypes.Win).Subscribe(OnWinScoreChanged));
            _scoresDisposables.Add(_scoreCounter.GetScore(ScoreTypes.Lose).Subscribe(OnLoseScoreChanged));
        }

        public void Dispose()
        {
            foreach (IDisposable scoresDisposable in _scoresDisposables)
                scoresDisposable.Dispose();
        }

        private void OnWinScoreChanged(int arg1, int newValue) => UpdateScore(newValue, _scoreCounter.GetScoreValue(ScoreTypes.Win));
        
        private void OnLoseScoreChanged(int arg1, int newValue) => UpdateScore(_scoreCounter.GetScoreValue(ScoreTypes.Lose), newValue);

        private void UpdateScore(int win, int lose) => _view.SetText(win.ToString() + "/" + lose.ToString());
    }
}