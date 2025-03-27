namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node headNode;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            bool isFound = false;
            int count = this.Count;
            var node = this.headNode;

            while (count > 0)
            {
                if (node.Element.Equals(item))
                {
                    isFound = true;
                    break;
                }
                node = node.NextNode;
                count--;
            }

            return isFound;
        }

        public T Dequeue()
        {
            if (this.headNode == null)
            {
                throw new InvalidOperationException();
            }

            var removedNode = this.headNode;
            this.headNode = this.headNode.NextNode;
            this.Count--;
            return removedNode.Element;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (this.headNode == null)
            {
                this.headNode = newNode;
            }
            else
            {
                var lastNode = this.headNode;

                while (lastNode.NextNode != null)
                {
                    lastNode = lastNode.NextNode;
                }

                lastNode.NextNode = newNode;

            }

            this.Count++;
        }

        public T Peek()
        {
            if (this.headNode == null)
            {
                throw new InvalidOperationException();
            }

            return this.headNode.Element;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var lastNode = this.headNode;

            while (lastNode.NextNode != null)
            {
                yield return lastNode.Element;
                lastNode = lastNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();


        private class Node
        {
            public Node(T element)
            {
                this.Element = element;
                this.NextNode = null;
            }

            public Node(T element, Node nextNode)
            {
                this.Element = element;
                this.NextNode = nextNode;
            }

            public T Element { get; set; }

            public Node NextNode { get; set; }

        }
    }

}