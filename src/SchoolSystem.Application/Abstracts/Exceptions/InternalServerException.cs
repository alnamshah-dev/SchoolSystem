namespace SchoolSystem.Application.Abstracts.Exceptions
{
    public class InternalServerException : Exception
    {
        public string? Details { get; }
        public InternalServerException(string message) : base(message)
        {
        }
        public InternalServerException(string details, string message) : base(message)
        {
            Details = details;
        }
    }
}
