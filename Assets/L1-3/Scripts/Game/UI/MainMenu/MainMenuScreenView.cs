using System;
using L1_3.Scripts.Game.UI.CommonView;
using L1_3.Scripts.Game.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace L1_3.Scripts.Game.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action ResetButtonClicked;
        
        [field: SerializeField] public IconTextListView Wallet { get; private set; }
        [field: SerializeField] public TextView ScoreView { get; private set; }
        
        [SerializeField] private Button _resetButton;

        private void OnEnable()
        {
            _resetButton.onClick.AddListener(OnResetButtonClicked);
        }

        private void OnDisable()
        {
            _resetButton.onClick.RemoveListener(OnResetButtonClicked);
        }

        private void OnResetButtonClicked() => ResetButtonClicked?.Invoke();
    }
}