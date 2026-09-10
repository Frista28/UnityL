using System;

namespace L1_3.Scripts.Game.Utilities.Reactive
{
    public interface IReadOnlyVariable<out T>
    {
        T Value { get; }

        IDisposable Subscribe(Action<T, T> action);
    }
}