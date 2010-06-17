using System;

namespace SpikeRhinoSecurity.Infrastructure
{
    public class ParamEventArgs<T> : EventArgs
    {
        public ParamEventArgs(T param)
        {
            Param = param;
        }

        public ParamEventArgs() {}

        public T Param { get; set; }
    }
}