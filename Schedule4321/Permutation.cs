using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule4321
{
    public class Permutation
    {

        /// <summary>
        /// Takes an array of objects and returns a "list" of all permuations of that array of ojectx
        /// </summary>
        /// <typeparam name="T">type of objects</typeparam>
        /// <param name="items">an array of objects of that type</param>
        /// <returns></returns>
        public IEnumerable<T[]> GetPermutations<T>(T[] items)
        {
            int[] work = new int[items.Length];
            for (int i = 0; i < work.Length; i++)
            {
                work[i] = i;
            }
            foreach (int[] index in GetIntPermutations(work, 0, work.Length))
            {
                T[] result = new T[index.Length];
                for (int i = 0; i < index.Length; i++) result[i] = items[index[i]];
                yield return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">an array of object indices</param>
        /// <param name="offset">an offset index of where to swap items</param>
        /// <param name="len">length to end of the array of objects</param>
        /// <returns></returns>
        private IEnumerable<int[]> GetIntPermutations(int[] index, int offset, int len)
        {
            if (len == 1)
            {
                yield return index;
            }
            else if (len == 2)
            {
                yield return index;
                Swap(index, offset, offset + 1);
                yield return index;
                Swap(index, offset, offset + 1);
            }
            else
            {
                foreach (int[] result in GetIntPermutations(index, offset + 1, len - 1))
                {
                    yield return result;
                }
                for (int i = 1; i < len; i++)
                {
                    Swap(index, offset, offset + i);
                    foreach (int[] result in GetIntPermutations(index, offset + 1, len - 1))
                    {
                        yield return result;
                    }
                    Swap(index, offset, offset + i);
                }
            }
        }

        /// <summary>
        /// Swap two objects in an array of objects
        /// </summary>
        /// <param name="index">an array of objects</param>
        /// <param name="offset1">index of one object to swap</param>
        /// <param name="offset2">index of the other object to swap</param>
        private void Swap(int[] index, int offset1, int offset2)
        {
            int temp = index[offset1];
            index[offset1] = index[offset2];
            index[offset2] = temp;
        }

    }

}
