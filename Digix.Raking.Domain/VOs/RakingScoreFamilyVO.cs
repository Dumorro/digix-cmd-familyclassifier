using System;
using System.Collections.Generic;
using System.Text;

namespace Digix.Raking.Domain.Core.VOs
{
    public struct RakingScoreFamilyVO
    {
        public Guid FamilyId;
        public int Score;
        public int TotalCriterias;
        public DateTime DateTimeSelection;
    }
}
