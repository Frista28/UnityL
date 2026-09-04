using L1_3.Scripts.Game.Gameplay.Subsequence;
using L1_3.Scripts.Game.Utilities.SceneManagement;

namespace L1_3.Scripts.Game.Infrastructure.Gameplay
{
    public class GameplaySceneContext : SceneContext
    {
        public GameplaySceneContext(SubsequenceType subsequenceType)
        {
            SubsequenceType = subsequenceType;
        }
        
        public SubsequenceType SubsequenceType { get; }
    }
}