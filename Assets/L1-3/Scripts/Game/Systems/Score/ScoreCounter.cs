using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.Utilities.DataManagement.DataProvider;
using L1_3.Scripts.Game.Utilities.DataManagement.SaveData;
using L1_3.Scripts.Game.Utilities.Reactive;

namespace L1_3.Scripts.Game.Systems.Score
{
    public class ScoreCounter : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly Dictionary<ScoreTypes, ReactiveVariable<int>> _scores;

        public ScoreCounter(Dictionary<ScoreTypes, ReactiveVariable<int>> scores, PlayerDataProvider playerDataProvider)
        {
            _scores = new Dictionary<ScoreTypes, ReactiveVariable<int>>(scores);
            
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public int Get(ScoreTypes scoreType)
        {
            if (!_scores.TryGetValue(scoreType, out var score))
                throw new InvalidOperationException("Score type " + scoreType + " not supported");
            
            return score.Value;
        }

        public void Add(ScoreTypes scoreType)
        {
            if (!_scores.TryGetValue(scoreType, out var score))
                throw new InvalidOperationException("Score type " + scoreType + " not supported");
            
            score.Value++;
        }

        public void Reset()
        {
            foreach (var score in _scores)
                score.Value.Value = 0;
        }

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<ScoreTypes, int> score in data.Scores)
            {
                if (_scores.TryGetValue(score.Key, out var issetScore))
                    issetScore.Value = score.Value;
                else
                    _scores.Add(score.Key, new ReactiveVariable<int>(score.Value));
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<ScoreTypes, ReactiveVariable<int>> score in _scores)
                data.Scores[score.Key] = score.Value.Value;
        }
    }
}