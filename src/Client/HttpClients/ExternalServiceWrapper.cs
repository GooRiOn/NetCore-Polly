using Client.Policies;
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
    public sealed class ExternalServiceWrapper : BaseServiceWrapper ,IExternalService
    {
        private readonly IExternalService _externalService;

        public ExternalServiceWrapper(ICustomPolicy customPolicy) :base(customPolicy)
            => _externalService = RestClient.For<IExternalService>("http://localhost:5001");

        public async Task<IEnumerable<string>> GetValuesAsync()
            => await ExecuteAsync(async () => await _externalService.GetValuesAsync());
    }
}

