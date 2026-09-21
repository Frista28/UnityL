using System.Collections.Generic;
using L1_3.Scripts.Game.UI.Core;
using UnityEngine;

namespace L1_3.Scripts.Game.UI.CommonView
{
    public class ElementsViewList<TElement> : MonoBehaviour, IView where TElement : MonoBehaviour, IView
    {
        [SerializeField] private Transform _parent;

        private List<TElement> _elements = new();

        public IReadOnlyList<TElement> Elements => _elements;

        public void Add(TElement element)
        {
            element.transform.SetParent(_parent);
            _elements.Add(element);
        }

        public void Remove(TElement element)
        {
            element.transform.SetParent(null);
            _elements.Remove(element);
        }
    }
}