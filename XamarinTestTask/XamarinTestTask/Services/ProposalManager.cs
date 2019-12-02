using System.Collections.Generic;
using XamarinTestTask.Models;

namespace XamarinTestTask.Services
{
    public class ProposalManager : IProposalManager
    {
        public List<Proposal> GetProposals()
        {
            var result = new List<Proposal>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new Proposal());
            }

            return result;
        }
    }
}
