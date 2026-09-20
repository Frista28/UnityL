using System;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.UI.CommonView;
using L1_3.Scripts.Game.UI.Core;
using L1_3.Scripts.Game.Utilities.Reactive;

namespace L1_3.Scripts.Game.UI.Wallet
{
    public class CurrencyPresenter : IPresenter
    {
        private readonly IReadOnlyVariable<int> _currency;
        
        private readonly IconTextView _view;

        private IDisposable _disposable;

        public CurrencyPresenter(
            IReadOnlyVariable<int> currency, 
            CurrencyTypes currencyType, 
            IconTextView view)
        {
            _currency = currency;
            _view = view;
        }

        public IconTextView View => _view;

        public void Initialize()
        {
            UpdateValue(_currency.Value);

            _disposable = _currency.Subscribe(OnCurrencyChanged);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnCurrencyChanged(int arg1, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetText(value.ToString());
    }
}