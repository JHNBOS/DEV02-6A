using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EntryPoint
{
    public class Sorting
    {
        public void DoMerge(Vector2 house, Vector2[] array, int left, int middle, int right)
        {
            Vector2[] temp = new Vector2[array.Length];

            int i;
            int l_e;
            int num;
            int pos;

            l_e = (middle - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= l_e) && (middle <= right))
            {
                if (Vector2.Distance(array[left], house) <= Vector2.Distance(array[middle], house))
                {
                    temp[pos++] = array[left++];
                }
                else
                {
                    temp[pos++] = array[middle++];
                }
            }

            while (left <= l_e)
            {
                temp[pos++] = array[left++];
            }

            while (middle <= right)
            {
                temp[pos++] = array[middle++];
            }

            for (i = 0; i < num; i++)
            {
                array[right] = temp[right];
                right--;
            }

        }

        public IEnumerable<Vector2> MergeSort(Vector2 house, Vector2[] array, int left, int right)
        {
            int middle;

            if (right > left)
            {
                middle = (right + left) / 2;

                MergeSort(house, array, left, middle);
                MergeSort(house, array, (middle + 1), right);

                DoMerge(house, array, left, (middle + 1), right);
            }

            return array;
        }
    }
}
