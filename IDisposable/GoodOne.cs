using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace IDisposable_TEST
{
    public sealed class SingleApplicationInstance : IDisposable
    {
        private Mutex namedMutex;
        private bool namedMutexCreatedNew;

        public SingleApplicationInstance(string applicationName)
        {
            this.namedMutex = new Mutex(false, applicationName, out namedMutexCreatedNew);
        }

        public bool AlreadyExisted
        {
            get { return !this.namedMutexCreatedNew; }
        }

        public void Dispose()
        {
            namedMutex.Close();
        }
    }
}
