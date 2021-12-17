using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSweeftDigital
{
    class MyStructure
    {
       private int[] array;
       private int count;
       public MyStructure(int length)
            {
                array = new int[length];
            }

        public void Insert(int element)
        {
            if(array.Length == count)
            {
                int[] newArray = new int[count * 2];

                for (int i = 0; i < count; i++)
                    newArray[i] = array[i];

                array = newArray;
                  
            }
            array[count++] = element;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < count; i++)
                    array[i] = array[i + 1];
            count--;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
                Console.WriteLine(array[i]);
        }

    }
}
