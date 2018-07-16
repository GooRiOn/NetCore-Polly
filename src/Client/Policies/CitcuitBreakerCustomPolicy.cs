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
                .CircuitBreaker(FailAttempts, OpenCircuitDuration);
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> factory)
            => await _circuitBreakerPolicy.ExecuteAsync(factory);        
    }
}
