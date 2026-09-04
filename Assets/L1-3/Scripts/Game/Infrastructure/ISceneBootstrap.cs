using System.Collections;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Utilities.SceneManagement;

namespace L1_3.Scripts.Game.Infrastructure
{
    public interface ISceneBootstrap
    {
        void ProcessRegistrations(DIContainer container, SceneContext sceneContext);

        IEnumerator Initialize();

        void Run();
    }
}