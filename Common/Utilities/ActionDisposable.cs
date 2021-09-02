﻿using System;

namespace TTN
{

    /// <summary>
    /// Allows action to be executed, when it is disposed
    /// </summary>
    internal struct ActionDisposable : IDisposable
    {
        readonly Action _action;

        public static readonly ActionDisposable Empty = new ActionDisposable(() => { });

        public ActionDisposable(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action();
        }

    }


}
