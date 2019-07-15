using Digix.Raking.Domain.Core.Adapters;
using Digix.Raking.Domain.Core.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Digix.Raking.Domain.Services.CommandProcess
{
    public class UpddateDistributedCacheHandle : IHandle<FamilyScoreCalculatedEvent>
    {
        private readonly ICacheAdapter _cacheAdapter;
        public UpddateDistributedCacheHandle(ICacheAdapter cacheAdapter)
        {
            _cacheAdapter = cacheAdapter;
        }


        public async Task Handle(FamilyScoreCalculatedEvent domainEvent)
        {
            await _cacheAdapter.SaveOrUpdate(domainEvent.FamilyId, domainEvent.Score, domainEvent.TotaCriterias, domainEvent.DateTimeOccurred);
        }
    }
}
