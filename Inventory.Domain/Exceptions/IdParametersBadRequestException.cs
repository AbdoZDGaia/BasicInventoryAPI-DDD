namespace Inventory.Domain.Exceptions
{
    public class IdParametersBadRequestException : BadRequestException
    {
        public IdParametersBadRequestException(string parameterName)
            : base($"Parameter {parameterName} is invalid")
        {
        }
    }
}
