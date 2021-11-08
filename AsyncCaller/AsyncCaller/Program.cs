using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCaller
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandler handler = new EventHandler((sender, args) => Thread.Sleep(500));
            AsyncCaller caller = new AsyncCaller(handler);

            bool ok = caller.Invoke(5000, null, EventArgs.Empty);
            
            caller.CompletedOK = (bool)ok;
            Console.WriteLine("completedOK=" + caller.CompletedOK.ToString());
            Console.ReadLine();
        }
    }
    public class AsyncCaller
    {
        private EventHandler _handler;
        private bool completedOK;
        public AsyncCaller(EventHandler handler)
        {
            _handler = handler;
        }
        public bool CompletedOK
        {
            get { return completedOK; }   // get method
            set { completedOK = value; }  // set method
        }

        public bool Invoke(int milliseconds, object sender, EventArgs args)
        {
            var task = Task.Factory.StartNew(() => _handler.Invoke(sender, args));

            return task.Wait(milliseconds);
        }

    }

}
