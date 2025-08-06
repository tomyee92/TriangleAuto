using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using Newtonsoft.Json;
using TriangleAuto.Utils;

namespace TriangleAuto.Model
{
    public class AutoRefreshSpammer : Action
    {
        private string ACTION_NAME = "AutoRefreshSpammer";
        private TriangleThread thread;
        public int refreshDelay { get; set; } = 5;
        public Key refreshKey { get; set; }

        public AutoRefreshSpammer()
        {

        }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                const int defaultDelayInSeconds = 1000;
                int delayInSeconds = this.refreshDelay * 1000;
                int delay = delayInSeconds == 0 ? defaultDelayInSeconds : delayInSeconds;
                this.thread = new TriangleThread(_ => AutorefreshThreadExecution(roClient, delay));
                TriangleThread.Start(this.thread);
            }
        }

        private int AutorefreshThreadExecution(Client roClient, int delay)
        {
            if (this.refreshKey != Key.None)
            {
                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), this.refreshKey.ToString()), 0);
            }
            Thread.Sleep(delay);
            return 0;
        }

        public void Stop()
        {
            TriangleThread.Stop(this.thread);
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName()
        {
            return ACTION_NAME;
        }
    }
}
