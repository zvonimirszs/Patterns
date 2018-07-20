using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostSharp.Aspects;
using Metrics;
using PostSharp.Serialization;

namespace Patterns.Aspects
{
    [PSerializable]
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        [PNonSerialized]
        static Dictionary<string, Counter> countersForMethods;

        public override void OnEntry(MethodExecutionArgs args)
        {
            // upisati u log: naziv metode (args.Method.Name) + vrijeme
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            // upisati u log: naziv metode (args.Method.Name) + vrijeme

            Counter counter = getCounterForMethod(args.Method.Name);
            counter.Increment();
        }

        static Counter getCounterForMethod(string methodName)
        {
            if (countersForMethods == null) countersForMethods = new Dictionary<string, Counter>();

            if (countersForMethods.ContainsKey(methodName)) return countersForMethods[methodName];
            else
            {
                Counter counter = Metric.Counter(methodName, Unit.Calls);
                countersForMethods[methodName] = counter;
                return counter;
            }
        }
    }
}