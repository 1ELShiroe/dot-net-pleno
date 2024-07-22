namespace StallosDotnetPleno.Application.UseCases
{
    public interface IUseCase<T>
    {
        void Execute(T req);
    }
}