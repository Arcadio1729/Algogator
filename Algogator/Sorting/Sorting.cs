using System;
using System.Collections.Generic;
using System.Text;

namespace Algogator
{
    public abstract class Sorting<T> : EventArgs
    {
        protected const int WAIT_TIME = 500;

        protected T INFINITY_VALUE;
        public T[] ARRAY
        {
            get
            {
                return this._ARRAY;
            }
            protected set
            {
                this._ARRAY = value;
            }
        }
        private T[] _ARRAY;
        public Func<T, T, bool> OnComparison;
        private void arrayInsert(T[] arr, T val, int idx)
        {
            int SIZE = arr.Length;
            
            T temp1=arr[idx];
            T temp2;
            arr[idx] = val;
            int start = idx + 1;

            //problem with swap if T is reference type
            for (int i = start; i < SIZE; i++)
            {
                temp2 = arr[i];
                arr[i] = temp1;
                temp1 = temp2;    
            }
        }
    }
    
}
