using Autofac;
using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Entities.Base;
using Digix.Raking.Domain.Core.Factories;
using Digix.Raking.Domain.Core.Services;
using Digix.Raking.Domain.Core.VOs;
using Digix.Raking.Domain.Services.ScoreRules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Digix.Raking.Domain.Services
{
    public class ScoreFamilyServiceManager : IScoreFamilyServiceManager
    {
        private readonly IScoreFactory _scoreFactory;

        public ScoreFamilyServiceManager( IScoreFactory scoreFactory)
        {
            _scoreFactory = scoreFactory;
        }

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

        private IList<FamilyScoreBase> GetScores(Family family) //TODO: refactor to auto generate list 
        {
            var familyIncome = _scoreFactory.CreateScoreRule<FamilyIncomeScore>(family);
            var familyDependent = _scoreFactory.CreateScoreRule<FamilyDedependentScore>(family);
            var familyApplicant = _scoreFactory.CreateScoreRule<FamilyAgeApplicantScore>(family);

            List<FamilyScoreBase> scores = new List<FamilyScoreBase>();
            scores.Add(familyIncome);
            scores.Add(familyDependent);
            scores.Add(familyApplicant);
            
            scores.ForEach(s => s.CalculateScore());

            return scores;
        }

    } 
}
