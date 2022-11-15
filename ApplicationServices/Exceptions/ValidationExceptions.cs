using FluentValidation.Results;

namespace ApplicationsServices.Exceptions
{
    public class ValidationExceptions : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationExceptions() : base("Existen uno o más errores de validación.")
        {
            Errors = new List<string>();
        }
        public ValidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        { 
            foreach(var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
