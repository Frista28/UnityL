using System.Collections;
using UnityEngine;

namespace L1_3.Scripts.Game.Utilities.CoroutineManagement
{
    public interface ICoroutinesPerformer
    {
        Coroutine StartPerform(IEnumerator coroutineFunction);
        void StopPerform(Coroutine coroutine);
    }
}