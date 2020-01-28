using System;

namespace Patlus.Common.UseCase.Exceptions
{
    public class NotFoundException : Exception
    {
        public readonly string EntityName;
        public readonly object EntityValue;

        public NotFoundException(string name, object value)
            : base($"Entity \"{name}\" `({value})` was not found.")
        {
            this.EntityName = name;
            this.EntityValue = value;
        }
    }
}
