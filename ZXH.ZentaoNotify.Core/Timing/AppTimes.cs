using System;
using Abp.Dependency;

namespace ZXH.ZendaoNotify.Core.Timing
{
    public class AppTimes : ISingletonDependency
    {
        public DateTime StartupTime { get; set; }
    }
}