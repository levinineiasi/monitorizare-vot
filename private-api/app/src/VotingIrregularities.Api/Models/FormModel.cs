using System;
using System.Collections.Generic;
using MediatR;

namespace VotingIrregularities.Api.Models
{
    public class FormModel
    {
        public class VersionQuery : IRequest<IEnumerable<VersionModel>>
        {
        }

        public class QuestionsQuery : IRequest<IEnumerable<SectionModel>>
        {
            public Guid FormCode { get; set; }
            public int CacheHours { get; set; }
            public int CacheMinutes { get; set; }
            public int CacheSeconds { get; set; }
        }
    }
}
