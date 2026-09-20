using L1_3.Scripts.Game.UI.Core;

namespace L1_3.Scripts.Game.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screen;
        
        public MainMenuScreenPresenter(MainMenuScreenView screen)
        {
            _screen = screen;
        }

        public void Initialize()
        {
        }
        
        public void Dispose()
        {
        }
    }
}