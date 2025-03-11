using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace BenchmarkWriteLog.Console
{
    public class WriteLogService
    {
        private readonly ILogger _logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        public Task<bool> WriteLogAsync(LogRequest logRequest, CancellationToken cancellationToken)
        {
            if(!ValidLog(logRequest))
            {
                _logger.Error("Erro para escrever log");
                return Task.FromResult(false);
            }
                    
            return Task.Run(() => {
                
                try
                {
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

        public Task<bool> WriteLogV2Async(LogRequest logRequest)
        {
            if(!ValidLog(logRequest))
            {
                _logger.Error("Erro para escrever log");
                return Task.FromResult(false);
            }
             
            try
            {
                _logger.Information("Log {0}:", JsonSerializer.Serialize(logRequest));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro para escrever log");
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        private static bool ValidLog(LogRequest logRequest)
        {
            if(string.IsNullOrEmpty(logRequest.Message))
                return false;

            return true;
        }
    }
}