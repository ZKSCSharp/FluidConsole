using Fluid_ConsoleManager.src.Events.Interfaces;
using Fluid_ConsoleManager.src.Handlers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid_ConsoleManager.src.Core
{
    public static class EventBus
    {
        private static Dictionary<Type, List<object>> handlers = new Dictionary<Type, List<object>>();

        public static void Register<T>(IEventHandler<T> handler) where T : IEvent
        {
            Type eventType = typeof(T);

            if (!handlers.ContainsKey(eventType))
            {
                handlers[eventType] = new List<object>();
            }

            if (!handlers[eventType].Contains(handler))
            {
                handlers[eventType].Add(handler);
            }
        }
        public static void Drop<T>(IEventHandler<T> handler) where T : IEvent
        {
            Type eventType = typeof(T);

            if (handlers.ContainsKey(eventType))
                handlers[eventType].Remove(handler); ;
            // Add FConsole Logger

        }

        public static void Publish<T>(T evt) where T : IEvent
        {
            Type eventType = typeof(T);

            if (handlers.TryGetValue(eventType, out List<object> list))
            {
                foreach (object obj in list)
                {
                    ((IEventHandler<T>)obj).Handle(evt);
                }
            }
        }

        public static int CountHandler<T>() where T : IEvent => handlers.Count;
    }
}
