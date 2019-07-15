using Digix.Raking.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digix.Raking.Domain.Services.ScoreRules
{
    class FamilyAgeApplicantScore : FamilyScoreBase
    {
        //TODO: change const to configurated values
        private const int SCORE_FIRST_RANGE_VALUE = 3;
        private const int SCORE_SECOND_RANGE_VALUE = 2;
        private const int SCORE_THIRD_RANGE_VALUE = 1;

        private const int LIMIT_FIRST_RANGE_VALUE = 45;
        private const int LIMIT_SECOND_RANGE_VALUE = 30;

        private const string APPLICANT_TYPE = "Pretendente"; //TODO: get from parameter

        public FamilyAgeApplicantScore(Family family) : base(family)
        {
        }


        protected override void CalculateScore()
        {
            int? ageApplicant = GetAgeApplicant();

            if (!ageApplicant.HasValue)
                base._isClassified = false;
            
            base._isClassified = true;

            if (ageApplicant <= LIMIT_FIRST_RANGE_VALUE)
                base._score = SCORE_FIRST_RANGE_VALUE;

            if (ageApplicant > LIMIT_FIRST_RANGE_VALUE && ageApplicant <= LIMIT_SECOND_RANGE_VALUE)
                base._score = SCORE_SECOND_RANGE_VALUE;

            base._score = SCORE_THIRD_RANGE_VALUE;
        }

        private int? GetAgeApplicant()
        {
            var applicant = this.family.People?.FirstOrDefault(a=> a.Type.Equals(APPLICANT_TYPE));

            if (applicant == null)
                return null;

            var age = DateTime.Now.Year - applicant.BirthDate.Year;

            return age;
        }
    }
}
