using Digix.Raking.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Digix.Raking.Domain.Core.Services
{
    public interface IRankingFamilyManager
    {
        Task ProcessClassification(IEnumerable<Family> families);
    }
}
