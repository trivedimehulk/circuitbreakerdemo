using Polly;
using Polly.Timeout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcmeCirctuiBreakerPatternApp
{
    class Program
    {

        static int MethodExecutionThreshold_seconds = 0;
        static int SampleThreadSleep_seconds = 2;
        static void Main(string[] args)
        {
            try
            {
                

                echo("================ CIRCUIT BREAKER PATTERN DEMO =====================");
                
                echo(@"Usage: This pattern handle faults that might take a variable amount of time to recover from, when connecting to a remote service or resource.");
                echo(@"This can improve the stability and resiliency of an application. For e.g. From UI->promise a 3 second response back from your business layer.");
                echo(@"If the business method takes more then 3 seconds, the method can come back with a handled timeout.");

                echo("Enter wait threshold (e.g. (integer) 3) [This is how much the code will wait for method to execute]:");
                MethodExecutionThreshold_seconds = Int32.Parse(Console.ReadLine());

                echo("Enter how much sample method should sleep (e.g. (integer) 5) [This is how much the code will make the thread sleep]:");
                SampleThreadSleep_seconds = Int32.Parse(Console.ReadLine());

                echo("Starting to execute a method...");
                echo("Method execution threshold:" + MethodExecutionThreshold_seconds.ToString());
                echo("Sample method will sleep for " + SampleThreadSleep_seconds.ToString() + " seconds...");
                echo("If the execution time is less then threshold we should see a success message");
                echo("==================");

                TimeoutPolicy timeoutPolicy = Policy.Timeout(MethodExecutionThreshold_seconds, TimeoutStrategy.Pessimistic, onTimeout: (context, timespan, task) =>
                    {
                        Console.WriteLine("The code execution took more then " + MethodExecutionThreshold_seconds.ToString() + " seconds. Aborted.");
                    });

                timeoutPolicy.Execute(() => ComplexAndSlowCode());
                echo("Method executed suceesfully");
            }
            catch (Exception ex)
            {
                echo("Polly excetpion catch ->" + ex.Message);
            }

            echo("Press any key to quit...");
            Console.ReadLine();
        }
        static void ComplexAndSlowCode()
        {
            Thread.Sleep(SampleThreadSleep_seconds * 1000); //milsecs
        }
        static void echo(string msg) { Console.WriteLine(msg); Console.WriteLine(""); }
    }
}
