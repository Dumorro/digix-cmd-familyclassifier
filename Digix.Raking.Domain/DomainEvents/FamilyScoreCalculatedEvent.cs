using Digix.Raking.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digix.Raking.Domain.Core.DomainEvents
{
    public class FamilyScoreCalculatedEvent : DomainEvent
    {
        public FamilyScoreCalculatedEvent(Guid familyId, int score, int totaCriterias)
        {
            FamilyId = familyId;
            Score = score;
            TotaCriterias = totaCriterias;
            base.DateTimeOccurred = DateTime.Now;
        }
        public Guid FamilyId{ get; private set; }
        public int Score { get; private set; }
        public int TotaCriterias { get; private set; }
    }
}
