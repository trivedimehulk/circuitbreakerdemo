using DAL;
using Polly;
using Polly.Timeout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class RecordMaster
    {
        public bool SaveRecord(string inMethodExecutionThreshold_seconds, string inSampleThreadSleep_seconds)
        {
            //Implement resiliency here
             int MethodExecutionThreshold_seconds = Int32.Parse(inMethodExecutionThreshold_seconds);
            int SampleThreadSleep_seconds = Int32.Parse(inSampleThreadSleep_seconds);

            TimeoutPolicy timeoutPolicy = Policy.Timeout(MethodExecutionThreshold_seconds, TimeoutStrategy.Pessimistic, onTimeout: (context, timespan, task) =>
            {
                throw new Exception("The DAL method execution took more then " + MethodExecutionThreshold_seconds.ToString() + " seconds. Aborted.");
            });


            return timeoutPolicy.Execute(() =>  (new RecordFactory()).SaveRecord(SampleThreadSleep_seconds));
            
        }
    }
}
