using System;

namespace VotingIrregularities.Domain.Models
{
    public partial class VersiuneFormular
    {
        public Guid CodFormular { get; set; }
        public int VersiuneaCurenta { get; set; }
        public string Nume { get; set; }
        public DateTime Data { get; set; }
        public int Ordine { get; set; }
    }
}
