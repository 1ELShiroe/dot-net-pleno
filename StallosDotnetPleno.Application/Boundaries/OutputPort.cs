namespace StallosDotnetPleno.Application.Boundaries
{
    public abstract class OutputPort<T>
    {
        public abstract void Standard(T output);
        public abstract void Error(string message);
        public abstract void NotFound(string message);
        public abstract void NotAuthorized(string message);
    }
}