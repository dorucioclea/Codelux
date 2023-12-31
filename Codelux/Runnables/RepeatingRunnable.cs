﻿using System;
using System.Threading;

namespace Codelux.Runnables
{
    public abstract class RepeatingRunnable : Runnable
    {
        private readonly Timer _timer;
        protected RepeatingRunnable(TimeSpan beginAfter, TimeSpan repeatEvery) => _timer = new(Callback, null, beginAfter, repeatEvery);

        protected RepeatingRunnable(TimeSpan repeatEvery) => _timer = new(Callback, null, repeatEvery, repeatEvery);

        protected override void Dispose(bool disposing)
        {
            Stop();
            
            if (_timer != null)
                _timer.Dispose();
        }
        
        private void Callback(object state) => Start();
    }
}
