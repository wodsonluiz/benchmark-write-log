using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace BenchmarkWriteLog.Api.Services
{
    public class WriteLogService : IWriteLogService
    {
        private readonly ILogger _logger;

        public WriteLogService(ILogger logger) =>
            _logger = logger;

        public Task<bool> WriteLogAsync(LogRequest logRequest, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                
                try
                {
                    if(!ValidLog(logRequest))
                    {
                        _logger.Error("Erro para escrever log");

                        return false;
                    }

                    _logger.Information("Log {0}:", JsonSerializer.Serialize(logRequest));
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Erro para escrever log");
                    return false;
                }

                return true;

            }, cancellationToken);
        }

        private static bool ValidLog(LogRequest logRequest)
        {
            if(string.IsNullOrEmpty(logRequest.Message))
                return false;

            return true;
        }
    }
}