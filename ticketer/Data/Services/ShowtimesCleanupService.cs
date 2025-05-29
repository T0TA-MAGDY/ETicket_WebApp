using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ticketer.Data;

public class ShowtimesCleanupService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IServiceProvider _services;

    public ShowtimesCleanupService(IServiceProvider services)
    {
        _services = services;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Run cleanup once every 24 hours
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(24));
        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using (var scope = _services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var pastShowtimes = dbContext.Showtimes
                .Where(st => st.Date < DateTime.Today);

            if (pastShowtimes.Any())
            {
                dbContext.Showtimes.RemoveRange(pastShowtimes);
                dbContext.SaveChanges();
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
