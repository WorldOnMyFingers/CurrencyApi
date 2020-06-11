﻿using System;
using System.Collections.Generic;

namespace CurrencyApi.Utilities
{
    public class LinkedListWithInit<T> : LinkedList<T>
    {
        public void Add(T item)
        {
            ((ICollection<T>)this).Add(item);
        }
    }

}
