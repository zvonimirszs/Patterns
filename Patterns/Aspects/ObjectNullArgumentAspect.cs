using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patterns.Aspects
{
    [Serializable]
    public class ObjectNullArgumentAspect : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            // ako je instanca SearchController, određena metoda i ako je argument NULL: baciti exception ArgumentNullException
            var parameters = args.Method.GetParameters();
            var arguments = args.Arguments;
            for (int i = 0; i < arguments.Count; i++)
            {
                if (arguments[i] == null)
                {
                    throw new ArgumentNullException(parameters[i].Name);
                }
            }
            args.Proceed();
        }
 
    }
}