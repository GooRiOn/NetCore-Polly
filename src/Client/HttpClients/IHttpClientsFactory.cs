using Client.Policies;
using System;

namespace Client.HttpClients
{
    public interface IHttpClientsFactory
    {
        TClient Create<TClient>();
        TClient Create<TClient>(Func<ICustomPolicyBuilder, ICustomPolicy> build);
    }
}
