using System;

namespace Patlus.Common.UseCase.Exceptions
{
    public class IntegrationFailureException : Exception
    {
        public IntegrationFailureException(string name)
               : base($"Integration failure to \"{name}\" service.")
        { }
    }
}
