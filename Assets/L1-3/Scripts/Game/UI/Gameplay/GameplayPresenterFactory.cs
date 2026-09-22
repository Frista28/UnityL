using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Subsequence;
using L1_3.Scripts.Game.UI.CommonView;
using L1_3.Scripts.Game.UI.Core;
using L1_3.Scripts.Game.UI.Gameplay.Subsequence;

namespace L1_3.Scripts.Game.UI.Gameplay
{
    public class GameplayPresenterFactory
    {
        private readonly DIContainer _container;

        public GameplayPresenterFactory(DIContainer container)
        {
            _container = container;
        }

        public GameplayScreenPresenter CreateMainMenuScreen(GameplayScreenView view)
        {
            return new GameplayScreenPresenter(
                view,
                _container.Resolve<GlobalPresentersFactory>(),
                this);
        }

        public SubsequencePresenter CreateSubsequencePresenter(
            TextView subsequenceView,
            TextView currentSubsequenceView)
        {
            return new SubsequencePresenter(
                subsequenceView,
                currentSubsequenceView,
                _container.Resolve<SubsequenceHandler>());
        }
    }
}