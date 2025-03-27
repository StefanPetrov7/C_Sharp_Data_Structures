namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node headNode;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item, this.headNode);
            this.headNode = newNode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var lastNode = new Node(item);

            if (this.headNode == null)
            {
                this.headNode = lastNode;
            }
            else
            {
                var firstNode = this.headNode;

                while (firstNode.NextNode != null)
                {
                    firstNode = firstNode.NextNode;
                }

                firstNode.NextNode = lastNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            if (this.headNode == null)
            {
                throw new InvalidOperationException();
            }

            return this.headNode.Element;
        }

        public T GetLast()
        {
            if (this.headNode == null)
            {
                throw new InvalidOperationException();
            }

            var lastNode = this.headNode;

            while (lastNode.NextNode != null)
            {
                lastNode = lastNode.NextNode;
            }

            return lastNode.Element;
        }

        public T RemoveFirst()
        {
            if (this.headNode == null)
            {
                throw new InvalidOperationException();
            }

            var removedNode = this.headNode;
            this.headNode = removedNode.NextNode;
            this.Count--;
            return removedNode.Element;
        }

        public T RemoveLast()
        {
            if (this.headNode == null)
            {
                throw new InvalidOperationException();
            }

            Node removedNode = null;

            if (this.headNode.NextNode == null)
            {
                removedNode = this.headNode;
                this.headNode = null;
            }
            else 
            {
                var lastNode = this.headNode;

                while (lastNode.NextNode != null)
                {
                    if (lastNode.NextNode.NextNode == null)
                    {
                        removedNode = lastNode.NextNode;
                        lastNode.NextNode = null;
                        break;
                    }

                    lastNode = lastNode.NextNode;
                }

            }

            this.Count--;
            return removedNode.Element; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.headNode;

            while (node != null)
            {
                yield return node.Element;
                node = node.NextNode;
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