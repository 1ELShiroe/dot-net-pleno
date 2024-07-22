namespace StallosDotnetPleno.Application
{
    public class ApplicationException(string businessMessage) : Exception(businessMessage)
    {
    }
}