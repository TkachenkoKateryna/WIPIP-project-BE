namespace Domain.Models.Exceptions
{
    public class NotFoundException<T> : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
