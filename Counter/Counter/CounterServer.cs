using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Counter
{
    public static class CounterServer
    {
        private static int count;

        private static ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            readWriteLock.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                readWriteLock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            readWriteLock.EnterWriteLock();
            try
            {
                checked
                {
                    count += value;
                }
            }
            finally
            {
                readWriteLock.ExitWriteLock();
            }
        }

    }
}
