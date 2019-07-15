using Bogus;
using Digix.Raking.Domain.Core.DomainEvents;
using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Services;
using Digix.Raking.Tests.Base;
using Digix.Raking.Tests.Builders;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Digix.Raking.Tests
{
    public class RankingFamilyManagerSmokeTest : TestBase
    {

        [Fact]
        public void Ranking_families_list_OK()
        {
            var rankingFamilyService = base.RankingFamilyManager;
            var listFamilies = new FamilesToProcessBuilder().Build();

            rankingFamilyService.ProcessClassification(listFamilies);
        }
    }
}