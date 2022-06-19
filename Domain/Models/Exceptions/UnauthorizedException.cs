namespace Domain.Models.Exceptions
{
    internal class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
