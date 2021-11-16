using System;
using System.Collections.Generic;
using System.Text;

namespace Algogator
{
    //Merge Sort
    public class SortingMerge<T> : Sorting<T>, ISorting<T>
    {
        public SortingMerge(ref T[] arr, Func<T, T, bool> comparison)
        {
            this.ARRAY = arr;
            this.OnComparison = comparison;
        }
        public SortingMerge(ref T[] arr, Func<T, T, bool> comparison, T infval)
        {
            this.ARRAY = arr;
            this.OnComparison = comparison;
            this.INFINITY_VALUE = infval;
        }

        public event ISorting<T>.SortIteratedEventHandler SortIterated;

        private T[] _ARRAY;
        public void sort()
        {
            SortMerge(0, this.ARRAY.Length - 1);
        }
        private void SortMerge(int start, int end)
        {
            if (start < end)
            {
                double d = Convert.ToDouble(end) - Convert.ToDouble(start);
                int mid = start+(int)Math.Floor((d / 2.00));

                this.SortMerge(start, mid);
                this.SortMerge(mid+1, end);
                this.merge(start, mid, end);

                this.OnIterated();

                System.Threading.Thread.Sleep(WAIT_TIME);
            }
        }
        private void merge(int start, int mid, int end)
        {
            int leftLength = mid - start+1;
            T[] leftArray = new T[leftLength+1];

            int rightLength = end - mid;
            T[] rightArray = new T[rightLength+1];

            for (int i = 0; i < leftLength; i++)
            {
                leftArray[i] = this.ARRAY[start+i];
            }

            for (int i = 0; i < rightLength; i++)
            {
                rightArray[i] = this.ARRAY[mid + i+1];
            }

            leftArray[leftLength] = this.INFINITY_VALUE;
            rightArray[rightLength] = this.INFINITY_VALUE;

            int leftCounter = 0;
            int rightCounter = 0;
            for(int i = start; i < end+1; i++)
            {
                if (this.OnComparison(leftArray[leftCounter],rightArray[rightCounter]))
                {
                    this.ARRAY[i] = leftArray[leftCounter];
                    leftCounter++;
                }
                else
                {
                    this.ARRAY[i] = rightArray[rightCounter];
                    rightCounter++;
                }
            }
        }
        protected virtual void OnIterated()
        {
            if (this.SortIterated != null)
                this.SortIterated(this, EventArgs.Empty);
        }
        public T[] getArray()
        {
            return this.ARRAY;
        }
    }
}
