using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Utilities.Timer;
using L4_5.Develop.Gameplay.Features.AI.States;
using L4_5.Develop.Gameplay.Features.AI.States.Teleport;
using L4_5.Develop.Gameplay.Utilities.Conditions;
using L4.Develop.Gameplay.EntitiesCore;

namespace L4_5.Develop.Gameplay.Features.AI
{
    public class BrainsFactory
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainsContext _brainsContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
        }
        
        public StateMachineBrain CreateTeleportGhostBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateRandomTeleportStateMachine(entity);
            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);
            
            return brain;
        }

        public StateMachineBrain CreateGhostBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateRandomMovementStateMachine(entity);
            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);
            
            return brain;
        }

        private AIStateMachine CreateRandomTeleportStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();
            
            RandomTeleportState randomTeleportState = new RandomTeleportState(entity, 0.5f);
            
            CurrentTargetTeleportState currentTargetTeleportState = new CurrentTargetTeleportState(entity, 0.5f);
            
            TimerService randomTeleportStateTimer = _timerServiceFactory.Create(5f);
            disposables.Add(randomTeleportStateTimer);
            disposables.Add(randomTeleportState.Entered.Subscribe(randomTeleportStateTimer.Restart));

            TimerService currentTargetTeleportStateTimer = _timerServiceFactory.Create(10f);
            disposables.Add(currentTargetTeleportStateTimer);
            disposables.Add(currentTargetTeleportState.Entered.Subscribe(currentTargetTeleportStateTimer.Restart));

            FuncCondition randomTeleportStateTimerEndedCondition = new FuncCondition(() => randomTeleportStateTimer.IsOver);
            FuncCondition currentTargetTeleportStateTimerEndedCondition = new FuncCondition(() => currentTargetTeleportStateTimer.IsOver);

            AIStateMachine stateMachine = new AIStateMachine(disposables);

            stateMachine.AddState(randomTeleportState);
            stateMachine.AddState(currentTargetTeleportState);

            stateMachine.AddTransition(randomTeleportState, currentTargetTeleportState, randomTeleportStateTimerEndedCondition);
            stateMachine.AddTransition(currentTargetTeleportState, randomTeleportState, currentTargetTeleportStateTimerEndedCondition);

            return stateMachine;
        }

        private AIStateMachine CreateRandomMovementStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();
            
            RandomMovementState randomMovementState = new RandomMovementState(entity, 0.5f);
            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovementState.Entered.Subscribe(movementTimer.Restart));

            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            FuncCondition movementTimerEndedCondition = new FuncCondition(() => movementTimer.IsOver);
            FuncCondition idleTimerEndedCondition = new FuncCondition(() => idleTimer.IsOver);

            AIStateMachine stateMachine = new AIStateMachine(disposables);

            stateMachine.AddState(randomMovementState);
            stateMachine.AddState(emptyState);

            stateMachine.AddTransition(randomMovementState, emptyState, movementTimerEndedCondition);
            stateMachine.AddTransition(emptyState, randomMovementState, idleTimerEndedCondition);

            return stateMachine;
        }
    }
}