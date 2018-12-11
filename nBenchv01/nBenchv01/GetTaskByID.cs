using NBench.Util;
using NBench;
using CaseStudy.WebApi.Tests;

/// <summary>
/// Test to see if we can achieve max throughput on a <see cref="AtomicCounter"/>
/// </summary>
public class GetTaskByID
{
    private Counter _counter;
    private Counter _counter2;

    [PerfSetup]
    public void Setup(BenchmarkContext context)
    {
        _counter = context.GetCounter("GetTaskByID");
        //_counter2 = context.GetCounter("GetTasks");
    }

    //[PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
    //    NumberOfIterations = 10, RunMode = RunMode.Throughput,
    //    RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
    //[CounterMeasurement("AddTasks")]
    //[MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]    
    //public void BenchmarkMethod(BenchmarkContext context)
    //{
    //    //var b = new byte[1024];
    //    //_counter.Increment();
    //    UnitTest1 u = new UnitTest1();
    //    u.AddTaskwithParent();
    //}

    [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
        NumberOfIterations = 500, RunMode = RunMode.Throughput,
        RunTimeMilliseconds = 600000, TestMode = TestMode.Measurement)]
    [CounterMeasurement("GetTaskByID")]
    [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
    public void BenchmarkMethod2(BenchmarkContext context)
    {
        //var b = new byte[1024];
        //_counter.Increment();
        TaskTest u = new TaskTest();
        u.GetTaskByID();
    }

    [PerfCleanup]
    public void Cleanup()
    {
        // does nothing
    }
}