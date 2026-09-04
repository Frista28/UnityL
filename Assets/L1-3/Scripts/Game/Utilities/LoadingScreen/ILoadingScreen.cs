namespace L1_3.Scripts.Game.Utilities.LoadingScreen
{
    public interface ILoadingScreen
    {
        bool IsShown { get; }
        void Show();
        void Hide();
    }
}