using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GenericPool<T> where T : IPooleable<T>, new()
    {
        private List<T> inUse = new List<T>();
        private List<T> available = new List<T>();

        public T Get()
        {
            T item;

            if (available.Count > 0)
            {
                Engine.Debug("Agarro del pool");
                item = available[0];
                available.Remove(item);
            }
            else
            {
                Engine.Debug("Creo");
                item = new T();
                item.OnDeactivate += OnDeactivateHandler;
            }

            inUse.Add(item);
            return item;
        }

        private void OnDeactivateHandler(T item)
        {
            Release(item);
        }

        public void Release(T item)
        {
            Engine.Debug("Release");
            inUse.Remove(item);
            available.Add(item);
        }
    }
}
