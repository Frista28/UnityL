using System;
using L1_3.Scripts.Game.Utilities.Reactive;
using UnityEngine;

namespace L1_3.Scripts.Game.Gameplay.Subsequence
{
    public class SubsequenceHandler
    {
        public event Action Win;
        public event Action Lose;
        
        private readonly SubsequenceGenerator _subsequenceGenerator;
        
        private readonly ReactiveVariable<string> _subsequence = new();
        private readonly ReactiveVariable<string> _currentSubsequence = new();
        
        private int _currentIndex;
        
        private bool _isRunning;

        public SubsequenceHandler(SubsequenceGenerator subsequenceGenerator)
        {
            _subsequenceGenerator = subsequenceGenerator;
        }
        
        public IReadOnlyVariable<string> Subsequence => _subsequence;
        
        public IReadOnlyVariable<string> CurrentSubsequence => _currentSubsequence;
        
        public bool IsCompleted => !_isRunning;

        public IReadOnlyVariable<string> Generate(SubsequenceType subsequenceType)
        {
            _subsequence.Value = _subsequenceGenerator.Generate(subsequenceType);
            _isRunning = true;
            return _subsequence;
        }

        public void Tick()
        {
            if (!_isRunning) return;
            
            if (Input.inputString == "") return;
            
            foreach (char input in Input.inputString)
            {
                _currentSubsequence.Value += input;
                
                if (input == _subsequence.Value[_currentIndex])
                {
                    Debug.Log(input);
                    _currentIndex++;

                    if (_currentIndex >= _subsequence.Value.Length)
                    {
                        _isRunning = false;
                        Win?.Invoke();
                        return;
                    }
                }
                else
                {
                    _isRunning = false;
                    Lose?.Invoke();
                    return;
                }
            }
        }
    }
}