using System;
using Autofac;
using Client.Policies;

namespace Client.HttpClients
{
    public class HttpClientsFactory : IHttpClientsFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public HttpClientsFactory(ILifetimeScope lifetimeScope)
            => _lifetimeScope = lifetimeScope;

        public TClient Create<TClient>()
            => _lifetimeScope.Resolve<TClient>(null);

        public TClient Create<TClient>(Func<ICustomPolicyBuilder, ICustomPolicy> build)
            => _lifetimeScope.Resolve<TClient>(new TypedParameter(typeof(ICustomPolicy), build(new CustomPolicyBuilder())));
    }
}
