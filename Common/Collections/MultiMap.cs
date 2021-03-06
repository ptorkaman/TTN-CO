using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;


namespace TTN
{
    /// <summary>
    /// A data structure that contains multiple values for each key.
    /// </summary>
    /// <typeparam name="TKey">The type of key.</typeparam>
    /// <typeparam name="TValue">The type of value.</typeparam>
    public class Multimap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, IList<TValue>>>
    {
        private readonly IDictionary<TKey, IList<TValue>> _items;
        private readonly Func<IList<TValue>> _listCreator;
        private readonly bool _isReadonly;

        public Multimap()
            : this(false)
        {
        }

        internal Multimap(bool threadSafe)
        {
            if (threadSafe)
            {
                _items = new ConcurrentDictionary<TKey, IList<TValue>>();
                _listCreator = () => new ThreadSafeList<TValue>();
            }
            else
            {
                _items = new Dictionary<TKey, IList<TValue>>();
                _listCreator = () => new List<TValue>();
            }
        }

        public Multimap(Func<IList<TValue>> listCreator)
            : this(new Dictionary<TKey, IList<TValue>>(), listCreator)
        {
        }


        internal Multimap(IDictionary<TKey, IList<TValue>> dictionary, Func<IList<TValue>> listCreator)
        {
            _items = dictionary;
            _listCreator = listCreator;
        }

        protected Multimap(IDictionary<TKey, IList<TValue>> dictionary, bool isReadonly)
        {
            Guard.ArgumentNotNull(() => dictionary);

            _items = dictionary;

            if (isReadonly && dictionary != null)
            {
                foreach (var kvp in dictionary)
                {
                    dictionary[kvp.Key] = kvp.Value.AsReadOnly();
                }
            }

            _isReadonly = isReadonly;
        }

        /// <summary>
        /// Gets the count of groups/keys.
        /// </summary>
        public int Count
        {
            get
            {
                return this._items.Keys.Count;
            }
        }

        /// <summary>
        /// Gets the total count of items in all groups.
        /// </summary>
        public int TotalValueCount
        {
            get
            {
                return this._items.Values.Sum(x => x.Count);
            }
        }

        /// <summary>
        /// Gets the collection of values stored under the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public virtual IList<TValue> this[TKey key]
        {
            get
            {
                if (!_items.ContainsKey(key))
                {
                    if (!_isReadonly)
                        _items[key] = _listCreator();
                    else
                        return null;
                }

                return _items[key];
            }
        }

        /// <summary>
        /// Gets the collection of keys.
        /// </summary>
        public virtual ICollection<TKey> Keys
        {
            get { return _items.Keys; }
        }

        /// <summary>
        /// Gets the collection of collections of values.
        /// </summary>
        public virtual ICollection<IList<TValue>> Values
        {
            get { return _items.Values; }
        }

        public IEnumerable<TValue> Find(TKey key, Expression<Func<TValue, bool>> predicate)
        {
            Guard.ArgumentNotNull(() => key);
            Guard.ArgumentNotNull(() => predicate);

            if (_items.ContainsKey(key))
            {
                return _items[key].Where(predicate.Compile());
            }

            return Enumerable.Empty<TValue>();
        }

        /// <summary>
        /// Adds the specified value for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public virtual void Add(TKey key, TValue value)
        {
            CheckNotReadonly();

            this[key].Add(value);
        }

        /// <summary>
        /// Adds the specified values to the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        public virtual void AddRange(TKey key, IEnumerable<TValue> values)
        {
            CheckNotReadonly();

            this[key].AddRange(values);
        }

        /// <summary>
        /// Removes the specified value for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>True</c> if such a value existed and was removed; otherwise <c>false</c>.</returns>
        public virtual bool Remove(TKey key, TValue value)
        {
            CheckNotReadonly();

            if (!_items.ContainsKey(key))
                return false;

            bool result = _items[key].Remove(value);
            if (_items[key].Count == 0)
                _items.Remove(key);

            return result;
        }

        /// <summary>
        /// Removes all values for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>True</c> if any such values existed; otherwise <c>false</c>.</returns>
        public virtual bool RemoveAll(TKey key)
        {
            CheckNotReadonly();
            return _items.Remove(key);
        }

        /// <summary>
        /// Removes all values.
        /// </summary>
        public virtual void Clear()
        {
            CheckNotReadonly();
            _items.Clear();
        }

        /// <summary>
        /// Determines whether the multimap contains any values for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>True</c> if the multimap has one or more values for the specified key, otherwise <c>false</c>.</returns>
        public virtual bool ContainsKey(TKey key)
        {
            return _items.ContainsKey(key);
        }

        /// <summary>
        /// Determines whether the multimap contains the specified value for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>True</c> if the multimap contains such a value; otherwise, <c>false</c>.</returns>
        public virtual bool ContainsValue(TKey key, TValue value)
        {
            return _items.ContainsKey(key) && _items[key].Contains(value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the multimap.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the multimap.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the multimap.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the multimap.</returns>
        public virtual IEnumerator<KeyValuePair<TKey, IList<TValue>>> GetEnumerator()
        {
            foreach (KeyValuePair<TKey, IList<TValue>> pair in _items)
                yield return pair;
        }

        private void CheckNotReadonly()
        {
            if (_isReadonly)
                throw new NotSupportedException("Multimap is read-only.");
        }

        #region Static members

        public static Multimap<TKey, TValue> ThreadSafe()
        {
            return new Multimap<TKey, TValue>(true);
        }

        public static Multimap<TKey, TValue> CreateFromLookup(ILookup<TKey, TValue> source)
        {
            Guard.ArgumentNotNull(() => source);

            var map = new Multimap<TKey, TValue>();

            foreach (IGrouping<TKey, TValue> group in source)
            {
                map.AddRange(group.Key, group);
            }

            return map;
        }

        #endregion

        #region Nested ThreadSafeMultimap

        //private class ThreadSafeMultimap<TKey, TValue> : Multimap<TKey, TValue>
        //{
        //    private readonly ReaderWriterLockSlim _rwLock;

        //    public ThreadSafeMultimap(ReaderWriterLockSlim rwLock)
        //    {
        //        _rwLock = rwLock;
        //    }

        //    public override void Add(TKey key, TValue value)
        //    {
        //        using (_rwLock.GetUpgradeableReadLock())
        //        {
        //            base.Add(key, value);
        //        }
        //    }

        //    public override void AddRange(TKey key, IEnumerable<TValue> values)
        //    {
        //        using (_rwLock.GetUpgradeableReadLock())
        //        {
        //            base.AddRange(key, values);
        //        }
        //    }

        //    public override bool ContainsValue(TKey key, TValue value)
        //    {        
        //        using (_rwLock.GetUpgradeableReadLock())
        //        {
        //            return base.ContainsValue(key, value);
        //        }
        //    }

        //    public override bool Remove(TKey key, TValue value)
        //    {              
        //        using (_rwLock.GetUpgradeableReadLock())
        //        {
        //            return base.Remove(key, value);
        //        }
        //    }

        //    public override IList<TValue> this[TKey key]
        //    {
        //        get
        //        {
        //            using (_rwLock.GetUpgradeableReadLock())
        //            { 
        //                return base[key];
        //            }
        //        }
        //    }

        //}

        #endregion
    }
}