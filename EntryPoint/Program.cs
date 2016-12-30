using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EntryPoint
{
#if WINDOWS || LINUX
    public static class Program
    {

        [STAThread]
        static void Main()
        {

            var fullscreen = false;
            read_input:
            switch (Microsoft.VisualBasic.Interaction.InputBox("Which assignment shall run next? (1, 2, 3, 4, or q for quit)", "Choose assignment", VirtualCity.GetInitialValue()))
            {
                case "1":
                    using (var game = VirtualCity.RunAssignment1(SortSpecialBuildingsByDistance, fullscreen))
                        game.Run();
                    break;
                case "2":
                    using (var game = VirtualCity.RunAssignment2(FindSpecialBuildingsWithinDistanceFromHouse, fullscreen))
                        game.Run();
                    break;
                case "3":
                    using (var game = VirtualCity.RunAssignment3(FindRoute, fullscreen))
                        game.Run();
                    break;
                case "4":
                    using (var game = VirtualCity.RunAssignment4(FindRoutesToAll, fullscreen))
                        game.Run();
                    break;
                case "q":
                    return;
            }
            goto read_input;
        }

        //Assignment 1
        private static IEnumerable<Vector2> SortSpecialBuildingsByDistance(Vector2 house, IEnumerable<Vector2> specialBuildings)
        {
            //return specialBuildings.OrderBy(v => Vector2.Distance(v, house));

            Vector2[] array = specialBuildings.ToArray();
            MergeSort(house, array, 0, (array.Length - 1));
            return array;
        }

        //Assignment 2
        private static IEnumerable<IEnumerable<Vector2>> FindSpecialBuildingsWithinDistanceFromHouse(
          IEnumerable<Vector2> specialBuildings, IEnumerable<Tuple<Vector2, float>> housesAndDistances)
        {
            /*
            return
            from h in housesAndDistances
            select
            from s in specialBuildings
            where Vector2.Distance(h.Item1, s) <= h.Item2
            select s;
            */

            //KDTree
            _2DTree kdTree = new _2DTree();

            //Return list
            List<List<Vector2>> returnList = new List<List<Vector2>>();

            //Lists of specialBuildings and houses
            List<Vector2> specialBuildingsList = specialBuildings.ToList();
            List<Tuple<Vector2, float>> housesList = housesAndDistances.ToList();

            foreach (var s in specialBuildingsList)
            {
                kdTree.Insert(s);
            }

            foreach (var t in housesList)
            {
                Console.WriteLine("House[" + t.Item1.X + ", " + t.Item1.Y + "]");
                Console.WriteLine("Radius: " + t.Item2);

                returnList.Add(kdTree.RangeSearch(t.Item1, t.Item2, specialBuildingsList));
            }

            return returnList;
            
        }

        private static IEnumerable<Tuple<Vector2, Vector2>> FindRoute(Vector2 startingBuilding,
          Vector2 destinationBuilding, IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
            List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
            var prevRoad = startingRoad;
            for (int i = 0; i < 30; i++)
            {
                prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, destinationBuilding)).First());
                fakeBestPath.Add(prevRoad);
            }
            return fakeBestPath;
        }

        private static IEnumerable<IEnumerable<Tuple<Vector2, Vector2>>> FindRoutesToAll(Vector2 startingBuilding,
          IEnumerable<Vector2> destinationBuildings, IEnumerable<Tuple<Vector2, Vector2>> roads)
        {
            List<List<Tuple<Vector2, Vector2>>> result = new List<List<Tuple<Vector2, Vector2>>>();
            foreach (var d in destinationBuildings)
            {
                var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
                List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
                var prevRoad = startingRoad;
                for (int i = 0; i < 30; i++)
                {
                    prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, d)).First());
                    fakeBestPath.Add(prevRoad);
                }
                result.Add(fakeBestPath);
            }
            return result;
        }

        //Assignment 1: Insertion Sort
        private static void DoMerge(Vector2 house, Vector2[] array, int left, int middle, int right)
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


        //Assignment 1: Merge Sort (Divide and conquer)
        private static IEnumerable<Vector2> MergeSort(Vector2 house, Vector2[] array, int left, int right)
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

        //Assignment 3: Dijkstra



        }
#endif
}
