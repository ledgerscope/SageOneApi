using System;
using System.Threading;
using System.Timers;

namespace SageOneApi.Client
{
    public class SageOneApiUsageRestrictionHandler : SageOneApiClientBaseHandler
    {
        private static int _maxRequestsPerMinute = 200;
        private System.Timers.Timer _timer;
        private int _requestAmount = 1;

        public SageOneApiUsageRestrictionHandler(ISageOneApiClient apiClient) : base(apiClient)
        {
            _timer = new System.Timers.Timer(60000);
            _timer.Elapsed += OnTimeElapsed;
        }

        public override T Get<T>(string id)
        {
            if (!_timer.Enabled)
            {
                _timer.Start();
            }

            while(_requestAmount > _maxRequestsPerMinute)
            {
                Thread.Sleep(1000);
            }

            var response = base.Get<T>(id);
          
            _requestAmount += 1;

            return response;
        }

        private void OnTimeElapsed(Object source, ElapsedEventArgs e)
        {
            _requestAmount = 0; 

            _timer.Stop();
            _timer.Start();                
        }
    }
}
