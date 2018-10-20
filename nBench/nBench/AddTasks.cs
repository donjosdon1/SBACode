using NBench.Util;
using NBench;
using TaskManager.WebApi.Tests;

/// <summary>
/// Test to see if we can achieve max throughput on a <see cref="AtomicCounter"/>
/// </summary>
public class AddTasks
{
    private Counter _counter;
    private Counter _counter2;

    [PerfSetup]
    public void Setup(BenchmarkContext context)
    {
        _counter = context.GetCounter("AddTasks");
        //_counter2 = context.GetCounter("GetTasks");
    }

    [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
        NumberOfIterations = 10, RunMode = RunMode.Throughput,
        RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
    [CounterMeasurement("AddTasks")]
    [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]    
    public void BenchmarkMethod(BenchmarkContext context)
    {
        //var b = new byte[1024];
        //_counter.Increment();
        UnitTest1 u = new UnitTest1();
        u.AddTaskwithParent();
    }

    //[PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
    //NumberOfIterations = 10, RunMode = RunMode.Throughput,
    //RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
    //[CounterMeasurement("GetTasks")]
    //[MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
    //public void BenchmarkMethod2(BenchmarkContext context)
    //{
    //    //var b = new byte[1024];
    //    //_counter.Increment();
    //    UnitTest1 u = new UnitTest1();
    //    u.GetAllTasks();
    //}

    [PerfCleanup]
    public void Cleanup()
    {
        // does nothing
    }
}