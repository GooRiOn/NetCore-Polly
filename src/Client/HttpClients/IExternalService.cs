using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.HttpClients
{
    public interface IExternalService
    {
        [Get("api/Values")]
        Task<IEnumerable<string>> GetValuesAsync();
    }
}
