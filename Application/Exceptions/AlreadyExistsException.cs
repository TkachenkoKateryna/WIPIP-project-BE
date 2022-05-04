namespace Application
{
    public class AlreadyExistsException<T> : Exception
    {
        public AlreadyExistsException(string message) : base(message)
        {
        }
    }
}
