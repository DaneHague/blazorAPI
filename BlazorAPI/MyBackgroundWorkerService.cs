using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyBackgroundWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ConcurrentQueue<string> _taskQueue;
        private readonly SemaphoreSlim _signal;
        private Timer _timer;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _taskQueue = new ConcurrentQueue<string>();
            _signal = new SemaphoreSlim(0);
        }

        // Add tasks to the queue
        public void EnqueueTask(string task)
        {
            _taskQueue.Enqueue(task);
            _signal.Release();
        }

        // Process tasks from the queue
        private async Task ProcessTasks(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _signal.WaitAsync(stoppingToken);

                if (_taskQueue.TryDequeue(out string task))
                {
                    _logger.LogInformation("Processing task: {task}", task);

                    // Process the task here
                    await Task.Delay(1000, stoppingToken); // Simulating task processing
                }
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            await ProcessTasks(stoppingToken);
        }
        private void DoWork(object state)
        {
            _logger.LogInformation("Timer triggered at: {time}", DateTimeOffset.Now);

            // Your background task logic here
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            await base.StopAsync(stoppingToken);
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }
    }
}
