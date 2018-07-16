using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Policies
{
    public class CustomPolicyBuilder : ICustomPolicyBuilder
    {
        public ICustomPolicy WithCircuitBreaker()
            => new CitcuitBreakerCustomPolicy();
    }
}
