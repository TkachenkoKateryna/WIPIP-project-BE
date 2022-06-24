namespace Domain.Models.Exceptions
{
    public class UnathorizedException : Exception
    {
        public UnathorizedException(string message) : base(message)
        {
        }
    }
}
