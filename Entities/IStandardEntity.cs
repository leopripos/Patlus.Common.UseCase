using System;

namespace Patlus.Common.UseCase.Entities
{
    public interface IStandardEntity
    {
        Guid Id { get; set; }
        Guid CreatorId { get; set; }
        DateTimeOffset CreatedTime { get; set; }
        DateTimeOffset LastModifiedTime { get; set; }

        bool Archived { get; set; }
    }
}
