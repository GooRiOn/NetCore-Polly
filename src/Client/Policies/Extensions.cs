using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Policies
{
    public static class Extensions
    {
        public static ICustomPolicy WithCircuitBreaker(this ICustomPolicyBuilder builder)
            => new CitcuitBreakerCustomPolicy();
    }
}
