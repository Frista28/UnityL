using L1_3.Scripts.Game.UI.Core;
using TMPro;
using UnityEngine;

namespace L1_3.Scripts.Game.UI.CommonView
{
    public class TextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text) => _text.text = text;
        
        public void SetColor(Color color) => _text.color = color;
    }
}