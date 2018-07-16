using Client.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.HttpClients
{
    public interface IHttpClientsFactory
    {
        TClient Create<TClient>();
        TClient Create<TClient>(Func<ICustomPolicy> factory);
    }
}
