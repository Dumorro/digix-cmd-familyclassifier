using Autofac;
using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Entities.Base;
using Digix.Raking.Domain.Core.Factories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Digix.Raking.Domain.Services.Factories
{
    public class ScoreFactory : IScoreFactory
    {
        private readonly IComponentContext _container;
        public ScoreFactory(IComponentContext container)
        {
            _container = container;
        }

        public T CreateScoreRule<T>(Family family) where T : FamilyScoreBase
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { family });
        }

        public List<FamilyScoreBase> CreateScoreRuleList(Family family)
        {
            List<FamilyScoreBase> familyScores = new List<FamilyScoreBase>();

            IEnumerable scores = (IEnumerable)_container.Resolve(typeof(IEnumerable<>).MakeGenericType(typeof(FamilyScoreBase)));

            foreach (var score in scores)
            {
                var s = (FamilyScoreBase)Activator.CreateInstance(typeof(FamilyScoreBase), new object[] { family });
                familyScores.Add(s);
            }


            return familyScores;
        }
    }
}
