namespace Microservices.Common.Exceptions
{
    public class MicroException : Exception
    {
        public string Code { get; }

        public MicroException()
        {
        }

        public MicroException(string code)
        {
            Code = code;
        }

        public MicroException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public MicroException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }
        public MicroException(Exception innerException, string message, params object[] args) : this(innerException, string.Empty, message, args)
        {
        }
        public MicroException(Exception innerException, string code, string message, params object[] args) : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}