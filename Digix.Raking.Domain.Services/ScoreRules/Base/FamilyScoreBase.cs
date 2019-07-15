using Digix.Raking.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digix.Raking.Domain.Services.ScoreRules
{
    public abstract class FamilyScoreBase
    {
        protected bool _isClassified;
        protected int _score;

        protected Family family { get; set; }

        public FamilyScoreBase(Family family)
        {
            this.family = family;
           CalculateScore();
        }
        protected abstract void CalculateScore();

        public bool IsClassified { get => _isClassified; }
        public int Score { get => _score; }
    }
}
