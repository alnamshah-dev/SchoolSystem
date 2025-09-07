namespace SchoolSystem.Application.Abstracts.Exceptions
{
    public class BadRequestException : Exception
    {
        public string? Details { get; }
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(string details, string message) : base(message)
        {
            Details = details;
        }
    }
}
