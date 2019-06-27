using Microsoft.Extensions.Logging;
namespace PersonalNotesAPI
{
    public partial class Startup
    {
        public void ConfigureLog(ILoggerFactory loggerFactory)
        {
            // It load configures from log4net.config
            loggerFactory.AddLog4Net();
        }
    }
}
