using System;

namespace Dynamics
{
    interface ISomeData { }
    class SomeActualData : ISomeData { }
    class SomeOtherData : ISomeData { }

    interface ISomeInterface
    {
        void DoSomething(ISomeData data);
    }

    class SomeImplementation : ISomeInterface
    {
        public void DoSomething(ISomeData data)
        {
            if (data is SomeActualData)
                HandleThis((SomeActualData)data);
            else if (data is SomeOtherData)
                HandleThis((SomeOtherData)data);
            //...
            else
                throw new Exception();
        }

        //public void DoSomething(ISomeData data)
        //{
        //    dynamic specificData = data;
        //    HandleThis(specificData);
        //}

        private void HandleThis(SomeActualData data)
        { /* ... */ }
        private void HandleThis(SomeOtherData data)
        { /* ... */ }

    }
}
