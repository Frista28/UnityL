using System.Collections.Generic;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.UI.CommonView;
using L1_3.Scripts.Game.UI.Core;

namespace L1_3.Scripts.Game.UI.Wallet
{
    public class WalletPresenter : IPresenter
    {
        private readonly WalletService _walletService;
        private readonly GlobalPresentersFactory _globalPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly IconTextListView _listView;

        private readonly List<CurrencyPresenter> _currencyPresenters = new();

        public WalletPresenter(
            WalletService walletService, 
            GlobalPresentersFactory globalPresentersFactory, 
            ViewsFactory viewsFactory, 
            IconTextListView listView)
        {
            _walletService = walletService;
            _globalPresentersFactory = globalPresentersFactory;
            _viewsFactory = viewsFactory;
            _listView = listView;
        }

        public void Initialize()
        {
            foreach (CurrencyTypes currencyType in _walletService.AvailableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewTypes.CurrencyView);

                _listView.Add(currencyView);

                CurrencyPresenter currencyPresenter = _globalPresentersFactory.CreateCurrencyPresenter(
                    currencyView,
                    _walletService.GetCurrency(currencyType),
                    currencyType);

                currencyPresenter.Initialize();
                _currencyPresenters.Add(currencyPresenter);
            }
        }

        public void Dispose()
        {
            foreach (CurrencyPresenter currencyPresenter in _currencyPresenters)
            {
                _listView.Remove(currencyPresenter.View);
                _viewsFactory.Release(currencyPresenter.View);
                currencyPresenter.Dispose();
            }

            _currencyPresenters.Clear();
        }
    }
}