namespace Client.Policies
{
    public interface ICustomPolicyBuilder
    {
        ICustomPolicy WithCircuitBreaker();
    }
}