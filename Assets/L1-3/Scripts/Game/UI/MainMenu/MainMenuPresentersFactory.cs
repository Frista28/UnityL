using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Menu;
using L1_3.Scripts.Game.UI.Core;

namespace L1_3.Scripts.Game.UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresenter CreateMainMenuScreen(MainMenuScreenView view)
        {
            return new MainMenuScreenPresenter(
                view,
                _container.Resolve<GlobalPresentersFactory>(),
                _container.Resolve<MenuSystem>());
        }
    }
}