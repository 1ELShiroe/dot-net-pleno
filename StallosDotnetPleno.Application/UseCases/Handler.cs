namespace StallosDotnetPleno.Application.UseCases
{
    public abstract class Handler<T>
    {
        protected Handler<T>? Successor;
        protected string HandlerName => $"{GetType().Name}<{typeof(T).Name}>";

        public Handler<T> SetSucessor(Handler<T> successor) => Successor = successor;

        public abstract void ProcessRequest(T req);
    }
}