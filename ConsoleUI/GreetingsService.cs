using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

//DI, Serilog, Settings

namespace ConsoleUI
{
    public class GreetingsService : IGreetingsService
    {
        private readonly ILogger<GreetingsService> _log;
        private readonly IConfiguration _config;

        public GreetingsService(ILogger<GreetingsService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void Run()
        {
            while (_config.GetValue<int>("LoopTimes") > 0)
            {
                for (int i = 0; i < _config.GetValue<int>("LoopTimes"); i++)
                {
                    _log.LogInformation("Run number {runNumber}", i);
                }
                _log.LogInformation("Waiting for 2 seconds");
                Thread.Sleep(2000);
            }
            _log.LogInformation("Exiting GreetingsService");

        }
    }
}
