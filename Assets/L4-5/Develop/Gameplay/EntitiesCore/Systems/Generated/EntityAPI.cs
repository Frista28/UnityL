namespace L4.Develop.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public L4_5.Develop.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<L4_5.Develop.Gameplay.Features.LifeCycle.CurrentHealth>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.CurrentHealth() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddCurrentHealth(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<L4_5.Develop.Gameplay.Features.LifeCycle.MaxHealth>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.MaxHealth() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMaxHealth(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.MaxHealth() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<L4_5.Develop.Gameplay.Features.LifeCycle.IsDead>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.IsDead() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddIsDead(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.IsDead() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<L4_5.Develop.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.DeathProcessInitialTime() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<L4_5.Develop.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.LifeCycle.InDeathProcess InDeathProcessC => GetComponent<L4_5.Develop.Gameplay.Features.LifeCycle.InDeathProcess>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.InDeathProcess() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddInDeathProcess(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.LifeCycle.InDeathProcess() {Value = value}); 
		}

		public L4.Develop.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.MoveDirection>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveDirection() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveDirection(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveDirection() {Value = value}); 
		}

		public L4.Develop.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.MoveSpeed>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveSpeed() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveSpeed(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveSpeed() {Value = value}); 
		}

		public L4.Develop.Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.CanMove>();

		public L4_5.Develop.Gameplay.Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddCanMove(L4_5.Develop.Gameplay.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.CanMove() {Value = value}); 
		}

		public L4.Develop.Gameplay.Features.MovementFeature.RotateDirection RotateDirectionC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.RotateDirection>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotateDirection => RotateDirectionC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddRotateDirection()
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.RotateDirection() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddRotateDirection(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.RotateDirection() {Value = value}); 
		}

		public L4.Develop.Gameplay.Features.MovementFeature.RotateSpeed RotateSpeedC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.RotateSpeed>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> RotateSpeed => RotateSpeedC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddRotateSpeed()
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.RotateSpeed() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddRotateSpeed(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.RotateSpeed() {Value = value}); 
		}

		public L4.Develop.Gameplay.Features.MovementFeature.CanRotate CanRotateC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.CanRotate>();

		public L4_5.Develop.Gameplay.Utilities.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddCanRotate(L4_5.Develop.Gameplay.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.CanRotate() {Value = value}); 
		}

		public L4.Develop.Gameplay.EntitiesCommon.RigidbodyComponent RigidbodyC => GetComponent<L4.Develop.Gameplay.EntitiesCommon.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new L4.Develop.Gameplay.EntitiesCommon.RigidbodyComponent() {Value = value}); 
		}

		public L4.Develop.Gameplay.EntitiesCommon.CharacterControllerComponent CharacterControllerC => GetComponent<L4.Develop.Gameplay.EntitiesCommon.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new L4.Develop.Gameplay.EntitiesCommon.CharacterControllerComponent() {Value = value}); 
		}

		public L4.Develop.Gameplay.EntitiesCommon.TransformComponent TransformC => GetComponent<L4.Develop.Gameplay.EntitiesCommon.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new L4.Develop.Gameplay.EntitiesCommon.TransformComponent() {Value = value}); 
		}

	}
}
