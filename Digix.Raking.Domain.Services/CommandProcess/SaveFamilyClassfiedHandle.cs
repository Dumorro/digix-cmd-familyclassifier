using Digix.Raking.Domain.Core.Adapters;
using Digix.Raking.Domain.Core.DomainEvents;
using Digix.Raking.Domain.Core.Services;
using System.Threading.Tasks;

namespace Digix.Raking.Domain.Services.CommandProcess
{
    public class FamilyClassfiedHandle : IHandle<FamilyScoreCalculatedEvent>
    {
        private readonly IAttendedFamiliesAdapter _attendedFamiliesAdapter;
        public FamilyClassfiedHandle( IAttendedFamiliesAdapter attendedFamiliesAdapter)
        {
            this._attendedFamiliesAdapter = attendedFamiliesAdapter;
        }

        public async Task Handle(FamilyScoreCalculatedEvent @event)
        {
            await _attendedFamiliesAdapter.SaveAttendedFamily(@event.FamilyId, @event.Score, @event.TotaCriterias, @event.DateTimeOccurred);
        }       
    }
}
