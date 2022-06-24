
using System.Collections;

namespace Domain.Models.Exceptions
{
    public class BadRequestException : Exception
    {
        private IDictionary data;
        public override IDictionary Data
        {
            get { return data; }
        }

        public BadRequestException(string message, string fieldName = null) : base(message)
        {
            data = new Dictionary<string, string>();
            this.data.Add("field", fieldName);
        }
    }
}
