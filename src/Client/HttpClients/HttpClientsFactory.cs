using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Policies;

namespace Client.HttpClients
{
    public class HttpClientsFactory : IHttpClientsFactory
    {
        public TClient Create<TClient>()
        {
            throw new NotImplementedException();
        }

        public TClient Create<TClient>(Func<ICustomPolicy> factory)
        {
            throw new NotImplementedException();
        }
    }
}
