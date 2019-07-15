using Digix.Raking.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digix.Raking.Domain.Services.ScoreRules
{
    class FamilyIncomeScore : FamilyScoreBase
    {

        private const int SCORE_FIRST_RANGE_VALUE = 3;
        private const int SCORE_SECOND_RANGE_VALUE = 2;
        private const int SCORE_THIRD_RANGE_VALUE = 1;
        
        private const double LIMIT_FIRST_RANGE_VALUE = 900;
        private const double LIMIT_SECOND_RANGE_VALUE = 1500;

        public FamilyIncomeScore(Family family) : base(family)
        {
        }
        protected override void CalculateScore()
        {
            double? totalIncome = base.family?.Incomes.Sum(i => i.Value);

            if (!totalIncome.HasValue)
            {
                base._isClassified = false;
                return;
            }

            base._isClassified = true;

            if (totalIncome <= LIMIT_FIRST_RANGE_VALUE)
                base._score = SCORE_FIRST_RANGE_VALUE;

            if (totalIncome > LIMIT_FIRST_RANGE_VALUE && totalIncome <= LIMIT_SECOND_RANGE_VALUE)
                base._score = SCORE_SECOND_RANGE_VALUE;

            base._score = SCORE_THIRD_RANGE_VALUE;
        }
    }
}
