using System;
using System.Collections.Generic;
using System.Linq;


namespace DeBox.Unitoolz.Utils
{
    public class Chance<T>
    {
        public readonly int Weight;
        public readonly T Object;

        public Chance(int weight, T obj)
        {
            Weight = weight;
            Object = obj;
        }
    }

    public class ChanceTable<T>
    {
        public int TotalWeight { get; private set; }

        private readonly List<Chance<T>> _chances = new List<Chance<T>>();

        public ChanceTable()
        {
        }

        public ChanceTable(Dictionary<T, int> initialChances) : this()
        {
            foreach (var chancePair in initialChances)
            {
                RegisterChance(chancePair.Key, chancePair.Value);
            }
        }

        public void RegisterChance(T obj, int weight)
        {
            if (weight <= 0)
            {
                return;
            }
            TotalWeight += weight;
            _chances.Add(new Chance<T>(weight, obj));
        }

        public T Roll()
        {

            var result = UnityEngine.Random.Range(0, TotalWeight);
            var currentWeight = 0;

            foreach (var chance in _chances)
            {
                currentWeight += chance.Weight;
                if (currentWeight >= result)
                {
                    return chance.Object;
                }
            }
            throw new InvalidProgramException("No chance registered for: " + result);
        }

        public float GetChanceByKey(T key)
        {
            var chance = _chances.FirstOrDefault(c => c.Object.Equals(key));
            if (chance == null)
            {
                return 0;
            }
            return chance.Weight;
        }
    }
}