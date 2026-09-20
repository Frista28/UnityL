using L1_3.Scripts.Game.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace L1_3.Scripts.Game.UI.CommonView
{
    public class IconTextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _icon;

        public void SetText(string text) => _text.text = text;

        public void SetIcon(Sprite icon) => _icon.sprite = icon;
    }
}