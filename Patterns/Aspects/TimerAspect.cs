using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Patterns.Aspects
{
    [Serializable]
    public class TimerAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        private Stopwatch stopwatch = new Stopwatch();

        public override void RuntimeInitialize(System.Reflection.MethodBase method)
        {
            stopwatch = new Stopwatch();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            stopwatch.Start();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            stopwatch.Stop();
            // upisati u log ili u neki drugi oblik: args.Method.Name, stopwatch.Elapsed
        }
    }
}