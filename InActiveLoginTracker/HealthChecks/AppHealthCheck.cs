using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace InactiveLoginTracker.HealthChecks
{
    public class AppHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // Placeholder: return Healthy status
            return Task.FromResult(HealthCheckResult.Healthy("App is running."));
        }
    }
}
