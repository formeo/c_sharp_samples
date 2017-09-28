using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Singletone_sample

{ 
    public sealed class singletone_lazy
    {
        private static readonly Lazy<singletone_lazy> lazy =
            new Lazy<singletone_lazy>(() => new singletone_lazy());

        public static singletone_lazy Instance { get { return lazy.Value; } }

        private singletone_lazy()
        {
        }
    }
}

