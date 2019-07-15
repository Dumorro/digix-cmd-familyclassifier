using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Digix.Raking.Domain.Core.Adapters
{
    public interface ICacheAdapter
    {
        Task<bool> SaveOrUpdate(Guid familyId, int score, int totalCriterias, DateTime dateTimeClassification);
    }
}
