using System;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleAuto.Utils
{
    public class TriangleThread
    {
        private Thread thread;
        private CancellationTokenSource cancellationTokenSource;

        public TriangleThread(Func<int, int> toRun)
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.thread = new Thread(() =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        toRun(0);
                    }catch(Exception ex) { 
                        Console.WriteLine("[TriangleThread Exception] Error while Executing Thread Method ==== "+ex.Message);
                    }
                    finally
                    {
                        Thread.Sleep(5);
                    }
                }
            });
            this.thread.SetApartmentState(ApartmentState.STA);
        }

        public static void Start(TriangleThread triangleThread)
        {
            triangleThread.thread.Start();
        }

        public static void Stop(TriangleThread triangleThread)
        {
            if (triangleThread != null && triangleThread.thread.IsAlive)
            {
                try { 
                    triangleThread.cancellationTokenSource.Cancel();
                    triangleThread.thread.Join(1000); // Wait up to 1 second for thread to finish
                }
                catch (Exception ex) {
                    Console.WriteLine("[Triangle Thread Exception] =========== We could not stop current thread: " + ex);
                }
            }
        }
    }
}
