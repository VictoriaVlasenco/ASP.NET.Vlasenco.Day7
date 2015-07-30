using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Library
{
    public static class Search
    {
        public static int FindBinary<T>(T[] array, T target, Comparison<T> comparer)
        {
            if(!isSorted(array, comparer))
                throw new ArgumentException("The array must be sorted");
            return BinarySearch(array, target, 0, array.Length - 1, comparer);
        }

        public static int SortAndFindBinary<T>(T[] array, T target, Comparison<T> comparer)
        {
            Sort(array, comparer);
            return BinarySearch(array, target, 0, array.Length - 1, comparer);
        }

        private static bool isSorted<T>(T[] array, Comparison<T> comparer)
        {
            if (array == null || array.Length < 1)
                throw new ArgumentException("The array is empty");
            T min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (comparer(array[i], min) < 0)
                    return false;
                min = array[i];
            }
            return true;
        }

        private static int BinarySearch<T>(T[] array, T target, int imin, int imax, Comparison<T> comparer)
        {
            if (array == null || array.Length < 1)
                return -1;
            int imid = (imin + imax)/2;

            if (comparer(array[imid], target) > 0)
                return BinarySearch(array, target, imin, imid - 1, comparer);
            if (comparer(array[imid], target) < 0)
                return BinarySearch(array, target, imid + 1, imax, comparer);
            return imid;
        }

        private static void Sort<T>(T[] array, Comparison<T> comparer)
        {
            QuickSort(array, 0, array.Length - 1, comparer);
        }
        private static void QuickSort<T>(T[] array, int left, int right, Comparison<T> comparer)
        {
            if (array == null || array.Length <= 1)
                return;
            if (left < right)
            {
                int pivot = Partition(array, left, right, comparer);

                if (pivot > 1)
                    QuickSort(array, left, pivot - 1, comparer);

                if (pivot + 1 < right)
                    QuickSort(array, pivot + 1, right, comparer);
            }
        }

        private static int Partition<T>(T[] array, int left, int right, Comparison<T> comparer)
        {
            T pivot = array[left];

            while (true)
            {
                while (comparer(array[left], pivot) < 0)
                    left++;

                while (comparer(array[right], pivot) > 0)
                    right--;

                if (left < right)
                {
                    Swap(ref array[left], ref array[right]);
                }
                else
                {
                    return right;
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
