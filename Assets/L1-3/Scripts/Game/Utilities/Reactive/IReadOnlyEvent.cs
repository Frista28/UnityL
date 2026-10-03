using System;

namespace L1_3.Scripts.Game.Utilities.Reactive
{
    public interface IReadOnlyEvent
    {
        IDisposable Subscribe(Action action);
    }

    public interface IReadOnlyEvent<T>
    {
        IDisposable Subscribe(Action<T> action);
    }
}