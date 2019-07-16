using Digix.Raking.Domain.Core.Entities;
using Digix.Raking.Domain.Core.Entities.Base;
using System;
using System.Linq;

namespace Digix.Raking.Domain.Services.ScoreRules
{
    public class FamilyAgeApplicantScore : FamilyScoreBase
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


        public override void CalculateScore()
        {
            int? ageApplicant = GetAgeApplicant();

            if (!ageApplicant.HasValue)
            {
                base._isClassified = false;
                return;
            }

            base._isClassified = true;

            if (ageApplicant >= LIMIT_FIRST_RANGE_VALUE)
            {
                base._score = SCORE_FIRST_RANGE_VALUE;
                return;
            }

            if (ageApplicant >= LIMIT_SECOND_RANGE_VALUE && ageApplicant < LIMIT_FIRST_RANGE_VALUE)
            {
                base._score = SCORE_SECOND_RANGE_VALUE;
                return;
            }

            base._score = SCORE_THIRD_RANGE_VALUE;
        }

        private int? GetAgeApplicant()
        {
            var applicant = this._family.People?.FirstOrDefault(a=> a.Type.Equals(APPLICANT_TYPE));

            if (applicant == null)
                return null;

            var age = DateTime.Now.Year - applicant.BirthDate.Year;

            return age;
        }
    }
}
