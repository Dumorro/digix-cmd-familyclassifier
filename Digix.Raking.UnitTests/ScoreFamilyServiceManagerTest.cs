using Digix.Raking.Domain.Core.DomainEvents;
using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Services;
using System;
using Xunit;

namespace Digix.Raking.UnitTests
{
    public class ScoreFamilyServiceManagerTest
    {
        private Family CreateFamily()
        {
            var family = new Family();
           // family.Id = Guid.NewGuid();
            return family;
        }

        [Fact]
        public void Test1()
        {

           // var rankingScore = _scoreFamilyServiceManager.Object.CalculateScore(CreateFamily());
        }
    }
}
