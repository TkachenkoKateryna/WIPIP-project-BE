using System.Collections;

namespace Domain.Models.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        private IDictionary data;
        public override IDictionary Data
        {
            get { return data; }
        }

        public AlreadyExistsException(string message, string fieldName = null) : base(message)
        {
            data = new Dictionary<string, string>();
            this.data.Add("field", fieldName);
        }
    }
}
