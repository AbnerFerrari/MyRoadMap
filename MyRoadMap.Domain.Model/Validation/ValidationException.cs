using System.ComponentModel.DataAnnotations;

namespace MyRoadMap.Domain.Model.Validation
{
    public class ValidationException : System.ComponentModel.DataAnnotations.ValidationException
    {
        public List<ValidationResult> Errors { get; set; }

        public ValidationException() : base()
        {

        }

        public ValidationException(string? message) : base(message)
        {

        }

        public ValidationException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

        public ValidationException(List<ValidationResult> errors)
        {
            Errors = errors;
        }
    }
}
