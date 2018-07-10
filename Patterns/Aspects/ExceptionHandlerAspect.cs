using Patterns.Models;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patterns.Aspects
{
    [Serializable]
    public class ExceptionHandlerAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            if (ExceptionHandler.Handle(args.Exception))
            {
                args.FlowBehavior = FlowBehavior.Continue;
            }
        }
    }
}