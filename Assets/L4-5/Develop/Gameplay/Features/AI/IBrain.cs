using System;

namespace L4_5.Develop.Gameplay.Features.AI
{
    public interface IBrain : IDisposable
    {
        void Enable();

        void Disable();

        void Update(float deltaTime);
    }
}