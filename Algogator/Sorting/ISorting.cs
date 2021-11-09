using System;
using System.Collections.Generic;
using System.Text;

namespace Algogator
{
    public interface ISorting<T>
    {
        public delegate void SortIteratedEventHandler(ISorting<T> sender, EventArgs e);
        public event SortIteratedEventHandler SortIterated;
        public T[] getArray();
        void sort();
    }
}
