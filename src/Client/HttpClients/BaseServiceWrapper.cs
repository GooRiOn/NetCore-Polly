using Client.Policies;
using System;
using System.Threading.Tasks;

namespace Client.HttpClients
{
    public abstract class BaseServiceWrapper
    {
        private ICustomPolicy _customPolicy;

        protected BaseServiceWrapper(ICustomPolicy customPolicy)
            => _customPolicy = customPolicy;

        protected async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> factory)
            => await _customPolicy.ExecuteAsync(factory);
    }
}
