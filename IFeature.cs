using System;

namespace Patlus.Common.UseCase
{
    public interface IFeature
    {
        Guid? RequestorId { get; set; }
    }
}
