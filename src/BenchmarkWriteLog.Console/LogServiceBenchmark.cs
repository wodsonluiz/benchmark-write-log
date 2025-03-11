using System;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkWriteLog.Console
{
    public class LogServiceBenchmark
{
    private readonly WriteLogService _logService = new();
    private readonly LogRequest _logRequest = new() { Message = string.Format("Teste de log {0}", Guid.NewGuid()), Level = "Verbose" };
    private readonly CancellationToken _cancellationToken = CancellationToken.None;

    [Benchmark]
    public async Task WriteLogAsync() => await _logService.WriteLogAsync(_logRequest, _cancellationToken);

    [Benchmark]
    public async Task WriteLogV2Async() => await _logService.WriteLogV2Async(_logRequest);
}
}