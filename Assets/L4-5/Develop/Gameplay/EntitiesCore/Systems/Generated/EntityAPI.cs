namespace L4.Develop.Gameplay.EntitiesCore
{
	public partial class Entity
	{
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

		public L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyMax MoveEnergyMaxC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyMax>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> MoveEnergyMax => MoveEnergyMaxC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveEnergyMax()
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyMax() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveEnergyMax(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyMax() {Value = value}); 
		}

		public L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyCurrent MoveEnergyCurrentC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyCurrent>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> MoveEnergyCurrent => MoveEnergyCurrentC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveEnergyCurrent()
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyCurrent() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveEnergyCurrent(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyCurrent() {Value = value}); 
		}

		public L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyRecovery MoveEnergyRecoveryC => GetComponent<L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyRecovery>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> MoveEnergyRecovery => MoveEnergyRecoveryC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveEnergyRecovery()
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyRecovery() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddMoveEnergyRecovery(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4.Develop.Gameplay.Features.MovementFeature.MoveEnergyRecovery() {Value = value}); 
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

		public L4_5.Develop.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<L4_5.Develop.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.Sensors.BodyCollider() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<L4_5.Develop.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<L4_5.Develop.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public L4_5.Develop.Gameplay.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(L4_5.Develop.Gameplay.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<L4_5.Develop.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public L4_5.Develop.Gameplay.Utilities.Buffer<L4.Develop.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(L4_5.Develop.Gameplay.Utilities.Buffer<L4.Develop.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.Sensors.SphereColliderRadius SphereColliderRadiusC => GetComponent<L4_5.Develop.Gameplay.Features.Sensors.SphereColliderRadius>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> SphereColliderRadius => SphereColliderRadiusC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddSphereColliderRadius()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.Sensors.SphereColliderRadius() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddSphereColliderRadius(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.Sensors.SphereColliderRadius() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportRequest TeleportRequestC => GetComponent<L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportRequest>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent TeleportRequest => TeleportRequestC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportRequest()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportRequest() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportRequest(L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportRequest() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportEvent TeleportEventC => GetComponent<L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportEvent>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> TeleportEvent => TeleportEventC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportEvent()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportEvent() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportEvent(L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportEvent() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportCost TeleportCostC => GetComponent<L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportCost>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> TeleportCost => TeleportCostC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportCost()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportCost() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportCost(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportCost() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportRadius TeleportRadiusC => GetComponent<L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportRadius>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> TeleportRadius => TeleportRadiusC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportRadius()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportRadius() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportRadius(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.TeleportRadius() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.CanTeleport CanTeleportC => GetComponent<L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.CanTeleport>();

		public L4_5.Develop.Gameplay.Utilities.Conditions.ICompositeCondition CanTeleport => CanTeleportC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddCanTeleport(L4_5.Develop.Gameplay.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.MovementFeature.Teleport.CanTeleport() {Value = value}); 
		}

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

		public L4_5.Develop.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<L4_5.Develop.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.ApplyDamage.TakeDamageRequest() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.ApplyDamage.TakeDamageRequest() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<L4_5.Develop.Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.ApplyDamage.TakeDamageEvent() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(L1_3.Scripts.Game.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.ApplyDamage.TakeDamageEvent() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<L4_5.Develop.Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public L4_5.Develop.Gameplay.Utilities.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddCanApplyDamage(L4_5.Develop.Gameplay.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.ApplyDamage.CanApplyDamage() {Value = value}); 
		}

		public L4_5.Develop.Gameplay.Features.ApplyDamage.TeleportDamage.TeleportContactDamage TeleportContactDamageC => GetComponent<L4_5.Develop.Gameplay.Features.ApplyDamage.TeleportDamage.TeleportContactDamage>();

		public L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> TeleportContactDamage => TeleportContactDamageC.Value;

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportContactDamage()
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.ApplyDamage.TeleportDamage.TeleportContactDamage() { Value = new L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public L4.Develop.Gameplay.EntitiesCore.Entity AddTeleportContactDamage(L1_3.Scripts.Game.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new L4_5.Develop.Gameplay.Features.ApplyDamage.TeleportDamage.TeleportContactDamage() {Value = value}); 
		}

	}
}
