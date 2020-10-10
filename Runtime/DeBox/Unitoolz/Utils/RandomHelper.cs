using System;
using System.Collections.Generic;
using System.Linq;


namespace DeBox.Unitoolz.Utils
{
    public static class RandomHelper
    {
        private static readonly Random _random = new Random();

        public static T RandomCollectionMember<T>(T[] collection)
        {
            var memberCount = collection.Length;
            var randomIndex = _random.Next(memberCount);
            return collection[randomIndex];
        }

        public static T RandomCollectionMember<T>(IEnumerable<T> collection)
        {
            return RandomCollectionMember(new List<T>(collection));
        }

        public static T RandomCollectionMember<T>(List<T> collection)
        {
            return RandomCollectionMember(collection.ToArray());
        }

        public static T RandomEnumMember<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            T randomMember = (T)values.GetValue(_random.Next(values.Length));
            return randomMember;
        }

        public static IEnumerable<T> GetRandomlyShuffledCollection<T>(IEnumerable<T> collection)
        {
            return collection.OrderBy(member => _random.Next());
        }

        public static void ShuffleListInPlace<T>(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var replaceIndex = UnityEngine.Random.Range(i, collection.Count);
                T tempData = collection[i];
                collection[i] = collection[replaceIndex];
                collection[replaceIndex] = tempData;
            }
        }
    }
}