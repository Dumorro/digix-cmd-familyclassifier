using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Entities.Base;
using System.Collections.Generic;

namespace Digix.Raking.Domain.Core.Factories
{
    public interface IScoreFactory
    {
        T CreateScoreRule<T>(Family family) where T : FamilyScoreBase;

        List<FamilyScoreBase> CreateScoreRuleList(Family family);
    }
}
