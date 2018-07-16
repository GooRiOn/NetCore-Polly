using System;
using System.Threading.Tasks;

namespace Client.Policies
{
    public interface ICustomPolicy
    {
        Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> factory);
    }
}
