using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCombination.BL
{
    public static class Bissnes
    {
        public static int NumCombination;
        public static int n;
        public static int[] lastCombination;

        public static int StartApi(int num)
        {
            try
            {
                n = num;
                int kefel = 1;
                n = num;
                for (int i = 1; i <= num; i++)
                {
                    kefel = kefel * i;
                }
                NumCombination = kefel;
                lastCombination= null;
                return NumCombination;
            }

            catch(Exception ex)
            {
                throw new Exception("error in Bissnes function StartApi" + ex);
            }
        }


        public static IEnumerable<int> NextApi()
        {
            try
            {
                if (lastCombination == null)
                {
                    int[] currentCombination = new int[n];
                    for (int i = 1; i <= n; i++)
                    {
                        currentCombination[i - 1] = i;
                    }
                    lastCombination = currentCombination;
                    return currentCombination;
                }
                else
                {
                    if (lastCombination.Length == 0)
                    {
                        lastCombination = Enumerable.Range(1, n).ToArray();
                    }
                    var result = NextPermutation(lastCombination.ToArray());
                    lastCombination = result;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error in Bissnes function NextApi" + ex);
            }
        }
        public static int[] NextPermutation(int[] array)
        {
            try { 
            // Find non-increasing suffix
            int i = array.Length - 1;
            while (i > 0 && array[i - 1] >= array[i])
                i--;
            if (i <= 0)
                return null;

            // Find successor to pivot
            int j = array.Length - 1;
            while (array[j] <= array[i - 1])
                j--;
            int temp = array[i - 1];
            array[i - 1] = array[j];
            array[j] = temp;

            // Reverse suffix
            j = array.Length - 1;
            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
            return array;
            }
            catch(Exception ex)
            {
                throw new Exception("error in Bissnes function NextCombination" + ex);

            }
        }
        static IEnumerable<IEnumerable<T>>
       GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        public  async static Task<dynamic> GetCombination( int pageNumber, int pageSize)
        {
            IEnumerable<int> enumerable = Enumerable.Range(1, n);
            List<int> asList = enumerable.ToList();
            //(pageNumber = 0) ? pageNumber = 1 : pageNumber = pageNumber; 
            return GetPermutations(asList, n).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
