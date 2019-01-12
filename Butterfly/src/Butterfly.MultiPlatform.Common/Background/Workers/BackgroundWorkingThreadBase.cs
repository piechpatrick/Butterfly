using Butterfly.MultiPlatform.Interfaces.Background;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Butterfly.MultiPlatform.Common.Background.Workers
{
    /// <summary>
    /// BackgroundWorkingServiceBase
    /// </summary>
    public abstract class BackgroundWorkingThreadBase : IBackgroundThreadWorker
    {
        private bool isRunning = true;
        private Thread workingThread;
        private int interval = 60000;
        private ThreadPriority threadPriority = ThreadPriority.BelowNormal;


        /// <summary>
        /// base()
        /// </summary>
        protected BackgroundWorkingThreadBase(int milisecondsInterval, ThreadPriority threadPriority)
        {
            this.interval = milisecondsInterval;
            this.threadPriority = threadPriority;
        }

        /// <summary>
        /// IsRunning
        /// </summary>
        public bool IsRunning => this.isRunning;

        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            try
            {
                this.workingThread = new Thread(this.Run);
                this.workingThread.Name = this.GetType().Name;
                this.workingThread.IsBackground = true;
                this.workingThread.Priority = this.threadPriority;
                this.workingThread.Start();
                this.OnStart(this.workingThread);
            }
            catch (ThreadStartException tsex)
            {
                this.OnError(this.workingThread, tsex);
            }
            catch (Exception ex)
            {
                this.OnError(this.workingThread,ex);
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            this.isRunning = false;
        }

        /// <summary>
        /// Run
        /// </summary>
        private void Run()
        {
            try
            {
                while (this.IsRunning)
                {
                    this.Work();
                    Thread.Sleep(this.interval);
                }
            }
            catch (ThreadAbortException aex)
            {
                this.OnError(this.workingThread, aex);
            }
            catch (ThreadInterruptedException itex)
            {
                this.OnError(this.workingThread, itex);
            }
            catch (Exception ex)
            {
                this.OnError(this.workingThread, ex);
            }
            finally
            {
                this.OnFinished(this.workingThread);
            }
        }

        /// <summary>
        /// Abstract work
        /// </summary>
        protected abstract void Work();


        /// <summary>
        /// OnStart
        /// </summary>
        /// <param name="thread"></param>
        protected abstract void OnStart(Thread thread);

        /// <summary>
        /// OnError
        /// </summary>
        /// <param name="thread"></param>
        /// <param name="exception"></param>
        protected abstract void OnError(Thread thread, Exception exception);

        /// <summary>
        /// thread
        /// </summary>
        /// <param name="thread"></param>
        protected abstract void OnFinished(Thread thread);
    }
}
