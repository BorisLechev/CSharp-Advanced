using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateCustomDataStructures
{
    /// <summary>
    /// Custom class
    /// </summary>
    public class CustomList
    {
        /// <summary>
        /// Default size of internal array
        /// </summary>
        private const int defaultSize = 2;

        /// <summary>
        /// Internal array
        /// </summary>
        private int[] innerArr;

        /// <summary>
        /// Number of elements in the list
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Creates custom integer list with default size
        /// </summary>
        public CustomList()
        {
            this.innerArr = new int[defaultSize];
        }

        /// <summary>
        /// Creates custom integer list with default size
        /// </summary>
        /// <param name="initialSize">Initial size of the list</param>
        public CustomList(int initialSize)
        {
            this.innerArr = new int[initialSize];
        }

        public int this[int index]
        {
            get
            {
                CheckIndexRange(index);
                return this.innerArr[index];
            }
            set
            {
                this.innerArr[index] = value;
            }
        }

        /// <summary>
        /// Add element in the list
        /// </summary>
        /// <param name="element"></param>
        public void Add(int element)
        {
            if (this.innerArr.Length == this.Count)
            {
                Grow();
            }

            this.innerArr[this.Count] = element; // [count] because is 0
            this.Count++;
        }

        /// <summary>
        /// AddRange method
        /// </summary>
        /// <param name="list"></param>
        public void AddRange(int[] list)
        {
            if (list.Length + this.Count >= this.innerArr.Length)
            {
                if (list.Length + this.Count > this.innerArr.Length * 2)
                {
                    Grow(list.Length + this.Count);
                }

                else
                {
                    Grow();
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                this.innerArr[this.Count] = list[i];
                this.Count++;
            }
        }

        /// <summary>
        /// Removes element at position
        /// </summary>
        /// <param name="index">position</param>
        /// <exception cref="IndexOutOfRangeException">The position is out of range</exception>
        public void RemoveAt(int index)
        {
            CheckIndexRange(index);
            ShiftLeft(index);
            this.Count--;
            Shrink();
        }

        public void InsertAt(int index, int element)
        {
            CheckIndexRange(index);
            ShiftRight(index);
            this.innerArr[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            return this.innerArr.Contains(element);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndexRange(firstIndex);
            CheckIndexRange(secondIndex);

            int tempElement = this.innerArr[firstIndex];
            this.innerArr[firstIndex] = this.innerArr[secondIndex];
            this.innerArr[secondIndex] = tempElement;
        }

        public void Shrink()
        {
            if (this.innerArr.Length / 4 > this.Count)
            {
                int[] tempArr = new int[this.innerArr.Length / 2];

                for (int i = 0; i < this.Count; i++)
                {
                    tempArr[i] = this.innerArr[i];
                }

                this.innerArr = tempArr;
            }
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.innerArr[i]);
            }
        }

        private void Grow()
        {
            Grow(this.innerArr.Length * 2);
        }

        /// <summary>
        /// Grow the size of the list twice
        /// </summary>
        private void Grow(int newSize)
        {
            int[] tempArr = new int[newSize];

            this.innerArr.CopyTo(tempArr, 0);
            this.innerArr = tempArr;
        }

        private void ShiftLeft(int position)
        {
            if (position < this.Count - 1) // if is not the last element
            {
                for (int i = position; i < this.Count; i++)
                {
                    this.innerArr[i] = this.innerArr[i + 1];
                }
            }

            else if (position == this.Count - 1)
            {
                this.innerArr[position] = default;
            }
        }

        private void ShiftRight(int position)
        {
            if (innerArr.Length == this.Count)
            {
                Grow();
            }

            for (int i = this.Count - 1; i >= position; i--)
            {
                this.innerArr[i + 1] = this.innerArr[i];
            }

            this.innerArr[position] = default;
        }

        private void CheckIndexRange(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
