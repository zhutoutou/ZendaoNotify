using System;
using Abp.Dependency;

namespace ZXH.ZentaoNotify.Core.Timing
{
    public class AppTimes : ISingletonDependency
    {
        public DateTime StartupTime { get; set; }
    }
}