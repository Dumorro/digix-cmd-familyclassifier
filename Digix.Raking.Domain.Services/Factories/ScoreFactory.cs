using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Services.ScoreRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digix.Raking.Domain.Services.Factories
{
    public static class ScoreFactory
    {
        public static T CreateScoreRule<T>(Family family) where T : FamilyScoreBase
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { family });
        }
    }
}
