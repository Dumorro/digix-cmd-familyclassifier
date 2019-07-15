using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Digix.Raking.Domain.Core.Adapters
{
    public interface IAttendedFamiliesAdapter //Adapter to access Attended module Web API.
    {
        Task SaveAttendedFamily(Guid familyId, int score, int totalCriterias, DateTime dateTimeClassification);
    }
}
