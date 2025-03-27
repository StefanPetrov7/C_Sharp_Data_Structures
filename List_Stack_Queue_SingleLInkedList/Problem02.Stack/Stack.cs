namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node topNode;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            bool isFound = false;
            int count = this.Count;
            Node[] nodeArr = new Node[count];

            for (int i = 0; i < count; i++)
            {
                var node = this.topNode;
                this.topNode = this.topNode.NextNode;
                nodeArr[i] = node;

                if (node.Element.Equals(item)) 
                {
                    isFound = true;
                    break;
                }
            }

            for (int i = nodeArr.Length - 1; i >= 0; i--)
            {
                this.topNode = nodeArr[i];
            }

            return isFound;
        }

        public T Peek()
        {
            if (this.topNode == null)
            {
                throw new InvalidOperationException();
            }

            var element = this.topNode.Element;
            return element;
        }

        public T Pop()
        {
            if (this.topNode == null)
            {
                throw new InvalidOperationException();
            }

            var oldNode = this.topNode;
            this.topNode = oldNode.NextNode;
            this.Count--;
            return oldNode.Element;
        }

        public void Push(T item)
        {
            var node = new Node(item, this.topNode);
            this.topNode = node;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.topNode;

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