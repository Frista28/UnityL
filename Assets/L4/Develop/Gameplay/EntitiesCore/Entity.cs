using System;
using System.Collections.Generic;
using L4.Develop.Gameplay.EntitiesCore.Systems;

namespace L4.Develop.Gameplay.EntitiesCore
{
    public class Entity : IDisposable
    {
        private readonly Dictionary<Type, IEntityComponent> _components = new Dictionary<Type, IEntityComponent>();
        
        private readonly List<IEntitySystem> _systems = new();
        private readonly List<IInitializableSystem> _initializables = new();
        private readonly List<IUpdatableSystem> _updatables = new();
        private readonly List<IDisposableSystem> _disposables = new();
        
        private bool _isInit;

        public void Initialize()
        {
            foreach (IInitializableSystem initializable in _initializables)
                initializable.OnInit(this);

            _isInit = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isInit == false)
                return;

            foreach (IUpdatableSystem updatable in _updatables)
                updatable.OnUpdate(deltaTime);
        }

        public void Dispose()
        {
            foreach (IDisposableSystem disposable in _disposables)
                disposable.OnDispose();

            _isInit = false;
        }

        public Entity AddComponent<T>(T component) where T : class, IEntityComponent
        {
            _components.Add(typeof(T), component);
            return this;
        }

        public bool HasComponent<T>() where T : class, IEntityComponent
            => _components.ContainsKey(typeof(T));

        public bool TryGetComponent<T>(out T component) where T : class, IEntityComponent
        {
            if (_components.TryGetValue(typeof(T), out IEntityComponent findedComponent))
            {
                component = (T)findedComponent;
                return true;
            }
            
            component = null;
            return false;
        }

        public T GetComponent<T>() where T : class, IEntityComponent
        {
            if (TryGetComponent(out T component) == false)
                throw new ArgumentException($"Entity not exist {typeof(T)}");

            return component;
        }
        
        public Entity AddSystem(IEntitySystem system)
        {
            if (_systems.Contains(system))
                throw new ArgumentException(system.GetType().ToString());

            _systems.Add(system);

            if (system is IInitializableSystem initializable)
            {
                _initializables.Add(initializable);
                
                if (_isInit)
                    initializable.OnInit(this);
            }

            if (system is IUpdatableSystem updatable)
                _updatables.Add(updatable);

            if (system is IDisposableSystem disposable)
                _disposables.Add(disposable);

            return this;
        }
    }
}