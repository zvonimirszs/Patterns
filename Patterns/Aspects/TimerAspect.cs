using Metrics;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Patterns.Aspects
{
    [PSerializable]
    public class TimerAspect : OnMethodBoundaryAspect
    {
        [PNonSerialized]
        private Stopwatch stopwatch = new Stopwatch();
        [PNonSerialized]
        private Timer timer;

        public override void RuntimeInitialize(System.Reflection.MethodBase method)
        {
            stopwatch = new Stopwatch();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            timer = Metric.Timer("Method " + args.Method.Name + " duration", Unit.Requests);
            stopwatch.Start();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            stopwatch.Stop();
            // upisati u log ili u neki drugi oblik: args.Method.Name, stopwatch.Elapsed
        }
    }
}