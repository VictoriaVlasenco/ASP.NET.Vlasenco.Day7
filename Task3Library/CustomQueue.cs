using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Library
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public int Count
        {
            get { return count; }
            private set { count = value; }
        }

        private T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        } 

        public void Enqueue(T item)
        {
            CheckCapacity();
            this[Count] = item;
            Count++;
        }

        public T Dequeue()
        {
            if (Count < 1) 
                throw new Exception("The queue is empty");
            T item = this[0];
            Array.Copy(items, 1, items, 0, count - 1);
            Count--;
            return item;
        }

        public T Peek()
        {
            if (Count < 1)
                throw new Exception("The queue is empty");
            return this[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator(this);
        } 

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct Iterator : IEnumerator<T>
        {
            private readonly CustomQueue<T> queue;
            private int currentIndex;

            public Iterator(CustomQueue<T> queue)
            {
                this.currentIndex = -1;
                this.queue = queue;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == queue.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue[currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public bool MoveNext()
            {
                return ++currentIndex < queue.Count;
            }

            public void Dispose() { }
        }

        private void CheckCapacity()
        {
            if (items == null || count == items.Length)
            {
                AddCapacity((count + 1) * 2);
            }
        }
        private void AddCapacity(int capacity)
        {
            T[] newItems = new T[capacity];
            if (items != null)
                Array.Copy(items, newItems, count);
            items = newItems;
        }
    }
}
