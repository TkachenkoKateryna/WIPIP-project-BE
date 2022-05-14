namespace Application.Exceptions
{
    internal class UnauthorizedException<T> : Exception
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
