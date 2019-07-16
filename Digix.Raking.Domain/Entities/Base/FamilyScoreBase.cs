namespace Digix.Raking.Domain.Core.Entities.Base
{
    public abstract class FamilyScoreBase : IFamilyScoreBase
    {
        protected bool _isClassified;
        protected int _score;

        protected Family _family;

        public FamilyScoreBase(Family family)
        {
            this._family = family;
        }
        public abstract void CalculateScore();

        public bool IsClassified { get => _isClassified; }
        public int Score { get => _score; }
    }
}
