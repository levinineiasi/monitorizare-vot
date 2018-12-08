using System.Threading.Tasks;

namespace VotingIrregularities.Api.Services
{
    public interface ISectieDeVotareService
    {
        Task<int> GetSingleVotingSection(string countyCode, int sectionNumber);
        Task<int> GetSingleVotingSection(int countyId, int sectionNumber);
    }
}
