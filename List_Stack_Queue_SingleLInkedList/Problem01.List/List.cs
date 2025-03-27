namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            this.items = new T[capacity];
            this.Count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.items[index];
            }
            set
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                IncreaseCapacity();
                this.items[this.Count] = item;
            }
            else
            {
                this.items[this.Count] = item;
            }

            this.Count++;
        }

        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (IsIndexValid(index) == false)
            {
                throw new IndexOutOfRangeException("Invalid index passed");
            }

            if (this.Count + 1 > this.items.Length)
            {
                IncreaseCapacity();
            }

            T[] newArr = new T[this.items.Length];

            Array.Copy(this.items, newArr, index);
            newArr[index] = item;
            Array.Copy(this.items, index, newArr, index + 1, this.Count - index);
            this.items = newArr;
            this.Count++;
        }

        public bool Remove(T item)
        {
            if (this.Contains(item) == false)
            {
                return false;
            }

            T[] newArr = new T[this.items.Length];
            bool isFound = false;


            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Equals(item))
                {
                    newArr[i] = this[i + 1];
                    isFound = true;
                    i++;
                    continue;
                }

                if (isFound == true)
                {
                    newArr[i - 1] = this[i];
                    continue;
                }

                newArr[i] = this[i];

            }

            this.items = newArr;
            this.Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            if (IsIndexValid(index) == false)
            {
                throw new IndexOutOfRangeException("Invalid index passed");
            }

            T[] newArr = new T[this.items.Length];

            Array.Copy(this.items, newArr, index - 1);
            Array.Copy(this.items, index + 1, newArr, index, this.Count - index);
            this.items = newArr;
            this.Count--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.items.GetEnumerator();

        private void IncreaseCapacity()
        {
            T[] newArr = new T[this.items.Length * 2];
            Array.Copy(this.items, newArr, this.items.Length);
            this.items = newArr;
        }


        private bool IsIndexValid(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                return false;
            }

            return true;
        }
    }
}