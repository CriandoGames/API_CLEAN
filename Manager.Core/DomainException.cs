namespace Manager.Core
{
    public class DomainException : Exception
    {

        internal List<string> _errors { get; set; }

        public IReadOnlyCollection<string> Errors => _errors;

        public DomainException()
        {
            _errors = new List<string>();
        }

        public DomainException(string message, List<string> erros) : base(message)
        {
            _errors = erros;
        }

        public DomainException(string message) : base(message)
        {
            _errors = new List<string>();
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
            _errors = new List<string>();
        }
    }

}
