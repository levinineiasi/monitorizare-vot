using System;

namespace VotingIrregularities.Api.Models
{
    public class VersionModel
    {
        public Guid Id { get; set; }
        public int CurrentVersion { get; set; }
        public string Name { get; set; }
    }
}
