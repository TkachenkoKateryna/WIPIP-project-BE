namespace Domain.Exceptions
{
    internal class UnauthorizedException<T> : Exception
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
