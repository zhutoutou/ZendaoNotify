using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Quartz;
using Quartz;

namespace ZXH.ZentaoNotify.Quartz.BaseJobs
{
    public class BugSearchJob : JobBase, ITransientDependency
    {
        public override async Task Execute(IJobExecutionContext context)
        {
            // var handler = new HttpClientHandler()
            // {
            //     AutomaticDecompression = DecompressionMethods.GZip,
            // };
            // using (var client = new HttpClient())
            // {
            //     var response = await client.GetAsync("http://project.aecg.com.cn/zentao/project-index-no.html");
            //     response.EnsureSuccessStatusCode();   
            //     var result = await response.Content.ReadAsStringAsync();               
            // }
            await Task.Run(()=>Logger.Info("Excuted MyLogJob..!"));
        }
    }
}