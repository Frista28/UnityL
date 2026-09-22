using L1_3.Scripts.Game.UI.CommonView;
using L1_3.Scripts.Game.UI.Core;
using UnityEngine;

namespace L1_3.Scripts.Game.UI.Gameplay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextListView Wallet { get; private set; }
        [field: SerializeField] public TextView ScoreView { get; private set; }
        
        [field: SerializeField] public TextView Subsequence { get; private set; }
        [field: SerializeField] public TextView CurrentSubsequence { get; private set; }
    }
}