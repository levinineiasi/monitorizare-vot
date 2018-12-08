using System;
using System.Collections.Generic;
using MediatR;

namespace VotingIrregularities.Api.Models
{
    public class ModelFormular
    {
        public class VersiuneQuery : IRequest<IEnumerable<ModelVersiune>>
        {
        }

        public class IntrebariQuery : IRequest<IEnumerable<ModelSectiune>>
        {
            public Guid CodFormular { get; set; }
            public int CacheHours { get; set; }
            public int CacheMinutes { get; set; }
            public int CacheSeconds { get; set; }
        }
    }
}
