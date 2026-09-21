using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.UI.CommonView;
using L1_3.Scripts.Game.UI.Score;
using L1_3.Scripts.Game.UI.Wallet;
using L1_3.Scripts.Game.Utilities.Reactive;

namespace L1_3.Scripts.Game.UI.Core
{
    public class GlobalPresentersFactory
    {
        private DIContainer _container;

        public GlobalPresentersFactory(DIContainer container)
        {
            _container = container;
        }
        
        public CurrencyPresenter CreateCurrencyPresenter(
            IconTextView view,
            IReadOnlyVariable<int> currency,
            CurrencyTypes currencyType)
        {
            return new CurrencyPresenter(
                currency,
                currencyType,
                view);
        }

        public WalletPresenter CreateWalletPresenter(IconTextListView listView)
        {
            return new WalletPresenter(
                _container.Resolve<WalletService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                listView);
        }

        public ScorePresenter CreateScorePresenter(TextView view)
        {
            return new ScorePresenter(
                _container.Resolve<ScoreCounter>(),
                view);
        }
    }
}