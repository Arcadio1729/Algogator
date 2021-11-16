using System;
using System.Collections.Generic;
using System.Text;

namespace Algogator
{
    public static class Display<T>
    {        
        public static void writeCurrentOrder(ISorting<T> s, EventArgs e)
        {
            foreach(var item in s.getArray())
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
