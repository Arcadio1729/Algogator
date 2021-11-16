using System;
using System.Collections.Generic;
using System.Text;

namespace Algogator
{
    public class SortingInsertion<T>:Sorting<T>,ISorting<T>
    {
        public SortingInsertion(ref T[] arr, Func<T, T, bool> comparison)
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
            T currentValue;
            for (int i = 1; i < this.ARRAY.Length; i++) //sorting in place
            {
                currentValue = this.ARRAY[i];
                int currentCounter = i-1;
                while (currentCounter>=0 && this.OnComparison(currentValue, this.ARRAY[currentCounter]))
                {
                    this.ARRAY[currentCounter + 1] = this.ARRAY[currentCounter];
                    currentCounter--;
                    this.OnIterated();
                }
                this.ARRAY[currentCounter+1] = currentValue;
            }
            this.OnIterated();
        }

        protected virtual void OnIterated()
        {
            if (this.SortIterated != null)
                this.SortIterated(this, EventArgs.Empty);
        }

    }
}
