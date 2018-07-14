using Polly;
using Polly.CircuitBreaker;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.HttpClients
{
    public sealed class ExternalServiceWrapper : IExternalService
    {
        private readonly IExternalService _externalService;
        private readonly CircuitBreakerPolicy _circuitBreaker;

        private static int FailAttempts => 2;
        private static TimeSpan OpenCircuitDuration => TimeSpan.FromMinutes(1);

        public ExternalServiceWrapper()
        {
            _externalService = RestClient.For<IExternalService>("http://localhost:5001");
            _circuitBreaker = CreateCircuitBreakerPolicy();
        }

        public async Task<IEnumerable<string>> GetValuesAsync()
            => _circuitBreaker.CircuitState == CircuitState.Closed 
                ? await _circuitBreaker.ExecuteAsync(async () => await _externalService.GetValuesAsync())
                : await Task.FromResult(Enumerable.Empty<string>());

        private CircuitBreakerPolicy CreateCircuitBreakerPolicy()
            => Policy
                .Handle<HttpRequestException>()
                .CircuitBreakerAsync(FailAttempts, OpenCircuitDuration) ;
    }
}

