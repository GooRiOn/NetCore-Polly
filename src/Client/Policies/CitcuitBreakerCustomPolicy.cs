using Polly;
using Polly.CircuitBreaker;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Policies
{
    public class CitcuitBreakerCustomPolicy : ICustomPolicy
    {
        private CircuitBreakerPolicy _circuitBreakerPolicy;

        private static int FailAttempts => 2;
        private static TimeSpan OpenCircuitDuration => TimeSpan.FromMinutes(1);

        public CitcuitBreakerCustomPolicy()
        {
            _circuitBreakerPolicy = Policy
                .Handle<HttpRequestException>()
                .CircuitBreakerAsync(FailAttempts, OpenCircuitDuration);
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> factory)
            => _circuitBreakerPolicy.CircuitState == CircuitState.Closed
            ? await _circuitBreakerPolicy.ExecuteAsync(async () => await factory())
            : await Task.FromResult(default(TResult));        

    }
}
