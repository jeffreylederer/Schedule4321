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
        /// <param name="count">size of array</param>
        /// <returns></returns>
        public IEnumerable<int[]> GetPermutations(int count)
        {
            var work = new int[count];
            for (var i = 0; i < work.Length; i++)
            {
                work[i] = i;
            }
            return GetIntPermutations(work, 0, work.Length).Select(index => work);
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
            switch (len)
            {
                case 1:
                    yield return index;
                    break;
                case 2:
                    yield return index;
                    Swap(index, offset, offset + 1);
                    yield return index;
                    Swap(index, offset, offset + 1);
                    break;
                default:
                    foreach (var result in GetIntPermutations(index, offset + 1, len - 1))
                    {
                        yield return result;
                    }
                    for (var i = 1; i < len; i++)
                    {
                        Swap(index, offset, offset + i);
                        foreach (var result in GetIntPermutations(index, offset + 1, len - 1))
                        {
                            yield return result;
                        }
                        Swap(index, offset, offset + i);
                    }
                    break;
            }
        }

        /// <summary>
        /// Swap two ints in an array of objects
        /// </summary>
        /// <param name="index">an array of ints</param>
        /// <param name="offset1">index of one object to swap</param>
        /// <param name="offset2">index of the other object to swap</param>
        private void Swap(int[] index, int offset1, int offset2)
        {
            var temp = index[offset1];
            index[offset1] = index[offset2];
            index[offset2] = temp;
        }

    }

}
