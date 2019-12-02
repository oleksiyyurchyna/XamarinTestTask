using System.Collections.Generic;
using XamarinTestTask.Models;

namespace XamarinTestTask.Services
{
    public interface IProposalManager
    {
        List<Proposal> GetProposals();
    }
}
