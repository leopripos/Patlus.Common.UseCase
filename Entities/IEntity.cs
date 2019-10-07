using System;

namespace Patlus.Common.UseCase.Entities
{
    public interface IStandardEntity
    {
        Guid CreatorId { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime LastModifiedTime { get; set; }

        bool Archived { get; set; }
    }
}
