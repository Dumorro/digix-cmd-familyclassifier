using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Services;
using Digix.Raking.Domain.Core.VOs;
using Digix.Raking.Domain.Services.Factories;
using Digix.Raking.Domain.Services.ScoreRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digix.Raking.Domain.Services
{
    public class ScoreFamilyServiceManager : IScoreFamilyServiceManager
    {
        public RakingScoreFamilyVO CalculateScore(Family family)
        {
            RakingScoreFamilyVO classification = new RakingScoreFamilyVO();

            var rules = GetScores(family);

            classification.FamilyId = family.Id;
            classification.DateTimeSelection = DateTime.UtcNow;
            classification.Score = rules.Sum(rule => rule.Score);
            classification.TotalCriterias = rules.Count(rule => rule.IsClassified);
                       
            return classification;
        }
        private IList<FamilyScoreBase> GetScores(Family family)
        {
            var familyIncome = ScoreFactory.CreateScoreRule<FamilyIncomeScore>(family);
            var familyDependent = ScoreFactory.CreateScoreRule<FamilyDedependentScore>(family);
            var familyApplicant = ScoreFactory.CreateScoreRule<FamilyAgeApplicantScore>(family);

            List<FamilyScoreBase> scores = new List<FamilyScoreBase>();
            scores.Add(familyIncome);
            scores.Add(familyDependent);
            scores.Add(familyApplicant);

            return scores;
        }
    } 
}
