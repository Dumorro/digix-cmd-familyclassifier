using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.VOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digix.Raking.Domain.Core.Services
{
    public interface IScoreFamilyServiceManager
    {
        RakingScoreFamilyVO CalculateScore(Family family);
    }
}
