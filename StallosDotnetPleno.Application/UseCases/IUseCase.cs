namespace StallosDotnetPleno.Application.UseCases
{
    public interface IUseCase<T>
    {
        void Execute(T req);
    }

    public interface IUseCaseAsync<T>
    {
        Task Execute(T req);
    }
}