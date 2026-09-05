using System;
using UnityEngine;

namespace L1_3.Scripts.Game.Gameplay.Subsequence
{
    public class SubsequenceHandler
    {
        public event Action Win;
        public event Action Lose;
        
        private readonly SubsequenceGenerator _subsequenceGenerator;
        
        private string _subsequence;
        private int _currentIndex;
        
        private bool _isRunning;

        public SubsequenceHandler(SubsequenceGenerator subsequenceGenerator)
        {
            _subsequenceGenerator = subsequenceGenerator;
        }
        
        public bool IsCompleted => !_isRunning;

        public string Generate(SubsequenceType subsequenceType)
        {
            _subsequence = _subsequenceGenerator.Generate(subsequenceType);
            _isRunning = true;
            return _subsequence;
        }

        public void Tick()
        {
            if (!_isRunning) return;
            
            if (Input.inputString == "") return;
            
            foreach (char input in Input.inputString)
            {
                if (input == _subsequence[_currentIndex])
                {
                    Debug.Log(input);
                    _currentIndex++;

                    if (_currentIndex >= _subsequence.Length)
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