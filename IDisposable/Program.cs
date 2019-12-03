using System;
using System.IO;

namespace IDisposable_TEST
{
    class Program
    {
        //Step 1: Don't do that until u need it
        //Step 2: Managed resources -> ONLY Dispose method
        //Step 3: Managed and unmanaged resources -> Dispose method and finalizer


        static void Main(string[] args)
        {
            //ObjectDisposedDemo();
            //ObjectDisposedWithUsingStatmentDemo();
            
            Console.ReadLine();
        }
        


        static void ObjectDisposedDemo()
        {
            MemoryStream ms = new MemoryStream(16);
            //ms.Close();
            ms.Dispose();

            try
            {
                ms.ReadByte();
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine("Caught: {0}", e.Message);
            }
        }

        static void ObjectDisposedWithUsingStatmentDemo()
        {
            MemoryStream ms = null;
            using (ms = new MemoryStream(16))
            {
                Console.WriteLine("Stream is working");
            }

            try
            {
                ms.ReadByte();
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine("Caught: {0}", e.Message);
            }
        }

    }
}
