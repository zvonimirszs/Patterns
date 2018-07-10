using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostSharp.Aspects;

namespace Patterns.Aspects
{
    [Serializable]
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            // upisati u log: naziv metode (args.Method.Name) + vrijeme
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            // upisati u log: naziv metode (args.Method.Name) + vrijeme
        }
    }
}