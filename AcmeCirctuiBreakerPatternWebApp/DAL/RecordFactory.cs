using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class RecordFactory
    {
        public bool SaveRecord(int secondsToSleep)
        {
            //sample execute method
            Thread.Sleep(secondsToSleep * 1000); //milsecs
            return true;
        }
    }
}
