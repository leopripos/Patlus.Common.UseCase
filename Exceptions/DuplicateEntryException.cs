namespace Patlus.Common.UseCase.Exceptions
{
    public class DuplicateEntryException : OperationNotAllowedException
    {
        public readonly string EntityName;
        public readonly object EntityValue;

        public DuplicateEntryException(string name, object value)
            : base($"Duplicate entity \"{name}\" `({value})`.")
        {
            this.EntityName = name;
            this.EntityValue = value;
        }
    }
}
