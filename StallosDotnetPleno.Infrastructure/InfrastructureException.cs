namespace StallosDotnetPleno.Infrastructure
{
    public class InfrastructureException(string businessMessage) : Exception(businessMessage)
    {
    }
}