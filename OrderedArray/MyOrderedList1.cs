using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedArray
{
    public class MyOrderedList1<T> : MyList<T>
        where T : IComparable
    // This states that MyOrderedList1 will only accept types that can utilize the comparison operators
    {
        public override void Insert(int index, T item)
        {
            throw new NotSupportedException("Inserting at an index is not supported by an ordered list");
        }

        public override void Insert(T item)
        {
            // This is where the ordering occurs

            if(size + 1 >= Capacity)
            {
                Grow();
            }

            int i = 0; // This way, i will persist after the for loop closes
            for(; i < size; i++)
            {
                // Is items[i] greater than item?
                if (items[i].CompareTo(item) >= 0)
                { 
                    // I is the insertion point
                    break;
                }
            }

            for (int j = size; j > i; j--)
            {
                items[j] = items[j - 1];
            }

            // insertion
            items[i] = item;

            size++;
        }

        public override int Find(T match)
        {
            for(int i = 0; i < size; i++)
            {
                int comparison = items[i].CompareTo(match);
                
                if (comparison == 0)
                {
                    return i;
                }
                else if (comparison > 0)
                {
                    return -1;
                }
            }
            return -1;
        }

       
    }
}
