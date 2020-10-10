using System;
using System.Collections.Generic;
using UnityEngine;


namespace Debox.Unitoolz.Util
{
    public enum PriorityQueueSortOrder
    {
        Asc,
        Desc,
    }

    public class PriorityQueue<K, T> where K : IComparable
    {
        private class QueueItem<K1, T1>
        {
            public readonly T1 Item;
            public readonly K1 Priority;

            public QueueItem(K1 priority, T1 item)
            {
                Item = item;
                Priority = priority;
            }
        }

        public readonly PriorityQueueSortOrder SortOrder;

        private List<QueueItem<K, T>> _items;

        public void Clear()
        {
            _items.Clear();
        }

        public PriorityQueue(PriorityQueueSortOrder sortOrder)
        {
            _items = new List<QueueItem<K, T>>();
            SortOrder = sortOrder;
        }

        public PriorityQueue() : this(PriorityQueueSortOrder.Asc)
        {
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public T Peek()
        {
            if (Count < 0)
            {
                throw new Exception("Empty queue");
            }

            return _items[0].Item;
        }

        public T Dequeue()
        {
            T item = Peek();
            _items.RemoveAt(0);
            return item;
        }


        public T Dequeue(out K priority)
        {
            QueueItem<K, T> q = _items[0];
            _items.RemoveAt(0);
            priority = q.Priority;
            return q.Item;
        }


        private int GetIndexForPriorityAsc(K priority)
        {
            int l = 0;
            int r = _items.Count - 1;
            int idx = 0;
            while (l <= r)
            {
                idx = Mathf.FloorToInt((l + r) / 2);
                if (_items[idx].Priority.CompareTo(priority) < 0)
                {
                    l = idx + 1;
                }
                else
                {
                    r = idx - 1;
                }
            }

            return idx;
        }

        private int GetIndexForPriorityDesc(K priority)
        {
            int l = 0;
            int r = _items.Count - 1;
            int idx = 0;
            while (l <= r)
            {
                idx = Mathf.FloorToInt((l + r) / 2);
                if (_items[idx].Priority.CompareTo(priority) > 0)
                {
                    l = idx + 1;
                }
                else
                {
                    r = idx - 1;
                }
            }

            return idx;
        }


        public void Enqueue(K priority, T item)
        {
            QueueItem<K, T> queueItem = new QueueItem<K, T>(priority, item);
            if (_items.Count == 0)
            {
                _items.Add(queueItem);
                return;
            }

            var idx = SortOrder == PriorityQueueSortOrder.Asc
                ? GetIndexForPriorityAsc(priority)
                : GetIndexForPriorityDesc(priority);
            QueueItem<K, T> q = _items[idx];
            _items.Insert(idx, queueItem);
        }
    }
}