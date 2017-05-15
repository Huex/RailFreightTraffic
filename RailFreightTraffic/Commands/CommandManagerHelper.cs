using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RailFreightTraffic.Commands
{
    /// <summary>
    /// Этот класс содержит методы CommandManager, которые помогают избежать утечек памяти, используя слабые ссылки.
    /// </summary>
    internal static class CommandManagerHelper
    {
        internal static void CallWeakReferenceHandlers(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                // Делаем моментальный снимок обработчиков до того, как мы вызываем их, 
                // так как обработчики могут модифицироваться, пока мы его читаем.

                EventHandler[] callees = new EventHandler[handlers.Count];
                int count = 0;

                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler handler = reference.Target as EventHandler;
                    if (handler == null)
                    {
                        // Очистка старых обработчиков, которые были собраны
                        handlers.RemoveAt(i);
                    }
                    else
                    {
                        callees[count] = handler;
                        count++;
                    }
                }

                // Вызов обработчиков, которые были собраны
                for (int i = 0; i < count; i++)
                {
                    EventHandler handler = callees[i];
                    handler(null, EventArgs.Empty);
                }
            }
        }

        internal static void AddHandlersToRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (WeakReference handlerRef in handlers)
                {
                    EventHandler handler = handlerRef.Target as EventHandler;
                    if (handler != null)
                    {
                        CommandManager.RequerySuggested += handler;
                    }
                }
            }
        }

        internal static void RemoveHandlersFromRequerySuggested(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                foreach (WeakReference handlerRef in handlers)
                {
                    EventHandler handler = handlerRef.Target as EventHandler;
                    if (handler != null)
                    {
                        CommandManager.RequerySuggested -= handler;
                    }
                }
            }
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler)
        {
            AddWeakReferenceHandler(ref handlers, handler, -1);
        }

        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler, int defaultListSize)
        {
            if (handlers == null)
            {
                handlers = (defaultListSize > 0 ? new List<WeakReference>(defaultListSize) : new List<WeakReference>());
            }

            handlers.Add(new WeakReference(handler));
        }

        internal static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers != null)
            {
                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    WeakReference reference = handlers[i];
                    EventHandler existingHandler = reference.Target as EventHandler;
                    if ((existingHandler == null) || (existingHandler == handler))
                    {
                        // Очистка старых обработчиков, 
                        // которые были собраны в дополнение к обработчику, который должен быть удален.
                        handlers.RemoveAt(i);
                    }
                }
            }
        }
    }
}
