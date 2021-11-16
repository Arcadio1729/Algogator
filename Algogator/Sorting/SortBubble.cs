using System;
using System.Collections.Generic;
using System.Text;

namespace Algogator
{
    public class SortingBubble<T> : Sorting<T>, ISorting<T>
    {
        public SortingBubble(ref T[] arr, Func<T, T, bool> comparison)
        {
            this.ARRAY = arr;
            this.OnComparison = comparison;
        }

        public event ISorting<T>.SortIteratedEventHandler SortIterated;

        public T[] getArray()
        {
            return this.ARRAY;
        }

        public void sort()
        {
            for(int i = 0; i < this.ARRAY.Length; i++)
            {
                for(int j = i; j < this.ARRAY.Length; j++)
                {
                    if (this.OnComparison(this.ARRAY[i], this.ARRAY[j]))
                    {
                        var temp = this.ARRAY[i];
                        this.ARRAY[i] = this.ARRAY[j];
                        this.ARRAY[j] = temp;
                    }
                    this.OnIterated();
                    System.Threading.Thread.Sleep(WAIT_TIME);
                }
            }
        }
        protected virtual void OnIterated()
        {
            if (this.SortIterated != null)
                this.SortIterated(this, EventArgs.Empty);
        }
    }
}
