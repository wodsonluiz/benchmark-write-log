using System.Threading;
using System.Threading.Tasks;

namespace BenchmarkWriteLog.Api.Services
{
    public interface IWriteLogService
    {
        public Task<bool> WriteLogAsync(LogRequest logRequest, CancellationToken cancellationToken);

        Task<bool> WriteLogV2Async(LogRequest logRequest);
    }
}