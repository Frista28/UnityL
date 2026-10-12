using System;
using System.Collections.Generic;
using L4_5.Develop.Gameplay.Utilities.StateMachineCore;

namespace L4_5.Develop.Gameplay.Features.AI
{
    public class AIStateMachine : StateMachine<IUpdatableState>
    {
        public AIStateMachine(List<IDisposable> disposables) : base(disposables)
        {
        }

        public AIStateMachine() : base (new List<IDisposable>())
        {
        }
        
        protected override void UpdateLogic(float deltaTime)
        {
            CurrentState?.Update(deltaTime);
        }
    }
}