using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrderedArray
{
    public class MyOrderedList2<T> : MyList<T>
        where T : IComparable
    {

        public override int Find(T match)
        {
            int left = 0;
            int right = size - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = items[mid].CompareTo(match);

                if(comparison == 0)
                {
                    return mid;
                }
                else if(comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        public override void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public override void Insert(T item)
        {
            if (size + 1 >= Capacity)
            {
                Grow();
            }

            int left = 0;
            int right = size - 1;
            int insertIndex = size; //if the item is the largest, it will be placed at the last index after it grows

            while(left <= right) 
            {
                int mid = left + (right - left) / 2;
                int comparison = items[mid].CompareTo(item);

                if (comparison == 0)
                {
                    insertIndex = mid;
                    break;
                }
                else if (comparison < 0) //Item less than midpoint item
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                    insertIndex = mid; // this will eventually get the item to the right spot
                }
            }

            for (int i = size; i > insertIndex; i--)
            {
                items[i] = items[i - 1];
            }

            items[insertIndex] = item;
            size++;
        }
    }
}
