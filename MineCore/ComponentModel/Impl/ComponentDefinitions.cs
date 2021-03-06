using System.Collections.Concurrent;
using MineCore.Utils;
using Optional;

namespace MineCore.ComponentModel.Impl
{
    public class ComponentDefinitions : IComponentDefinitions
    {
        private ConcurrentDictionary<string, IComponent> _defineComponents =
            new ConcurrentDictionary<string, IComponent>();

        public bool RegisterComponent(IComponent component)
        {
            component.ThrownOnArgNull(nameof(component));

            string name = component.NameSpace + ":" + component.Name;
            if (!_defineComponents.ContainsKey(name))
            {
                return _defineComponents.TryAdd(name, component);
            }

            return false;
        }

        public Option<IComponent> GetComponent(string name)
        {
            name.ThrownOnArgNull(nameof(name));

            if (_defineComponents.TryGetValue(name, out IComponent component))
            {
                return component.SomeNotNull();
            }

            return Option.None<IComponent>();
        }

        public Option<T> GetComponent<T>(string name) where T : IComponent
        {
            name.ThrownOnArgNull(nameof(name));

            if (_defineComponents.TryGetValue(name, out IComponent component))
            {
                return ((T) component).SomeNotNull();
            }

            return Option.None<T>();
        }
    }
}