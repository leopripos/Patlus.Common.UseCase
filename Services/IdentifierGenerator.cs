using System;

namespace Patlus.Common.UseCase.Services
{
    public class IdentifierGenerator : IIdentifierService
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
