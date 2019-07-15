using Digix.Raking.Domain.Core.DomainEvents;
using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digix.Raking.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class RankingFamilyManager : IRankingFamilyManager
    {
        private List<int> ALLOWED_STATUS_IDS;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly IScoreFamilyServiceManager _scoreFamilyServiceManager;

        public RankingFamilyManager(IDomainEventDispatcher domainEventDispatcher, IScoreFamilyServiceManager scoreFamilyServiceManager)
        {
            this._domainEventDispatcher = domainEventDispatcher;
            this._scoreFamilyServiceManager = scoreFamilyServiceManager;

            ALLOWED_STATUS_IDS = GetAllowedStatusId();
        }
        private List<int> GetAllowedStatusId()
        {
            var allowedId = 0;  //TODO: change to get parameter from a datasource

            var ids = new List<int>();
            ids.Add(allowedId);

            return ids;
        }

        public async Task ProcessClassification(IEnumerable<Family> families)
        {
            Parallel.ForEach(families.Where(f=> ALLOWED_STATUS_IDS.Contains(f.Status)), 
                                (family) =>
                                {
                                    QueueToRanking(family);
                                }
                            );
        }
        private void QueueToRanking(Family family)
        {
            var classification = _scoreFamilyServiceManager.CalculateScore(family);
            var @event = new FamilyScoreCalculatedEvent(family.Id, classification.Score, classification.TotalCriterias);

            _domainEventDispatcher.Dispatch(@event);
        }

    }
}
