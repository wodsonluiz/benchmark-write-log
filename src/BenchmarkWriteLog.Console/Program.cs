﻿namespace BenchmarkWriteLog.Console;

using System;
using BenchmarkDotNet.Running;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<LogServiceBenchmark>();
    }
}
